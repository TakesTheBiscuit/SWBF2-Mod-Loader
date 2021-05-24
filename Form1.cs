using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace BattlefrontIIMOU
{
    public partial class Form1 : Form
    {

        public string modDataPath;
        public string eaLinkPath;

        public string cmd;





        public Form1(string command)
        {
            InitializeComponent();
            Console.WriteLine(command);

            this.cmd = command;
            
        }




        private void Form1_Load(object sender, EventArgs e)
        {

            this.modDataPath = @Properties.Settings.Default.modDataPath;
            //Console.WriteLine(this.modDataPath);

            this.eaLinkPath = @Properties.Settings.Default.eaLinkPath;
            //Console.WriteLine(this.eaLinkPath);



            this.cmd = this.cmd.Replace("link2ea", "\"originallink2ea");
            this.cmd = this.cmd.Replace("Hotfix=go", "Hotfix=go -datapath %22" + this.modDataPath + "%22");

            Process myProcess = new Process();
            myProcess.StartInfo.FileName = this.eaLinkPath;
            myProcess.StartInfo.Arguments = this.cmd;
            myProcess.Start();


        }



        private void button1_Click_1(object sender, EventArgs e)
        {


            // 1. copy BattlefrontIIMOU.exe to this folder: C:\Program Files (x86)\Origin

            // 2. open regedit, rename HKEY_CLASSES_ROOT\link2ea to originallink2ea HKEY_CLASSES_ROOT\originallink2ea
            
            // 3. make a new key under HKEY_CLASSES_ROOT\link2ea --> that is where this application will be called! :) 
            // new key on HKEY_CLASSES_ROOT = link2ea
            // default REG_SZ value should be = 'URL:EALINK Protocol'
            // new string on HKEY_CLASSES_ROOT\link2ea name 'URL Protocol', value is blank


            // new key on  HKEY_CLASSES_ROOT\link2ea = shell
            // new key on  HKEY_CLASSES_ROOT\link2ea\shell = open
            // new key on  HKEY_CLASSES_ROOT\link2ea\shell\open = command

            // 4. HKEY_CLASSES_ROOT\link2ea\shell\open\command , default REG_SZ: to have value: "C:\Program Files (x86)\Origin\BattlefrontIIMOU.exe" "%1" "%2" "%3" "%4" "%5" "%6" "%7" "%8" "%9"

            // todo: pass these along to real original_link2ea



        }
    }
}
