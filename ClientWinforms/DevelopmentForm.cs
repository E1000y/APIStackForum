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
        DAL _dal = DAL.getDAL();

        List<Subject> _lstSubjects;
        List<Answer> _lstAnswers;

        int activeCategory = 0;
        bool _isVisitor = false;

        string _jwt;
        public DevelopmentForm(string jwt, bool isVisitor)
        {
            _jwt = jwt;
            _isVisitor = isVisitor;
            InitializeComponent();
            btnChangePassword.Enabled = !isVisitor;
            tabControl1.Enabled = !isVisitor;
            tabControl2.Enabled = !isVisitor;
            
        }
        void ButtonClickOneEvent(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = (btn.BackColor == Color.White) ? Color.Red : Color.White;
            }
        }

        private void DevelopmentForm_Load(object sender, EventArgs e)
        {
            TxtToken.Text = _jwt;
            btnDev_Click(sender, e);
        }

        private async void btnDev_Click(object sender, EventArgs e)
        {
            dgvAnswers.DataSource = null;
            initializeBindingSubjects();
            activeCategory = 1;
            await RefreshSubjectAsync(activeCategory);
        }

        private void initializeBindingSubjects()
        {
            if(_lstSubjects != null && _lstSubjects.Count > 0)
            {
            dgvSubjects.DataSource = bsSubjects;
                dgvSubjects.Columns["id"].Visible = false;

            }
        }

        private async Task RefreshSubjectAsync(int id, int idsubject = 0)
        {
            _lstSubjects = await _dal.GetSubjectsByCategoryId(id);

            if (_lstSubjects != null)
            {
                bsSubjects.DataSource = _lstSubjects;
                bsSubjects.ResetBindings(false);
                bsSubjects.Position = _lstSubjects.FindIndex(u => u.Id == idsubject);
            }

          }

        private async void btnEmploi_Click(object sender, EventArgs e)
        {
            dgvAnswers.DataSource = null;
            initializeBindingSubjects();
            activeCategory = 2;
            await RefreshSubjectAsync (activeCategory);
        }

        private async void btnFormation_Click(object sender, EventArgs e)
        {
            dgvAnswers.DataSource = null;
            initializeBindingSubjects();
            activeCategory = 3;
           await RefreshSubjectAsync(activeCategory);
        }

        private async void btnFun_Click(object sender, EventArgs e)
        {
            dgvAnswers.DataSource = null;
            initializeBindingSubjects();
            activeCategory = 4;
           await RefreshSubjectAsync(activeCategory);
        }

        private async void btnDivers_Click(object sender, EventArgs e)
        {
            dgvAnswers.DataSource = null;
            initializeBindingSubjects();
            activeCategory = 5;

         await   RefreshSubjectAsync(activeCategory);
        }

        private async void dgvSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Subject subject = (Subject)bsSubjects.Current;
            Answer answer = (Answer)bsAnswers.Current;
          await  RefreshAnswersAsync(subject);

            TxtModifySubjectName.Text = subject.Name;
            txtModifySubjectDescription.Text = subject.Description;
            if(answer != null)
            {
                txtModifyAnswerBody.Text = answer.Body;

            }

        }

        private async  Task RefreshAnswersAsync(Subject subject)
        {
            _lstAnswers = await _dal.GetAnswersBySubjectIdAsync(subject.Id);

            if (_lstAnswers != null)
            {
                bsAnswers.DataSource = _lstAnswers;
                dgvAnswers.DataSource = bsAnswers;
               bsAnswers.ResetBindings(false);
                /*bsAnswers.Position = _lstAnswers.FindIndex(u => u.Id == subject.Id);*/
            }
        }

        private async void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Subject subject = (Subject)bsSubjects.Current;

          await  RefreshAnswersAsync(subject);
        }

        private async void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            //Delete pending subject

            //throw new NotImplementedException();

            Subject subject = (Subject)bsSubjects.Current;

            bool result = await _dal.deleteSubjectAsync(subject.Id);

            if (result)
            {
                MessageBox.Show("ligne supprimée");
            }
            else
            {
                MessageBox.Show("Erreur de suppression");
            }

            await RefreshSubjectAsync(subject.categoryId);

        }

        

        private void btnDev_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            String subjectName = txtSubjectName.Text;
            String subjectDescription = txtDescription.Text;

            CreateSubjectAsync(subjectName, subjectDescription, activeCategory);

        }

        private async void CreateSubjectAsync(string subjectName, string subjectDescription, int categoryId)
        {
            await _dal.createSubjectAsync(subjectName, subjectDescription, categoryId);
           await RefreshSubjectAsync(categoryId);
        }

        private async void ModifyButton_Click(object sender, EventArgs e)
        {
            
           String modifiedSubjectName = TxtModifySubjectName.Text;
            String modifiedSubjectDescription = txtModifySubjectDescription.Text;
            Subject subject = (Subject)bsSubjects.Current;
            await _dal.modifySubjectAsync(subject.Id, modifiedSubjectName, modifiedSubjectDescription, activeCategory);
            await RefreshSubjectAsync(activeCategory);
        }

      

        private async void btnAddAnswer_Click(object sender, EventArgs e)
        {

            string addAnswerBody = txtAddAnswerBody.Text;
            Subject subject = (Subject)bsSubjects.Current;
            var res = await _dal.createAnswerAsync(subject.Id, addAnswerBody);
            
          
            await RefreshAnswersAsync(subject);
        }

        private async void btnModifyAnswer_Click(object sender, EventArgs e)
        {
            Subject subject = (Subject)bsSubjects.Current;
            Answer answer = (Answer)bsAnswers.Current;
           
            string modifyAnswerBody = txtModifyAnswerBody.Text;
            var res = await _dal.modifyAnswerAsync(modifyAnswerBody, subject.Id, answer.Id);
            await RefreshAnswersAsync(subject);
        }

        private async void btnDeleteAnswer_Click(object sender, EventArgs e)
        {
            Subject subject = (Subject)bsSubjects.Current;
            Answer answer = (Answer)bsAnswers.Current;

            bool result = await _dal.deleteAnswerAsync(answer.Id);

            await RefreshAnswersAsync(subject);

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {

        }
    }
}
