﻿using System;
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
    }

}
