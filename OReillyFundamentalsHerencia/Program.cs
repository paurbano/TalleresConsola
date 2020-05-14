using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OReillyFundamentalsHerencia
{

    public class Window
    {
        private int top;
        private int left;
        public Window(int top,int left)
        {
            this.top = top;
            this.left = left;
        }

        //simula dibujar la ventana
        public void DrawWindow()
        {
            Console.WriteLine("Ventana en {0},{1}",top,left);
        }
    }
    //Deriva-hereda de Window
    public class ListBox : Window
    {
        private string mListsContents; //nuevo miembro propio de la clase

        //Constructor añade el nuevo miembro
        public ListBox(int top,int left,string content):base(top,left) //Llama al constructor de la clase padre
        {
            this.mListsContents = content;
        }

        //Nueva version del metodo, notese la palabra clave new
        //en el método derivado se cambia el comportamiento
        public new void DrawWindow(){
            base.DrawWindow(); //Llama al metodo base
            Console.WriteLine("Escribir cadena a ListBox: {0}",mListsContents);
        }
    }

    public class Tester
    {
        public static void Main(string[] args)
        {
            //Crear una instancia de la clase base
            Window w = new Window(5,10);
            w.DrawWindow();

            //Crear una instancia hija
            ListBox l = new ListBox(10, 10,"LIstBox");
            l.DrawWindow();

        }
    }
}
