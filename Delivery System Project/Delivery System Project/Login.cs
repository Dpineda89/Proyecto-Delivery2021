using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliverySystem.Security;

namespace Delivery_System_Project
{
    public partial class Login : Form
    {
        UserSecurity userSecurity;
        public Login()
        {
            InitializeComponent();
            this.userSecurity = new UserSecurity();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Loggin(e);
        }

        void Loggin(EventArgs e)
        {
            var result = this.userSecurity.ValidateUser(this.textBox1.Text, this.textBox2.Text);

            if (result!= null)
            {
                DeliverySystem.Libreria.Utilidades.GeneralInfo.Usuario = result.UserName;
                this.ParentForm.Refresh();
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales inválidas");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    textBox2.Focus();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox1.Text))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button1.PerformClick();
                }
            }
        }
    }
}
