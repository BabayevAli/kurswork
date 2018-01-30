﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp33
{
    public partial class TrainSelect : Form
    {
        public string gel, get, qatar;
        public DateTime time;

        private void panel1_Click(object sender, EventArgs e)
        {
            Form2 trains = new Form2();
            trains.ShowDialog();
        }

        public TrainSelect()
        {
            InitializeComponent();
        }

        private void TrainSelect_Load(object sender, EventArgs e)
        {
            label14.Text = gel;
            label15.Text = get;
            label16.Text = time.ToShortDateString();
            label17.Text = "Qatar";
            label20.Text = gel + " - " + get + "(" + time.ToShortDateString() + ")";
        }
    }
}