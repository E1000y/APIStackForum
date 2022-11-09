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
    public partial class SignInForm : Form
    {

        DAL _dal = DAL.getDAL();
        public SignInForm()
        {
            InitializeComponent();
        }

        private async void btnLogInDuSignIn_Click(object sender, EventArgs e)
        {
            var jwt = await _dal.Login(txtUserNameSignIn.Text, TxtPasswordSignIn.Text);





            if (jwt != null)
            {


                DialogResult = DialogResult.OK;


            }
            else
            {
                MessageBox.Show("Erreur de login");
            }
        }
    }
}
