using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents;

namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    public static class ContractGenerator
    {
        //Salary cap of the league the system is currently generating contracts for
        //Default of 50
        private static double _salaryCap = 50.0;
        /// <summary>
        /// Sets the salary cap for the league that the ContractGenerator is generating for
        /// </summary>
        /// <param name="newCap">New cap being set(Must be between 40.0 and 100.0)</param>
        public static void SetSalaryCap(double newCap)
        {
            if (newCap < 40.0 || newCap > 100.0)
            {
                throw new ArgumentException("New Salary Cap must be between 40 and 100");
            }
            else
            {
                _salaryCap = newCap;
            }
        }
        public static void GenerateContract(Player player)
        {
            //Players 21 or under will be getting contracts that pass until the end of their 21 year old contracts
            if (player.Age <= 21)
            {
                if (player is Forward)
                    GenerateYouthContract((Forward)player);
                else if (player is Defender)
                    GenerateYouthContract((Defender)player);
                else if (player is Goalie)
                    GenerateYouthContract((Goalie)player);
                else
                    throw new ArgumentException("Player passed must be of forward,defender, or goalie type");
            }
            //Players over 21 will be getting veteran contracts
            else
            {
                if (player is Forward)
                    GenerateVeteranContract((Forward)player);
                else if (player is Defender)
                    GenerateVeteranContract((Forward)player);
                else if (player is Goalie)
                    GenerateVeteranContract((Forward)player);
                else
                    throw new ArgumentException("Player passed must be of forward,defender, or goalie type");
            }
        }
        private static void GenerateVeteranContract(Forward player)
        {
            int years = YearsForVeteranContract(player);
        }
        private static void GenerateVeteranContract(Defender player)
        {
            int years = YearsForVeteranContract(player);
        }
        private static void GenerateVeteranContract(Goalie player)
        {
            int years = YearsForVeteranContract(player);
        }
        private static void GenerateYouthContract(Forward player)
        {
            int years = YearsForEntryContract(player);
            double amount = 0;
            switch (player.PlayerStatus)
            {
                case ForwardPlayerStatus.Generational:
                    amount = 2;
                    break;
                case ForwardPlayerStatus.Superstar:
                    amount = 1.5;
                    break;
                case ForwardPlayerStatus.FirstLine:
                    amount = 1;
                    break;
                case ForwardPlayerStatus.TopSix:
                    amount = .5;
                    break;
                case ForwardPlayerStatus.TopNine:
                    amount = .5;
                    break;
                case ForwardPlayerStatus.BottomSix:
                    amount = .5;
                    break;
                case ForwardPlayerStatus.RolePlayer:
                    amount = 0;
                    break;
                case ForwardPlayerStatus.Unset:
                    amount = 0;
                    break;
            }
            Contract contract = new Contract(1, years, amount);
            player.AddContract(contract);
        }
        private static void GenerateYouthContract(Defender player)
        {
            int years = YearsForEntryContract(player);
            double amount = 0;
            switch (player.PlayerStatus)
            {
                case DefensePlayerStatus.Generational:
                    amount = 2.5;
                    break;
                case DefensePlayerStatus.Superstar:
                    amount = 2;
                    break;
                case DefensePlayerStatus.FirstPairing:
                    amount = 1.5;
                    break;
                case DefensePlayerStatus.SecondPairing:
                    amount = 1;
                    break;
                case DefensePlayerStatus.BottomPairing:
                    amount = .5;
                    break;
                case DefensePlayerStatus.Role:
                    amount = 0;
                    break;
                case DefensePlayerStatus.Unset:
                    amount = 0;
                    break;
            }
            Contract contract = new Contract(1, years, amount);
            player.AddContract(contract);
        }
        private static void GenerateYouthContract(Goalie player)
        {
            int years = YearsForEntryContract(player);
            double amount = 0;
            switch (player.PlayerStatus)
            {
                case GoaliePlayerStatus.Generational:
                    amount = 2.5;
                    break;
                case GoaliePlayerStatus.Elite:
                    amount = 2;
                    break;
                case GoaliePlayerStatus.Starter:
                    amount = 1.5;
                    break;
                case GoaliePlayerStatus.LowStarter:
                    amount = 1;
                    break;
                case GoaliePlayerStatus.Backup:
                    amount = .5;
                    break;
                case GoaliePlayerStatus.Role:
                case GoaliePlayerStatus.Unset:
                    amount = 0;
                    break;
            }
            Contract contract = new Contract(1, years, amount);
            player.AddContract(contract);
        }
        private static int YearsForEntryContract(Player player)
        {
            int years = 1;
            switch (player.Age)
            {
                case 18:
                    years = 4;
                    break;
                case 19:
                    years = 3;
                    break;
                case 20:
                    years = 2;
                    break;
                case 21:
                default:
                    years = 1;
                    break;
            }
            return years;
        }
        private static int YearsForVeteranContract(Player player)
        {
            Random rand = new Random();
            //1 - 8 year contracts
            int years = rand.Next(1, 9);
            //Only gives 1 year deals to players 41 or over
            if (player.Age >= 41)
            {
                years = 1;
            }
            //If the contract would bring them to over 41, shorten it to run till 41 instead
            else if (player.Age + years > 41)
            {
                years = 41 - player.Age;
            }
            return years;
        }
    }
}

