﻿using System;
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
            forzarSemaforoRojo = false;
            apagarSemaforos();
            lblnumero.ForeColor = Color.FromArgb(43, 43, 43);
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
        private bool forzarSemaforoRojo;
        private static string ruta = System.IO.Path.GetFullPath(@"..\..\Recursos\");
        private Dictionary<string, string> colores = new Dictionary<string, string>() {
            { "Green", ruta + "SVerde.png" },
            { "Yellow", ruta + "SAmarillo.png" },
            { "Red", ruta + "SRojo.png" },
            { "ff2b2b2b", ruta + "SEmpty.png" },
        };

        private void apagar() {
            color = Color.FromArgb(43, 43, 43);
            if(hiloTrabajo != null) hiloTrabajo.Abort();
            pausarPrograma = false;
            btnIniciar.Enabled = true;
            btnPausar.Enabled = false;
            btnDetener.Enabled = false;
            forzarSemaforoRojo = false;
        }

        private void iniciarSimulacion() {
            semaforoVerticalEncendido = true;
            ejecutarSimulador = true;
            if(!pausarPrograma) {
                numero = 0;
                contadorSegundos = 1;
            } else {
                numero--;
                mostrarFlechas();
            }
            hiloTrabajo = new Thread(new ThreadStart(simular));
            hiloTrabajo.Start();
        }

        private void detenerSimulacion() {
            ejecutarSimulador = false;
            semaforoVerticalEncendido = true;
            apagar();
            movimientoNumero();
            apagarSemaforos();
        }

        private void movimientoNumero() {
            lblnumero.Text = numero.ToString();
            lblnumero.ForeColor = color;

            if(forzarSemaforoRojo) {
                setearImagen("Red");
                forzarSemaforoRojo = false;
                return;
            }
          
            setearImagen(color.Name);
        }

        private void simular() {
            int sleep = 0;
            bool banderaAux = true; //Indica el color/acciones para el proceso amarillo "parpadear"
            bool banderaPreventivas = true; //Indica el color para el proceso preventivas "parpadear"

            ////Se estara ejecutando indeterminadamente hasta que se detenga manualmente el proceso
            while(ejecutarSimulador) {
                if(!preventivasOn) {
                    if(contadorSegundos == 2) {
                        mostrarFlechas();
                    }
                    if(contadorSegundos == 27) { //Cambiar de semaforo
                        contadorSegundos = 1; //Resetear conteo
                        numero = 1; //Primer valor
                        color = Color.Green; //Siempre inicia en verde
                        sleep = 500;
                        semaforoVerticalEncendido = !semaforoVerticalEncendido; //Invertir semaforos encendidos
                    } else if(contadorSegundos < 17) { //Fijo | 15 segundos | Verde
                        if(contadorSegundos == 16) {
                            color = Color.FromArgb(43, 43, 43); //Se "apaga". Sleep 500.
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
                            color = Color.FromArgb(43, 43, 43);
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
                            color = Color.FromArgb(43, 43, 43);
                            sleep = 500;
                        }
                    } else if(contadorSegundos < 27) { //Fijo | 02 segundos | Rojo
                        numero = contadorSegundos - 23; //Vuelve a ir del 1-2.
                        color = Color.Red;
                        sleep = contadorSegundos == 24 ? 500 : 1000;

                        if(contadorSegundos == 26) {
                            numero = 2;
                            color = Color.FromArgb(43, 43, 43);
                            sleep = 500;
                            forzarSemaforoRojo = true;
                        }
                    }
                } else { //MODO PREVENTIVAS
                    numero = 0;
                    color = banderaPreventivas ? Color.Yellow : Color.FromArgb(43, 43, 43);
                    sleep = 500;
                    banderaPreventivas = !banderaPreventivas;
                    contadorSegundos = 0; //Que vuelva a iniciar siempre (cuando apaguen preventivas)
                    semaforoVerticalEncendido = true; //Que vuelva a iniciar con el semaforo vertical
                }
                
                Thread.Sleep(sleep);
                Invoke(dActualizarVista);
                contadorSegundos++;
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

        private void setearImagen(string color) {
            //Obtenemos la imagen que deseamos colocar
            Image semaforo1 = Image.FromFile(colores[color]);
            Image semaforo2 = Image.FromFile(colores[color]);
            Image semaforoR1 = Image.FromFile(colores["Red"]);
            Image semaforoR2 = Image.FromFile(colores["Red"]);

            if(preventivasOn && (color.Equals("Yellow") || color.Equals("ff2b2b2b"))) {
                semaforoR1 = Image.FromFile(colores[color]);
                semaforoR2 = Image.FromFile(colores[color]);
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

        private void apagarSemaforos() {
            Image semaforo1 = Image.FromFile(colores["ff2b2b2b"]);
            Image semaforo2 = Image.FromFile(colores["ff2b2b2b"]);
            Image semaforo3 = Image.FromFile(colores["ff2b2b2b"]);
            Image semaforo4 = Image.FromFile(colores["ff2b2b2b"]);

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
    }
}
