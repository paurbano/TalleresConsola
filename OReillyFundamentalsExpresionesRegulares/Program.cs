using System;
using System.Text;
using System.Text.RegularExpressions;

namespace OReillyFundamentalsExpresionesRegulares
{
    /// <summary>
    /// uso de expresiones regulares con:
    /// Clase Regex:
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string cadena = "uno,dos,tres, Piratasoft & Asociados Inc.";
            //Crea un objeto expresión regular y define la expresión " |, |, "
            Regex regex = new Regex(" |, |, ");
            StringBuilder sBuilder = new StringBuilder();
            int id = 1;

            //Versión simple Regex
            //Llama al metodo Split de Regex, actua de forma similar al método de cadenas
            Console.WriteLine("Versión Simple de Regex ObjetoRegex.Split(cadena):");
            foreach(string cad in regex.Split(cadena))
            {
                sBuilder.AppendFormat("{0}: {1}\n", id++, cad);
            }
            Console.WriteLine(sBuilder);

            //Versión estatica Regex
            //En lugar de instanciar un objeto, usa la versión estática de Split()
            //Toma una cadena y el patrón a buscar
            sBuilder.Clear();
            Console.WriteLine("Versión Estática de Regex.Split(cadena,patron):");
            foreach(string cad in Regex.Split(cadena," |, |,"))
            {
                sBuilder.AppendFormat("{0}: {1}\n", id++, cad);
            }
            Console.WriteLine(sBuilder);


            //Buscar una cadena repetidamente y devolver el resultado en una colección
            //Se basa en el uso de MatchCollection y Match
            cadena = "Esta es una cadena de prueba";

            //Encontrar cualquier espacio no en blanco, seguido de un espacio en blanco
            //\S espacios no enblanco +: inidica uno o más
            Regex exp = new Regex(@"(\S+)+\s");

            //Obtener la colección de coincidencias
            MatchCollection coincidencias = exp.Matches(cadena);

            Console.WriteLine("\t\tUso de MatchCollection y Match, encontrar una cadena seguida de un espacio en:{0}", cadena);

            //Iterar sobbre la colección
            foreach (Match coincidencia in coincidencias)
            {
                Console.WriteLine("Longitud coincidencia :{0}", coincidencia.Length);
                if (coincidencia.Length != 0)
                {
                    Console.WriteLine("coincidencia:{0}",coincidencia.ToString());
                }
            }

            //Uso de grupos
            //Algunas veces se necesita agrupar sub-expresiones coincidentes de la cadena principal, para darles un uso particular
            //Ejemplo direcciones IP: x.x.x.x
            //En el siguiente ejemplo se usa la clase Group para tal fin
            cadena = "12:30:05 168.0.0.10 palaobra.com "+
                     "04:03:28 127.0.0.0 foo.com " +
                     "04:03:29 127.0.0.0 bar.com ";

            //define los grupos de busqueda
            //Grupo tiempo:uno o más digitos o dos puntos seguidos de espacio
            Regex expresion = new Regex(@"(?<tiempo>(\d|\:)+)\s" +
                                        @"(?<ip>(\d|\.)+)\s" + //dirección IP:uno o más digitos ó puntos seguidos de espacio
                                        @"(?<sitio>\S+)");//Sitio: uno ó más caracteres

            //obtener la colección de coincidencias
            MatchCollection coincidenciasGrupo = expresion.Matches(cadena);

            Console.WriteLine();
            Console.WriteLine("\t\t\tUso de Grupos, cadena ejemplo: {0}", cadena);
            //recorremos la colección
            foreach(Match coincidencia in coincidenciasGrupo)
            {
                //Si la longitud de la coincidencia es diferente de 0, encontro una imprima
                if (coincidencia.Length!=0)
                {
                    Console.WriteLine("Coincidencia: {0}",coincidencia.ToString());
                    Console.WriteLine("Tiempo:{0}",coincidencia.Groups["tiempo"]);
                    Console.WriteLine("Ip:{0}", coincidencia.Groups["ip"]);
                    Console.WriteLine("URL:{0}\n", coincidencia.Groups["sitio"]);
                }
            }

            //Cuando se da el caso de que las coincidencias estan en diferentes posiciones, se van sobreescibiedo quedando solo la última
            //Para este caso se usa CaptureCollection

            cadena = "04:03:27 PalaObra 0.0.0.127 CapitalBurt ";

            //Expresión regular con grupos dobles
            Regex expresionReg = new Regex( @"(?<Tiempo>(\d|\:)+\s)"+
                                            @"(?<Compañia>\S+)\s"+
                                            @"(?<Ip>(\d|\.)+)\s"+
                                            @"(?<Compañia>\S+)\s");
            
            //OBtener las coleccion de coincidencias de la cadena
            coincidenciasGrupo = expresionReg.Matches(cadena);

            Console.WriteLine();
            Console.WriteLine("\t\t\tCapture Collection, cadena ejemplo: {0}", cadena);
            
            //recorremos la colección
            foreach (Match captura in coincidenciasGrupo)
            {
                //Si la longitud de la coincidencia es diferente de 0, encontro una imprima
                if (captura.Length != 0)
                {
                    Console.WriteLine("Coincidencia: {0}", captura.ToString());
                    Console.WriteLine("Tiempo:{0}", captura.Groups["Tiempo"]);
                    Console.WriteLine("Ip:{0}", captura.Groups["Ip"]);
                    Console.WriteLine("Compañia:");

                    //captura.Groups["Compañia"].Captures : devuelve una colección de Captures para el grupo almacenado en Groups.["Compañia"]
                    //Iterar sobre la colección de Captures en el grupo Compañia, dentro de la coleccion de grupos de la coincidencia
                    foreach (Capture cap in captura.Groups["Compañia"].Captures)
                    {
                        Console.WriteLine("\t{0}",cap.ToString());
                    }
                }
            }
        }
    }
}

