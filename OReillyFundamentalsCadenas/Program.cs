using System;

namespace OReillyFundamentalsCadenas
{
    /// <summary>
    /// Algunas funciones y operaciones con
    /// 
    /// cadenas
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //definir algunas cadenas
            string s1 = "abcd";
            string s2 = "ABCD";
            string s3 = @"El loro que repite, todo, lo que dice la Gente!"; //cadena literal,el "@" le dice al constructor que la cadena debe usarse literalmente como esta, asi esta tenga caracteres de escape.
            string split = "uno,dos,tres Piratasoft & Asociados Inc.";
            string salida = "";

            int resultado,contador;

            //constantes para los espacios y comas
            const char espacio = ' ';
            const char coma = ',';
            
            //arreglo de delimitadores para separar la frase
            char[] delimitadores = new char[] 
            { 
                espacio,
                coma
            };

                       
            //comparar 2 cadenas,distinguiendo mayusculas
            resultado = string.Compare(s1, s2);
            Console.WriteLine("Comparación s1:{0} y s2:{1}, resultado:{2}\n",s1,s2,resultado);

            //Sobrecarga de compare, sin distinción de mayusculas
            //adiciona parámetro booleano true
            resultado = string.Compare(s1, s2,true);
            Console.WriteLine("Sin distinguir mayusculas");
            Console.WriteLine("Comparación s1:{0},s2:{1}, resultado:{2}\n", s1, s2, resultado);

            //Concatenar cadenas
            string s5 = string.Concat(s1, s2);
            Console.WriteLine("Concatenación con método Concat s1 y s2:{0}\n",s5);
            string s6 = s1 + s2;
            Console.WriteLine("s6 Concatenada de s1 + s2:{0}\n", s6);

            //Copiar una cadena
            string s7 = string.Copy(s6);
            Console.WriteLine("s7 copiada de s6:{0}",s7);
            string s8 = s7;
            Console.WriteLine("s8=s7:{0}\n",s8);

            //Formas de comparación
            Console.WriteLine("Es s8.Equals(s7)?:{0}", s8.Equals(s7));
            Console.WriteLine("Es Igual(s7,s8)?:{0}", string.Equals(s7,s8));
            Console.WriteLine("s7==s8?:{0}\n", s7 == s8);

            //propiedades de longitud e indice
            Console.WriteLine("Cadena s8 de longitud:{0}",s8.Length);
            Console.WriteLine("El cuarto caracter es {0}:\n", s8[3]);

            //ver si una cadena termina en un grupo de caracteres
            Console.WriteLine("s3:{0}\n termina en Gente ?: {1}", s3, s3.EndsWith("Gente"));
            Console.WriteLine("Termina en Gente! ?:{0}\n",s3.EndsWith("Gente!"));

            //Retornar el indice de una subcadena
            Console.WriteLine("La palabra <repite> en s3 aparece en:{0}\n",s3.IndexOf("repite"));

            //Dividir una cadena usando el método split
            //este método recibe un arreglo con los delimitadores-caracteres que seperan las palabras
            //retorna un arreglo de subcadenas
            Console.WriteLine("Dividir cadenas usando método Split()");
            Console.WriteLine("Cadena: {0}",split);
            contador = 1;
            foreach (string substring in split.Split(delimitadores))
            {
                salida += contador++;
                salida += ": ";
                salida += substring;
                salida += "\n";
            }
            Console.WriteLine(salida);
        }
    }
}
