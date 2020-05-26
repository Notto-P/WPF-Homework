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

namespace Hashtable_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Hashtable hastable;
        public MainWindow()
        {
            InitializeComponent();
            hastable = new Hashtable();
        }

        // Add button : key ที่มีแล้วจะ add ซ้ำไม่ได้ จะ error
        private void Btn_add_Click(object sender, RoutedEventArgs e) 
        {
            if (String.IsNullOrEmpty(tb_key.Text))                   //ถ้าในกล่องข้อความว่างเปล่า
            {
                MessageBox.Show("Please input 'KEY' ");
            }
            else if(String.IsNullOrEmpty(tb_value.Text))
            {
                MessageBox.Show("Please input 'VALUE' ");
            }
            else
            {
                ICollection collection = hastable.Keys;
                if(collection.Count == 0)
                {
                    hastable.Add(tb_key.Text, tb_value.Text);              //เพิ่มข้อมูลลงใน hastable
                    MessageBox.Show("Added '" + tb_key.Text + " : " + tb_value.Text + "'");
                    tb_key.Clear();         //เคลียร์กล่องข้อความ
                    tb_value.Clear();
                }
                else
                {
                    foreach (string key in collection)
                    {
                        if (key == tb_key.Text)  //ถ้าเจอข้อมูลที่เหมือนกับที่ซ้ำกันให้ break ออกจากลูป
                        {
                            MessageBox.Show("The key '" + tb_key.Text + "' is already exist");
                            break;
                        }
                        else  //ถ้าไม่เจอจะทำการเพิ่มข้อมูลลงไป และ ออกจากลูป
                        {
                            hastable.Add(tb_key.Text, tb_value.Text);              //เพิ่มข้อมูลลงใน hastable
                            MessageBox.Show("Added '" + tb_key.Text + " : " + tb_value.Text + "'");
                            break;
                        }
                    }
                    tb_key.Clear();         //เคลียร์กล่องข้อความ
                    tb_value.Clear();
                }
            }  
        }




        //Remove Button  : ลบข้อมูลที่มี key เหมือนกับข้อมูลในช่อง key
        private void Btn_remove_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tb_key.Text)) //ถ้ากล่องข้อความว่างเปล่า
            {
                MessageBox.Show("Please input 'KEY' for removing");
            }
            else
            {
                ICollection collection = hastable.Keys;
                if (collection.Count == 0)
                {
                    MessageBox.Show("No data in collection");
                }
                else
                {
                    int checkData = 1;
                    foreach (string key in collection)
                    {
                        if (key == tb_key.Text)  //ถ้าเจอข้อมูลที่เหมือนกับที่ซ้ำกันให้ break ออกจากลูป
                        {
                            hastable.Remove(tb_key.Text);
                            MessageBox.Show("The key '" + tb_key.Text + "' was deleted");
                            checkData = 2;
                            break;
                        }
                    }
                    if(checkData == 1)
                    {
                        MessageBox.Show("'" + tb_key.Text + "' is not found in collection");
                    }
                    tb_key.Clear();         //เคลียร์กล่องข้อความ
                    tb_value.Clear();
                }
            }
        }




        // ฟังก์ชั่นของปุ่ม show 
        private void Btn_show_Click(object sender, RoutedEventArgs e)
        {
            ICollection collection = hastable.Keys;     // Hastable เวลาดึงข้อมูล จะดึงจากตัว index หรือ key ไม่ใช่ตัวข้อมูลหรือ value ทำให้ต้องใช้ฟังก์ชั่นนี้เพื่อดึง index หรือ key มาใส่ในตัวแปรที่กำหนด (collection)

            if(collection.Count == 0)
            {
                MessageBox.Show("no data");
            }
            else
            {
                string Data = "";
                foreach (string key in collection)
                {
                    Data = Data + "\n" + key + " : " + hastable[key]; // \n คือขึ้นบรรทัดใหม่
                }
                MessageBox.Show("Count : " + collection.Count.ToString() + "\nData is shown below " + Data);
                //MessageBox.Show(hastable[key].ToString());  // เวลาเรียกโชว์ต้องดึงโดยใช้ index , ชื่ออาร์เรย์hastable[index]
            }

            
        }
    }
}
