using System;

namespace OReillyFundamentalsDestruirObjetos
{
       public class Font: IDisposable
        {
            public string Tipo { get; set; }
            public float tamano { get; set; }
            bool is_disposed = false;
            public Font(string pTipo, float pTamano)
            {
                this.Tipo = pTipo;
                this.tamano = pTamano;
            }
           
            protected virtual void Dispose(bool disposing)
        {
            if (!is_disposed) // only dispose once!
            {
                if (disposing)
                {
                    Console.WriteLine("No en destructor, Bien para referenciar otros objetos");
                }
                // perform cleanup for this object
                Console.WriteLine("Disposing...");
            }
            this.is_disposed = true;
        }

            public void Dispose()
        {
            Dispose(true);
            // tell the GC not to finalize
            GC.SuppressFinalize(this);
        }

            ~Font()
                {
                    Dispose(false);
                    Console.WriteLine("In destructor.");
                }

        }

        //Uso de la sentencia using, asegura que el metodo Dispose() se llame lo mas pronto posible, cuando termina de ejecutarse el comando using
        //el comando using protege excepciones no anticipadas.
        public static void Main()
        {
            
            using (Font theFont = new Font("Arial", 10.0f))
            {
                // use theFont

            }   // compiler will call Dispose on theFont

            Font anotherFont = new Font("Courier", 12.0f);

            using (anotherFont)
            {
                // use anotherFont

            }  // compiler calls Dispose on anotherFont

        }
        
    
}
