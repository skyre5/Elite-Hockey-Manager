using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes.LeagueComponents.OffseasonClasses;
using Elite_Hockey_Manager.Classes.LeagueComponents;
using Elite_Hockey_Manager.Classes;

namespace Elite_Hockey_Manager.Forms.GameForms.OffseasonForms
{
    public partial class DraftForm : Form
    {
        private Draft _draft;
        public DraftForm()
        {
            InitializeComponent();
        }
        public DraftForm(Draft draft)
        {
            InitializeComponent();
            _draft = draft;
        }

        private void DraftForm_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("Year {0} Draft", _draft.Year);
            UpdateRoundAndPick();
            if (_draft.CurrentPick != 1)
            {
                foreach (DraftPick pick in _draft.DraftPicks)
                {
                    Label pickLabel = CreateDraftPickLabel(pick);
                    draftDisplayLayoutPanel.Controls.Add(pickLabel);
                }
            }
            if (_draft.DoneDrafting)
            {
                DisableSimButtons();
            }
        }
        private void UpdateRoundAndPick()
        {
            if (_draft.DoneDrafting)
            {
                roundLabel.Text = $"Year {_draft.Year} Draft Finished";
                pickLabel.Text = "";
            }
            else
            {
                roundLabel.Text = String.Format("Current Round:{0}", _draft.CurrentRound);
                pickLabel.Text = String.Format("Current Pick:{0}", _draft.CurrentPick);
            }
        }

        private void simPickButton_Click(object sender, EventArgs e)
        {
            int pickNumber = _draft.CurrentPick;
            _draft.SimPick();
            Label pickLabel = CreateDraftPickLabel(_draft.DraftPicks[pickNumber - 1]);
            draftDisplayLayoutPanel.Controls.Add(pickLabel);
            UpdateRoundAndPick();
            if (_draft.DoneDrafting)
            {
                DisableSimButtons();
            }
        }

        private void simRoundButton_Click(object sender, EventArgs e)
        {
            int pickNumber = _draft.CurrentPick;
            _draft.SimRound();
            int finalRoundPickNumber = _draft.CurrentPick;
            //pickNumber reduced by one to get it to zero index based
            DraftPick[] newPicks = _draft.DraftPicks.Skip(pickNumber - 1).Take(finalRoundPickNumber - pickNumber).ToArray();
            foreach (DraftPick pick in newPicks)
            {
                Label pickLabel = CreateDraftPickLabel(pick);
                draftDisplayLayoutPanel.Controls.Add(pickLabel);
            }
            UpdateRoundAndPick();
            if (_draft.DoneDrafting)
            {
                DisableSimButtons();
            }
        }

        private void simDraftButton_Click(object sender, EventArgs e)
        {
            int pickNumber = _draft.CurrentPick;
            _draft.SimDraft();
            int finalRoundPickNumber = _draft.CurrentPick;
            //pickNumber reduced by one to get it to zero index based
            DraftPick[] newPicks = _draft.DraftPicks.Skip(pickNumber - 1).Take(finalRoundPickNumber - pickNumber).ToArray();
            foreach (DraftPick pick in newPicks)
            {
                Label pickLabel = CreateDraftPickLabel(pick);
                draftDisplayLayoutPanel.Controls.Add(pickLabel);
            }
            UpdateRoundAndPick();
            if (_draft.DoneDrafting)
            {
                DisableSimButtons();
            }
        }
        private Label CreateDraftPickLabel(DraftPick draftPick)
        {
            Label pickLabel = new Label();
            pickLabel.Text = $"{draftPick.Team.FullName} select ({draftPick.Player.Position}) {draftPick.Player.FullName} OVR:{draftPick.Player.Overall} with pick #{draftPick.Pick}";
            pickLabel.AutoSize = true;
            pickLabel.MouseDoubleClick += (sender, e) => { OpenPlayerFormOnDoubleClickHandler(sender, e, draftPick.Player); };
            return pickLabel;
        }
        /// <summary>
        /// Enabled when the draft is complete and drafting is no longer possible 
        /// </summary>
        private void DisableSimButtons()
        {
            simPickButton.Enabled = false;
            simRoundButton.Enabled = false;
            simDraftButton.Enabled = false;
        }
        private void OpenPlayerFormOnDoubleClickHandler(object sender, EventArgs e, Player player)
        {
            PlayerDisplayForm form = new PlayerDisplayForm(player);
            form.ShowDialog();
        }
    }
}
