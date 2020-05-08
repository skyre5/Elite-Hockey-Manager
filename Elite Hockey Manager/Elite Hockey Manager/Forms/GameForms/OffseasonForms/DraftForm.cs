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
        //Used to track number of draft pick selections added to LayoutPanel
        private int _counter = 0;
        private Team _selectingTeam;
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
            //If the draft was already in progress, add previous draft picks to layout panel
            if (_draft.CurrentPick != 1)
            {
                AddDraftPicksToLayout(_draft.DraftPicks);
                UpdateSelectingTeam();
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
            AddDraftPicksToLayout(new DraftPick[] { _draft.DraftPicks[pickNumber - 1] });
            //Label pickLabel = CreateDraftPickLabel(_draft.DraftPicks[pickNumber - 1]);
            //draftDisplayLayoutPanel.Controls.Add(pickLabel);
            UpdateRoundAndPick();
            if (_draft.DoneDrafting)
            {
                DisableSimButtons();
            }
            UpdateSelectingTeam();
        }

        private void simRoundButton_Click(object sender, EventArgs e)
        {
            int pickNumber = _draft.CurrentPick;
            _draft.SimRound();
            int finalRoundPickNumber = _draft.CurrentPick;
            //pickNumber reduced by one to get it to zero index based
            DraftPick[] newPicks = _draft.DraftPicks.Skip(pickNumber - 1).Take(finalRoundPickNumber - pickNumber).ToArray();

            //Adds new draft picks to layout panel
            AddDraftPicksToLayout(newPicks);

            UpdateRoundAndPick();
            if (_draft.DoneDrafting)
            {
                DisableSimButtons();
            }
            UpdateSelectingTeam();
        }

        private void simDraftButton_Click(object sender, EventArgs e)
        {
            int pickNumber = _draft.CurrentPick;
            _draft.SimDraft();
            int finalRoundPickNumber = _draft.CurrentPick;
            //pickNumber reduced by one to get it to zero index based
            DraftPick[] newPicks = _draft.DraftPicks.Skip(pickNumber - 1).Take(finalRoundPickNumber - pickNumber).ToArray();

            //Adds the newPicks to the layout panel
            AddDraftPicksToLayout(newPicks);

            UpdateRoundAndPick();
            DisableSimButtons();
            UpdateSelectingTeam();
        }
        //Shows the team next in order to draft in the upcomingTeamLabel
        private void UpdateSelectingTeam()
        {
            //If the draft is over, there is no upcoming team. disable the upcomingTeamLabel
            if (_draft.DoneDrafting)
            {
                upcomingTeamLabel.Text = "";
                upcomingTeamLabel.Enabled = false;
                return;
            }
            _selectingTeam = _draft.TeamDraftOrder[(_draft.CurrentPick - 1) % _draft.Teams];
            upcomingTeamLabel.Text = $"Selecting Team:{_selectingTeam.FullName}";
        }
        private Label CreateDraftPickLabel(DraftPick draftPick)
        {
            Label pickLabel = new Label();
            pickLabel.Text = $"{draftPick.Team.FullName} select ({draftPick.Player.Position}) {draftPick.Player.FullName} OVR:{draftPick.Player.Overall} with pick #{draftPick.Pick}";
            pickLabel.AutoSize = true;
            pickLabel.MouseDoubleClick += (sender, e) => { OpenPlayerFormOnDoubleClickHandler(sender, e, draftPick.Player); };
            return pickLabel;
        }
        private void AddDraftPicksToLayout(DraftPick[] picks)
        {
            foreach (DraftPick pick in picks)
            {
                //If the pick hasn't been chosen yet, exits out of loop since the rest of the picks will be the same
                if (pick.Equals(default(DraftPick)))
                {
                    return;
                }
                _counter++;
                if (_counter % _draft.Teams == 1)
                {
                    AddRoundLabel();
                }
                Label pickLabel = CreateDraftPickLabel(pick);
                draftDisplayLayoutPanel.Controls.Add(pickLabel);
            }
        }
        private void AddRoundLabel()
        {
            Label roundLabel = new Label();
            roundLabel.Text = $"------Round {_counter / _draft.Teams + 1}------";
            draftDisplayLayoutPanel.Controls.Add(roundLabel);
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

        /// <summary>
        /// When the selecting team is double clicked, display team in the view team form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upcomingTeamLabel_DoubleClick(object sender, EventArgs e)
        {
            if (_selectingTeam == null)
            {
                return;
            }
            ViewTeamForm form = new ViewTeamForm(_selectingTeam);
            form.ShowDialog();
        }
    }
}
