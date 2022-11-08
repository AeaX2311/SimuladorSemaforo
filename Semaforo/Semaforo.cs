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
            dActualizarVista = new DActualizarVista(movimientoNumero);
            apagar();
            pausarPrograma = false;
            preventivasOn = false;
        }

        private delegate void DActualizarVista();
        private DActualizarVista dActualizarVista = null;
        private Thread hiloTrabajo = null;
        private bool ejecutarSimulador;
        private int numero;
        private Color color;
        int contadorSegundos;
        private bool semaforoVerticalEncendido;
        private bool pausarPrograma;
        private bool preventivasOn;

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

        private void movimientoNumero() {
            lblnumero.Text = numero.ToString();
            lblnumero.ForeColor = color;
            lblSemaforo.Text = semaforoVerticalEncendido ? "VERTICAL" : "HORIZONTAL";
        }

        private void simular() {
            int sleep = 0;
            bool banderaAux = true; //Indica el color/acciones para el proceso amarillo "parpadear"
            bool banderaPreventivas = true; //Indica el color para el proceso preventivas "parpadear"

            ////Se estara ejecutando indeterminadamente hasta que se detenga manualmente el proceso
            while(ejecutarSimulador) {
                //Stopwatch timeMeasure = new Stopwatch();
                //timeMeasure.Start();
                if(!preventivasOn) {
                    if(contadorSegundos == 27) { //Cambiar de semaforo
                        contadorSegundos = 1; //Resetear conteo
                        numero = 1; //Primer valor
                        color = Color.Green; //Siempre inicia en verde
                        sleep = 500;
                        semaforoVerticalEncendido = !semaforoVerticalEncendido; //Invertir semaforos encendidos
                    } else if(contadorSegundos < 17) { //Fijo | 15 segundos | Verde
                        if(contadorSegundos == 16) {
                            color = Color.White; //Se "apaga". Sleep 500.
                            numero--; //Quiero que mantenga el mismo numero
                            banderaAux = true;
                            sleep = 500;
                        } else {
                            color = Color.Green; //Encendido default
                            sleep = 1000;
                        }

                        numero++;
                    } else if(contadorSegundos < 21) { //Parp | 03 segundos | Verde
                        numero = contadorSegundos - 16; //Vuelve a ir del 1-3. Sleep 500.
                        sleep = 500;

                        if(banderaAux) {
                            if(contadorSegundos == 20) {
                                color = Color.Yellow;
                                numero = 1;
                                sleep = 500;
                            } else {
                                color = Color.Green;
                            }
                        } else {
                            color = Color.White;
                            numero--;
                            contadorSegundos--;
                        }

                        banderaAux = !banderaAux;
                    } else if(contadorSegundos < 24) { //Fijo | 03 segundos | Amarillo
                        numero = contadorSegundos - 19; //Vuelve a ir del 1-3.
                        color = Color.Yellow;
                        sleep = 1000;

                        if(contadorSegundos == 23) {
                            numero = 3;
                            color = Color.White;
                            sleep = 500;
                        }
                    } else if(contadorSegundos < 27) { //Fijo | 02 segundos | Rojo
                        numero = contadorSegundos - 23; //Vuelve a ir del 1-2.
                        color = Color.Red;
                        sleep = contadorSegundos == 24 ? 500 : 1000;

                        if(contadorSegundos == 26) {
                            numero = 2;
                            color = Color.White;
                            sleep = 500;
                        }
                    }
                } else { //MODO PREVENTIVAS
                    numero = 0;
                    color = banderaPreventivas ? Color.Yellow : Color.White;
                    sleep = 1000;
                    banderaPreventivas = !banderaPreventivas;
                    contadorSegundos = 0; //Que vuelva a iniciar siempre (cuando apaguen preventivas)
                    semaforoVerticalEncendido = true; //Que vuelva a iniciar con el semaforo vertical
                }
                
                Thread.Sleep(sleep);
                Invoke(dActualizarVista);
                contadorSegundos++;

                //timeMeasure.Stop();
                //Console.WriteLine($"Tiempo: {timeMeasure.Elapsed.TotalMilliseconds} ms");
            }
            
            apagar();
        }

        private void Semaforo_FormClosing(object sender, FormClosingEventArgs e) {
            apagar();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            preventivasOn = chkPreventivas.Checked;
        }

        private void btnIniciar_Click_1(object sender, EventArgs e) {
            iniciarSimulacion();
        }

        private void btnPausar_Click(object sender, EventArgs e) {
            apagar();
            pausarPrograma = true;
        }

        private void btnDetener_Click(object sender, EventArgs e) {
            detenerSimulacion();
        }
    }


}
