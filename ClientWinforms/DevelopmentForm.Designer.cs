
namespace ClientWinforms
{
    partial class DevelopmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtToken = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDivers = new System.Windows.Forms.Button();
            this.btnFun = new System.Windows.Forms.Button();
            this.btnFormation = new System.Windows.Forms.Button();
            this.btnEmploi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDev = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnAddAnswer = new System.Windows.Forms.Button();
            this.txtAddAnswerBody = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnModifyAnswer = new System.Windows.Forms.Button();
            this.txtModifyAnswerBody = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnDeleteAnswer = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ModifySubject = new System.Windows.Forms.Button();
            this.txtModifySubjectDescription = new System.Windows.Forms.TextBox();
            this.TxtModifySubjectName = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnDeleteSubject = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvAnswers = new System.Windows.Forms.DataGridView();
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.bsSubjects = new System.Windows.Forms.BindingSource(this.components);
            this.bsAnswers = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnswers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnswers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(679, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Role";
            // 
            // TxtToken
            // 
            this.TxtToken.Location = new System.Drawing.Point(727, 0);
            this.TxtToken.Multiline = true;
            this.TxtToken.Name = "TxtToken";
            this.TxtToken.ReadOnly = true;
            this.TxtToken.Size = new System.Drawing.Size(153, 58);
            this.TxtToken.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDivers);
            this.panel1.Controls.Add(this.btnFun);
            this.panel1.Controls.Add(this.btnFormation);
            this.panel1.Controls.Add(this.btnEmploi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnDev);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 732);
            this.panel1.TabIndex = 7;
            // 
            // btnDivers
            // 
            this.btnDivers.Location = new System.Drawing.Point(0, 324);
            this.btnDivers.Name = "btnDivers";
            this.btnDivers.Size = new System.Drawing.Size(200, 72);
            this.btnDivers.TabIndex = 5;
            this.btnDivers.Text = "Divers";
            this.btnDivers.UseVisualStyleBackColor = true;
            this.btnDivers.Click += new System.EventHandler(this.btnDivers_Click);
            // 
            // btnFun
            // 
            this.btnFun.Location = new System.Drawing.Point(0, 255);
            this.btnFun.Name = "btnFun";
            this.btnFun.Size = new System.Drawing.Size(200, 74);
            this.btnFun.TabIndex = 4;
            this.btnFun.Text = "Fun";
            this.btnFun.UseVisualStyleBackColor = true;
            this.btnFun.Click += new System.EventHandler(this.btnFun_Click);
            // 
            // btnFormation
            // 
            this.btnFormation.Location = new System.Drawing.Point(0, 190);
            this.btnFormation.Name = "btnFormation";
            this.btnFormation.Size = new System.Drawing.Size(200, 69);
            this.btnFormation.TabIndex = 3;
            this.btnFormation.Text = "Formation";
            this.btnFormation.UseVisualStyleBackColor = true;
            this.btnFormation.Click += new System.EventHandler(this.btnFormation_Click);
            // 
            // btnEmploi
            // 
            this.btnEmploi.Location = new System.Drawing.Point(0, 129);
            this.btnEmploi.Name = "btnEmploi";
            this.btnEmploi.Size = new System.Drawing.Size(200, 65);
            this.btnEmploi.TabIndex = 2;
            this.btnEmploi.Text = "Emploi";
            this.btnEmploi.UseVisualStyleBackColor = true;
            this.btnEmploi.Click += new System.EventHandler(this.btnEmploi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Categories";
            // 
            // btnDev
            // 
            this.btnDev.Location = new System.Drawing.Point(0, 68);
            this.btnDev.Name = "btnDev";
            this.btnDev.Size = new System.Drawing.Size(200, 64);
            this.btnDev.TabIndex = 0;
            this.btnDev.Text = "Dev";
            this.btnDev.UseVisualStyleBackColor = true;
            this.btnDev.Click += new System.EventHandler(this.btnDev_Click);
            this.btnDev.MouseHover += new System.EventHandler(this.btnDev_MouseHover);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl2);
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dgvAnswers);
            this.panel2.Controls.Add(this.dgvSubjects);
            this.panel2.Location = new System.Drawing.Point(200, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(858, 661);
            this.panel2.TabIndex = 8;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(27, 502);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(636, 156);
            this.tabControl2.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnAddAnswer);
            this.tabPage4.Controls.Add(this.txtAddAnswerBody);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(628, 128);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Ajouter";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnAddAnswer
            // 
            this.btnAddAnswer.Location = new System.Drawing.Point(280, 75);
            this.btnAddAnswer.Name = "btnAddAnswer";
            this.btnAddAnswer.Size = new System.Drawing.Size(122, 29);
            this.btnAddAnswer.TabIndex = 2;
            this.btnAddAnswer.Text = "Ajouter une réponse";
            this.btnAddAnswer.UseVisualStyleBackColor = true;
            this.btnAddAnswer.Click += new System.EventHandler(this.btnAddAnswer_Click);
            // 
            // txtAddAnswerBody
            // 
            this.txtAddAnswerBody.Location = new System.Drawing.Point(15, 6);
            this.txtAddAnswerBody.Multiline = true;
            this.txtAddAnswerBody.Name = "txtAddAnswerBody";
            this.txtAddAnswerBody.Size = new System.Drawing.Size(224, 111);
            this.txtAddAnswerBody.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnModifyAnswer);
            this.tabPage5.Controls.Add(this.txtModifyAnswerBody);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(628, 128);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Modifier";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnModifyAnswer
            // 
            this.btnModifyAnswer.Location = new System.Drawing.Point(280, 67);
            this.btnModifyAnswer.Name = "btnModifyAnswer";
            this.btnModifyAnswer.Size = new System.Drawing.Size(122, 29);
            this.btnModifyAnswer.TabIndex = 2;
            this.btnModifyAnswer.Text = "Modifier la réponse";
            this.btnModifyAnswer.UseVisualStyleBackColor = true;
            this.btnModifyAnswer.Click += new System.EventHandler(this.btnModifyAnswer_Click);
            // 
            // txtModifyAnswerBody
            // 
            this.txtModifyAnswerBody.Location = new System.Drawing.Point(10, 6);
            this.txtModifyAnswerBody.Multiline = true;
            this.txtModifyAnswerBody.Name = "txtModifyAnswerBody";
            this.txtModifyAnswerBody.Size = new System.Drawing.Size(209, 105);
            this.txtModifyAnswerBody.TabIndex = 1;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.btnDeleteAnswer);
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(628, 128);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Supprimer";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAnswer
            // 
            this.btnDeleteAnswer.Location = new System.Drawing.Point(268, 57);
            this.btnDeleteAnswer.Name = "btnDeleteAnswer";
            this.btnDeleteAnswer.Size = new System.Drawing.Size(147, 32);
            this.btnDeleteAnswer.TabIndex = 0;
            this.btnDeleteAnswer.Text = "Supprimer une réponse";
            this.btnDeleteAnswer.UseVisualStyleBackColor = true;
            this.btnDeleteAnswer.Click += new System.EventHandler(this.btnDeleteAnswer_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(27, 183);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 122);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAddSubject);
            this.tabPage1.Controls.Add(this.txtDescription);
            this.tabPage1.Controls.Add(this.txtSubjectName);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(632, 94);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ajouter";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Location = new System.Drawing.Point(280, 43);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(122, 29);
            this.btnAddSubject.TabIndex = 2;
            this.btnAddSubject.Text = "Ajouter un sujet";
            this.btnAddSubject.UseVisualStyleBackColor = true;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(15, 36);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(222, 52);
            this.txtDescription.TabIndex = 1;
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(15, 7);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(104, 23);
            this.txtSubjectName.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ModifySubject);
            this.tabPage2.Controls.Add(this.txtModifySubjectDescription);
            this.tabPage2.Controls.Add(this.TxtModifySubjectName);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(632, 94);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Modifier";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ModifySubject
            // 
            this.ModifySubject.Location = new System.Drawing.Point(280, 46);
            this.ModifySubject.Name = "ModifySubject";
            this.ModifySubject.Size = new System.Drawing.Size(122, 30);
            this.ModifySubject.TabIndex = 2;
            this.ModifySubject.Text = "Modifier un sujet";
            this.ModifySubject.UseVisualStyleBackColor = true;
            this.ModifySubject.Click += new System.EventHandler(this.ModifyButton_Click);
            // 
            // txtModifySubjectDescription
            // 
            this.txtModifySubjectDescription.Location = new System.Drawing.Point(15, 36);
            this.txtModifySubjectDescription.Multiline = true;
            this.txtModifySubjectDescription.Name = "txtModifySubjectDescription";
            this.txtModifySubjectDescription.Size = new System.Drawing.Size(225, 52);
            this.txtModifySubjectDescription.TabIndex = 1;
            // 
            // TxtModifySubjectName
            // 
            this.TxtModifySubjectName.Location = new System.Drawing.Point(15, 7);
            this.TxtModifySubjectName.Name = "TxtModifySubjectName";
            this.TxtModifySubjectName.Size = new System.Drawing.Size(102, 23);
            this.TxtModifySubjectName.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnDeleteSubject);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(632, 94);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Supprimer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSubject
            // 
            this.btnDeleteSubject.Location = new System.Drawing.Point(280, 39);
            this.btnDeleteSubject.Name = "btnDeleteSubject";
            this.btnDeleteSubject.Size = new System.Drawing.Size(122, 33);
            this.btnDeleteSubject.TabIndex = 0;
            this.btnDeleteSubject.Text = "Supprimer le sujet";
            this.btnDeleteSubject.UseVisualStyleBackColor = true;
            this.btnDeleteSubject.Click += new System.EventHandler(this.btnDeleteSubject_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Réponses au sujet sélectionné";
            // 
            // dgvAnswers
            // 
            this.dgvAnswers.AllowUserToAddRows = false;
            this.dgvAnswers.AllowUserToDeleteRows = false;
            this.dgvAnswers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnswers.Location = new System.Drawing.Point(10, 326);
            this.dgvAnswers.Name = "dgvAnswers";
            this.dgvAnswers.ReadOnly = true;
            this.dgvAnswers.RowTemplate.Height = 25;
            this.dgvAnswers.Size = new System.Drawing.Size(657, 170);
            this.dgvAnswers.TabIndex = 1;
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.AllowUserToAddRows = false;
            this.dgvSubjects.AllowUserToDeleteRows = false;
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.Location = new System.Drawing.Point(9, 3);
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.ReadOnly = true;
            this.dgvSubjects.RowTemplate.Height = 25;
            this.dgvSubjects.Size = new System.Drawing.Size(658, 174);
            this.dgvSubjects.TabIndex = 0;
            this.dgvSubjects.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubjects_CellClick);
            this.dgvSubjects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubjects_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sujets";
            // 
            // DevelopmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 732);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TxtToken);
            this.Controls.Add(this.label1);
            this.Name = "DevelopmentForm";
            this.Text = "DevelopmentForm";
            this.Load += new System.EventHandler(this.DevelopmentForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnswers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnswers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtToken;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDev;
        private System.Windows.Forms.Button btnEmploi;
        private System.Windows.Forms.Button btnDivers;
        private System.Windows.Forms.Button btnFun;
        private System.Windows.Forms.Button btnFormation;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvAnswers;
        private System.Windows.Forms.DataGridView dgvSubjects;
        private System.Windows.Forms.BindingSource bsSubjects;
        private System.Windows.Forms.BindingSource bsAnswers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnDeleteSubject;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.TextBox txtModifySubjectDescription;
        private System.Windows.Forms.TextBox TxtModifySubjectName;
        private System.Windows.Forms.Button ModifySubject;
        private System.Windows.Forms.Button btnAddAnswer;
        private System.Windows.Forms.TextBox txtAddAnswerBody;
        private System.Windows.Forms.Button btnModifyAnswer;
        private System.Windows.Forms.TextBox txtModifyAnswerBody;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDeleteAnswer;
    }
}