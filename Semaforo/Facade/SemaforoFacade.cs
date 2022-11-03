using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaforo.Facade {
    class SemaforoFacade {
        private bool ejecutarSimulador = false;

        public void iniciarSimulacion() {
            ejecutarSimulador = true;
        }

        public void detenerSimulacion() {
            ejecutarSimulador = false;
        }

        
    }
}
