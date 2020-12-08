using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_App.Class_Lib;

namespace Library_App.Forms
{
    public partial class ReturnForm : Form
    {
        public int std_ID;
        public ReturnForm(int Std_ID)
        {
            InitializeComponent();
            std_ID = Std_ID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book b = Book.LoadByISBN(int.Parse(ISBN_TB.Text));
            if (b != null)
            {
                Edition_CB.DataSource = b.LoadAllEditions();
            }
        }

        private void Submit_btn_Click(object sender, EventArgs e)
        {
            Book b = Book.LoadByISBN(int.Parse(ISBN_TB.Text));
            if (b == null)
            {
                MessageBox.Show("You Haven't Borrowed Book with this ISBN");
            }
            else
            {
                Student s = Student.LoadByID(std_ID);
                s.Return(int.Parse(ISBN_TB.Text));
            }
            this.Close();

        }

        private void ReturnForm_Load(object sender, EventArgs e)
        {

        }
    }
}
