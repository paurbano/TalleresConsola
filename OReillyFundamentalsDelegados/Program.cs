using System;

namespace OReillyFundamentalsDelegados
{
    /// <summary>
    /// Ejemplo de uso de delegados, esta aplicación simula un procesador de imagen y diferentes efectos que un usuario puede aplicarle(opacidad, rotar, recortar,etc..)
    /// el usuario puede seleccionar uno o varios y luego aplicarlos en la secuencia seleccionada.
    /// Para más información ver:
    /// https://msdn.microsoft.com/es-es/library/aa288459(v=vs.71).aspx
    /// </summary>
    
    public class Imagen
    {
        public Imagen()
        {
            Console.WriteLine("Una Imagen Creada o Cargada");
        }

    }

    //Declaración Delegado
    public delegate void AplicarEfecto();

    public class ProcesadorImagen

    {
        //Variables miembro privadas
        private AplicarEfecto[] arregloEfectos;
        private Imagen imagen;
        private int numeroEfectosSeleccionados=0;
        
        //Crea varios delegados estáticos atados a métodos miembro
              
        public AplicarEfecto EfectoDifuminar = new AplicarEfecto(Difuminar);
        public AplicarEfecto EfectoFiltro = new AplicarEfecto(Filtro);
        public AplicarEfecto EfectoRotar = new AplicarEfecto(Rotar);
        public AplicarEfecto EfectoAfilar = new AplicarEfecto(Afilar);

        /// <summary>
        /// El problema con los delegados estáticos es que deben instanciarse, se usen o no. 
        /// Se puede mejorar esto haciendo los delegados propiedades de las clases, para asi llamarlos directamente por estas con la ventaja
        /// de que el delegado no es creado, sino hasta que es solicitado
        /// por ejemplo:
        /// public static EfectoDifuminar 
        /// {
        ///     get
        ///     {
        ///      return new AplicarEfecto(Difuminar);
        ///     }
        /// }
        /// 
        /// </summary>
        

        //El constructor inicializa la imagen y el arreglo de afectos a aplicar
        public ProcesadorImagen(Imagen imagen)
        {
            this.imagen = imagen;
            arregloEfectos = new AplicarEfecto[10];
        }

        //Metodos para procesar imagen
        //En una aplicación real de tratamiento de imagenes
        //estos métodos serían un poco más complejos

        public static void Difuminar()
        {
            Console.WriteLine("Difuminando Imagen!...");
        }

        public static void Filtro()
        {
            Console.WriteLine("Filtrando Imagen!...");
        }

        public static void Rotar()
        {
            Console.WriteLine("Rotando Imagen...");
        }

        public static void Afilar()
        {
            Console.WriteLine("Afilando Imagen...");
        }

        /// <summary>
        /// En una solución real se usaria una colección dinamica, no de tamaño fija
        /// </summary>
        /// <param name="efecto"></param>
        public void AgregarEfectos(AplicarEfecto efecto)
        {
            if (numeroEfectosSeleccionados >= 10)
                throw new Exception("Demasiados Efectos en la lista");

            arregloEfectos[numeroEfectosSeleccionados++] = efecto;
        }
                
        //Aplicar los efectos a la imagen
        public void ProcesarImagen()
        {
            for (int i = 0; i < numeroEfectosSeleccionados; i++)
            {
                arregloEfectos[i]();
            }
        }
    }

    class Editor
    {
        static void Main(string[] args)
        {
            Imagen imagen = new Imagen();

            //Cargar los métodos de efectos a aplicar, adicionarlos según se requieran
            //Llamar al procesador de imagenes y correr los métodos en el orden seleccionado
            
            //
            ProcesadorImagen procesador = new ProcesadorImagen(imagen);

            //Instanciación Delegados usando la clase 
            //Cambiar orden y ver resultado
            procesador.AgregarEfectos(procesador.EfectoRotar);
            procesador.AgregarEfectos(procesador.EfectoFiltro);
            procesador.AgregarEfectos(procesador.EfectoDifuminar);
            procesador.AgregarEfectos(procesador.EfectoAfilar);

            //Aplicar los efectos deacuerdo al orden creado previamente
            //Ejecutar los métodos del arreglo <<arregloEfectos>>
            procesador.ProcesarImagen();
        }
    }
}
