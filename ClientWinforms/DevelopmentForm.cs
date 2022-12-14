using Domain.DTO.Responses;
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

        List<SubjectDetailWriterNameResponseDTO> _lstSubjects;
        List<AnswerDetailWriterNameResponseDTO> _lstAnswers;

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
            btnLogOut.Enabled = !isVisitor;
            btnSignUp.Enabled = isVisitor;
            
        }
        void ButtonClickOneEvent(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = (btn.BackColor == Color.White) ? Color.Red : Color.White;
            }
        }

        private async void DevelopmentForm_Load(object sender, EventArgs e)
        {
            await RefreshSubjectAsync(1);
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
                dgvSubjects.Columns["name"].HeaderText = "Nom du sujet";
                dgvSubjects.Columns["WriterName"].HeaderText = "Nom de l'auteur";
                dgvSubjects.Columns["CategoryId"].Visible = false;
                dgvSubjects.Columns["CreationDate"].HeaderText = "Date de création";

            }
         //   initializeBindingAnswers();
        }

        private void initializeBindingAnswers()
        {
            if (_lstAnswers != null && _lstAnswers.Count > 0)
            {
                dgvAnswers.DataSource = bsAnswers;
                dgvAnswers.Columns["Id"].Visible = false;
                dgvAnswers.Columns["Body"].HeaderText = "Corps de la réponse";
                dgvAnswers.Columns["WriterName"].HeaderText = "Nom de l'auteur";
                dgvAnswers.Columns["SubjectId"].Visible = false;
                dgvAnswers.Columns["CreationDate"].HeaderText = "Date de création";
            }
        }

        private async Task RefreshSubjectAsync(int id, int idsubject = 0)
        {
           

            _lstSubjects = await _dal.GetSubjectsByCategoryId(id);

            if (_lstSubjects != null)
            {
                if (!tabControl2.Controls.Contains(tabPage4))
                {
                tabControl2.Controls.Add(tabPage4);
                }


                if (!tabControl1.Controls.Contains(tabPage2))
                {
                tabControl1.Controls.Add(tabPage2);
                tabControl1.Controls.Add(tabPage3);

                }
                bsSubjects.DataSource = _lstSubjects;
                bsSubjects.ResetBindings(false);
                bsSubjects.Position = _lstSubjects.FindIndex(u => u.Id == idsubject);
            }
            else
            {
                tabControl2.Controls.Remove(tabPage4);
                tabControl2.Controls.Remove(tabPage5);
                tabControl2.Controls.Remove(tabPage6);
                bsSubjects.DataSource = null;
                tabControl1.Controls.Remove(tabPage2);
                tabControl1.Controls.Remove(tabPage3);
            }

          }

        private async void btnEmploi_Click(object sender, EventArgs e)
        {
            dgvAnswers.DataSource = null;
            initializeBindingSubjects();
            activeCategory = 2;
            await RefreshSubjectAsync(activeCategory);
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



            SubjectDetailWriterNameResponseDTO subject = (SubjectDetailWriterNameResponseDTO)bsSubjects.Current;
            AnswerDetailWriterNameResponseDTO answer = (AnswerDetailWriterNameResponseDTO)bsAnswers.Current;
          await  RefreshAnswersAsync(subject.Id);

            TxtModifySubjectName.Text = subject.Name;
            txtModifySubjectDescription.Text = subject.Description;
            if(answer != null)
            {
                txtModifyAnswerBody.Text = answer.Body;

            }

        }

        private async  Task RefreshAnswersAsync(int SubjectId)
        {
            _lstAnswers = await _dal.GetAnswersBySubjectIdAsync(SubjectId);
          
            if (_lstAnswers != null)
            {

                if (!tabControl2.Controls.Contains(tabPage5))
                {
                tabControl2.Controls.Add(tabPage5);
                tabControl2.Controls.Add(tabPage6);
                }
                bsAnswers.DataSource = _lstAnswers;
                dgvAnswers.DataSource = bsAnswers;
               bsAnswers.ResetBindings(false);
                /*bsAnswers.Position = _lstAnswers.FindIndex(u => u.Id == subject.Id);*/
            }
            else
            {
                dgvAnswers.DataSource = null;
                tabControl2.Controls.Remove(tabPage5);
                tabControl2.Controls.Remove(tabPage6);
            }

            initializeBindingAnswers();
        }

        private async void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SubjectDetailWriterNameResponseDTO subjectDetail = (SubjectDetailWriterNameResponseDTO)bsSubjects.Current;

            Subject subject = new Subject
            {
                Id = subjectDetail.Id,
                categoryId = subjectDetail.CategoryId,
                Name = subjectDetail.Name,
                CreationDate = subjectDetail.CreationDate


            };

            initializeBindingAnswers();
            await  RefreshAnswersAsync(subject.Id);
        }

        private async void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            //Delete pending subject

 

            SubjectDetailWriterNameResponseDTO subject = (SubjectDetailWriterNameResponseDTO)bsSubjects.Current;

            bool result = await _dal.deleteSubjectAsync(subject.Id);

            if (result)
            {
                MessageBox.Show("ligne supprimée");
            }
            else
            {
                MessageBox.Show("Erreur de suppression, l'utilisateur courant n'a pas les droits.");
            }

            await RefreshSubjectAsync(subject.CategoryId);
            await RefreshAnswersAsync(subject.Id);

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
            SubjectDetailWriterNameResponseDTO subject = (SubjectDetailWriterNameResponseDTO)bsSubjects.Current;
            if (subject != null)
            {
            await _dal.modifySubjectAsync(subject.Id, modifiedSubjectName, modifiedSubjectDescription, activeCategory);
            await RefreshSubjectAsync(activeCategory);

            }
            
        }

      

        private async void btnAddAnswer_Click(object sender, EventArgs e)
        {

            string addAnswerBody = txtAddAnswerBody.Text;
            SubjectDetailWriterNameResponseDTO subject = (SubjectDetailWriterNameResponseDTO)bsSubjects.Current;
            
            var res = await _dal.createAnswerAsync(subject.Id, addAnswerBody);
            
          
            await RefreshAnswersAsync(subject.Id);
        }

        private async void btnModifyAnswer_Click(object sender, EventArgs e)
        {
            SubjectDetailWriterNameResponseDTO subject = (SubjectDetailWriterNameResponseDTO)bsSubjects.Current;
            AnswerDetailWriterNameResponseDTO answer = (AnswerDetailWriterNameResponseDTO)bsAnswers.Current;

            string modifyAnswerBody = txtModifyAnswerBody.Text;
            var res = await _dal.modifyAnswerAsync(modifyAnswerBody, subject.Id, answer.Id);
            await RefreshAnswersAsync(subject.Id);
        }

        private async void btnDeleteAnswer_Click(object sender, EventArgs e)
        {
            SubjectDetailWriterNameResponseDTO subject = (SubjectDetailWriterNameResponseDTO)bsSubjects.Current;
            AnswerDetailWriterNameResponseDTO answer = (AnswerDetailWriterNameResponseDTO)bsAnswers.Current;

            bool result = await _dal.deleteAnswerAsync(answer.Id);
            if (result)
            {
                MessageBox.Show("ligne supprimée");
            }
            else
            {
                MessageBox.Show("Erreur de suppression, l'utilisateur courant n'a pas les droits.");
            }
            await RefreshAnswersAsync(subject.Id);

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm pwform = new ChangePasswordForm();
            pwform.Show();
          

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
           
            SignUp signUp = new SignUp();
           DialogResult dr = signUp.ShowDialog();

           if(dr == DialogResult.OK)
            {
                btnChangePassword.Enabled = true;
                tabControl1.Enabled = true;
                tabControl2.Enabled = true;
                btnSignUp.Enabled = false;
                btnLogOut.Enabled = true;
            }
            
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {

            SignInForm signIn = new SignInForm();
            DialogResult dr = signIn.ShowDialog();

            if (dr == DialogResult.OK)
            {
                btnChangePassword.Enabled = true;
                tabControl1.Enabled = true;
                tabControl2.Enabled = true;
                btnSignUp.Enabled = false;
                btnLogOut.Enabled = true;
            }
            

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            _jwt = null;

            btnChangePassword.Enabled = false;
            tabControl1.Enabled = false;
            tabControl2.Enabled = false;
            btnSignUp.Enabled = true;
            btnSignIn.Enabled = true;
            btnLogOut.Enabled = false;

        }

  
    }
}
