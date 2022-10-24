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
    public partial class DevelopmentForm : Form
    {
        DAL _dal = new DAL();

        List<Subject> _lstSubjects;

        string _jwt;
        public DevelopmentForm(string jwt)
        {
            _jwt = jwt;
            InitializeComponent();
        }

        private void DevelopmentForm_Load(object sender, EventArgs e)
        {
            TxtToken.Text = _jwt;
        }

        private void btnDev_Click(object sender, EventArgs e)
        {
            initializeBindingSubjects();
            RefreshAsync(1);
        }

        private void initializeBindingSubjects()
        {
            if(_lstSubjects != null && _lstSubjects.Count > 0)
            {
            dgvSubjects.DataSource = bsSubjects;

            }
        }

        private async Task RefreshAsync(int id)
        {
            _lstSubjects = await _dal.GetSubjectsByCategoryId(id);

            if (_lstSubjects != null)
            {
                bsSubjects.DataSource = _lstSubjects;
                bsSubjects.ResetBindings(false);
                bsSubjects.Position = _lstSubjects.FindIndex(u => u.Id == id);
            }
        }

        private void btnEmploi_Click(object sender, EventArgs e)
        {
            initializeBindingSubjects();
            RefreshAsync(2);
        }

        private void btnFormation_Click(object sender, EventArgs e)
        {
            initializeBindingSubjects();
            RefreshAsync(3);
        }

        private void btnFun_Click(object sender, EventArgs e)
        {
            initializeBindingSubjects();
            RefreshAsync(4);
        }

        private void btnDivers_Click(object sender, EventArgs e)
        {
            initializeBindingSubjects();
            RefreshAsync(5);
        }
    }
}
