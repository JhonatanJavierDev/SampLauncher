using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pc_samp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string ServerIP = "localhost";//aca se conecta a la ip mencionada
            string SPHash = ""; //PASSWORD en caso de que tu servidor contenga una clave de acceso
            string GTAPath = Registry.CurrentUser.OpenSubKey(@"Software\\SAMP").GetValue("gta_sa_exe").ToString();
            GTAPath = GTAPath.Substring(0, GTAPath.LastIndexOf(@"\") + 1);

       //     string[] CheckFile1 = Directory.GetFiles(GTAPath, "k-proyects.dll");
            string[] CheckFile2 = Directory.GetFiles(GTAPath, "K1.k");
            /*aca es un ejercicio sencillo para detectar hacks
            solo es cuestión de que busques cuales son los más usados y los pongas dentro de las comillas*/

            if (CheckFile2.Length > 0)
            {
                MessageBox.Show("Tu GTA se encuentra vulnerado!!!!!", "ADVERTENCIA DE HACKS!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                Registry.CurrentUser.OpenSubKey(@"Software\SAMP", true).SetValue("PlayerName", textBox1.Text);
                Process.Start(GTAPath + "samp.exe", ServerIP + SPHash);
            }
        }
    }
}
