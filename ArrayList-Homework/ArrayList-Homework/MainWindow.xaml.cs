using System;
using System.Collections;
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

namespace ArrayList_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ArrayList arrayList;  // ประกาศตัวแปร arrayList

        public MainWindow()
        {
            InitializeComponent();
            arrayList = new ArrayList();  // สร้าง ArrayList
        }


        // ฟังก์ชั่นของปุ่ม show all
        private void Btn_showAll_Click(object sender, RoutedEventArgs e)
        {
            if (arrayList.Count == 0)  // ถ้าใน arrayList ไม่มีข้อมูล
            {
                MessageBox.Show("No data in collection");
            }
            else   // ถ้ามีข้อมูล ให้แสดงผลตามนี้
            {
                string Data = "";
                int index = 0;
                foreach (string dataInArray in arrayList)
                {
                    index = (index+1);
                    Data = Data + "\n" + index + " : " + dataInArray; // \n คือขึ้นบรรทัดใหม่
                }
                MessageBox.Show("Count : " + arrayList.Count.ToString() + "\nData is shown below " + Data);
            }
            
        }


    // ฟังก์ชั่นของปุ่ม Add
        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(tb_input.Text)) //ถ้าในกล่องข้อความว่างเปล่า
            {
                MessageBox.Show("Please input your data in textBox");
            }
            else
            {
                arrayList.Add(tb_input.Text); //เพิ่มข้อมูลลงใน arrayList
                MessageBox.Show("Added '" + tb_input.Text + "' into the collection");
                tb_input.Clear();             //เคลียร์กล่องข้อความ
            }
            
        }


        //ฟังก์ชั่นของปุ่ม Remove
        private void Btn_remove_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tb_input.Text)) //ถ้ากล่องข้อความว่างเปล่า
            {
                MessageBox.Show("Please input your data in textBox");
            }
            else
            {
                if (arrayList.Count == 0) //ถ้าใน arrayList ไม่มีข้อมูล
                {
                    MessageBox.Show("No data in collection");
                }
                else
                {
                    foreach (string dataInArray in arrayList)
                    {
                        if (dataInArray == tb_input.Text)  //ถ้าเจอข้อมูลที่เหมือนกับที่ใส่ในกล่องข้อความให้ลบออก และ break ออกจากลูป
                        {
                            arrayList.Remove(tb_input.Text);
                            MessageBox.Show("Removed '" + tb_input.Text + "' from the collection");
                            break;
                        }
                        else  //ถ้าไม่เจอข้อมูลที่จะลบ
                        {
                            MessageBox.Show("'" + tb_input.Text + "' is not found in collection");
                        }
                    }
                }
                
                tb_input.Clear();
            }
        }
    }
}
