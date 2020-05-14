using System;

namespace OReillyFundamentalsInterfacesSobreEscritura
{
    interface IStorable {
        int Status { get; set; }
        void Write(Object obj);
        void Read();
    }

    interface ICompressible
    {
        void Compres();
        void Decompress();
    }

    //Extender una interfaz
    interface ILoggedCompresible : ICompressible
    {
        //Método adicional a los de ICompressible
        void LogSavedBytes();
    }

    //Combinar Interfaces
    interface IStoreableCompressible : IStorable, ILoggedCompresible
    {
        void OriginalSize();
    }

    //Otra interface
    interface IEncryptable
    {
        void Encrypt();
        void Decrypt();
    }

    //Clase que implementa dos interfaces:IStorable,IEncrypt
    public class Documento : IStoreableCompressible, IEncryptable 
    {
        //Almacena el valor para la propiedad status de la interface IStorable
        private int status = 0;

        public Documento(string s)
        {
            Console.WriteLine("Creando Documento:{0}",s);
        }

        //Implementando métodos de IStorable
        public void Read()
        {
            Console.WriteLine("Implementando metodo Read de IStorable");
        }

        public void Write(Object obj)
        {
            Console.WriteLine("Implementando metodo Write de IStorable");
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        //Implementar ICompressible

        public void Compres()
        {
            Console.WriteLine("Implementando método Compress de ICompressible");
        }

        public void Decompress()
        {
            Console.WriteLine("Implementando método Decompress de ICompressible");
        }

        //Implementar ILoggedCompressible
        public void LogSavedBytes()
        {
            Console.WriteLine("Implementando método LogSavedBytes de ILoggedCompressible");
        }

        //Implementar IStoreCompresible
        public void OriginalSize()
        {
            Console.WriteLine("Implementando método OriginalSize de IStoreCompresible");
        }

        //Implementar IEncrypt
        public void Encrypt()
        {
            Console.WriteLine("Implementando método Encrypt de IEncrypt");
        }

        public void Decrypt()
        {
            Console.WriteLine("Implementando método Decrypt de IEncrypt");
        }
    }

    public class Tester
    {
        static void Main()
        {
            //Crear un objeto tipo Documento
            Documento doc = new Documento("Documento 1");

            //Convertir el documento a las diferentes interfaces
            IStorable isDoc = doc as IStorable;
            if(isDoc!=null){
                isDoc.Read();
            }
            else
                Console.WriteLine("IStorable no soportada");

            ILoggedCompresible ilcDoc = doc as ILoggedCompresible;

            if(ilcDoc!=null){
                ilcDoc.Compres();
                ilcDoc.LogSavedBytes();
            }
            else
                Console.WriteLine("ILoggedCompresible no soportada");

            IStoreableCompressible iScDoc = doc as IStoreableCompressible;
            if (iScDoc != null)
            {
                iScDoc.Compres();
                iScDoc.LogSavedBytes();
                iScDoc.OriginalSize();
            }
            else
                Console.WriteLine("IStoreableCompressible no soportada");
        }
    }
}
