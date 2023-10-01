using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp_char
{
    public partial class Form1 : Form
    {
        private char[] symb;
        public Form1()
        {
            InitializeComponent();
            symb= new char[1000];

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            textBox1.Text = "";
            for (int i = 0; i < symb.Length; i++)
            {
                symb[i] = Convert.ToChar(rnd.Next(48, 1112));
                textBox1.Text += symb[i]+" ";
                
            }
        }

        private String search(ref char[] symb, char c)
        {
            String str="";
            int kk = 0;
            for(int i = 0; i < symb.Length; i++)
            {
                if (c == symb[i])
                {
                    str = string.Concat(str, "#",i+1,"; ");
                    kk++;

                }
            }
            if (str.Length > 1)
            {
                str = str.Remove(str.Length -2,2);
                if(kk>1) str = string.Concat("Цей символ знайдено на позиціях ", str,".");
                if (kk == 1) str = string.Concat("Цей символ знайдено на позиції ", str, ".");
            }
            else str = "Цей символ не знайдено";
            return str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String text = textBox2.Text;
            if(textBox1.Text.Length > 0)
            {
                if (text.Length > 0)
                {
                    textBox3.Text = search(ref this.symb, text[0]);
                }
                else MessageBox.Show("Спочатку введіть символ", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Спочатку згенеруйте масив символів!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
