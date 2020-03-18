using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checking_lab
{
    class Checking_lab
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            RootFind.ValueEntering(out double a, out int n);
            RootFind.Computing(a, n);
        }
    }

    class RootFind
    {

       internal static void ValueEntering(out double a, out int n)
        {
            Console.WriteLine("Enter value - a, root degree - n");
            try
            {
                string[] temp = Console.ReadLine().Replace(',','.').Split(' ');
                
                a = Convert.ToDouble(temp[0]);
                n = Convert.ToInt32(temp[1]);

                if (n <= 0)
                {
                    Console.WriteLine("Incorrect enter!\n");
                    ValueEntering(out a, out n);
                }
                
                //if(n < 0 && n % 2 == 0)
                //{
                //    Console.WriteLine("Incorrect enter!\n");
                //    ValueEntering(out a, out n);
                //}

                if(a < 0 && n % 2 == 0)
                {
                    Console.WriteLine("Incorrect enter!\n");
                    ValueEntering(out a, out n);
                }
            }
            catch
            {
                Console.WriteLine("Incorrect enter!\n");
                a = n = 0;
                ValueEntering(out a, out n);
            }
        }
        
        internal static void Computing(double a, int n)
        {
            const double accuracy = 0.00001;
            if(a != 0)
            {
                if(a < 0 && n % 2 != 0)
                {
                    double nx = a / n;
                    double x_k = nx;
                    double term = 0;

                    do
                    {
                        nx = x_k;
                        term = nx - a / Math.Pow(nx, n - 1);
                        x_k = nx - term / n;
                    } while (Math.Abs(x_k - nx) > accuracy);
                    ValueOutput(a, n, x_k);
                }
                else if(a > 0)
                {
                    double nx = a / n;
                    double x_k = nx;
                    double term = 0;

                    do
                    {
                        nx = x_k;
                        term = nx - a / Math.Pow(nx, n - 1);
                        x_k = nx - term / n;
                    } while (Math.Abs(x_k - nx) > accuracy);
                    ValueOutput(a, n, x_k);
                }
            }
            else
            {
                ValueOutput(a, n, 0);
            }
        }
        
        private static void ValueOutput(double a, int n, double root)
        {
            Console.OutputEncoding = Encoding.Unicode;
            if(n > 2)
            {
                Console.WriteLine("\n {0}\n  \u221A{1} = {2}\n", n, a, root);
            }
            else
            {
                Console.WriteLine("\n \u221A{1} = {2}\n", n, a, root);
            }
            Console.WriteLine("Verification with Math.Pow\n");
            if(a < 0 && n % 2 != 0)
            {
                Console.WriteLine("Math.Pow = -{0}\n", Math.Pow(a * (-1d), 1d / n));
            }
            else
            {
                Console.WriteLine("Math.Pow = {0}\n", Math.Pow(a, 1d / n));
            }
        }
    }
}
