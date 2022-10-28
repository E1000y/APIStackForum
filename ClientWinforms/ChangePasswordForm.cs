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
    public partial class ChangePasswordForm : Form
    {
        DAL _dal = DAL.getDAL();

        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            bool IsOldPwdOk = false;

            var result = await _dal.ModifyPasswordAsync(txtOldPassword.Text, txtNewPassword.Text);

            if (result)
            {
                labelDisplay.Visible = true;
                labelDisplay.Text = "Mot de passe changé";
            }
            else
            {
                labelDisplay.Visible = true;
                labelDisplay.Text = "Erreur mot de passe";
            }


        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
