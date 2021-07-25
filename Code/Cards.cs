using System;

namespace BlackJack
{
    static class Cards
    {
        // generates a random card value
        public static string GenerateCardValue()
        {
            Random randomnumber = new Random();
            switch (randomnumber.Next(1, 14))
            {
                case 1:
                    return " 2";
                case 2:
                    return " 3";
                case 3:
                    return " 4";
                case 4:
                    return " 5";
                case 5:
                    return " 6";
                case 6:
                    return " 7";
                case 7:
                    return " 8";
                case 8:
                    return " 9";
                case 9:
                    return "10";
                case 10:
                    return " J";
                case 11:
                    return " Q";
                case 12:
                    return " K";
                case 13:
                    return " A";
                default:
                    return null;
            }

        }


        //generates a random card suit
        public static string GenerateCardSuit()
        {
            Random randomnumber = new Random();
            switch (randomnumber.Next(1, 5))
            {
                case 1:
                    return "♣";
                case 2:
                    return "♦";
                case 3:
                    return "♥";
                case 4:
                    return "♠";
                default:
                    return null;
            }

        }


        // TODO: make cards not random generated but generate a card deck and choose random card from that
    }
}