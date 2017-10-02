namespace WifiManager
{
    partial class Main
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
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_admin_profiles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pg_log = new System.Windows.Forms.TabPage();
            this.log = new System.Windows.Forms.RichTextBox();
            this.pg_wifi = new System.Windows.Forms.TabPage();
            this.btn_edit_profile = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_scan = new System.Windows.Forms.Button();
            this.cb_active_wifi = new System.Windows.Forms.CheckBox();
            this.dg_wifi = new System.Windows.Forms.DataGridView();
            this.col_active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_ssid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_profile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rssi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bssid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_adapter = new System.Windows.Forms.ComboBox();
            this.tc = new System.Windows.Forms.TabControl();
            this.pg_ap = new System.Windows.Forms.TabPage();
            this.btn_add_privcon = new System.Windows.Forms.Button();
            this.cb_con_priv = new System.Windows.Forms.ComboBox();
            this.lb_con_priv = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_con_pub = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_key_count = new System.Windows.Forms.Label();
            this.lb_connected_peers = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tb_ap_ssid = new System.Windows.Forms.TextBox();
            this.tb_connected = new System.Windows.Forms.TextBox();
            this.cb_active_ap = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_ap_connected = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_ap_max_clients = new System.Windows.Forms.NumericUpDown();
            this.tb_ap_key = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pg_log.SuspendLayout();
            this.pg_wifi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_wifi)).BeginInit();
            this.tc.SuspendLayout();
            this.pg_ap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ap_max_clients)).BeginInit();
            this.SuspendLayout();
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_admin_profiles});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // mi_admin_profiles
            // 
            this.mi_admin_profiles.Name = "mi_admin_profiles";
            this.mi_admin_profiles.Size = new System.Drawing.Size(177, 22);
            this.mi_admin_profiles.Text = "Administrar Perfiles";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(520, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pg_log
            // 
            this.pg_log.Controls.Add(this.log);
            this.pg_log.Location = new System.Drawing.Point(4, 22);
            this.pg_log.Name = "pg_log";
            this.pg_log.Padding = new System.Windows.Forms.Padding(3);
            this.pg_log.Size = new System.Drawing.Size(512, 431);
            this.pg_log.TabIndex = 1;
            this.pg_log.Text = "Log";
            this.pg_log.UseVisualStyleBackColor = true;
            // 
            // log
            // 
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.Location = new System.Drawing.Point(3, 3);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(506, 425);
            this.log.TabIndex = 0;
            this.log.Text = "";
            // 
            // pg_wifi
            // 
            this.pg_wifi.Controls.Add(this.btn_edit_profile);
            this.pg_wifi.Controls.Add(this.btn_disconnect);
            this.pg_wifi.Controls.Add(this.btn_connect);
            this.pg_wifi.Controls.Add(this.btn_scan);
            this.pg_wifi.Controls.Add(this.cb_active_wifi);
            this.pg_wifi.Controls.Add(this.dg_wifi);
            this.pg_wifi.Location = new System.Drawing.Point(4, 22);
            this.pg_wifi.Name = "pg_wifi";
            this.pg_wifi.Padding = new System.Windows.Forms.Padding(3);
            this.pg_wifi.Size = new System.Drawing.Size(512, 431);
            this.pg_wifi.TabIndex = 0;
            this.pg_wifi.Text = "WIFI";
            this.pg_wifi.UseVisualStyleBackColor = true;
            // 
            // btn_edit_profile
            // 
            this.btn_edit_profile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_edit_profile.Location = new System.Drawing.Point(426, 399);
            this.btn_edit_profile.Name = "btn_edit_profile";
            this.btn_edit_profile.Size = new System.Drawing.Size(75, 23);
            this.btn_edit_profile.TabIndex = 5;
            this.btn_edit_profile.Text = "Editar Perfil";
            this.btn_edit_profile.UseVisualStyleBackColor = true;
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_disconnect.Location = new System.Drawing.Point(6, 399);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(80, 23);
            this.btn_disconnect.TabIndex = 4;
            this.btn_disconnect.Text = "Desconectar";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            // 
            // btn_connect
            // 
            this.btn_connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_connect.Location = new System.Drawing.Point(92, 399);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(80, 23);
            this.btn_connect.TabIndex = 3;
            this.btn_connect.Text = "Conectar";
            this.btn_connect.UseVisualStyleBackColor = true;
            // 
            // btn_scan
            // 
            this.btn_scan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_scan.Location = new System.Drawing.Point(428, 6);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(75, 23);
            this.btn_scan.TabIndex = 2;
            this.btn_scan.Text = "Actualizar";
            this.btn_scan.UseVisualStyleBackColor = true;
            // 
            // cb_active_wifi
            // 
            this.cb_active_wifi.AutoCheck = false;
            this.cb_active_wifi.AutoSize = true;
            this.cb_active_wifi.Checked = true;
            this.cb_active_wifi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_active_wifi.Location = new System.Drawing.Point(6, 10);
            this.cb_active_wifi.Name = "cb_active_wifi";
            this.cb_active_wifi.Size = new System.Drawing.Size(56, 17);
            this.cb_active_wifi.TabIndex = 0;
            this.cb_active_wifi.Text = "Activo";
            this.cb_active_wifi.UseVisualStyleBackColor = true;
            // 
            // dg_wifi
            // 
            this.dg_wifi.AllowUserToAddRows = false;
            this.dg_wifi.AllowUserToDeleteRows = false;
            this.dg_wifi.AllowUserToResizeColumns = false;
            this.dg_wifi.AllowUserToResizeRows = false;
            this.dg_wifi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_wifi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_wifi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_active,
            this.col_ssid,
            this.col_profile,
            this.col_rssi,
            this.col_bssid});
            this.dg_wifi.Location = new System.Drawing.Point(6, 33);
            this.dg_wifi.MultiSelect = false;
            this.dg_wifi.Name = "dg_wifi";
            this.dg_wifi.ReadOnly = true;
            this.dg_wifi.RowHeadersVisible = false;
            this.dg_wifi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_wifi.Size = new System.Drawing.Size(497, 360);
            this.dg_wifi.TabIndex = 1;
            // 
            // col_active
            // 
            this.col_active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_active.DataPropertyName = "Active";
            this.col_active.HeaderText = "";
            this.col_active.Name = "col_active";
            this.col_active.ReadOnly = true;
            this.col_active.Width = 5;
            // 
            // col_ssid
            // 
            this.col_ssid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_ssid.DataPropertyName = "SSID";
            this.col_ssid.HeaderText = "SSID";
            this.col_ssid.MinimumWidth = 100;
            this.col_ssid.Name = "col_ssid";
            this.col_ssid.ReadOnly = true;
            this.col_ssid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // col_profile
            // 
            this.col_profile.DataPropertyName = "ProfileName";
            this.col_profile.HeaderText = "Perfil";
            this.col_profile.Name = "col_profile";
            this.col_profile.ReadOnly = true;
            // 
            // col_rssi
            // 
            this.col_rssi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_rssi.DataPropertyName = "RSSI";
            this.col_rssi.HeaderText = "Señal";
            this.col_rssi.MinimumWidth = 40;
            this.col_rssi.Name = "col_rssi";
            this.col_rssi.ReadOnly = true;
            this.col_rssi.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_rssi.Width = 40;
            // 
            // col_bssid
            // 
            this.col_bssid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_bssid.DataPropertyName = "BSSID";
            this.col_bssid.HeaderText = "BSSID";
            this.col_bssid.Name = "col_bssid";
            this.col_bssid.ReadOnly = true;
            this.col_bssid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_bssid.Width = 64;
            // 
            // cb_adapter
            // 
            this.cb_adapter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_adapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_adapter.FormattingEnabled = true;
            this.cb_adapter.IntegralHeight = false;
            this.cb_adapter.ItemHeight = 13;
            this.cb_adapter.Location = new System.Drawing.Point(367, 1);
            this.cb_adapter.Name = "cb_adapter";
            this.cb_adapter.Size = new System.Drawing.Size(149, 21);
            this.cb_adapter.TabIndex = 2;
            // 
            // tc
            // 
            this.tc.Controls.Add(this.pg_wifi);
            this.tc.Controls.Add(this.pg_ap);
            this.tc.Controls.Add(this.pg_log);
            this.tc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc.Location = new System.Drawing.Point(0, 24);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(520, 457);
            this.tc.TabIndex = 0;
            // 
            // pg_ap
            // 
            this.pg_ap.Controls.Add(this.btn_add_privcon);
            this.pg_ap.Controls.Add(this.cb_con_priv);
            this.pg_ap.Controls.Add(this.lb_con_priv);
            this.pg_ap.Controls.Add(this.label8);
            this.pg_ap.Controls.Add(this.cb_con_pub);
            this.pg_ap.Controls.Add(this.label6);
            this.pg_ap.Controls.Add(this.label7);
            this.pg_ap.Controls.Add(this.lb_key_count);
            this.pg_ap.Controls.Add(this.lb_connected_peers);
            this.pg_ap.Controls.Add(this.textBox2);
            this.pg_ap.Controls.Add(this.tb_ap_ssid);
            this.pg_ap.Controls.Add(this.tb_connected);
            this.pg_ap.Controls.Add(this.cb_active_ap);
            this.pg_ap.Controls.Add(this.label4);
            this.pg_ap.Controls.Add(this.label1);
            this.pg_ap.Controls.Add(this.lb_ap_connected);
            this.pg_ap.Controls.Add(this.label2);
            this.pg_ap.Controls.Add(this.nud_ap_max_clients);
            this.pg_ap.Controls.Add(this.tb_ap_key);
            this.pg_ap.Controls.Add(this.label3);
            this.pg_ap.Location = new System.Drawing.Point(4, 22);
            this.pg_ap.Name = "pg_ap";
            this.pg_ap.Padding = new System.Windows.Forms.Padding(3);
            this.pg_ap.Size = new System.Drawing.Size(512, 431);
            this.pg_ap.TabIndex = 2;
            this.pg_ap.Text = "AP";
            this.pg_ap.UseVisualStyleBackColor = true;
            // 
            // btn_add_privcon
            // 
            this.btn_add_privcon.Location = new System.Drawing.Point(164, 370);
            this.btn_add_privcon.Name = "btn_add_privcon";
            this.btn_add_privcon.Size = new System.Drawing.Size(24, 21);
            this.btn_add_privcon.TabIndex = 25;
            this.btn_add_privcon.Text = "+";
            this.btn_add_privcon.UseVisualStyleBackColor = true;
            // 
            // cb_con_priv
            // 
            this.cb_con_priv.FormattingEnabled = true;
            this.cb_con_priv.Location = new System.Drawing.Point(11, 370);
            this.cb_con_priv.Name = "cb_con_priv";
            this.cb_con_priv.Size = new System.Drawing.Size(147, 21);
            this.cb_con_priv.TabIndex = 24;
            // 
            // lb_con_priv
            // 
            this.lb_con_priv.FormattingEnabled = true;
            this.lb_con_priv.Location = new System.Drawing.Point(11, 269);
            this.lb_con_priv.Name = "lb_con_priv";
            this.lb_con_priv.Size = new System.Drawing.Size(147, 95);
            this.lb_con_priv.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Conex. Privada";
            // 
            // cb_con_pub
            // 
            this.cb_con_pub.FormattingEnabled = true;
            this.cb_con_pub.Location = new System.Drawing.Point(11, 216);
            this.cb_con_pub.Name = "cb_con_pub";
            this.cb_con_pub.Size = new System.Drawing.Size(147, 21);
            this.cb_con_pub.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Conex. Pública";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "ICS";
            // 
            // lb_key_count
            // 
            this.lb_key_count.AutoSize = true;
            this.lb_key_count.ForeColor = System.Drawing.Color.Red;
            this.lb_key_count.Location = new System.Drawing.Point(161, 102);
            this.lb_key_count.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lb_key_count.Name = "lb_key_count";
            this.lb_key_count.Size = new System.Drawing.Size(0, 13);
            this.lb_key_count.TabIndex = 17;
            this.lb_key_count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_connected_peers
            // 
            this.lb_connected_peers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_connected_peers.FormattingEnabled = true;
            this.lb_connected_peers.Location = new System.Drawing.Point(202, 23);
            this.lb_connected_peers.Name = "lb_connected_peers";
            this.lb_connected_peers.Size = new System.Drawing.Size(302, 368);
            this.lb_connected_peers.TabIndex = 16;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(280, 403);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(109, 20);
            this.textBox2.TabIndex = 14;
            // 
            // tb_ap_ssid
            // 
            this.tb_ap_ssid.Location = new System.Drawing.Point(8, 59);
            this.tb_ap_ssid.Name = "tb_ap_ssid";
            this.tb_ap_ssid.Size = new System.Drawing.Size(150, 20);
            this.tb_ap_ssid.TabIndex = 5;
            // 
            // tb_connected
            // 
            this.tb_connected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_connected.Location = new System.Drawing.Point(468, 403);
            this.tb_connected.Name = "tb_connected";
            this.tb_connected.ReadOnly = true;
            this.tb_connected.Size = new System.Drawing.Size(36, 20);
            this.tb_connected.TabIndex = 13;
            // 
            // cb_active_ap
            // 
            this.cb_active_ap.AutoCheck = false;
            this.cb_active_ap.AutoSize = true;
            this.cb_active_ap.Location = new System.Drawing.Point(8, 23);
            this.cb_active_ap.Name = "cb_active_ap";
            this.cb_active_ap.Size = new System.Drawing.Size(56, 17);
            this.cb_active_ap.TabIndex = 3;
            this.cb_active_ap.Text = "Activo";
            this.cb_active_ap.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 406);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Direccion IP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "SSID";
            // 
            // lb_ap_connected
            // 
            this.lb_ap_connected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_ap_connected.AutoSize = true;
            this.lb_ap_connected.Location = new System.Drawing.Point(395, 406);
            this.lb_ap_connected.Name = "lb_ap_connected";
            this.lb_ap_connected.Size = new System.Drawing.Size(67, 13);
            this.lb_ap_connected.TabIndex = 11;
            this.lb_ap_connected.Text = "Conectados:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Contraseña";
            // 
            // nud_ap_max_clients
            // 
            this.nud_ap_max_clients.Location = new System.Drawing.Point(8, 138);
            this.nud_ap_max_clients.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_ap_max_clients.Name = "nud_ap_max_clients";
            this.nud_ap_max_clients.Size = new System.Drawing.Size(110, 20);
            this.nud_ap_max_clients.TabIndex = 10;
            this.nud_ap_max_clients.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tb_ap_key
            // 
            this.tb_ap_key.Location = new System.Drawing.Point(8, 99);
            this.tb_ap_key.Name = "tb_ap_key";
            this.tb_ap_key.Size = new System.Drawing.Size(150, 20);
            this.tb_ap_key.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cant. Max. de Clientes";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(319, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Interfaz";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(520, 481);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tc);
            this.Controls.Add(this.cb_adapter);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(530, 520);
            this.Name = "Main";
            this.Text = "Wifi Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pg_log.ResumeLayout(false);
            this.pg_wifi.ResumeLayout(false);
            this.pg_wifi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_wifi)).EndInit();
            this.tc.ResumeLayout(false);
            this.pg_ap.ResumeLayout(false);
            this.pg_ap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ap_max_clients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabPage pg_log;
        private System.Windows.Forms.TabPage pg_wifi;
        private System.Windows.Forms.ComboBox cb_adapter;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_scan;
        private System.Windows.Forms.DataGridView dg_wifi;
        private System.Windows.Forms.CheckBox cb_active_wifi;
        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.RichTextBox log;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_active;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ssid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_profile;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rssi;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bssid;
        private System.Windows.Forms.TabPage pg_ap;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox tb_ap_ssid;
        private System.Windows.Forms.TextBox tb_connected;
        private System.Windows.Forms.CheckBox cb_active_ap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_ap_connected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_ap_max_clients;
        private System.Windows.Forms.TextBox tb_ap_key;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_edit_profile;
        private System.Windows.Forms.ToolStripMenuItem mi_admin_profiles;
        private System.Windows.Forms.ListBox lb_connected_peers;
        private System.Windows.Forms.Label lb_key_count;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_con_pub;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_add_privcon;
        private System.Windows.Forms.ComboBox cb_con_priv;
        private System.Windows.Forms.ListBox lb_con_priv;
        }
}

