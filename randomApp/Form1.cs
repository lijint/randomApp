using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace randomApp
{
    public partial class Form1 : Form
    {

        private List<string> bankList;

        //private Dictionary<int, string> banklist;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sbank = textBox1.Text;
                if(string.IsNullOrEmpty(sbank))
                {
                    throw new Exception("请输入银行名称");
                }
                if (bankList.Count > 0)
                {
                    foreach (string b in bankList)
                    {
                        if (string.Compare(b, sbank) == 0)
                        {
                            throw new Exception("重复录入银行");
                        }
                    }
                }
                //Bank bank = new Bank()
                //{
                //    name = sbank,
                //    index = bankList.Count + 1
                //};
                bankList.Add(sbank);
                display();
                textBox1.Clear();
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string item = (string)listBox1.SelectedItem;
                if (string.IsNullOrEmpty(item))
                {
                    throw new Exception("请选择要删除的银行");
                }
                foreach (string s in bankList)
                {
                    if (string.Compare(s, item) == 0)
                    {
                        bankList.Remove(item);
                        break;
                    }
                }
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (bankList.Count <= 0)
                {
                    throw new Exception("无抽取数据");
                }
                Random r = new Random();
                int res = r.Next(0, bankList.Count);
                label1.Text = bankList[res];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return;
        }

        private void display()
        {
            listBox1.Items.Clear();
            foreach(string b in bankList)
            {
                listBox1.Items.Add(b);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(textBox1.Focused)
                {
                    button1.PerformClick();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bankList = new List<string>();
            display();
            label1.Text = "";
            //textBox1.Focus();

        }
    }

    public class Bank
    {
        public int index;
        public string name;
    }
}
