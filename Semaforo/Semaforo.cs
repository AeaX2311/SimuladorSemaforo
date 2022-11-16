using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Semaforo {
    public partial class Semaforo : Form {
        public Semaforo() {
            InitializeComponent();
            dActualizarVista = new DActualizarVista(movimientoNumero);
            apagar();
            pausarPrograma = false;
            preventivasOn = false;
            apagarSemaforos();
            lblnumero.ForeColor = Color.FromArgb(43, 43, 43);
        }

        #region Declaracion de variables
        private delegate void DActualizarVista();
        private DActualizarVista dActualizarVista = null;
        private Thread hiloTrabajo = null;
        private bool simuladorEjecutandose;
        private int numeroAMostrar;
        private Color colorAMostrar;
        int contadorEventos;
        private bool semaforoVerticalEncendido;
        private bool pausarPrograma;
        private bool preventivasOn;
        private static string ruta = System.IO.Path.GetFullPath(@"..\..\Recursos\");
        private Dictionary<string, string> imagenesSegunColor = new Dictionary<string, string>() {
            { "Green", ruta + "SVerde.png" },
            { "Yellow", ruta + "SAmarillo.png" },
            { "Red", ruta + "SRojo.png" },
            { "ff2b2b2b", ruta + "SEmpty.png" },
        };
        #endregion

        #region Eventos del formulario
        private void Semaforo_FormClosing(object sender, FormClosingEventArgs e) {
            apagar();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            preventivasOn = chkPreventivas.Checked;
        }

        private void btnIniciar_Click_1(object sender, EventArgs e) {
            iniciarSimulacion();
            btnIniciar.Enabled = false;
            btnPausar.Enabled = true;
            btnDetener.Enabled = true;
        }

        private void btnPausar_Click(object sender, EventArgs e) {
            apagar();
            pausarPrograma = true;

            pcbF1.Image = null;
            pcbF2.Image = null;
            pcbF3.Image = null;
            pcbF4.Image = null;
        }

        private void btnDetener_Click(object sender, EventArgs e) {
            detenerSimulacion();
        }
        #endregion

        #region Metodos logicos
        /// <summary>
        /// Apagado visible + Fin del hilo de trabajo
        /// </summary>
        private void apagar() {
            colorAMostrar = Color.FromArgb(43, 43, 43);
            if(hiloTrabajo != null) hiloTrabajo.Abort();
            pausarPrograma = false;
            btnIniciar.Enabled = true;
            btnPausar.Enabled = false;
            btnDetener.Enabled = false;
        }

        /// <summary>
        /// Inicio de la simulacion
        /// </summary>
        private void iniciarSimulacion() {
            simuladorEjecutandose = true;
            if(!pausarPrograma) {
                semaforoVerticalEncendido = true;
                numeroAMostrar = 0;
                contadorEventos = 1;
            } else {
                numeroAMostrar--;
                mostrarFlechas();
            }
            hiloTrabajo = new Thread(new ThreadStart(simular));
            hiloTrabajo.Start();
        }

        /// <summary>
        /// Fin de la simulacion, apagado TOTAL
        /// </summary>
        private void detenerSimulacion() {
            simuladorEjecutandose = false;
            semaforoVerticalEncendido = true;
            apagar();
            movimientoNumero();
            apagarSemaforos();
        }

        /// <summary>
        /// Actualiza la vista: Semaforos y label
        /// </summary>
        private void movimientoNumero() {
            lblnumero.Text = numeroAMostrar.ToString();
            lblnumero.ForeColor = colorAMostrar;
            setearImagen(colorAMostrar.Name);
        }

        /// <summary>
        /// Contiene el proceso maestro de la simulacion, se basa en un evento especifico para cada estado(numero).
        /// Se encarga de determinar el color a mostrar, el numero y la duracion de cada evento.
        /// </summary>
        private void simular() {
            int sleep = 0;
            bool banderaAux = true; //Indica el color/acciones para el proceso amarillo "parpadear"
            bool banderaPreventivas = true; //Indica el color para el proceso preventivas "parpadear"

            ////Se estara ejecutando indeterminadamente hasta que se detenga manualmente el proceso
            while(simuladorEjecutandose) {
                if(!preventivasOn) {
                    if(contadorEventos == 2) {
                        mostrarFlechas();
                    }
                    if(contadorEventos == 27) { //Cambiar de semaforo
                        contadorEventos = 1; //Resetear conteo
                        numeroAMostrar = 1; //Primer valor
                        colorAMostrar = Color.Green; //Siempre inicia en verde
                        sleep = 500;
                        //semaforoVerticalEncendido = !semaforoVerticalEncendido; //Invertir semaforos encendidos
                    } else if(contadorEventos < 17) { //Fijo | 15 segundos | Verde
                        if(contadorEventos == 16) {
                            colorAMostrar = Color.FromArgb(43, 43, 43); //Se "apaga". Sleep 500.
                            numeroAMostrar--; //Quiero que mantenga el mismo numero
                            banderaAux = true;
                            sleep = 500;
                        } else {
                            colorAMostrar = Color.Green; //Encendido default
                            sleep = 1000;
                        }

                        numeroAMostrar++;
                    } else if(contadorEventos < 21) { //Parp | 03 segundos | Verde
                        numeroAMostrar = contadorEventos - 16; //Vuelve a ir del 1-3. Sleep 500.
                        sleep = 500;

                        if(banderaAux) {
                            if(contadorEventos == 20) {
                                colorAMostrar = Color.Yellow;
                                numeroAMostrar = 1;
                                sleep = 500;
                            } else {
                                colorAMostrar = Color.Green;
                            }
                        } else {
                            colorAMostrar = Color.FromArgb(43, 43, 43);
                            numeroAMostrar--;
                            contadorEventos--;
                        }

                        banderaAux = !banderaAux;
                    } else if(contadorEventos < 24) { //Fijo | 03 segundos | Amarillo
                        numeroAMostrar = contadorEventos - 19; //Vuelve a ir del 1-3.
                        colorAMostrar = Color.Yellow;
                        sleep = 1000;

                        if(contadorEventos == 23) {
                            numeroAMostrar = 3;
                            colorAMostrar = Color.FromArgb(43, 43, 43);
                            sleep = 500;
                        }
                    } else if(contadorEventos < 27) { //Fijo | 02 segundos | Rojo
                        numeroAMostrar = contadorEventos - 23; //Vuelve a ir del 1-2.
                        colorAMostrar = Color.Red;
                        sleep = contadorEventos == 24 ? 500 : 1000;

                        if(contadorEventos == 26) {
                            numeroAMostrar = 2;
                            colorAMostrar = Color.FromArgb(43, 43, 43);
                            sleep = 500;
                            semaforoVerticalEncendido = !semaforoVerticalEncendido; //Invertir semaforos encendidos
                        }
                    }
                } else { //MODO PREVENTIVAS
                    numeroAMostrar = 0;
                    colorAMostrar = banderaPreventivas ? Color.Yellow : Color.FromArgb(43, 43, 43);
                    sleep = 500;
                    banderaPreventivas = !banderaPreventivas;
                    contadorEventos = 0; //Que vuelva a iniciar siempre (cuando apaguen preventivas)
                    semaforoVerticalEncendido = true; //Que vuelva a iniciar con el semaforo vertical
                }
                
                Thread.Sleep(sleep);
                Invoke(dActualizarVista);
                contadorEventos++;
            }
            
            apagar();
        }

        /// <summary>
        /// Cambia las imagenes de los semaforos, y coloca la imagen del diccionario, segun determinado color
        /// </summary>
        /// <param name="color">El nombre del color, debe existir en el diccionario de rutas</param>
        private void setearImagen(string color) {
            //Obtenemos la imagen que deseamos colocar
            Image semaforo1 = Image.FromFile(imagenesSegunColor[color]);
            Image semaforo2 = Image.FromFile(imagenesSegunColor[color]);
            Image semaforoR1 = Image.FromFile(imagenesSegunColor["Red"]);
            Image semaforoR2 = Image.FromFile(imagenesSegunColor["Red"]);

            if(preventivasOn && (color.Equals("Yellow") || color.Equals("ff2b2b2b"))) {
                semaforoR1 = Image.FromFile(imagenesSegunColor[color]);
                semaforoR2 = Image.FromFile(imagenesSegunColor[color]);
                semaforo2.RotateFlip(RotateFlipType.Rotate180FlipX);
                semaforoR1.RotateFlip(RotateFlipType.Rotate270FlipX);
                semaforoR2.RotateFlip(RotateFlipType.Rotate90FlipX);

                pcbN.BackgroundImage = semaforo1;
                pcbS.BackgroundImage = semaforo2;
                pcbE.BackgroundImage = semaforoR1;
                pcbO.BackgroundImage = semaforoR2;

                pcbF1.Image = null;
                pcbF2.Image = null;
                pcbF3.Image = null;
                pcbF4.Image = null;

                return;
            }
            if(semaforoVerticalEncendido) { //Semaforos N y S encendidos
                semaforo2.RotateFlip(RotateFlipType.Rotate180FlipX);
                semaforoR1.RotateFlip(RotateFlipType.Rotate270FlipX);
                semaforoR2.RotateFlip(RotateFlipType.Rotate90FlipX);

                pcbN.BackgroundImage = semaforo1;
                pcbS.BackgroundImage = semaforo2;
                pcbE.BackgroundImage = semaforoR1;
                pcbO.BackgroundImage = semaforoR2;
            } else { //Semaforos E y O encendidos
                semaforoR2.RotateFlip(RotateFlipType.Rotate180FlipX);
                semaforo1.RotateFlip(RotateFlipType.Rotate270FlipX);
                semaforo2.RotateFlip(RotateFlipType.Rotate90FlipX);

                pcbE.BackgroundImage = semaforo1;
                pcbO.BackgroundImage = semaforo2;
                pcbN.BackgroundImage = semaforoR1;
                pcbS.BackgroundImage = semaforoR2;
            }
        }

        /// <summary>
        /// Establece todos los semaforos (imagenes) en su tonalidad gris, apagada
        /// </summary>
        private void apagarSemaforos() {
            Image semaforo1 = Image.FromFile(imagenesSegunColor["ff2b2b2b"]);
            Image semaforo2 = Image.FromFile(imagenesSegunColor["ff2b2b2b"]);
            Image semaforo3 = Image.FromFile(imagenesSegunColor["ff2b2b2b"]);
            Image semaforo4 = Image.FromFile(imagenesSegunColor["ff2b2b2b"]);

            semaforo2.RotateFlip(RotateFlipType.Rotate180FlipX);
            semaforo3.RotateFlip(RotateFlipType.Rotate270FlipX);
            semaforo4.RotateFlip(RotateFlipType.Rotate90FlipX);

            pcbN.BackgroundImage = semaforo1;
            pcbS.BackgroundImage = semaforo2;
            pcbE.BackgroundImage = semaforo3;
            pcbO.BackgroundImage = semaforo4;

            pcbF1.Image = null;
            pcbF2.Image = null;
            pcbF3.Image = null;
            pcbF4.Image = null;
        }

        /// <summary>
        /// Muestra las imagenes de las flechas de "avance" indicativas.
        /// </summary>
        private void mostrarFlechas() {
            if(semaforoVerticalEncendido) {
                pcbF1.Image = Image.FromFile(ruta + "Flecha2.gif");
                pcbF2.Image = Image.FromFile(ruta + "Flecha3.gif");
                pcbF3.Image = null;
                pcbF4.Image = null;
            } else {
                pcbF3.Image = Image.FromFile(ruta + "Flecha.gif");
                pcbF4.Image = Image.FromFile(ruta + "Flecha4.gif");
                pcbF1.Image = null;
                pcbF2.Image = null;
            }
        }
        #endregion
    }
}
