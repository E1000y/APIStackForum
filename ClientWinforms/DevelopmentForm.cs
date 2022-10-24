﻿using Domain.Entities;
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
        List<Answer> _lstAnswers;

        string _jwt;
        public DevelopmentForm(string jwt)
        {
            _jwt = jwt;
            InitializeComponent();
            
        }

        private void DevelopmentForm_Load(object sender, EventArgs e)
        {
            TxtToken.Text = _jwt;
            btnDev_Click(sender, e);
        }

        private void btnDev_Click(object sender, EventArgs e)
        {
            dgvAnswers.DataSource = null;
            initializeBindingSubjects();
            RefreshAsync(1);
        }

        private void initializeBindingSubjects()
        {
            if(_lstSubjects != null && _lstSubjects.Count > 0)
            {
            dgvSubjects.DataSource = bsSubjects;
                dgvSubjects.Columns["id"].Visible = false;

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
            dgvAnswers.DataSource = null;
            initializeBindingSubjects();
            RefreshAsync(2);
        }

        private void btnFormation_Click(object sender, EventArgs e)
        {
            dgvAnswers.DataSource = null;
            initializeBindingSubjects();
            RefreshAsync(3);
        }

        private void btnFun_Click(object sender, EventArgs e)
        {
            dgvAnswers.DataSource = null;
            initializeBindingSubjects();
            RefreshAsync(4);
        }

        private void btnDivers_Click(object sender, EventArgs e)
        {
            dgvAnswers.DataSource = null;
            initializeBindingSubjects();
            RefreshAsync(5);
        }

        private void dgvSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Subject subject = (Subject)bsSubjects.Current;

            RefreshAnswersAsync(subject);

        }

        private async void RefreshAnswersAsync(Subject subject)
        {
            _lstAnswers = await _dal.GetAnswersBySubjectIdAsync(subject.Id);

            if (_lstAnswers != null)
            {
                bsAnswers.DataSource = _lstAnswers;
                dgvAnswers.DataSource = bsAnswers;
               /* bsAnswers.ResetBindings(false);
                bsAnswers.Position = _lstAnswers.FindIndex(u => u.Id == subject.Id);*/
            }
        }

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Subject subject = (Subject)bsSubjects.Current;

            RefreshAnswersAsync(subject);
        }
    }
}
