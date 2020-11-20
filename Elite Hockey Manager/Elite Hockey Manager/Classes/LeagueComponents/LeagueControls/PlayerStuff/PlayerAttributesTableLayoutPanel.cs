using System;
using System.Drawing;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStuff
{
    public class PlayerAttributesTableLayoutPanel : System.Windows.Forms.TableLayoutPanel
    {
        private Player _player;

        public Player Player
        {
            get
            {
                return _player;
            }
            set
            {
                if (value != null)
                {
                    _player = value;
                    LoadTable();
                }
            }
        }

        public PlayerAttributesTableLayoutPanel()
        {
        }

        private void LoadTable()
        {
            Tuple<string, int>[] attributes = _player.Attributes.GetAttributeNames();
            //Rounds up the number of attributes divided by 3
            int newRowCount = (attributes.Length + this.ColumnCount - 1) / this.ColumnCount;
            int index = 0;
            int endIndex = attributes.Length;
            for (int row = 0; row < newRowCount; row++)
            {
                if (row >= 1)
                {
                    this.RowCount++;
                    this.RowStyles.Add(new RowStyle(SizeType.Absolute, 15));
                }
                for (int col = 0; col < this.ColumnCount; col++)
                {
                    if (index == endIndex)
                        break;
                    this.Controls.Add(CreateLabel(attributes[index]), col, row);
                    index++;
                }
            }
        }

        private Label CreateLabel(Tuple<string, int> attribute)
        {
            Label attributeLabel = new Label();
            attributeLabel.AutoSize = true;
            attributeLabel.Text = $@"{attribute.Item1,-14}:{attribute.Item2}";
            attributeLabel.Font = new Font("Courier New", 8f);
            return attributeLabel;
        }
    }
}