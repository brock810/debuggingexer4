using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static Random rng = new Random();
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Laser Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator!\nWould you like to generate a random activity? (yes/no): ");
            string answer = Console.ReadLine().ToLower();

            if (answer == "no")
            {
                Console.WriteLine("Goodbye!");
                return;
            }

            bool cont = true;

            Console.WriteLine("We are going to need your information first!");
            Console.Write("What is your name? ");
            string userName = Console.ReadLine();
            Console.Write("What is your age? ");
            int userAge;
            while (!int.TryParse(Console.ReadLine(), out userAge))
            {
                Console.Write("Please enter a valid age: ");
            }

            

            Console.Write("Would you like to see the current list of activities? (yes/no): ");
            bool seeList = Console.ReadLine().ToLower() == "yes";
            if (seeList)
            {
                Console.WriteLine("Current activities:");
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();

                Console.Write("Would you like to add any activities before we generate one? (yes/no): ");
                bool addToList = Console.ReadLine().ToLower() == "yes";
                if (addToList)
                {
                    Console.WriteLine();
                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);

                        Console.WriteLine("Updated activities:");
                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();

                        Console.Write("Would you like to add more? (yes/no): ");
                        addToList = Console.ReadLine().ToLower() == "yes";
                    }
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();

                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();

                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge < 10 && randomActivity == "Paintball")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    continue;
                }
                else if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    continue;
                }

                Console.Write($"Ah got it! {randomActivity}, your random activity is: {userName}! Do you want to generate another random activity? (yes/no): ");
                cont = Console.ReadLine().ToLower() == "yes";

            }
        }
    }
}

