using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _184988SelectionSort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Random r = new Random(2);
            int quant = 1000000;
            int[] nums = new int[quant];
            for (int i = 0; i < quant; i++)
            {
                nums[i] = r.Next(quant);
            }

            foreach (int output in nums)
                Console.WriteLine(output);
            
            Console.WriteLine("----split----");

            DateTime start = DateTime.Now;

            for (int i = 0; i < quant; i++)
            {
                int[] temps = new int[2];
                temps[0] = nums[i];
                temps[1] = nums.Skip(i).Take(quant - i).Min();
                
                for (int ii = i; ii < quant; ii++)
                {
                    if (nums[ii] == temps[1])
                    {
                        nums[ii] = temps[0];
                        nums[i] = temps[1];
                        ii = quant;
                    }
                }
            }

            DateTime end = DateTime.Now;

            TimeSpan dif = end.Subtract(start);
            MessageBox.Show(dif.TotalMilliseconds.ToString() + " Miliseconds taken.");

            foreach (int output in nums)
                Console.WriteLine(output);
        }


    }
}
