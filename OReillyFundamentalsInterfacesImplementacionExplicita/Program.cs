using System;

namespace OReillyFundamentalsInterfacesImplementacionExplicita
{
    /// <summary>
    /// La Implementación explicita en interfaces se da cuando una clase implementa dos o más clases y estas tienen métodos iguales. p.e Leer()
    /// En ese caso se crea un conflicto, para ello la clase debe usar implementación explicita,para al menos uno de los dos.
    /// Hay algunas restricciones para esta situación:
    /// - El método declarado de manera explicita no puede declararse con los modificadores de acceso abstract,virtual,override o new
    /// - No se puede acceder al método explicito de manera directa a traves del objeto. Se debe hacer mediante un cast de la interface.
    /// </summary>
    interface IStorable {
        void Read();
        void Write();
    }

    interface ITalk
    {
        void Talk();
        void Read();
    }

    //La clase Documento implementa las dos interfaces, por tanto todos sus métodos
    public class Documento : IStorable, ITalk
    {
        //Método Constructor
        public Documento(String s)
        {
            Console.WriteLine("Creando Documento:{0}",s);
        }

        //Se define el metodo Read como virtual, para permitir su sobrecarga por clases hijas
        public virtual void Read()
        {
            Console.WriteLine("Implementando método read de IStorable.Read()");
        }
        public void Write()
        {
            Console.WriteLine("Implementando método Write de IStorable.Write");
        }

        //Implementación explicita del método 
        // [Interface].metodo
        void ITalk.Read()
        {
            Console.WriteLine("Implementando método explicitamente ITalk.Read()");
        }

        //Este se define igual 
        public void Talk()
        {
            Console.WriteLine("Implementando método ITalk.Talk()");
        }
    }

    public class Tester
    {
        static void Main()
        {
            Documento doc = new Documento("Documento 1");
            ITalk idoc = doc as ITalk;
            if (idoc != null)
            {
                idoc.Read();
            }

            doc.Read();
            doc.Talk();
            doc.Write();
        }
    }
}
