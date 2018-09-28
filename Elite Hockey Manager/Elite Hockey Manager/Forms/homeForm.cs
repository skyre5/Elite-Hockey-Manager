﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes;
using Elite_Hockey_Manager.Classes.LeagueComponents;
using Elite_Hockey_Manager.Forms;
using Elite_Hockey_Manager.Forms.HelperForms;
using System.Collections;

namespace Elite_Hockey_Manager
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void homeForm_Load(object sender, EventArgs e)
        {
            Center c = new Center("1", "2", 20);
            SkaterAttributes attrib = new SkaterAttributes();
            Center center2 = new Center("1", "2", 22, attrib);
            List<Forward> list1 = new List<Forward>();
            List<Center> list2 = new List<Center>();
            //Team x = new Team("Philly Flyers");
            


        }

        private void playersBtn_Click(object sender, EventArgs e)
        {
            CreatePlayerForm form = new CreatePlayerForm();
            form.ShowDialog();
        }

        private void teamsButton_Click(object sender, EventArgs e)
        {
            CreateTeamForm form = new CreateTeamForm();
            form.ShowDialog();
        }

        private void leagueButton_Click(object sender, EventArgs e)
        {
            CreateLeagueForm form = new CreateLeagueForm();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewGameForm form = new NewGameForm();
            form.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int overall = 0;
            IDictionary dic = new Dictionary<int, int>();
            for (int i = 0; i < 1000; i++)
            {
                Player x = PlayerGenerator.GenerateForward(0, 1);
                if (x.Overall > overall)
                {
                    if (!dic.Contains(x.Overall))
                    {
                        dic.Add(x.Overall, 1);
                    }
                    else
                    {
                        dic[x.Overall] = (int)dic[x.Overall] + 1;
                    }
                }

            }
            Console.Write("f");
        }
    }
}
