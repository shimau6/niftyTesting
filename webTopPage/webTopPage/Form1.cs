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
            label4.Text = "新規登録が完了しました。ログインしてください";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginFlow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = ".svm";
            ofd.InitialDirectory = @".\imglab\SAVE";
            ofd.Filter = "SVMファイル(*.svm)|*.svm";
            ofd.Title = "送信したいSVMファイルを選択";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileUpload(ofd.FileName,userNiftyInfo.username + "_" +  ofd.SafeFileName,textBox3.Text);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConnectNiftyClass c = new ConnectNiftyClass();
            c.logout();
            label4.Text = "ログアウトしたお";
        }

        private void LoginFlow()
        {
            ConnectNiftyClass c = new ConnectNiftyClass();
            var account = c.login(textBox1.Text, textBox2.Text);
            userNiftyInfo.set(account);
            label4.Text = "ログインが完了しました。";
            if (userNiftyInfo.svmID == null)
            {
                var res = c.setUserData();
                userNiftyInfo.svmID = res.objectId;
                c.updateUser();
                label4.Text = "いろいろできた";
            }
        }

        private void fileUpload(string PATH,string name,string password)
        {
            ConnectNiftyClass c = new ConnectNiftyClass();
            c.uploadFile(PATH,name);
            c.setSVM(name,password);
            label4.Text = "できた";
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
                    + "Pass : " + s.pass;
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
            }
        }
    }

}
