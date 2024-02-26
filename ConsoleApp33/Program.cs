using System;
using System.Collections.Generic;

namespace TouristCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> cityCosts = new Dictionary<string, int>()
            {
                {"Берлин", 399},
                {"Прага", 300},
                {"Париж", 350},
                {"Рига", 250},
                {"Лондон", 390},
                {"Ватикан", 500},
                {"Палермо", 230},
                {"Варшава", 300},
                {"Кишинёв", 215},
                {"Мадрид", 260},
                {"Будапешт", 269}
            };

            Dictionary<string, int> transitCosts = new Dictionary<string, int>()
            {
                {"Мадрид", 190},
                {"Кишинёв", 110},
                {"Лондон", 270},
                {"Рига", 170},
                {"Париж", 220},
                {"Берлин", 175},
                {"Будапешт", 230},
                {"Варшава", 190},
            };

            Console.WriteLine("Бюджет:");
            int budget = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Откуда:");
            string departureCity = Console.ReadLine();

            Console.WriteLine("В какие города (от 1 до 3 через запятую):");
            string[] visitCities = Console.ReadLine().Split(',');

            int totalCost = 0;

            foreach (var city in visitCities)
            {
                int cityCost = cityCosts[city.Trim()];

                if (cityCost > 0)
                {
                    bool isNonEUTourist = true;

                    if (isNonEUTourist)
                    {
                        double tax = cityCost * 0.04;
                        cityCost += (int)tax;
                    }
                }

                totalCost += cityCost;

                if (city == "Ватикан")
                {
                    totalCost += cityCost / 2;
                }
                else if (city == "Палермо")
                {
                    if (departureCity == "Лондон")
                    {
                        totalCost += (int)(cityCost * 0.07);
                    }
                    else if (departureCity == "Кишинёв")
                    {
                        totalCost += (int)(cityCost * 0.11);
                    }
                }
                else if (city == "Рига")
                {
                    if (departureCity == "Париж")
                    {
                        totalCost += (int)(cityCost * 0.09);
                    }
                }

            totalCost += cityCosts[city.Trim()];

                if (city == "Ватикан")
                {
                    totalCost += cityCosts[city.Trim()] / 2;
                }
                else if (city == "Палермо")
                {
                    if (departureCity == "Лондон")
                    {
                        totalCost += (int)(cityCosts[city.Trim()] * 0.07);
                    }
                    else if (departureCity == "Кишинёв")
                    {
                        totalCost += (int)(cityCosts[city.Trim()] * 0.11);
                    }
                }
                else if (city == "Рига")
                {
                    if (departureCity == "Париж")
                    {
                        totalCost += (int)(cityCosts[city.Trim()] * 0.09);
                    }
                }
            }

            if (departureCity == "Мадрид")
            {
                totalCost += transitCosts["Мадрид"];
                totalCost += transitCosts["Париж"];
            }
            else if (departureCity == "Кишинёв")
            {
                totalCost += transitCosts["Кишинёв"];
                totalCost += transitCosts["Будапешт"];
            }
            else if (departureCity == "Лондон")
            {
                totalCost += transitCosts["Лондон"];
                totalCost += transitCosts["Париж"];
            }
            else if (departureCity == "Рига")
            {
                totalCost += transitCosts["Рига"];
                totalCost += transitCosts["Варшава"];
            }

            if (visitCities.Contains("Палермо") && visitCities.Contains("Рига"))
            {
                totalCost += cityCosts["Берлин"];
                totalCost += cityCosts["Варшава"];
            }

            if (departureCity == "Берлин")
            {
                totalCost += (int)(totalCost * 0.13);
            }

            if (totalCost > budget)
            {
                Console.WriteLine($"Итог: {totalCost}. Мало, лучше Кишинёв");
            }
            else
            {
                Console.WriteLine($"Итог: {totalCost}. Все четко");
            }
        }
    }
}