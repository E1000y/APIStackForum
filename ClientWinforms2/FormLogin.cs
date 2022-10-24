using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWinforms2
{
    public partial class LoginForm : Form
    {
        DAL _dal = new DAL();

        public LoginForm()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, EventArgs e)
        {
            var jwt = await _dal.Login(txtLogin.Text, txtPassword.Text);


            if (jwt != null)
            {
                await RefreshAsync(0);
                InitializeBinding();
                //    DevelopmentForm developmentForm = new DevelopmentForm();
                //    developmentForm.Show();
                 // this.Hide();
            }
        }

        private async Task RefreshAsync(int id = 0)
        {
            _lstUtilisateurs = await _dal.GetAllUtilisateursAsync();

            if (_lstUtilisateurs != null)
            {
                bsUsers.DataSource = _lstUtilisateurs;
                bsUsers.ResetBindings(false);
                bsUsers.Position = _lstUtilisateurs.FindIndex(u => u.Id == id);
            }

           


        }
    }
