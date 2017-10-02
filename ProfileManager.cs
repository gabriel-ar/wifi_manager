using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WlanApi;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace WifiManager {
    public partial class ProfileManager:Form {

        static string[] connection_type = new string[] { "IBSS", "ESS" };
        static string[] connection_mode = new string[] { "manual", "auto" };
        static string[] authentication = new string[] { "open", "shared", "WPA", "WPAPSK", "WPA2", "WPA2PSK" };
        static string[] encryption = new string[] { "none", "WEP", "TKIP", "AES" };
        static string[] key_type = new string[] { "networkKey", "passPhrase" };

        public bool is_new = false;
        public string str_profile_name;

        WlanClient.WlanInterface adapter;

        Wlan.WlanProfileInfo[] profile_info;
        string[] profiles;
        XmlDocument profile;

        public ProfileManager(WlanClient.WlanInterface adapter) {
            InitializeComponent();

            cb_type.DataSource = connection_type;
            cb_mode.DataSource = connection_mode;
            cb_auth.DataSource = authentication;
            cb_encryption.DataSource = encryption;
            cb_key_type.DataSource = key_type;

            this.adapter = adapter;
            profile = new XmlDocument();


            //actuliza profile_info & profiles
            UpdateProfiles();

            cb_select_profile.SelectedIndexChanged += IndexSelected;
            btn_save.Click += Save;
            btn_delete.Click += Delete;
            cb_auth.SelectedIndexChanged += AuthChanged;
            }

        public void RestoreForm() {
            ControlBox = true;
            btn_delete.Text = "Eliminar";
            cb_select_profile.Enabled = true;
            tb_ssid.Enabled = true;
            cb_type.Enabled = true;
            cb_auth.Enabled = true;
            cb_encryption.Enabled = true;
            cb_key_type.Enabled = true;
            tb_key.Enabled = true;
            cb_protected.Enabled = true;
            }

        public void OpenManager() {
            UpdateProfiles();
            UpdateData();
            ShowDialog();
            }

        public void OpenManager(Wlan.WlanAvailableNetwork network) {
            UpdateProfiles();
            if(network.profileName.Length == 0) {
                is_new = true;
                ControlBox = false;
                btn_delete.Text = "Cancelar";
                cb_select_profile.Enabled = false;

                string ssid = Encoding.Default.GetString(network.dot11Ssid.SSID);
                tb_prof_name.Text = ssid;
                tb_ssid.Text = ssid;
                tb_ssid.Enabled = false;

                switch(network.dot11BssType) {
                    case Wlan.Dot11BssType.Independent:
                        cb_type.SelectedIndex = 0; break;

                    case Wlan.Dot11BssType.Infrastructure:
                        cb_type.SelectedIndex = 1; break;
                    }
                cb_type.Enabled = false;

                switch(network.dot11DefaultAuthAlgorithm) {
                    case Wlan.Dot11AuthAlgorithm.IEEE80211_Open:
                        cb_auth.SelectedIndex = 0; break;
                    case Wlan.Dot11AuthAlgorithm.IEEE80211_SharedKey:
                        cb_auth.SelectedIndex = 1; break;

                    case Wlan.Dot11AuthAlgorithm.WPA:
                        cb_auth.SelectedIndex = 2; break;

                    case Wlan.Dot11AuthAlgorithm.WPA_PSK:
                        cb_auth.SelectedIndex = 3; break;

                    case Wlan.Dot11AuthAlgorithm.RSNA:
                        cb_auth.SelectedIndex = 4; break;

                    case Wlan.Dot11AuthAlgorithm.RSNA_PSK:
                        cb_auth.SelectedIndex = 5; break;
                    }
                cb_auth.Enabled = false;

                if(network.securityEnabled)
                    cb_encryption.SelectedIndex = 3;
                cb_encryption.Enabled = false;

                if(cb_auth.SelectedIndex == 0) {
                    cb_key_type.Enabled = false;
                    tb_key.Enabled = false;
                    cb_protected.Enabled = false;
                    }
                tb_key.Text = "";
                } else {
                for(int c = 0; c < profiles.Length; c++) {
                    if(profiles[c] == network.profileName) {
                        cb_select_profile.SelectedIndex = c;
                        UpdateData();
                        break;
                        }
                    }
                }

            ShowDialog();
            }

        private void AuthChanged(object sender, EventArgs e) {
            bool res = cb_auth.SelectedIndex > 0;
            cb_key_type.Enabled = res;
            tb_key.Enabled = res;
            cb_protected.Enabled = res;
            }

        private void IndexSelected(object sender, EventArgs e) {
            UpdateData();
            }

        void UpdateProfiles() {
            profile_info = adapter.GetProfiles();
            profiles = new string[profile_info.Length];

            for(int c = 0; c < profile_info.Length; c++) {
                profiles[c] = profile_info[c].profileName;
                }

            cb_select_profile.DataSource = profiles;
            }

        void UpdateData() {
            if(profiles.Length > 0) {
                if(cb_select_profile.SelectedIndex > profiles.Length - 1) {
                    cb_select_profile.SelectedIndex = 0;
                    } else {
                    profile.LoadXml(adapter.GetProfileXml(profiles[cb_select_profile.SelectedIndex]));
                    tb_preview.Text = profile.InnerXml;
                    PharseProfile();
                    }
                } else {
                Close();
                }
            }

        void PharseProfile() {
            tb_prof_name.Text = profile["WLANProfile"]["name"].InnerText;
            tb_ssid.Text = profile["WLANProfile"]["SSIDConfig"]["SSID"]["name"].InnerText;

            for(int c = 0; c < connection_type.Length; c++) {
                if(profile["WLANProfile"]["connectionType"] != null
                    && connection_type[c] == profile["WLANProfile"]["connectionType"].InnerText)
                    cb_type.SelectedIndex = c;
                }

            for(int c = 0; c < connection_mode.Length; c++) {
                if(profile["WLANProfile"]["connectionMode"] != null
                    && connection_mode[c] == profile["WLANProfile"]["connectionMode"].InnerText)
                    cb_mode.SelectedIndex = c;
                }

            for(int c = 0; c < authentication.Length; c++) {
                if(profile["WLANProfile"]["MSM"]["security"]["authEncryption"]["authentication"] != null
                    && authentication[c] == profile["WLANProfile"]["MSM"]["security"]["authEncryption"]["authentication"].InnerText) {
                    cb_auth.SelectedIndex = c;

                    bool enable = c != 0;
                    cb_key_type.Enabled = enable;
                    tb_key.Enabled = enable;
                    cb_protected.Enabled = enable;

                    if(enable) {
                        for(int cc = 0; cc < key_type.Length; cc++) {
                            if(profile["WLANProfile"]["MSM"]["security"]["sharedKey"]["keyType"] != null
                                && key_type[cc] == profile["WLANProfile"]["MSM"]["security"]["sharedKey"]["keyType"].InnerText)
                                cb_key_type.SelectedIndex = cc;
                            }

                        cb_protected.Checked = bool.Parse(profile["WLANProfile"]["MSM"]["security"]["sharedKey"]["protected"].InnerText);
                        tb_key.Text = profile["WLANProfile"]["MSM"]["security"]["sharedKey"]["keyMaterial"].InnerText;
                        } else {
                        tb_key.Text = "";
                        }
                    }
                }

            for(int c = 0; c < encryption.Length; c++) {
                if(profile["WLANProfile"]["MSM"]["security"]["authEncryption"]["encryption"] != null
                    && encryption[c] == profile["WLANProfile"]["MSM"]["security"]["authEncryption"]["encryption"].InnerText)
                    cb_encryption.SelectedIndex = c;
                }
            }

        private void Save(object sender, EventArgs e) {

            if(tb_prof_name.Text.Length == 0) {
                MessageBox.Show("El nombre de Perfil no debe estar vacio.");
                return;
                }

            if(tb_ssid.Text.Length == 0) {
                MessageBox.Show("El SSID no debe estar vacio.");
                return;
                }

            if(cb_auth.SelectedIndex > 0 && tb_key.Enabled && tb_key.TextLength < 8) {
                MessageBox.Show("Este metodo de autenticacion requiere de una contraseña de 8 o mas caracteres.");
                return;
                }

            string xmlsn = "http://www.microsoft.com/networking/WLAN/profile/v1";
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", null, null));
            doc.AppendChild(doc.CreateElement("WLANProfile", xmlsn));

            doc["WLANProfile"].AppendChild(doc.CreateElement("name", xmlsn));
            doc["WLANProfile"]["name"].InnerText = tb_prof_name.Text;
            doc["WLANProfile"].AppendChild(doc.CreateElement("SSIDConfig", xmlsn));
            doc["WLANProfile"]["SSIDConfig"].AppendChild(doc.CreateElement("SSID", xmlsn));
            doc["WLANProfile"]["SSIDConfig"]["SSID"].AppendChild(doc.CreateElement("hex", xmlsn));
            doc["WLANProfile"]["SSIDConfig"]["SSID"]["hex"].InnerXml
                = BitConverter.ToString(Encoding.Default.GetBytes(tb_ssid.Text)).Replace("-", "");
            doc["WLANProfile"]["SSIDConfig"]["SSID"].AppendChild(doc.CreateElement("name", xmlsn));
            doc["WLANProfile"]["SSIDConfig"]["SSID"]["name"].InnerText = tb_ssid.Text;
            doc["WLANProfile"].AppendChild(doc.CreateElement("connectionType", xmlsn));
            doc["WLANProfile"]["connectionType"].InnerText = connection_type[cb_type.SelectedIndex];
            doc["WLANProfile"].AppendChild(doc.CreateElement("connectionMode", xmlsn));
            doc["WLANProfile"]["connectionMode"].InnerText = connection_mode[cb_mode.SelectedIndex];
            doc["WLANProfile"].AppendChild(doc.CreateElement("MSM", xmlsn));
            doc["WLANProfile"]["MSM"].AppendChild(doc.CreateElement("security", xmlsn));
            doc["WLANProfile"]["MSM"]["security"].AppendChild(doc.CreateElement("authEncryption", xmlsn));
            doc["WLANProfile"]["MSM"]["security"]["authEncryption"].AppendChild(doc.CreateElement("authentication", xmlsn));
            doc["WLANProfile"]["MSM"]["security"]["authEncryption"]["authentication"].InnerText = authentication[cb_auth.SelectedIndex];
            doc["WLANProfile"]["MSM"]["security"]["authEncryption"].AppendChild(doc.CreateElement("encryption", xmlsn));
            doc["WLANProfile"]["MSM"]["security"]["authEncryption"]["encryption"].InnerText = encryption[cb_encryption.SelectedIndex];
            doc["WLANProfile"]["MSM"]["security"]["authEncryption"].AppendChild(doc.CreateElement("useOneX", xmlsn));
            doc["WLANProfile"]["MSM"]["security"]["authEncryption"]["useOneX"].InnerText = "false";

            if(cb_auth.SelectedIndex > 0) {
                doc["WLANProfile"]["MSM"]["security"].AppendChild(doc.CreateElement("sharedKey", xmlsn));
                doc["WLANProfile"]["MSM"]["security"]["sharedKey"].AppendChild(doc.CreateElement("keyType", xmlsn));
                doc["WLANProfile"]["MSM"]["security"]["sharedKey"]["keyType"].InnerText = key_type[cb_key_type.SelectedIndex];

                doc["WLANProfile"]["MSM"]["security"]["sharedKey"].AppendChild(doc.CreateElement("protected", xmlsn));
                doc["WLANProfile"]["MSM"]["security"]["sharedKey"]["protected"].InnerText = cb_protected.Checked.ToString().ToLower();

                doc["WLANProfile"]["MSM"]["security"]["sharedKey"].AppendChild(doc.CreateElement("keyMaterial", xmlsn));
                doc["WLANProfile"]["MSM"]["security"]["sharedKey"]["keyMaterial"].InnerText = tb_key.Text;
                }

            if(!is_new) {
                str_profile_name = profile["WLANProfile"]["name"].InnerText;
                try {
                    adapter.DeleteProfile(str_profile_name);
                    } catch(Exception ex) {
                    MessageBox.Show("En delete profile: " + ex.Message);
                    }
                } else {
                str_profile_name = tb_prof_name.Text;
                }

            try {
                adapter.SetProfile(Wlan.WlanProfileFlags.AllUser, doc.OuterXml, false);
                } catch(Exception ex) {
                MessageBox.Show("En set profile: " + ex.Message);
                tb_preview.Text = doc.OuterXml;
                return;
                }

            UpdateProfiles();
            UpdateData();

            if(is_new)
                Close();
            }

        private void Delete(object sender, EventArgs e) {
            if(is_new) {
                Close();
                } else {
                //try {
                adapter.DeleteProfile(profiles[cb_select_profile.SelectedIndex]);
                UpdateProfiles();
                UpdateData();
                //} catch(Exception ex) {
                //MessageBox.Show("Fallo al emliminar: " + ex.Message);
                // }

                }
            }

        }
    }
