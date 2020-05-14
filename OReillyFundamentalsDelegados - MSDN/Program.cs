using System;
using System.Collections;

namespace OReillyFundamentalsDelegados___MSDN
{
    /// <summary>
    /// El uso de delegados promueve una buena separación de la funcionalidad entre la base de datos de la librería y 
    /// el código del programa cliente. El código del cliente no tiene conocimiento de cómo están almacenados los libros 
    /// ni de cómo busca el código de la librería de los libros en rústica. El código de la librería no conoce qué procesamiento 
    /// se realiza sobre los libros en rústica después de encontrarlos. 
    /// 
    /// Correr el proyecto paso a paso (F11) para ver el uso de los delegados
    /// </summary>
    public struct Libro
    {
        public string Titulo; //Titulo libro
        public string Autor; //
        public decimal Precio;
        public bool Rustico; //Es rustico?

        public Libro(string titulo, string autor, decimal precio, bool rustico)
        {
            Titulo = titulo;
            Autor = autor;
            Precio = precio;
            Rustico = rustico;
        }
    }

    //Declara el delegado
    public delegate void ProcesarLibro(Libro libro);

    //Mantiene una base de libros
    public class LibroDB
    {
        //Lista de los libros en la Bd
        ArrayList lista = new ArrayList();

        //Adiciona un libro a la lista
        public void AdicionaLibro(string titulo, string autor, decimal precio, bool deBolsillo)
        {
            lista.Add(new Libro(titulo, autor,  precio,deBolsillo));
        }

        //Llamar al delegado pasado a cada libro rustico para procesarlo
        public void ProcesarLibrosRustico(ProcesarLibro procesarLibro)
        {
            foreach (Libro l in lista)
            {
                if (l.Rustico)
                    //Llamada al delegado
                    procesarLibro(l);
            }
        }
    }

    public class TotalizadorPrecios
    {
        int contadorLibros = 0;
        decimal precioLibros = 0.0m;

        internal void AdicionarLibroaTotal(Libro libro)
        {
            contadorLibros += 1;
            precioLibros += libro.Precio;
        }

        internal decimal PrecioPromedio()
        {
            return precioLibros / contadorLibros;
        }
    }

    class Program
    {
        static void ImprimeTitulo(Libro libro)
        {
            Console.WriteLine("  {0}",libro.Titulo);
        }

        //Ejecucion
        static void Main(string[] args)
        {
            LibroDB librodb = new LibroDB();

            //agrega algunos libros
            AdicionaLibros(librodb);

            //Muestra los titulos de los libros Rústicos
            Console.WriteLine("Titulo libros Rusticos:");

            //Crea un nuevo objeto delegado asociado con el método estático Test.ImprimeTitulo
            librodb.ProcesarLibrosRustico(new ProcesarLibro(ImprimeTitulo));

            //Obtiene el promedio de los libros de bolsillo usando un objeto <<TotalizadorPrecios>>
            TotalizadorPrecios totalizador = new TotalizadorPrecios();

            //Crea un nuevo objeto delegado asociado con el método no estático AdicionarLibroaTotal del objeto totalizador
            librodb.ProcesarLibrosRustico(new ProcesarLibro(totalizador.AdicionarLibroaTotal));
            Console.WriteLine("Precio Promedio Libros Rústicos: ${0:#.##}",totalizador.PrecioPromedio());
        }

        static void AdicionaLibros(LibroDB librodb)
        {
            librodb.AdicionaLibro("The C Programming Language","Brian W. Kernighan and Dennis M. Ritchie", 19.95m, true);
            librodb.AdicionaLibro("The Unicode Standard 2.0","The Unicode Consortium", 39.95m, true);
            librodb.AdicionaLibro("The MS-DOS Encyclopedia","Ray Duncan", 129.95m, false);
            librodb.AdicionaLibro("Dogbert's Clues for the Clueless","Scott Adams", 12.00m, true);
        }
    }
}
