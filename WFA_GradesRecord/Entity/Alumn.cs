using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_GradesRecord.Entity
{
    class Alumn : IDisposable
    {

        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Curso { get; set; }
        public int N1 { get; set; }
        public int N2 { get; set; }
        public int N3 { get; set; }

        public int NotaFinal
        {
            get
            {
                return Promedio();
            }
        }
        public bool Estado
        {
            get
            {
                return Aprobado(NotaFinal);
            }
        }

        public int Promedio()
        {
            return (N1 + N2 + N3) / 3;
        }

        public bool Aprobado(int promedio)
        {
            if (promedio >= 11)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~Alumn()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
