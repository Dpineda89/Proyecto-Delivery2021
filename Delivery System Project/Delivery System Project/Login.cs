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
            var result = this.userSecurity.ValidateUser(this.textBox1.Text, this.textBox2.Text);

            if (result == true)
            {
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
    }
}
