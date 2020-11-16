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
        public static void GenerateContract(Player player, int year = 1)
        {
            //Players 21 or under will be getting contracts that pass until the end of their 21 year old contracts
            if (player.Age <= 21)
            {
                if (player is Forward)
                    GenerateYouthContract((Forward)player, year);
                else if (player is Defender)
                    GenerateYouthContract((Defender)player, year);
                else if (player is Goalie)
                    GenerateYouthContract((Goalie)player, year);
                else
                    throw new ArgumentException("Player passed must be of forward,defender, or goalie type");
            }
            //Players over 21 will be getting veteran contracts
            else
            {
                GenerateVeteranContract(player, year);
            }
        }
        private static void GenerateVeteranContract(Player player, int year)
        {
            int duration = YearsForVeteranContract(player);
            int overall = player.Overall;
            double minContractAmount = 0;
            double maxContractAmount = 0;
            if (overall > 95)
            {
                minContractAmount = 6 + (0.5 * (overall - 95));
                maxContractAmount = 10 + (0.5 * (overall - 95));
            }
            else if (overall > 90)
            {
                minContractAmount = 5 + (0.5 * (overall - 90));
                maxContractAmount = 8.5 + (0.5 * (overall - 90));
            }
            else if (overall > 85)
            {
                minContractAmount = 4 + (0.5 * (overall - 85));
                maxContractAmount = 5 + (0.5 * (overall - 85));
            }
            else if (overall > 80)
            {
                minContractAmount = 3 + (0.5 * (overall - 80));
                maxContractAmount = 4 + (0.25 * (overall - 80));
            }
            else if (overall > 75)
            {
                minContractAmount = 1.5 + (0.25 * (overall - 75));
                maxContractAmount = 2.5 + (0.25 * (overall - 75));
            }
            else if (overall > 70)
            {
                minContractAmount = 0 + (0.25 * (overall - 70));
                maxContractAmount = .5 + (0.25 * (overall - 70));
            }
            if (minContractAmount == 0 && maxContractAmount == 0)
            {
                Contract contract = new Contract(year, duration, .5);
                player.AddContract(contract);
            }
            else
            {
                double amount = GenerateContractAmount(minContractAmount, maxContractAmount);
                if (amount < .5)
                {
                    amount = .5;
                }
                Contract contract = new Contract(year, duration, amount);
                player.AddContract(contract);
            }
        }
        private static double GenerateContractAmount(double minAmount, double maxAmount)
        {
            Random rand = new Random();
            int lowerBound = (int)(minAmount / .25);
            int upperBound = (int)(maxAmount / .25);
            int amount = rand.Next(lowerBound, upperBound + 1);
            return (amount * 0.25);
        }
        private static void GenerateYouthContract(Forward player, int year)
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
                    amount = .5;
                    break;
                case ForwardPlayerStatus.Unset:
                    amount = .5;
                    break;
            }
            Contract contract = new Contract(year, years, amount);
            player.AddContract(contract);
        }
        private static void GenerateYouthContract(Defender player, int year)
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
                    amount = .5;
                    break;
                case DefensePlayerStatus.Unset:
                    amount = .5;
                    break;
            }
            Contract contract = new Contract(year, years, amount);
            player.AddContract(contract);
        }
        private static void GenerateYouthContract(Goalie player, int year)
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
                    amount = .5;
                    break;
            }
            Contract contract = new Contract(year, years, amount);
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

