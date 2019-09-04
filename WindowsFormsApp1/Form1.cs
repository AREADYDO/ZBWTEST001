using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
    }
        public static SqlConnection conn;
        string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();//读取配置文件连接信息
        


        private void button1_Click(object sender, EventArgs e)
        {
            int Rows = 0;
            Random r = new Random();
            int n = r.Next(100000000, 999999999);
            textBox2.Text = textBox1.Text;
            string sql = string.Format("Insert into OrderTest(AirId ,DateTime, AirCode, AirName, StartPoint, EndPoint, AirDate,Price,Site,Card,Name ) values ('{0}','{1}','{2}',N'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", textBox2.Text, DateTime.Now.ToString(), textBox1.Text, "中国航空", "北京", "上海", DateTime.Now.ToString(), r.Next(00, 99), r.Next(100, 999), r.Next(100000000, 999999999).ToString()+ r.Next(000000000, 999999999).ToString(),"***");
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                Rows = command.ExecuteNonQuery();

                if (Rows == 1)
                {
                    //return true;
                    label1.Text = "ok!";
                }
                else
                {
                    // return false;
                    label1.Text = "err!";
                }
            }
            catch (SqlException ex)
            {
                string error = ex.ToString();
                // return false;
            }
            finally
            {
                conn.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int Rows = 0;
            Random r = new Random();
            int n = r.Next(100000000, 999999999);
            textBox1.Text = n.ToString();
            string sql = string.Format("Insert into AirTest(AirId ,DateTime, AirCode, AirName, AirDate, Price, Memo) values ('{0}','{1}','{2}',N'{3}','{4}','{5}','{6}')", textBox1.Text, DateTime.Now.ToString(), textBox1.Text,"中国航空", DateTime.Now.ToString(), r.Next(100, 999), "N");
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                Rows = command.ExecuteNonQuery();

                if (Rows == 1)
                {
                    //return true;
                    label1.Text = "ok!";
                }
                else
                {
                    // return false;
                    label1.Text = "err!";
                }
            }
            catch (SqlException ex)
            {
                string error = ex.ToString();
               // return false;
            }
            finally
            {
                conn.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            conn = new SqlConnection(strConnection);
        }
    }
}
