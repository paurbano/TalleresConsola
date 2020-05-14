using System;

namespace OReillyFundamentalsInterfacesSobreEscritura
{
    interface IStorable
    {
        void Read();
        void Write();
    }

    //Clase que  implementa IStorable
    public class Documento : IStorable
    {
        public Documento(string cad)
        {
            Console.WriteLine("Creando Documento {0}",cad);
        }

        //Implementación métodos de la Interface

        //Definir virtual al método Read,para permitir sobreescritura a las clases hijas
        public virtual void Read()
        {
            Console.WriteLine("Método Read de documento implementando IStorable");
        }

        //Dejar igual a Write en el ejemplo,para mostrar que no es obligatorio definir virtual todos los métodos
        //aunque en una implementación real deberia ser asi
        public void Write()
        {
            Console.WriteLine("Método Write de documento implementando IStorable");
        }
    }

    //Clase Nota hereda de Documento
    public class Nota:Documento
    {
        public Nota(string s) :base(s)
        {
            Console.WriteLine("Creando Nota {0}",s);
        }

        //Sobreescritura método Read - No es necesario ni obligatorio
        public override void Read()
        {
            Console.WriteLine("Sobrecarga Método read en Nota");
        }

        //nueva versión de método Write
        public new void Write()
        {
            Console.WriteLine("Implementación método Write para Nota!");
        }
    }
    public class Tester
    {
        static void Main()
        {
            //Documento doc = new Documento("Documento");
            
            //Crear un objeto Documento - direccionado al heap de Nota
            Documento oDoc = new Nota("Nota 1");
            IStorable isNote = oDoc as IStorable;
            if (isNote != null)
            {
                isNote.Read();
                isNote.Write();
            }

            Console.WriteLine("\n");
            
            //Llamada directa a los métodos
            oDoc.Read();
            oDoc.Write();
            
            Console.WriteLine("\n");

            //Crear un objeto Nota
            Nota nota = new Nota("Nota 2");
            IStorable esNota = nota as IStorable;
            if (esNota != null)
            {
                esNota.Read();
                esNota.Write();
            }

            Console.WriteLine("\n");

            nota.Read();
            nota.Write();
        }
    }
}
