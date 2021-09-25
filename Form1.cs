using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKM.V3;
using SKM.V3.Methods;
using SKM.V3.Models;
namespace InstallerF1Nal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.ForeColor = Color.Blue;
            richTextBox1.AppendText("Installer started....");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var licenseKey = textBox1.Text + "-"+ textBox2.Text +"-"+ textBox3.Text +"-"+ textBox4.Text;
            Boolean vaild = true;
            //Key verification here
            var token = "WyI0NzcxMjY1IiwiRE1yakovVnBpQXpLOUhIQ0hWY0ZjRDhJUVVZQmQrRTltSlR2SkVwNiJd";
            var RSAPubKey = "<RSAKeyValue><Modulus>pXTUjbPnZtEQNU05QJZ91FL+25l0MXOBnzZ2F07cT2vyY9Zi0ElHvBiCw07RSIHDFj1V0b7a/oR1E3cNsQoum5J57iovQbUdk3KDma4M8gtjYqUsTy/Ag1apEk8XS3f+9Q+GsMr5qt7fgpav2PsyF4Lxb7pYzU3vwpGmLDKif+/ZBrtDR/1pA4M22kf9jszagJKhh/q12B6kp8mYstFtsduMw3akdQ0cyxygLrwXILtqTxuz1uEC7bsTKR1nG3w7oj3Fv0SWfkN7e/HrTqx0A0LylWll+K0Jhq7SvJvhaPQm5MI8/V43v4gJpZXXPsyKMida1IJldVC5Wk96zs0IPw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            var result = Key.Activate(token: token, parameters: new ActivateModel()
            {
                Key = licenseKey,
                ProductId = 12264,
                Sign = true,
                MachineCode = Helpers.GetMachineCode()
            });

            if (result == null || result.Result == ResultType.Error ||
    !result.LicenseKey.HasValidSignature(RSAPubKey).IsValid())
            {
                string mess = "License " + licenseKey + " is invaild!";
                MessageBox.Show("License is invalid");
            }
            else {
                MessageBox.Show("License is vaild, press OK to start installation");
                richTextBox1.AppendText("\nUnpacking Python3.9...");
                string result6 = Path.GetTempPath();
                richTextBox1.AppendText("\n%temp% for you is at: " + result6);
                string currentPath = Directory.GetCurrentDirectory();
                richTextBox1.AppendText("\nCurrent directory is: " + currentPath);
                richTextBox1.AppendText("\nCopying from "+ currentPath + "\\python-3.9.7-amd64.exe" + " to " + result6);
                progressBar1.Value = 8;
                richTextBox1.AppendText("\nCopying files....");
                Thread.Sleep(5000);
                Process.Start((currentPath + "\\python-3.9.7-amd64.exe"), "/quiet InstallAllUsers=1 PrependPath=1 Include_test=0");
                progressBar1.Value = 30;
                for (int i =30; i<101; i++)
                {
                    progressBar1.Value = i;
                    Thread.Sleep(3000);
                }
                


                


            }


        }
    }
}
