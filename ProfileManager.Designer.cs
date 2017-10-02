namespace WifiManager {
    partial class ProfileManager {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && ( components != null )) {
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_select_profile = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ssid = new System.Windows.Forms.TextBox();
            this.tb_prof_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_mode = new System.Windows.Forms.ComboBox();
            this.cb_auth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_encryption = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_key_type = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_key = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_preview = new System.Windows.Forms.RichTextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.cb_protected = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Perfil";
            // 
            // cb_select_profile
            // 
            this.cb_select_profile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_select_profile.FormattingEnabled = true;
            this.cb_select_profile.Location = new System.Drawing.Point(48, 9);
            this.cb_select_profile.Name = "cb_select_profile";
            this.cb_select_profile.Size = new System.Drawing.Size(121, 21);
            this.cb_select_profile.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SSID";
            // 
            // tb_ssid
            // 
            this.tb_ssid.Location = new System.Drawing.Point(100, 92);
            this.tb_ssid.MaxLength = 32;
            this.tb_ssid.Name = "tb_ssid";
            this.tb_ssid.Size = new System.Drawing.Size(100, 20);
            this.tb_ssid.TabIndex = 3;
            // 
            // tb_prof_name
            // 
            this.tb_prof_name.Location = new System.Drawing.Point(100, 66);
            this.tb_prof_name.Name = "tb_prof_name";
            this.tb_prof_name.Size = new System.Drawing.Size(100, 20);
            this.tb_prof_name.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre de Perfil";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Modo";
            // 
            // cb_mode
            // 
            this.cb_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mode.FormattingEnabled = true;
            this.cb_mode.Location = new System.Drawing.Point(100, 145);
            this.cb_mode.Name = "cb_mode";
            this.cb_mode.Size = new System.Drawing.Size(100, 21);
            this.cb_mode.TabIndex = 8;
            // 
            // cb_auth
            // 
            this.cb_auth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_auth.FormattingEnabled = true;
            this.cb_auth.Location = new System.Drawing.Point(100, 199);
            this.cb_auth.Name = "cb_auth";
            this.cb_auth.Size = new System.Drawing.Size(100, 21);
            this.cb_auth.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Autenticación";
            // 
            // cb_encryption
            // 
            this.cb_encryption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_encryption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_encryption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_encryption.Location = new System.Drawing.Point(100, 226);
            this.cb_encryption.Name = "cb_encryption";
            this.cb_encryption.Size = new System.Drawing.Size(100, 21);
            this.cb_encryption.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Encripción";
            // 
            // cb_key_type
            // 
            this.cb_key_type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb_key_type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_key_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_key_type.Location = new System.Drawing.Point(100, 253);
            this.cb_key_type.Name = "cb_key_type";
            this.cb_key_type.Size = new System.Drawing.Size(100, 21);
            this.cb_key_type.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Tipo de Clave";
            // 
            // tb_key
            // 
            this.tb_key.Location = new System.Drawing.Point(100, 280);
            this.tb_key.Name = "tb_key";
            this.tb_key.Size = new System.Drawing.Size(100, 20);
            this.tb_key.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Clave";
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(100, 118);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(100, 21);
            this.cb_type.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Tipo";
            // 
            // tb_preview
            // 
            this.tb_preview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_preview.Location = new System.Drawing.Point(209, 66);
            this.tb_preview.Name = "tb_preview";
            this.tb_preview.Size = new System.Drawing.Size(313, 363);
            this.tb_preview.TabIndex = 21;
            this.tb_preview.Text = "";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(128, 406);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 22;
            this.btn_save.Text = "Guardar";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(48, 406);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 23;
            this.btn_delete.Text = "Eliminar";
            this.btn_delete.UseVisualStyleBackColor = true;
            // 
            // cb_protected
            // 
            this.cb_protected.AutoSize = true;
            this.cb_protected.Location = new System.Drawing.Point(100, 307);
            this.cb_protected.Name = "cb_protected";
            this.cb_protected.Size = new System.Drawing.Size(71, 17);
            this.cb_protected.TabIndex = 24;
            this.cb_protected.Text = "Protegida";
            this.cb_protected.UseVisualStyleBackColor = true;
            // 
            // ProfileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 441);
            this.Controls.Add(this.cb_protected);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tb_preview);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.tb_key);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cb_key_type);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_encryption);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_auth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_mode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_prof_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_ssid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_select_profile);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(720, 480);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(550, 480);
            this.Name = "ProfileManager";
            this.Text = "Administrador de Perfiles";
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_select_profile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_ssid;
        private System.Windows.Forms.TextBox tb_prof_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_mode;
        private System.Windows.Forms.ComboBox cb_auth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_encryption;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_key_type;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_key;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox tb_preview;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.CheckBox cb_protected;
        }
    }