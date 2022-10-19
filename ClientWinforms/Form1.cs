using Domain.Entities;
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
    public partial class Form1 : Form

    {
        DAL _dal = new DAL();
        List<Subject> _lstUtilisateurs;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bsUsers_CurrentChanged(object sender, EventArgs e)
        {
            var util = (Subject)bsUsers.Current;
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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var jwt = await _dal.Login(txtLogin.Text, txtPassword.Text);



            if (jwt != null)
            {
                DevelopmentForm developmentForm = new DevelopmentForm();
                developmentForm.Show();
                this.Hide();
            }
           
        }
    }
}
