using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    [Serializable]
    internal class DraftPick
    {
        #region Constructors

        /// <summary>
        /// DraftPick constructor
        /// </summary>
        /// <param name="assignedTeam"></param>
        /// <param name="round"></param>
        public DraftPick(Team assignedTeam, int round)
        {
            AssignedTeam = assignedTeam;
            OwningTeam = assignedTeam;
            Round = round;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Read Only
        /// The team that this pick originally belonged to. Picks may get traded to other teams and
        /// the assigned team is used to determine draft order
        /// </summary>
        public Team AssignedTeam
        {
            get;
        }

        /// <summary>
        /// The team that is in current possession of the draft pick. Will always start with the same value of the assigned team.
        /// When traded the new team will be set as the owning team
        /// </summary>
        public Team OwningTeam
        {
            get;
            set;
        }

        /// <summary>
        /// Read Only
        /// The round of the draft that this pick gives the owning team
        /// </summary>
        public int Round
        {
            get;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>String displaying round of draft pick and assigned team if owned by separate team</returns>
        public override string ToString()
        {
            if (OwningTeam == AssignedTeam)
            {
                return $"Draft Pick Rd:{Round}";
            }
            else
            {
                return $"Draft Pick Rd:{Round} by {AssignedTeam.Abbreviation}";
            }
        }

        #endregion Methods
    }
}