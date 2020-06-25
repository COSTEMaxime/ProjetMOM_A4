namespace Client {
    partial class MainView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.authenticationGroupBox = new System.Windows.Forms.GroupBox();
            this.logoutButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.decryptionGroupBox = new System.Windows.Forms.GroupBox();
            this.decryptionButton = new System.Windows.Forms.Button();
            this.systemFilesTreeView = new System.Windows.Forms.TreeView();
            this.consoleGroupBox = new System.Windows.Forms.GroupBox();
            this.consoleTextBox = new System.Windows.Forms.RichTextBox();
            this.authenticationGroupBox.SuspendLayout();
            this.decryptionGroupBox.SuspendLayout();
            this.consoleGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // authenticationGroupBox
            // 
            this.authenticationGroupBox.AutoSize = true;
            this.authenticationGroupBox.Controls.Add(this.logoutButton);
            this.authenticationGroupBox.Controls.Add(this.registerButton);
            this.authenticationGroupBox.Controls.Add(this.loginButton);
            this.authenticationGroupBox.Controls.Add(this.passwordTextBox);
            this.authenticationGroupBox.Controls.Add(this.passwordLabel);
            this.authenticationGroupBox.Controls.Add(this.usernameTextBox);
            this.authenticationGroupBox.Controls.Add(this.usernameLabel);
            this.authenticationGroupBox.Location = new System.Drawing.Point(13, 13);
            this.authenticationGroupBox.Name = "authenticationGroupBox";
            this.authenticationGroupBox.Size = new System.Drawing.Size(228, 144);
            this.authenticationGroupBox.TabIndex = 0;
            this.authenticationGroupBox.TabStop = false;
            this.authenticationGroupBox.Text = "Authentication";
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(154, 102);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(68, 23);
            this.logoutButton.TabIndex = 6;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(80, 102);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(68, 23);
            this.registerButton.TabIndex = 5;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(6, 102);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(68, 23);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.Location = new System.Drawing.Point(7, 76);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(215, 20);
            this.passwordTextBox.TabIndex = 3;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(7, 59);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameTextBox.Location = new System.Drawing.Point(6, 32);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(216, 20);
            this.usernameTextBox.TabIndex = 1;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(6, 16);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username";
            // 
            // decryptionGroupBox
            // 
            this.decryptionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.decryptionGroupBox.Controls.Add(this.decryptionButton);
            this.decryptionGroupBox.Controls.Add(this.systemFilesTreeView);
            this.decryptionGroupBox.Location = new System.Drawing.Point(13, 163);
            this.decryptionGroupBox.Name = "decryptionGroupBox";
            this.decryptionGroupBox.Size = new System.Drawing.Size(228, 288);
            this.decryptionGroupBox.TabIndex = 1;
            this.decryptionGroupBox.TabStop = false;
            this.decryptionGroupBox.Text = "Decryption";
            // 
            // decryptionButton
            // 
            this.decryptionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.decryptionButton.Location = new System.Drawing.Point(154, 259);
            this.decryptionButton.Name = "decryptionButton";
            this.decryptionButton.Size = new System.Drawing.Size(68, 23);
            this.decryptionButton.TabIndex = 1;
            this.decryptionButton.Text = "Decrypt";
            this.decryptionButton.UseVisualStyleBackColor = true;
            this.decryptionButton.Click += new System.EventHandler(this.decryptionButton_Click);
            // 
            // systemFilesTreeView
            // 
            this.systemFilesTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.systemFilesTreeView.Location = new System.Drawing.Point(6, 19);
            this.systemFilesTreeView.Name = "systemFilesTreeView";
            this.systemFilesTreeView.Size = new System.Drawing.Size(215, 233);
            this.systemFilesTreeView.TabIndex = 0;
            this.systemFilesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.systemFilesTreeView_AfterSelect);
            // 
            // consoleGroupBox
            // 
            this.consoleGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleGroupBox.AutoSize = true;
            this.consoleGroupBox.Controls.Add(this.consoleTextBox);
            this.consoleGroupBox.Location = new System.Drawing.Point(247, 12);
            this.consoleGroupBox.Name = "consoleGroupBox";
            this.consoleGroupBox.Size = new System.Drawing.Size(325, 438);
            this.consoleGroupBox.TabIndex = 2;
            this.consoleGroupBox.TabStop = false;
            this.consoleGroupBox.Text = "Console";
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.consoleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consoleTextBox.Location = new System.Drawing.Point(7, 20);
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.Size = new System.Drawing.Size(309, 406);
            this.consoleTextBox.TabIndex = 0;
            this.consoleTextBox.Text = "";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.consoleGroupBox);
            this.Controls.Add(this.decryptionGroupBox);
            this.Controls.Add(this.authenticationGroupBox);
            this.MinimumSize = new System.Drawing.Size(450, 350);
            this.Name = "MainView";
            this.Text = "Form1";
            this.authenticationGroupBox.ResumeLayout(false);
            this.authenticationGroupBox.PerformLayout();
            this.decryptionGroupBox.ResumeLayout(false);
            this.consoleGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox authenticationGroupBox;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.GroupBox decryptionGroupBox;
        private System.Windows.Forms.Button decryptionButton;
        private System.Windows.Forms.TreeView systemFilesTreeView;
        private System.Windows.Forms.GroupBox consoleGroupBox;
        private System.Windows.Forms.RichTextBox consoleTextBox;
    }
}

