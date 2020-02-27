using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public class SkaterStats : PlayerStats
    {
        //int _gamesPlayed = 0;

        //int _plusMinus = 0;
        //int _penaltyMinutes = 0;

        //int _powerplayGoals = 0;
        //int _powerplayAssists = 0;

        //int _shorthandedGoals = 0;
        //int _shortHandedAssists = 0;

        //int _faceoffWins = 0;
        //int _faceoffLosses = 0;
        public SkaterStats(int year, int teamID, bool playoff = false) : base(year, teamID, playoff)
        {
        }
        //15 seconds per time on ice
        public int TimeOnIce
        {
            get;
            set;
        } = 0;
        public int Goals
        {
            get;
            set;
        } = 0;
        public int Assists
        {
            get;
            set;
        } = 0;
        public int Shots
        {
            get;
            set;
        } = 0;
        public int PlusMinus
        {
            get;
            set;
        } = 0;
        public int PenaltyMinutes
        {
            get;
            set;
        } = 0;
        public int PowerplayGoals
        {
            get;
            set;
        } = 0;
        public int PowerplayAssists
        {
            get;
            set;
        } = 0;
        public int ShorthandedGoals
        {
            get;
            set;
        } = 0;
        public int ShorthandedAssists
        {
            get;
            set;
        } = 0;
        public int FaceoffWins
        {
            get;
            set;
        } = 0;
        public int FaceoffLosses
        {
            get;
            set;
        } = 0;
        public int Points
        {
            get { return Goals + Assists; }
        }
        public int PowerplayPoints
        {
            get { return PowerplayGoals + PowerplayAssists; }
        }
        public int ShorthandedPoints
        {
            get { return ShorthandedGoals + ShorthandedAssists; }
        }
    }
}
