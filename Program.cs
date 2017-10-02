using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WifiManager {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while(true) {
               // try {
                    Application.Run(new Main());
                    break;
                   /* } catch(Exception e) {
                    DialogResult result = MessageBox.Show("Se ha experimentado un problema, vamos a guardar los datos del error. Quieres Reiniciar el programa?", "Wifi Manager", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if(result != DialogResult.OK)
                        break;

                    }*/
                }
            }
        }
    }
