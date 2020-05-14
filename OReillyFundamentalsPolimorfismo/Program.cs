//Para crear un método que soporte polimorfismo,este se debe marcar con la palabra virtual en su clase base.
//Ej. public virtual void DrawWindow( )

using System;

namespace OReillyFundamentalsPolimorfismo
{
    public class Window
    {
        //Miembros protegidos por lo tanto visibles solo en las clases hijas
        protected int top;
        protected int left;
        public Window(int top, int left)
        {
            this.top = top;
            this.left = left;
        }

        //simula dibujar la ventana
        //uso de virtual, permite a las clases hijas hacer sobreEscritura
        //sobre el metodo
        public virtual void DrawWindow()
        {
            Console.WriteLine("Ventana en {0},{1}", top, left);
        }
    }
    //Deriva-hereda de Window
    public class ListBox : Window
    {
        private string mListsContents; //nuevo miembro propio de la clase

        //Constructor añade el nuevo miembro
        public ListBox(int top, int left, string content)
            : base(top, left) //Llama al constructor de la clase padre
        {
            this.mListsContents = content;
        }

        //Nueva version del metodo, notese la palabra clave override
        //en el método derivado se cambia el comportamiento
        public override void DrawWindow()
        {
            base.DrawWindow(); //Llama al metodo base - No es obligatorio
            Console.WriteLine("Escribir cadena a ListBox: {0}", mListsContents);
        }
    }

    public class Button : Window
    {
        public Button(int top,int left):base(top,left) { }

        //SobreEscritura del método de la clase base que hace efectiva el polimorfismo.
        public override void DrawWindow()
        {
            base.DrawWindow();
            Console.WriteLine("Dibujar Boton:{0},{1} \n", top, left);
        }
    }

    public class Tester
    {
        public static void Main(string[] args)
        {
            //Crear una instancia de la clase base
            Window win = new Window(5, 10);
            ListBox l = new ListBox(10, 10, "Objeto ListBox");
            Button b = new Button(5,6);

            win.DrawWindow();
            l.DrawWindow();
            b.DrawWindow();
           
            Window[] winArreglo= new Window[3];
            winArreglo[0] = new Window(2, 2);
            winArreglo[1] = new ListBox(3, 5, "ListBox en un arreglo");
            winArreglo[2] = new Button(4, 4);

            for (int i = 0;i<3 ; i++)
            {
                winArreglo[i].DrawWindow();
            }
            

        }
    }
}
