using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;


namespace webTopPage
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

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectNiftyClass c = new ConnectNiftyClass();
            var account = c.createAccount(textBox1.Text, textBox2.Text);
            //if(account.objectId != null) MyUtility.CONFIRM("新規登録が完了しました。ログインしてください");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginFlow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.svm";
            ofd.InitialDirectory = APPDATA.WORKING_FOLDER;
            ofd.Filter = "svmファイル|*.svm";
            ofd.Title = "送信したいSVMファイルを選択";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.SafeFileName.Split('.')[1].Equals("svm"))
                {
                    fileUpload(ofd.FileName, userNiftyInfo.username + "_" + ofd.SafeFileName, textBox3.Text);
                }else
                {
                    MyUtility.WARNING("SVMファイルを選択してくださいよ…");
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConnectNiftyClass c = new ConnectNiftyClass();
            c.logout();
        }

        private void LoginFlow()
        {
            ConnectNiftyClass c = new ConnectNiftyClass();
            var account = c.login(textBox1.Text, textBox2.Text);

        }

        private void fileUpload(string PATH,string name,string password)
        {
            ConnectNiftyClass c = new ConnectNiftyClass();
            c.uploadFile(PATH,name,password);
        }

        private ResponseSVM listedSVM;
        private void button5_Click(object sender, EventArgs e)
        {
            listedSVM = new ConnectNiftyClass().listSVM();
            listBox1.Items.Clear();
            foreach(var l in listedSVM.results)
            {
                listBox1.Items.Add(l.svm);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex >= 0)
            {
                var s = listedSVM.results.Find(x => x.svm.Equals(listBox1.SelectedItem.ToString()));
                label6.Text = "Name : " + s.svm + Environment.NewLine
                    + "Pass : " + s.pass + Environment.NewLine
                    + "Date : " + s.updateDate;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                new ConnectNiftyClass().deleteSVM(listBox1.SelectedItem.ToString());
                listedSVM = new ConnectNiftyClass().listSVM();
                listBox1.Items.Clear();
                foreach (var l in listedSVM.results)
                {
                    listBox1.Items.Add(l.svm);
                }
                label6.Text = "";
                MyUtility.CONFIRM("削除が完了しました");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (new ConnectNiftyClass().abletoGetFile(textBox5.Text, textBox6.Text))
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.DownloadFile("https://mb.api.cloud.nifty.com/2013-09-01/applications/uWQNRyEG9BTLATfj/publicFiles/" + textBox5.Text,
                    APPDATA.WORKING_FOLDER + @"\" + textBox5.Text);
                wc.Dispose();
                MyUtility.CONFIRM("ダウンロードが完了しました");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenCameraForm o = new OpenCameraForm();
            o.ShowDialog(this);
            o.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p;
            p =
            System.Diagnostics.Process.Start(
                @".\imglab.exe");
            p.WaitForExit();
        }
    }

}
