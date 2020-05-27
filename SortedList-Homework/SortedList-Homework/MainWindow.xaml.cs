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

namespace SortedList_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SortedList sortedList;  // เก็บข้อมูลเหมือนกับ Hastable แต่มันจะเรียงลำดับข้อมูลจากน้อยไปมากของ key มาให้เลย
        public MainWindow()
        {
            InitializeComponent();
            sortedList = new SortedList();
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(tb_key.Text))
            {
                MessageBox.Show("Please input 'KEY' ");

            }
            else if (String.IsNullOrEmpty(tb_Value.Text))
            {
                MessageBox.Show("Please input 'VALUE' ");
            }
            else
            {
                ICollection collection = sortedList.Keys;
                if (collection.Count == 0)
                {
                    sortedList.Add(tb_key.Text, tb_Value.Text);             //เพิ่มข้อมูลลงใน sortedList
                    //sortedList.Add(int.Parse( tb_key.Text), tb_Value.Text); //ถ้าต้องการให้ Key เป็นจำนวนเต็ม ก็เพิ่มไปแบบ int ***

                    MessageBox.Show("Added '" + tb_key.Text + " : " + tb_Value.Text + "'");
                    tb_key.Clear();         //เคลียร์กล่องข้อความ
                    tb_Value.Clear();
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
                            sortedList.Add(tb_key.Text, tb_Value.Text);              //เพิ่มข้อมูลลงใน sortedList
                            MessageBox.Show("Added '" + tb_key.Text + " : " + tb_Value.Text + "'");
                            break;
                        }
                    }
                    tb_key.Clear();         //เคลียร์กล่องข้อความ
                    tb_Value.Clear();
                }
                string Data = "";
                foreach (string key in collection)
                //foreach (int key in collection)   //ถ้าต้องการให้ Key เป็นจำนวนเต็ม ***
                {
                    Data = Data + "\n" + key + " : " + sortedList[key]; // \n คือขึ้นบรรทัดใหม่
                }
                MessageBox.Show("Count : " + collection.Count.ToString() + "\nData is shown below " + Data);


            }
        }
    }
}
