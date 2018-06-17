﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public class Team
    {
        private string _location;
        private string _teamName;
        private string _logoPath = null;
        private int _teamID;
        private static int idCount = 0;
        private List<Player> roster = new List<Player>();
        private List<Player> farm = new List<Player>();

        private Forward[,] forwards = new Forward[4, 3];
        private Defender[,] defenders = new Defender[3, 2];
        private Goalie[] goalies = new Goalie[2];
        private Skater[] scratched = new Skater[3];
        public Team(string location, string name)
        {
            Location = location;
            TeamName = name;
            idCount++;
            _teamID = idCount;
        }
        public Team(string location, string name, string imagePath)
        {
            Location = location;
            TeamName = name;
            LogoPath = imagePath;
            idCount++;
            _teamID = idCount;
        }
        public string TeamName
        {
            get
            {
                return _teamName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Team name must contain characters");
                }
                else
                {
                    _teamName = value.Trim();
                }
            }
        }
        public string LogoPath
        {
            get
            {
                return _logoPath;
            }
            set
            {
                _logoPath = value;
            }
        }
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("location must contain characters");
                }
                else
                {
                    _location = value.Trim();
                }

            }
        }
        public Image Logo
        {
            get
            {
                try
                {
                    Image image = Image.FromFile(_logoPath);
                    return image;
                }
                catch
                {
                    return null;
                }
            }
        }
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", _location, _teamName);
            }
        }
        public int TeamID
        {
            get
            {
                return _teamID;
            }
        }
        public override string ToString()
        {
            return FullName;
        }
    }
}
