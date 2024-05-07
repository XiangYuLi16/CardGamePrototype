using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Random num = new Random();

            // Computer's initial card draw
            int computerCard = num.Next(1, 14);
            Console.WriteLine("Computer drew a: " + DisplayCardValue(computerCard));

            // Player's choice to draw cards
            Console.WriteLine("Do you want to draw 1 or 2 cards? (Enter 1 or 2):");
            int choice = int.Parse(Console.ReadLine());
            int playerCard1 = num.Next(1, 14);
            int playerCard2 = 0;

            if (choice == 2)
            {
                // Player draws two cards
                playerCard2 = num.Next(1, 14);
                Console.WriteLine("You drew: " + DisplayCardValue(playerCard1) + " and " + DisplayCardValue(playerCard2));

                // Computer draws one more card
                int computerSecondCard = num.Next(1, 14);
                Console.WriteLine("Computer draws another card: " + DisplayCardValue(computerSecondCard));

                // Sum the values and compare
                if (AdjustAceValue(playerCard1) + AdjustAceValue(playerCard2) > AdjustAceValue(computerCard) + AdjustAceValue(computerSecondCard))
                {
                    Console.WriteLine("You Win!");
                }
                else
                {
                    Console.WriteLine("You Lose!");
                }
            }
            else
            {
                // Player draws one card
                Console.WriteLine("You drew: " + DisplayCardValue(playerCard1));

                // Compare the single card values
                if (AdjustAceValue(playerCard1) < AdjustAceValue(computerCard))
                {
                    Console.WriteLine("You Win!");
                }
                else
                {
                    Console.WriteLine("You Lose!");
                }
            }
        }

        static string DisplayCardValue(int cardValue)
        {
            switch (cardValue)
            {
                case 13: return "King";
                case 12: return "Queen";
                case 11: return "Jack";
                case 1: return "Ace";
                default: return cardValue.ToString();
            }
        }

        static int AdjustAceValue(int cardValue)
        {
            // This could be modified to allow choosing Ace value of 1 or 11 based on strategy.
            return cardValue == 1 ? 11 : cardValue > 10 ? 10 : cardValue;
        }
    }
}
