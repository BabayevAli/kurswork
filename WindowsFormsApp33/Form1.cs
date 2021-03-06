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
    public partial class Form1 : Form
    {
        bool checkdate = false;
        MonthCalendar a = null;
        List<string> list = new List<string>();
        MonthCalendar f;
        Dictionary<string,ListQatar> qatarsss;
        public Form1()
        {
            InitializeComponent();
            panel2.Enabled = true;
            list.Add("ASTARA");
            list.Add("BAKI - SƏRN");
            list.Add("BAŞ ƏLƏT");
            list.Add("BİLƏCƏRİ");
            list.Add("CƏLİLABAD");
            list.Add("DAYKƏND");
            list.Add("KEŞLƏ");
            list.Add("LƏNKƏRAN");
            list.Add("LİMAN");
            list.Add("LÖKBATAN");
            list.Add("MASALLI");
            list.Add("OSMANLI");
            list.Add("PL. 111 KM");
            list.Add("QAMIŞLIQ");
            list.Add("QARADAĞ");
            list.Add("QASIMLI");
            list.Add("QIRMIZIKƏND");
            list.Add("SALYAN");
            list.Add("ŞİRVAN - ÇEŞİD.");
            list.Add("ŞİRVAN - SƏRN.");
            qatarsss = new Dictionary<string, ListQatar>();
            foreach (var item in comboBox1.Items)
            {
                foreach (var item1 in comboBox2.Items)
                {
                    string a1 = item.ToString() + "-" + item1.ToString();
                    qatarsss[a1] = null;
                }
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            a = new MonthCalendar();
            a.MaxDate = DateTime.Now.AddDays(10);
            a.MinDate = DateTime.Now;
            a.TabIndex = 20;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            a.Location = new Point(60, 289);
            a.DateSelected += A_DateSelected;
            Controls.Add(a);
        }
        private void A_DateSelected(object sender, DateRangeEventArgs e)
        {
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = true;
            f = (MonthCalendar)sender;
            label1.Text = f.SelectionRange.Start.ToShortDateString();
            Controls.Remove((MonthCalendar)sender);
            checkdate = true;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            MonthCalendar a1 = new MonthCalendar();
            a1.MinDate = DateTime.Now;
            a1.TabIndex = 14;
            a1.TabIndex = 20;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            panel3.Visible = false;
            a1.Location = new Point(354, 289);
            a1.DateSelected += A_DateSelected1; ;
            Controls.Add(a1);
        }

        private void A_DateSelected1(object sender, DateRangeEventArgs e)
        {
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = true;
            panel3.Visible = true;
            MonthCalendar f = (MonthCalendar)sender;
            label2.Text = f.SelectionRange.Start.ToShortDateString();
            Controls.Remove((MonthCalendar)sender);
        }
        private void panel3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 || Int32.Parse(comboBox3.SelectedItem.ToString()) +
                                               Int32.Parse(comboBox4.SelectedItem.ToString()) +
                                               Int32.Parse(comboBox5.SelectedItem.ToString()) == 0)
            {
                return;
            }
            else if (comboBox2.SelectedIndex < 0)
            {
                return;
            }
            else if (checkdate == false)
            {
                return;
            }
            else if (checkBox1.Checked == false)
            {
                return;
            }
            else if (qatarsss[comboBox1.SelectedItem.ToString() + "-" + comboBox2.SelectedItem.ToString()] == null)
            {
                qatarsss[comboBox1.SelectedItem.ToString() + "-" + comboBox2.SelectedItem.ToString()] = new ListQatar();
            }
            TrainSelect train = new TrainSelect();
            train.time = f.SelectionRange.Start;
            train.gel = comboBox1.SelectedItem.ToString();
            train.get = comboBox2.SelectedItem.ToString();
            train.big = Int32.Parse(comboBox3.SelectedItem.ToString());
            train.mid = Int32.Parse(comboBox4.SelectedItem.ToString());
            train.low = Int32.Parse(comboBox5.SelectedItem.ToString());
            Hide();
            List<bool> bools = new List<bool>();
            int count = 0;
            foreach (var item in qatarsss[comboBox1.SelectedItem.ToString() + "-" + comboBox2.SelectedItem.ToString()].qatars[a.SelectionStart.ToShortDateString()].places.Values)
            {
                if(item == null)
                {
                    bools.Add(true);
                    count++;
                }
                else
                {
                    bools.Add(false);
                }
            }
            train.trains.a.pls = bools;
            train.coun = count;
            train.ShowDialog();
            if (train.dialogs == DialogResult.OK)
            {
                MessageBox.Show("Elave Olundu");
                Dictionary<string, sbyte> trainsplacesinfo = train.trains.a.dic;
                var nam = trainsplacesinfo.Keys.ToList();
                var num = trainsplacesinfo.Values.ToList();
                for (int i = 0; i < nam.Count; i++)
                {
                    qatarsss[comboBox1.SelectedItem.ToString() + "-" +comboBox2.SelectedItem.ToString()].qatars[a.SelectionStart.ToShortDateString()].places[num[i]] = train.trains.users.Find(x=> x.Name == nam[i]);
                }
                Show();
            }
            else
            {
                Show();
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            panel2.Enabled = false;
            comboBox3.SelectedItem = "0"; comboBox4.SelectedItem = "0"; comboBox5.SelectedItem = "0";
     
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            var az = comboBox1.SelectedItem;
            comboBox1.SelectedItem = comboBox2.SelectedItem;
            comboBox2.SelectedItem = az;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == comboBox2.SelectedItem.ToString())
                {
                    MessageBox.Show("Eyni yeri secmek olmaz!!");
                    comboBox1.SelectedItem = -1;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                if (comboBox2.SelectedItem.ToString() == comboBox1.SelectedItem.ToString())
                {
                    MessageBox.Show("Eyni yeri secmek olmaz!!");
                    comboBox2.SelectedIndex = -1;
                }
            }
        }

    }

    public class User
    {
        public string Name, Surname, SeriaNum, Country, Cinsi;
        public DateTime Birth;
        public User(string n, string s, string i, string c, string sex, DateTime time)
        {
            Name = n;
            Surname = s;
            SeriaNum = i;
            Country = c;
            Cinsi = sex;
            Birth = time;
        }
    }
    public class VaqonBig
    {
        public Dictionary<sbyte, User> places;
        public VaqonBig()
        {
            places = new Dictionary<sbyte, User>();
        }
    }


    public class ListQatar
    {
        public Dictionary<string, VaqonBig> qatars;
        public ListQatar()
        {
            qatars = new Dictionary<string, VaqonBig>();
            qatars[DateTime.Now.AddDays(0).ToShortDateString()] = new VaqonBig();
            qatars[DateTime.Now.AddDays(1).ToShortDateString()] = new VaqonBig();
            qatars[DateTime.Now.AddDays(2).ToShortDateString()] = new VaqonBig();
            qatars[DateTime.Now.AddDays(3).ToShortDateString()] = new VaqonBig();
            qatars[DateTime.Now.AddDays(4).ToShortDateString()] = new VaqonBig();
            qatars[DateTime.Now.AddDays(5).ToShortDateString()] = new VaqonBig();
            qatars[DateTime.Now.AddDays(6).ToShortDateString()] = new VaqonBig();
            qatars[DateTime.Now.AddDays(7).ToShortDateString()] = new VaqonBig();
            qatars[DateTime.Now.AddDays(8).ToShortDateString()] = new VaqonBig();
            qatars[DateTime.Now.AddDays(9).ToShortDateString()] = new VaqonBig();
            foreach (var item in qatars.Keys)
            {
                for (sbyte k = 0; k < 9; k++)
                {
                    qatars[item].places[k] = null;
                }
            }
        }

        
    }
}
