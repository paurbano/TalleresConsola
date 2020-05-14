using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OReillyFundamentalsClasesAbstractas
{
    abstract public class Window
    {
        protected int top;
        protected int left;
        public Window(int top, int left)
        {
            this.top = top;
            this.left = left;
        }

        abstract public void DrawWindow();
    }

    public class ListBox : Window
    {
        private string listBoxContent;

        //Constructor
        public ListBox(int top, int left, string content)
            : base(top, left)
        {
            listBoxContent = content;
        }

        //Sobrecarga metodo DrawWindow implementando método abstracto
        public override void DrawWindow()
        {
            Console.WriteLine("Contenido ListBox:{0}",listBoxContent);
            
        }
    }

    public class Botton : Window
    {
        //Constructor 
        public Botton(int top,int left):base(top,left)
        {

        }
        //implementación método abstracto
        public override void DrawWindow()
        {
            Console.WriteLine("Boton en {0},{1}\n",top,left);
        }
    }

    public class Tester
    {
        public static void Main(){
            Window[] arrayWin = new Window[3];
            arrayWin[0] = new ListBox(2, 2, "ListBox1");
            arrayWin[1] = new ListBox(5, 8, "ListBox2");
            arrayWin[2] = new Botton(3, 4);

            for (int i = 0; i <= 2; i++)
            {
                arrayWin[i].DrawWindow();
            }
        }
    }
}
