﻿using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Visagent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string GetMD5FromFile(string filenPath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filenPath))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var md5signatures = File.ReadAllLines("MD5base.txt");
            if (md5signatures.Contains(tbMD5.Text))
            {
                lblStatus.Text = "Infected!";
                lblStatus.ForeColor = Color.Red;
            }

            else
            {
                lblStatus.Text = "Clean!";
                lblStatus.ForeColor = Color.Green;
            }

        }

        private void tbFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void browseForFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Textfiles | *.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbMD5.Text = GetMD5FromFile(ofd.FileName);
            }
        }
    }
}