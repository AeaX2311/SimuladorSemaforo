using Semaforo.Facade;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semaforo {
    public partial class Semaforo : Form {
        public Semaforo() {
            InitializeComponent();
            semaforoFacade = new SemaforoFacade();
            dActualizarVista = new DActualizarVista(movimientoNumero);
            apagar();
            pausarPrograma = false;
        }

        SemaforoFacade semaforoFacade;
        private delegate void DActualizarVista();
        private DActualizarVista dActualizarVista = null;
        private Thread hiloTrabajo = null;
        private bool ejecutarSimulador;
        private int numero;
        private Color color;
        int contadorSegundos;
        private bool semaforoVerticalEncendido;
        private bool pausarPrograma;

        private void apagar() {
            color = Color.White;
            semaforoVerticalEncendido = true;
            if(hiloTrabajo != null) hiloTrabajo.Abort();
            pausarPrograma = false;
        }
        private void iniciarSimulacion() {
            ejecutarSimulador = true;
            if(!pausarPrograma) {
                numero = 0;
                contadorSegundos = 1;
            } else {
                numero--;
            }
            hiloTrabajo = new Thread(new ThreadStart(simular));
            hiloTrabajo.Start();
        }

        private void detenerSimulacion() {
            ejecutarSimulador = false;
        }

        private void btnIniciar_Click(object sender, EventArgs e) {
            iniciarSimulacion();
        }

        private void btnDetener_Click(object sender, EventArgs e) {
            detenerSimulacion();
        }

        private void movimientoNumero() {
            lblnumero.Text = numero.ToString();
            lblnumero.ForeColor = color;
            lblSemaforo.Text = semaforoVerticalEncendido ? "VERTICAL" : "HORIZONTAL";
        }

        private void simular() {
            Color colorAux = Color.Green;
            int sleep = 0;
            bool banderaAux = true; //Indica el color/acciones para el proceso amarillo "parpadear"

            ////Se estara ejecutando indeterminadamente hasta que se detenga manualmente el proceso
            while(ejecutarSimulador) {
                Stopwatch timeMeasure = new Stopwatch();
                timeMeasure.Start();

                if(contadorSegundos == 27) { //Cambiar de semaforo
                    contadorSegundos = 1; //Resetear conteo
                    numero = 1; //Primer valor
                    colorAux = Color.Green; //Siempre inicia en verde
                    sleep = 500;
                    semaforoVerticalEncendido = !semaforoVerticalEncendido; //Invertir semaforos encendidos
                } else if(contadorSegundos < 17) { //Fijo | 15 segundos | Verde
                    if(contadorSegundos == 16) {
                        colorAux = Color.White; //Se "apaga". Sleep 500.
                        numero--; //Quiero que mantenga el mismo numero
                        banderaAux = true;
                        sleep = 500;
                    } else {
                        colorAux = Color.Green; //Encendido default
                        sleep = 1000;
                    }

                    numero++;
                } else if(contadorSegundos < 21) { //Parp | 03 segundos | Verde
                    numero = contadorSegundos - 16; //Vuelve a ir del 1-3. Sleep 500.
                    sleep = 500;
                    if(banderaAux) {
                        if(contadorSegundos == 20) {
                            colorAux = Color.Yellow;
                            numero = 1;
                            sleep = 500;
                        }else {
                            colorAux = Color.Green;
                        }
                    } else {
                        colorAux = Color.White;
                        numero--;
                        contadorSegundos--;
                    }

                    banderaAux = !banderaAux;
                } else if(contadorSegundos < 24) { //Fijo | 03 segundos | Amarillo
                    numero = contadorSegundos - 19; //Vuelve a ir del 1-3.
                    colorAux = Color.Yellow;
                    sleep = 1000;

                    if(contadorSegundos == 23) {
                        numero = 3;
                        colorAux = Color.White;
                        sleep = 500;
                    }
                } else if(contadorSegundos < 27) { //Fijo | 02 segundos | Rojo
                    numero = contadorSegundos - 23; //Vuelve a ir del 1-2.
                    colorAux = Color.Red;
                    sleep = contadorSegundos == 24 ? 500 : 1000;

                    if(contadorSegundos == 26) {
                        numero = 2;
                        colorAux = Color.White;
                        sleep = 500;
                    }
                }
                
                color = colorAux;
                Thread.Sleep(sleep);
                Invoke(dActualizarVista);
                contadorSegundos++;

                timeMeasure.Stop();
                Console.WriteLine($"Tiempo: {timeMeasure.Elapsed.TotalMilliseconds} ms");
            }
            
            apagar();
        }

        private void Semaforo_FormClosing(object sender, FormClosingEventArgs e) {
            apagar();
        }

        private void btnPausa_Click(object sender, EventArgs e) {
            apagar();
            pausarPrograma = true;
        }
    }
}
