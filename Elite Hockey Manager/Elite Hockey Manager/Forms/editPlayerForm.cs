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
using System.Reflection;

namespace Elite_Hockey_Manager.Forms
{
    public partial class EditPlayerForm : Form
    {
        //Value used to tell if there was a change when leaving a textbox
        string initialValue;
        Player player;
        public EditPlayerForm(Player chosenPlayer)
        {
            player = chosenPlayer;
            InitializeComponent();
        }
        private void EditPlayerForm_Load(object sender, EventArgs e)
        {
            this.Text = player.FullName + " - Edit";
            firstText.Text = player.FirstName;
            lastText.Text = player.LastName;
            ageText.Text = player.Age.ToString();
            idText.Text = player.ID.ToString();
            overallLabel.Text = String.Format("Overall: {0}", player.Overall);
            FillStats();

        }
        private void TextBoxLeave(object sender, EventArgs e)
        {
            TextBox statText = (TextBox)sender;
            string propertyName = (string)statText.Tag;
            string newValue = statText.Text.Trim();
            //If there has been a change
            if (newValue != initialValue)
            {
                PropertyInfo property;
                try
                {
                    property = player.Attributes.GetType().GetProperty(propertyName);
                    property.SetValue(player.Attributes, Convert.ChangeType(newValue, property.PropertyType));
                    overallLabel.Text = String.Format("Overall: {0}", player.Overall);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void TextBoxEnter(object sender, EventArgs e)
        {
            TextBox statBox = (TextBox)sender;
            initialValue = statBox.Text.Trim();
        }
        private void FillStats()
        {
            Tuple<String, int>[] statNames;
            if (player is Skater)
            {
                statNames = ((SkaterAttributes)player.Attributes).GetStatNames();
            }
            else if (player is Goalie)
            {
                statNames = ((GoalieAttributes)player.Attributes).GetStatNames();
            }
            else
            {
                MessageBox.Show("Error: Player is not of correct type");
                this.Close();
                return;
            }
            int startingX = 5;
            //The internal y value of within the statsGroup groupbox
            int startingY = 20;
            for (int i = 0; i < statNames.Length; i++)
            {
                Label statLabel = new Label();
                statLabel.Text = String.Format("{0,15} :", statNames[i].Item1);
                statLabel.AutoSize = true;
                statLabel.Location = new System.Drawing.Point(startingX, startingY + (i *20) );
                statsGroup.Controls.Add(statLabel);

                TextBox statText = new TextBox();
                statText.Text = statNames[i].Item2.ToString();
                statText.Tag = statNames[i].Item1;
                statText.Size = new System.Drawing.Size(43, 20);
                statText.Location = new System.Drawing.Point(startingX + 150, startingY + (i * 20) );
                statText.Leave += new System.EventHandler(this.TextBoxLeave);
                statText.Enter += new System.EventHandler(this.TextBoxEnter);
                statsGroup.Controls.Add(statText);

            }
        }

    }
}
