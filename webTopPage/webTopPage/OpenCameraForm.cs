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
            OpenCamera();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenCamera();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenCamera();
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

        private void OpenCamera()
        {

        }
    }
}
