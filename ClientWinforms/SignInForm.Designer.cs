
namespace ClientWinforms
{
    partial class SignInForm
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
            this.txtUserNameSignIn = new System.Windows.Forms.TextBox();
            this.TxtPasswordSignIn = new System.Windows.Forms.TextBox();
            this.btnLogInDuSignIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUserNameSignIn
            // 
            this.txtUserNameSignIn.Location = new System.Drawing.Point(113, 35);
            this.txtUserNameSignIn.Name = "txtUserNameSignIn";
            this.txtUserNameSignIn.Size = new System.Drawing.Size(146, 23);
            this.txtUserNameSignIn.TabIndex = 0;
            // 
            // TxtPasswordSignIn
            // 
            this.TxtPasswordSignIn.Location = new System.Drawing.Point(113, 76);
            this.TxtPasswordSignIn.Name = "TxtPasswordSignIn";
            this.TxtPasswordSignIn.Size = new System.Drawing.Size(146, 23);
            this.TxtPasswordSignIn.TabIndex = 1;
            // 
            // btnLogInDuSignIn
            // 
            this.btnLogInDuSignIn.Location = new System.Drawing.Point(319, 35);
            this.btnLogInDuSignIn.Name = "btnLogInDuSignIn";
            this.btnLogInDuSignIn.Size = new System.Drawing.Size(97, 60);
            this.btnLogInDuSignIn.TabIndex = 2;
            this.btnLogInDuSignIn.Text = "Log In";
            this.btnLogInDuSignIn.UseVisualStyleBackColor = true;
            this.btnLogInDuSignIn.Click += new System.EventHandler(this.btnLogInDuSignIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nom d\'utilisateur";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mot de passe";
            // 
            // SignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 177);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogInDuSignIn);
            this.Controls.Add(this.TxtPasswordSignIn);
            this.Controls.Add(this.txtUserNameSignIn);
            this.Name = "SignInForm";
            this.Text = "SignInForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserNameSignIn;
        private System.Windows.Forms.TextBox TxtPasswordSignIn;
        private System.Windows.Forms.Button btnLogInDuSignIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}