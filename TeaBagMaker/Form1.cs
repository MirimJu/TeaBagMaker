using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeaBagMaker
{
    public partial class Form1 : Form
    {
        string[] teaList = new string[] { "홍차", "녹차", "루이보스차", "국화차" };
        int teaTime;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < teaList.Length; i++)
            {
                this.cBox.Items.Add(teaList[i]);
            }
            this.cBox.SelectedIndex = 0;
        }

        private void CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBox.SelectedIndex == 0 || cBox.SelectedIndex == 3)
            {
                teaTime = 60*2;
            }
            else if (cBox.SelectedIndex == 1)
            {
                teaTime = 60 * 3;
            }
            else
            {
                teaTime = 60 * 5;
            }
            this.countTxt.Text = teaTime / 60 + "분" + teaTime % 60 + "초";
        }

        private void CountBtn_Click(object sender, EventArgs e)
        {
            this.Timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (teaTime < 1)
            {
                this.Timer.Enabled = false;
                MessageBox.Show("티백을 건지세요!", "알림",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cBox.Focus();
                this.countTxt.Text = "";
            }
            else
            {
                this.teaTime--;
                this.countTxt.Text = teaTime / 60 + "분" + teaTime % 60 + "초 남았습니다!";
            }
        }
    }
}
