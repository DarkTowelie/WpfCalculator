using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double num1;
        double num2;
        char oper;
        bool dotExist;
        int currentNumber;

        public MainWindow()
        {
            InitializeComponent();
            num1 = 0;
            num2 = 0;
            oper = ' ';
            dotExist = false;
            currentNumber = 1;
        }

        void addNum(int num)
        {
            if (currentNumber == 1 || currentNumber == 2)
            {
                tb_Result.Text += Convert.ToString(num);
            }
        }

        void addDot()
        {
            if (!String.IsNullOrEmpty(tb_Result.Text) && dotExist == false)
            {
                tb_Result.Text += ",";
                dotExist = true;
            }
        }

        double convertToNum(string num)
        {
            try
            {
                return Convert.ToDouble(num);
            }
            catch
            {
                num = num.Replace(',', '.');
                return Convert.ToDouble(num);
            }
        }

        void clearTb()
        {
            tb_Result.Text = string.Empty;
            dotExist = false;

        }

        void operClick(char oper)
        {
            if (currentNumber == 1 || currentNumber == 3)
            {
                num1 = convertToNum(tb_Result.Text);
                this.oper = oper;
                currentNumber = 2;
                clearTb();
            }
        }

        void getResult()
        {
            currentNumber = 3;
            num2 = convertToNum(tb_Result.Text);

            switch (oper)
            {
                case ('+'):
                    tb_Result.Text = Convert.ToString(num1 + num2);
                    break;
                case ('-'):
                    tb_Result.Text = Convert.ToString(num1 - num2);
                    break;
                case ('/'):
                    tb_Result.Text = Convert.ToString(Math.Round(num1 / num2, 5));
                    break;
                case ('*'):
                    tb_Result.Text = Convert.ToString(num1 * num2);
                    break;
                case ('%'):
                    tb_Result.Text = Convert.ToString(num2 / 100);
                    break;
            }
        }

        private void b_Num0_Click(object sender, RoutedEventArgs e)
        {
            addNum(0);
        }

        private void b_Num1_Click(object sender, RoutedEventArgs e)
        {
            addNum(1);
        }

        private void b_Num2_Click(object sender, RoutedEventArgs e)
        {
            addNum(2);
        }

        private void b_Num3_Click(object sender, RoutedEventArgs e)
        {
            addNum(3);
        }

        private void b_Num4_Click(object sender, RoutedEventArgs e)
        {
            addNum(4);
        }

        private void b_Num5_Click(object sender, RoutedEventArgs e)
        {
            addNum(5);
        }

        private void b_Num6_Click(object sender, RoutedEventArgs e)
        {
            addNum(6);
        }

        private void b_num7_Click(object sender, RoutedEventArgs e)
        {
            addNum(7);
        }

        private void b_Num8_Click(object sender, RoutedEventArgs e)
        {
            addNum(8);
        }

        private void b_Num9_Click(object sender, RoutedEventArgs e)
        {
            addNum(9);
        }

        private void b_AC_Click(object sender, RoutedEventArgs e)
        {
            clearTb();
            currentNumber = 1;
        }

        private void b_Dot_Click(object sender, RoutedEventArgs e)
        {
            addDot();
        }

        private void b_Devide_Click(object sender, RoutedEventArgs e)
        {
            operClick('/');
        }

        private void b_Mult_Click(object sender, RoutedEventArgs e)
        {
            operClick('*');
        }

        private void b_Minus_Click(object sender, RoutedEventArgs e)
        {
            operClick('-');
        }

        private void b_Plus_Click(object sender, RoutedEventArgs e)
        {
            operClick('+');
        }

        private void b_Percent_Click(object sender, RoutedEventArgs e)
        {
            oper = '%';
            getResult();
        }

        private void b_Equal_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber == 2)
            {
                getResult();
            }
        }

        private void b_ChangeSymbol_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_Result.Text) && currentNumber != 3)
            {
                if (tb_Result.Text[0] != '-')
                    tb_Result.Text = tb_Result.Text.Insert(0, "-");
                else
                    tb_Result.Text = tb_Result.Text.Remove(0, 1);
            }
        }
    }
}
