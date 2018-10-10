using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brudnopis2
{
    public interface IA
    {
        int X { get; set; }
        int Y { get; set; }
    }

    public class ia : IA
    {
        private int x;
        private int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public ia(int a, int b)
        {
            X = a;
            Y = b;
        }

        public override string ToString()
        {
            return string.Format($"x: {X}, y: {Y}");
        }

    }


    class Program
    {

        static void Main(string[] args)
        {


            ia first = new ia(2,3);
            ia second = new ia(55, 17);

            Console.WriteLine(first);
            Console.WriteLine(second);

            List<IA> listaIa = new List<IA>
            {
                first,
                second
            };

            Console.WriteLine(listaIa[1]);
            Console.WriteLine(listaIa[0]);

            Console.WriteLine();
            Console.WriteLine("ShowList");
            ShowList(listaIa);

            Console.ReadKey();
        }

        public static void ShowList(IList<IA> lista)
        {
            foreach(IA ia in lista)
                Console.WriteLine($"ia.X: {ia.X} ia.Y: {ia.Y}");
        }
    }

}
