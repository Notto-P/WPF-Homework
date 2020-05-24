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

namespace Homework_WPF_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_calculate_Click(object sender, RoutedEventArgs e)
        {
            double income = double.Parse(tb_income.Text);
            double expend = double.Parse(tb_expend.Text);
            double totalPrice = double.Parse(tb_giftPrice.Text);
            int totalDays;

            if (String.IsNullOrEmpty(tb_income.Text))
            {
                MessageBox.Show("Please input your income");
            }
            else if (String.IsNullOrEmpty(tb_expend.Text))
            {
                MessageBox.Show("Please input your expend");
            }
            else if (String.IsNullOrEmpty(tb_giftPrice.Text))
            {
                MessageBox.Show("Please input your gift price");
            }
            else
            {
                double realTotalDays = totalPrice / (income - expend);
                totalDays = Convert.ToInt32( totalPrice / (income - expend));
                if (realTotalDays > totalDays)
                {
                    tb_totalDay.Text = (totalDays+1).ToString();
                }
                else
                {
                    tb_totalDay.Text = totalDays.ToString();
                }
                
            }
        }

    
    }
}
