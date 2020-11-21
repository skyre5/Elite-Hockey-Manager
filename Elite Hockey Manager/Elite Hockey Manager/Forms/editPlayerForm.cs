using Elite_Hockey_Manager.Classes;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms
{
    public partial class EditPlayerForm : Form
    {
        #region Fields

        //Value used to tell if there was a change when leaving a textbox
        private string initialValue;

        private Player player;

        #endregion Fields

        #region Constructors

        public EditPlayerForm(Player chosenPlayer)
        {
            player = chosenPlayer;
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void EditPlayerForm_Load(object sender, EventArgs e)
        {
            this.Text = player.FullName + " - Edit";
            firstText.Text = player.FirstName;
            lastText.Text = player.LastName;
            ageText.Text = player.Age.ToString();
            idText.Text = player.ID.ToString();
            overallLabel.Text = $"Overall: {player.Overall}";
            FillStats();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillStats()
        {
            Tuple<String, int>[] statNames;
            if (player is Skater)
            {
                statNames = ((SkaterAttributes)player.Attributes).GetAttributeNames();
            }
            else if (player is Goalie)
            {
                statNames = ((GoalieAttributes)player.Attributes).GetAttributeNames();
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
                statLabel.Text = $"{statNames[i].Item1,15} :";
                statLabel.AutoSize = true;
                statLabel.Location = new System.Drawing.Point(startingX, startingY + (i * 20));
                statsGroup.Controls.Add(statLabel);

                TextBox statText = new TextBox();
                statText.Text = statNames[i].Item2.ToString();
                statText.Tag = statNames[i].Item1;
                statText.Size = new System.Drawing.Size(43, 20);
                statText.Location = new System.Drawing.Point(startingX + 150, startingY + (i * 20));
                statText.Leave += new System.EventHandler(this.TextBoxLeave);
                statText.Enter += new System.EventHandler(this.TextBoxEnter);
                statsGroup.Controls.Add(statText);
            }
        }

        private void GeneralTextBoxLeave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string generalText = textBox.Text.Trim();
            //If a change has occured
            if (generalText == initialValue)
            {
                return;
            }
            try
            {
                switch (textBox.Tag.ToString())
                {
                    case "FirstName":
                        player.FirstName = generalText;
                        break;

                    case "LastName":
                        player.LastName = generalText;
                        break;

                    case "Age":
                        player.Age = int.Parse(generalText);
                        break;
                }
            }
            catch (Exception ex)
            {
                textBox.Text = initialValue;
                MessageBox.Show(ex.ToString());
            }
        }

        private void TextBoxEnter(object sender, EventArgs e)
        {
            TextBox statBox = (TextBox)sender;
            initialValue = statBox.Text.Trim();
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
                    property.SetValue(player.Attributes, Convert.ChangeType(newValue, property.PropertyType), null);
                    statText.Text = property.GetValue(player.Attributes).ToString();
                    overallLabel.Text = $"Overall: {player.Overall}";
                }
                catch (Exception ex)
                {
                    statText.Text = initialValue;
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
        }

        #endregion Methods
    }
}