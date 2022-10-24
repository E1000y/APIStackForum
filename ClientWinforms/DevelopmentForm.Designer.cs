
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
            this.dgvAnswers = new System.Windows.Forms.DataGridView();
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.bsSubjects = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnswers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSubjects)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(200, 557);
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
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvAnswers);
            this.panel2.Controls.Add(this.dgvSubjects);
            this.panel2.Location = new System.Drawing.Point(200, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(680, 429);
            this.panel2.TabIndex = 8;
            // 
            // dgvAnswers
            // 
            this.dgvAnswers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnswers.Location = new System.Drawing.Point(9, 206);
            this.dgvAnswers.Name = "dgvAnswers";
            this.dgvAnswers.RowTemplate.Height = 25;
            this.dgvAnswers.Size = new System.Drawing.Size(657, 170);
            this.dgvAnswers.TabIndex = 1;
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.AllowUserToAddRows = false;
            this.dgvSubjects.AllowUserToDeleteRows = false;
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.Location = new System.Drawing.Point(9, 14);
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.ReadOnly = true;
            this.dgvSubjects.RowTemplate.Height = 25;
            this.dgvSubjects.Size = new System.Drawing.Size(658, 155);
            this.dgvSubjects.TabIndex = 0;
            // 
            // DevelopmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 557);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnswers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSubjects)).EndInit();
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
    }
}