
namespace ClientWinforms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.bsUsers = new System.Windows.Forms.BindingSource(this.components);
            this.TxtToken = new System.Windows.Forms.TextBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.bsCategories = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(104, 51);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(37, 15);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Login";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(101, 87);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(57, 15);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(180, 48);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(124, 23);
            this.txtLogin.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(180, 78);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(124, 23);
            this.txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(340, 51);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(71, 50);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // bsUsers
            // 
            this.bsUsers.CurrentChanged += new System.EventHandler(this.bsUsers_CurrentChanged);
            // 
            // TxtToken
            // 
            this.TxtToken.Location = new System.Drawing.Point(451, 30);
            this.TxtToken.Multiline = true;
            this.TxtToken.Name = "TxtToken";
            this.TxtToken.ReadOnly = true;
            this.TxtToken.Size = new System.Drawing.Size(163, 87);
            this.TxtToken.TabIndex = 5;
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(78, 132);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowTemplate.Height = 25;
            this.dgvUsers.Size = new System.Drawing.Size(599, 102);
            this.dgvUsers.TabIndex = 6;
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new System.Drawing.Point(78, 302);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowTemplate.Height = 25;
            this.dgvCategories.Size = new System.Drawing.Size(589, 63);
            this.dgvCategories.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 518);
            this.Controls.Add(this.dgvCategories);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.TxtToken);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Name = "Form1";
            this.Text = "bsCategories";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.BindingSource bsUsers;
        private System.Windows.Forms.TextBox TxtToken;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.BindingSource bsCategories;
    }
}

