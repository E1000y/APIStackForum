using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWinforms
{
    public partial class SignUp : Form
    {
        DAL _dal = DAL.getDAL();
  

        public SignUp()
        {
            InitializeComponent();
        }

        private async void btnCreateUser_Click(object sender, EventArgs e)
        {



          bool res =  await _dal.CreateWriterAsync(txtFirstName.Text, txtLastName.Text, txtLogin.Text, txtPassword.Text);

            if (res)
            {
                MessageBox.Show("Utilisateur créé");
                string jwt = await _dal.Login(txtLogin.Text, txtPassword.Text);
                if (jwt != null)
                {


                    DialogResult = DialogResult.OK;
                   
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Erreur de login");
                }

            }
            else
            {
                MessageBox.Show("Erreur dans la création de l'utilisateur");
              
            }
            
        }
    }
}
