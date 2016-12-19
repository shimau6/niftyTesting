using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webTopPage
{
    public partial class OpenCameraForm : Form
    {
        public OpenCameraForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenCamera(0,"none",textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenCamera(1, textBox3.Text, textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenCamera(2, textBox4.Text, textBox2.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenCamera(3, "0", "0");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.svm";
            ofd.InitialDirectory = APPDATA.WORKING_FOLDER;
            ofd.Filter = "svmファイル|*.svm";
            ofd.Title = "使用したいSVMファイルの選択";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.SafeFileName.Split('.')[1].Equals("svm"))
                {
                    textBox1.Text = ofd.FileName;
                }
            }
        }

        private void OpenCamera(int number,string movieUrl,string outputUrl)
        {
            if (outputUrl == "" || outputUrl == null) outputUrl = "0";
            else {
                string time = DateTime.Now.ToString("yyyyMMddHHmmss");
                outputUrl += @"\" + time;
                System.IO.Directory.CreateDirectory(outputUrl); 
            }
            string outputImageCuted = "0";
            if (checkBox1.Checked) outputImageCuted = "1";
            string arg = textBox1.Text + " " + number + " " + movieUrl + " " + outputUrl + " " + outputImageCuted;
            System.Diagnostics.Process p;
            p =
            System.Diagnostics.Process.Start(
                @".\svm_usingTest.exe"
                , arg);
            p.WaitForExit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "検知画像を入れたいフォルダを指定してください。";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.SelectedPath = @"C:\Windows";
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                textBox2.Text = fbd.SelectedPath;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.InitialDirectory = APPDATA.WORKING_FOLDER;
            ofd.Filter = "動画(*.mp4;*.avi;*.gif)|*.mp4;*.avi;*.gif";
            ofd.Title = "使用したい動画ファイルの選択";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = ofd.FileName;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.InitialDirectory = APPDATA.WORKING_FOLDER;
            ofd.Filter = "静画(*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
            ofd.Title = "使用したい静画ファイルの選択";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = ofd.FileName;
            }
        }


    }
}
