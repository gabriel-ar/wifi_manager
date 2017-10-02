using System;
using System.Text;
using System.Windows.Forms;
using WlanApi;
using NETCONLib;
using System.Runtime.InteropServices;
using Windows.Networking.Connectivity;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace WifiManager {
    public partial class Main:Form {

        string eol = "\n";

        NotifyIcon icon;
        ContextMenuStrip ic_menu;

        WlanEventCallback wlan_event_cb;
        HNEventCallback hn_event_cb;

        WlanClient wlan;
        WlanClient.WlanInterface[] adapters;
        WlanClient.WlanInterface adapter;

        Wlan.WlanAvailableNetwork[] av_nets;
        AP[] access_points;

        ProfileManager profile_manager;

        string[] hn_peers;

        Thread th_conn_check;
        System.Threading.Timer tm_conn_check;

        List<string> pub_con;
        List<string> priv_con;
        List<string> priv_con_cb;
        List<int> priv_con_cb_index;

        List<INetConnection> inet_connections;

        public Main() {
            InitializeComponent();

            tm_conn_check = new System.Threading.Timer(StartCheck, null, 0, 30000);

            ToolStripItem ic_menu_close = new ToolStripLabel("Cerrar");
            ic_menu = new ContextMenuStrip();
            ic_menu.Items.Add(ic_menu_close);

            icon = new NotifyIcon();
            icon.Icon = Icon;
            icon.Text = this.Text;
            icon.ContextMenuStrip = ic_menu;
            icon.Visible = true;

            inet_connections = new List<INetConnection>();

            wlan = new WlanClient();
            adapters = wlan.Interfaces;

            wlan.HostedNetworkNotification += HostedNetworkNotification;

            //WIFI
            UpdateAdapters();
            if(adapters.Length > 0) {
                //TODO Seleccionar el ultimo configurado por GUID
                adapter = adapters[0];
                adapter.WlanNotification += WlanEvent;

                if(adapter.Autoconf)
                    UpdateAPs();
                } else {
                SetEnabled(false);
                }

            profile_manager = new ProfileManager(adapter);

            //UI
            CheckProfiles();
            LoadApValues();

            UpdateICS();

            //Listeners
            FormClosing += Closing;
            icon.MouseClick += NotifyClick;
            ic_menu_close.Click += RealClose;

            cb_adapter.SelectedIndexChanged += AdapterSelected;
            btn_scan.Click += Scan;
            btn_connect.Click += Connect;
            btn_disconnect.Click += Disconnect;
            btn_edit_profile.Click += EditProfile;

            mi_admin_profiles.Click += OpenEditProfile;
            profile_manager.FormClosed += EPClosed;
            dg_wifi.CellMouseDoubleClick += EditProfile;

            cb_active_ap.Click += ActiveAp;
            tb_ap_key.TextChanged += ApKeyCahnged;

            btn_add_privcon.Click += AddPrivConn;

            wlan_event_cb = new WlanEventCallback(WlanEventSecure);
            hn_event_cb = new HNEventCallback(HNEventSecure);
            }//Main

        void UpdateAdapters() {
            adapters = wlan.Interfaces;
            string[] cb_content = new string[adapters.Length];
            for(int c = 0; c < adapters.Length; c++) {
                cb_content[c] = adapters[c].InterfaceName;
                }
            cb_adapter.DataSource = cb_content;
            }

        void UpdateAPs() {
            try {
                av_nets = adapter.GetAvailableNetworkList(Wlan.WlanGetAvailableNetworkFlags.IncludeAllAdhocProfiles);
                } catch(Exception) {
                SetEnabled(false);
                return;
                }

            access_points = new AP[av_nets.Length];
            for(int c = 0; c < av_nets.Length; c++) {
                access_points[c] = new AP(av_nets[c].flags.HasFlag(Wlan.WlanAvailableNetworkFlags.Connected),
                    Encoding.Default.GetString(av_nets[c].dot11Ssid.SSID).Remove((int) av_nets[c].dot11Ssid.SSIDLength),
                    av_nets[c].profileName,
                    av_nets[c].wlanSignalQuality.ToString(),
                    av_nets[c].numberOfBssids.ToString());
                }
            dg_wifi.DataSource = access_points;
            SetEnabled(true);
            return;
            }

        #region Wi-Fi

        private void AdapterSelected(object sender, EventArgs e) {
            adapter.WlanNotification -= WlanEvent;
            adapter = adapters[cb_adapter.SelectedIndex];
            adapter.WlanNotification += WlanEvent;
            }

        private void Scan(object sender, EventArgs e) {
            try {
                adapter.Scan();
                } catch(Exception) {
                SetEnabled(false);
                return;
                }

            btn_scan.Enabled = false;
            }

        private void EditProfile(object sender, DataGridViewCellMouseEventArgs e) {
            profile_manager.OpenManager(av_nets[dg_wifi.SelectedRows[0].Index]);
            }

        private void EditProfile(object sender, EventArgs e) {
            profile_manager.OpenManager(av_nets[dg_wifi.SelectedRows[0].Index]);
            }

        private void OpenEditProfile(object sender, EventArgs e) {
            profile_manager.OpenManager();
            }

        void CheckProfiles() {
            mi_admin_profiles.Enabled = adapter.GetProfiles().Length > 0;
            }

        private void EPClosed(object sender, FormClosedEventArgs e) {
            if(profile_manager.is_new) {
                profile_manager.RestoreForm();

                Wlan.WlanConnectionParameters con_params = new Wlan.WlanConnectionParameters();
                con_params.wlanConnectionMode = Wlan.WlanConnectionMode.Profile;
                con_params.profile = profile_manager.str_profile_name;
                con_params.dot11BssType = Wlan.Dot11BssType.Any;
                con_params.flags = 0;

                try {
                    Wlan.WlanConnect(wlan.ClientHandle, adapter.InterfaceGuid, ref con_params, IntPtr.Zero);
                    } catch(Exception ex) {
                    MessageBox.Show("Fallo al conectar: " + ex.Message);
                    }

                profile_manager.is_new = false;
                }
            CheckProfiles();
            }

        private void Connect(object sender, EventArgs e) {
            string profile_name;

            if(av_nets[dg_wifi.SelectedRows[0].Index].profileName.Length == 0) {
                profile_manager.OpenManager(av_nets[dg_wifi.SelectedRows[0].Index]);
                return;
                } else {
                profile_name = av_nets[dg_wifi.SelectedRows[0].Index].profileName;
                }

            Wlan.WlanConnectionParameters con_params = new Wlan.WlanConnectionParameters();
            con_params.wlanConnectionMode = Wlan.WlanConnectionMode.Profile;
            con_params.profile = profile_name;
            con_params.dot11BssType = Wlan.Dot11BssType.Any;
            con_params.flags = 0;

            try {
                Wlan.WlanConnect(wlan.ClientHandle, adapter.InterfaceGuid, ref con_params, IntPtr.Zero);
                } catch(Exception ex) {
                MessageBox.Show("Fallo al conectar: " + ex.Message);
                }
            }

        private void Disconnect(object sender, EventArgs e) {
            adapter.Disconnect();
            }

        private void WlanEvent(Wlan.WlanNotificationData data) {
            try {
                Invoke(wlan_event_cb, new object[] { data });
                } catch {

                }

            }

        delegate void WlanEventCallback(Wlan.WlanNotificationData data);
        void WlanEventSecure(Wlan.WlanNotificationData data) {
            switch(data.notificationSource) {
                case Wlan.WlanNotificationSource.ACM:
                    switch((Wlan.WlanNotificationCodeAcm) data.NotificationCode) {

                        case Wlan.WlanNotificationCodeAcm.ScanComplete:
                            if(!btn_scan.Enabled)
                                btn_scan.Enabled = true;
                            UpdateAPs();
                            break;

                        }

                    log.Text += "ACM: " + ( (Wlan.WlanNotificationCodeAcm) data.NotificationCode ).ToString() + eol;
                    break;

                case Wlan.WlanNotificationSource.MSM:
                    log.Text += "MSM: " + ( (Wlan.WlanNotificationCodeMsm) data.NotificationCode ).ToString() + eol;
                    break;

                case Wlan.WlanNotificationSource.HNWK:
                    log.Text += "HNWK: " + ( (Wlan.HostedNetworkNotificationCode) data.NotificationCode ).ToString() + eol;
                    break;

                default:
                    log.Text += data.notificationSource.ToString() + ": " + data.notificationCode.ToString() + eol;
                    break;
                }
            }

        void SetEnabled(bool enabled) {
            pg_wifi.Enabled = enabled;
            pg_ap.Enabled = enabled;
            cb_active_wifi.Checked = enabled;
            }

        public class AP {
            bool active;
            string ssid;
            string prof_name;
            string rssi;
            string bssid;


            public AP(bool active, string ssid, string prof_name, string rssi, string bssid) {
                this.active = active;
                this.ssid = ssid;
                this.prof_name = prof_name;
                this.rssi = rssi;
                this.bssid = bssid;
                }

            public bool Active { get { return active; } }
            public string SSID { get { return ssid.Trim(); } }
            public string ProfileName { get { return prof_name; } }
            public string RSSI { get { return rssi + "%"; } }
            public string BSSID { get { return bssid; } }
            }

        #endregion

        #region AP

        private void ApKeyCahnged(object sender, EventArgs e) {
            if(tb_ap_key.TextLength < 8) {
                lb_key_count.Show();
                lb_key_count.Text = tb_ap_key.TextLength + "/8";
                } else {
                lb_key_count.Hide();
                }
            }


        private void HostedNetworkNotification(Wlan.WlanNotificationData notif_data) {
            Invoke(hn_event_cb, new object[] { notif_data });
            }

        delegate void HNEventCallback(Wlan.WlanNotificationData notif_data);

        private void HNEventSecure(Wlan.WlanNotificationData notif_data) {
            log.Text += "HNWK: " + ( (Wlan.HostedNetworkNotificationCode) notif_data.notificationCode ).ToString() + eol;

            switch((Wlan.HostedNetworkNotificationCode) notif_data.notificationCode) {
                case Wlan.HostedNetworkNotificationCode.RadioStateChange:
                case Wlan.HostedNetworkNotificationCode.StateChange:
                    LoadApValues();
                    break;

                case Wlan.HostedNetworkNotificationCode.PeerStateChange:
                    LoadApPeers();
                    break;
                }
            }


        private void ActiveAp(object sender, EventArgs e) {
            if(cb_active_ap.Checked) {
                wlan.HostedNetworkStop();
                } else {
                wlan.HostedNetworkConnectionSettings(tb_ap_ssid.Text, (uint) nud_ap_max_clients.Value);
                if(tb_ap_key.TextLength >= 8)
                    wlan.HostedNetworkSetSecondaryKey(tb_ap_key.Text);
                wlan.HostedNetworkStart();
                }
            Cursor = Cursors.AppStarting;
            LoadApValues();
            }

        public void LoadApValues() {

            Wlan.WlanHostedNetworkConnectionSettings settings;
            wlan.HostedNetworkQueryConnection(out settings);

            tb_ap_ssid.Text = Encoding.Default.GetString(settings.HostedNetworkSsid.SSID).Remove((int) settings.HostedNetworkSsid.SSIDLength);
            nud_ap_max_clients.Value = (int) settings.MaxNumberOfPeers;

            string key;
            wlan.HostedNetworkQuerySecondaryKey(out key);
            tb_ap_key.Text = key;

            if(wlan.HostedNetworkStatus().HostedNetworkState == Wlan.HostedNetworkState.Active) {
                cb_active_ap.Checked = true;
                } else {
                cb_active_ap.Checked = false;
                }
            Cursor = Cursors.Default;
            LoadApPeers();
            }

        public void LoadApPeers() {
            Wlan.WlanHostedNetworkStatus status = wlan.HostedNetworkStatus();

            string oui = File.ReadAllText("oui.csv");

            hn_peers = new string[status.NumberOfPeers];
            for(int c = 0; c < status.NumberOfPeers; c++) {

                string mac = BitConverter.ToString(status.peer_list[c].PeerMacAddress).Replace('-', ':');

                string find = "^" + mac.Replace(":", "").Remove(6) + ".*?,(?<man>.*?),(.*?)$";
                Match mac_line = Regex.Match(oui, find, RegexOptions.Multiline | RegexOptions.IgnoreCase);

                hn_peers[c] = mac + " - " + mac_line.Groups["man"].Value.Replace("\"", "");
                }
            tb_connected.Text = status.NumberOfPeers.ToString();
            lb_connected_peers.DataSource = hn_peers;
            }

        #endregion

        #region ICS

        //TODO SLOWWWW
        void UpdateICS() {

            NetSharingManager manager = new NetSharingManagerClass();
            bool instaled = manager.SharingInstalled;

            cb_con_pub.Enabled = instaled;
            lb_con_priv.Enabled = instaled;
            cb_con_priv.Enabled = instaled;
            btn_add_privcon.Enabled = instaled;


            pub_con = new List<string>();
            priv_con = new List<string>();
            priv_con_cb = new List<string>();
            priv_con_cb_index = new List<int>();

            int index = 0;
            int? selected_index = null;
            foreach(INetConnection con in manager.EnumEveryConnection) {
                try {
                    inet_connections.Add(con);
                    INetConnectionProps prop = manager.NetConnectionProps[con];
                    INetSharingConfiguration conf = manager.INetSharingConfigurationForINetConnection[con];
                    
                    pub_con.Add(prop.Name);

                    if((tagNETCON_CHARACTERISTIC_FLAGS) prop.Characteristics != tagNETCON_CHARACTERISTIC_FLAGS.NCCF_INCOMING_ONLY &&
                        conf.SharingConnectionType == tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PUBLIC
                        && conf.SharingEnabled) {
                        selected_index = index;
                        } else {
                        if(conf.SharingConnectionType == tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PRIVATE) {
                            priv_con.Add(prop.Name);
                            } else {
                            priv_con_cb.Add(prop.Name);
                            priv_con_cb_index.Add(index);
                            }
                        }

                    //Info
                    Print(prop.DeviceName + " - " + prop.Status + " - " + prop.MediaType+
                    " - " + conf.SharingEnabled + " - " + conf.SharingConnectionType+" - "+ (tagNETCON_CHARACTERISTIC_FLAGS) prop.Characteristics);


                    index++;
                    } catch(Exception e) {

                    }
                }

            cb_con_pub.DataSource = pub_con;
            if(selected_index != null)
                cb_con_pub.SelectedIndex = (int) selected_index;

            lb_con_priv.DataSource = priv_con;
            cb_con_priv.DataSource = priv_con_cb;
            }

        private void AddPrivConn(object sender, EventArgs e) {
            try {
                NetSharingManager manager = new NetSharingManagerClass();
                INetConnection con = inet_connections[priv_con_cb_index[cb_con_priv.SelectedIndex]];

                INetConnectionProps prop = manager.NetConnectionProps[con];
                INetSharingConfiguration conf = manager.INetSharingConfigurationForINetConnection[con];

                conf.EnableSharing(tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PRIVATE);
                priv_con.Add(prop.DeviceName);
                } catch(Exception) {

                }

            UpdateICS();
            }


        enum tagNETCON_CHARACTERISTIC_FLAGS {
            NCCF_NONE = 0,
            NCCF_ALL_USERS = 0x1,
            NCCF_ALLOW_DUPLICATION = 0x2,
            NCCF_ALLOW_REMOVAL = 0x4, 
            NCCF_ALLOW_RENAME = 0x8,
            NCCF_INCOMING_ONLY = 0x20,
            NCCF_OUTGOING_ONLY = 0x40,
            NCCF_BRANDED = 0x80,
            NCCF_SHARED = 0x100,
            NCCF_BRIDGED = 0x200,
            NCCF_FIREWALLED = 0x400,
            NCCF_DEFAULT = 0x800,
            NCCF_HOMENET_CAPABLE = 0x1000,
            NCCF_SHARED_PRIVATE = 0x2000,
            NCCF_QUARANTINED = 0x4000,
            NCCF_RESERVED = 0x8000,
            NCCF_HOSTED_NETWORK = 0x10000,
            NCCF_VIRTUAL_STATION = 0x20000,
            NCCF_WIFI_DIRECT = 0x40000,
            NCCF_BLUETOOTH_MASK = 0xf0000,
            NCCF_LAN_MASK = 0xf00000
            }

        #endregion

        #region ConnCheck

        void StartCheck(object state) {
            th_conn_check = new Thread(CheckConnection);
            th_conn_check.Start();
            }

        public void CheckConnection() {
            if(IsConnected()) {
                Debug.Print("Conectado");
                } else {
                Debug.Print("Desconectado");
                }
            Thread.CurrentThread.Abort();
            }


        public static bool IsConnected() {
            try {
                HttpWebRequest check = (HttpWebRequest) HttpWebRequest.Create("http://connectivitycheck.gstatic.com/generate_204");
                check.Timeout = 15000;
                HttpWebResponse resp = (HttpWebResponse) check.GetResponse();
                return resp.StatusCode == HttpStatusCode.NoContent;
                } catch(Exception e) {
                Debug.WriteLine("IsConnected: " + e.Message);
                return false;
                }
            }

        #endregion

        #region Misc
        private void Closing(object sender, FormClosingEventArgs e) {
            if(!real_close) {
                e.Cancel = true;
                Hide();
                }
            }

        private void NotifyClick(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left && !Visible) {
                Show();
                }
            }

        bool real_close = false;
        private void RealClose(object sender, EventArgs e) {
            real_close = true;
            Close();
            }

        void Print(string print) {
            log.Text += print + eol;
            }

        void Print(int print) {
            log.Text += print + eol;
            }

        #endregion



        }
    }
