using System;
using System.Threading;

namespace BlackJack
{
    class Dealer : Player
    {
        public Dealer()
        {
            Random random = new Random();
            switch (random.Next(1, 21))
            {
                case 1:
                    this.Name = "Dealer Troy";
                    break;
                case 2:
                    this.Name = "Dealer Fred";
                    break;
                case 3:
                    this.Name = "Dealer Wayne";
                    break;
                case 4:
                    this.Name = "Dealer Doug";
                    break;
                case 5:
                    this.Name = "Dealer Hector";
                    break;
                case 6:
                    this.Name = "Dealer Adam";
                    break;
                case 7:
                    this.Name = "Dealer Isaac";
                    break;
                case 8:
                    this.Name = "Dealer Andy";
                    break;
                case 9:
                    this.Name = "Dealer Scott";
                    break;
                case 10:
                    this.Name = "Dealer Ben";
                    break;
                case 11:
                    this.Name = "Dealer Anna";
                    break;
                case 12:
                    this.Name = "Dealer Linda";
                    break;
                case 13:
                    this.Name = "Dealer Teresa";
                    break;
                case 14:
                    this.Name = "Dealer Anisa";
                    break;
                case 15:
                    this.Name = "Dealer Caitlyn";
                    break;
                case 16:
                    this.Name = "Dealer Bella";
                    break;
                case 17:
                    this.Name = "Dealer Courtney";
                    break;
                case 18:
                    this.Name = "Dealer Sara";
                    break;
                case 19:
                    this.Name = "Dealer Jessica";
                    break;
                case 20:
                    this.Name = "Dealer Yasmine";
                    break;
                default:
                    this.Name = "Dealer";
                    break;
            }

            this.PlayfieldPositionLeft = 5;
            this.PlayfieldPositionTop = 4;
            this.IsDealer = true;

        }

        // draw cards until got 
        public void DoDealerThing()
        {
            this.RevealFirstCard();
            this.DrawPlayfield();
            while (this.Handvalue < 17)
            {
                this.DrawCard();
                Thread.Sleep(650);
            }
        }


        // draws two cards and checks if blackjack. if blackjack returns true, else returns false
        public bool DealerStart() 
        {
            // draw two cards
            this.HandcardNumber.Add(Cards.GenerateCardValue());
            this.HandcardSuit.Add(Cards.GenerateCardSuit());
            this.HandcardNumber.Add(Cards.GenerateCardValue());
            this.HandcardSuit.Add(Cards.GenerateCardSuit());


            this.CalculateHandvalue();

            // if blackjack : reveals second card and returns true
            if (this.HandcardNumber[1] == " A" & this.Handvalue == 21)
            {
                this.GUIDrawDealersFirstTwoCards();
                Thread.Sleep(750);
                this.RevealFirstCard();
                return true;
            }

            // else: draws cards (one faced down) and returns false 
            else
            {
                this.GUIDrawDealersFirstTwoCards();
                this.CalculateOnlySecondCardAndSayHandValue();
                return false;
            }
        }


        // Reveals the first card
        public void RevealFirstCard()
        {

            // clear first card body
            GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1, this.PlayfieldPositionTop + 2, "     ", 16);
            GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1, this.PlayfieldPositionTop + 3, "     ", 16);
            GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1, this.PlayfieldPositionTop + 4, "     ", 16);

            // draw first cards content
            if (this.HandcardSuit[0] == "♦" | this.HandcardSuit[0] == "♥")
            {
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 5, this.PlayfieldPositionTop + 2, this.HandcardSuit[0], 13);
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1, this.PlayfieldPositionTop + 4, this.HandcardSuit[0], 13);
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 2, this.PlayfieldPositionTop + 3, this.HandcardNumber[0], 13);
            }
            else if (this.HandcardSuit[0] == "■")
            {
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 5, this.PlayfieldPositionTop + 2, this.HandcardSuit[0], 3);
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1, this.PlayfieldPositionTop + 4, this.HandcardSuit[0], 3);
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 2, this.PlayfieldPositionTop + 3, this.HandcardNumber[0], 3);
            }
            else
            {
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 5, this.PlayfieldPositionTop + 2, this.HandcardSuit[0], 16);
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1, this.PlayfieldPositionTop + 4, this.HandcardSuit[0], 16);
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 2, this.PlayfieldPositionTop + 3, this.HandcardNumber[0], 16);
            }
            this.CalculateHandvalue();
            GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft, this.PlayfieldPositionTop + 6, "                                                                                                             ", 16);
            GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft, this.PlayfieldPositionTop + 6, $"{this.Name} got {this.Handvalue}", 16);
            GUI.PlayRevealCardSound();
            Thread.Sleep(1000);
        }


        // calculates only his second card and say handvalue (= card 2 value)
        private void CalculateOnlySecondCardAndSayHandValue()
        {
            // calculating only second card
            this.Handvalue = 0;
            switch (this.HandcardNumber[1])
            {
                case " 2":
                    this.Handvalue = this.Handvalue + 2;
                    break;
                case " 3":
                    this.Handvalue = this.Handvalue + 3;
                    break;
                case " 4":
                    this.Handvalue = this.Handvalue + 4;
                    break;
                case " 5":
                    this.Handvalue = this.Handvalue + 5;
                    break;
                case " 6":
                    this.Handvalue = this.Handvalue + 6;
                    break;
                case " 7":
                    this.Handvalue = this.Handvalue + 7;
                    break;
                case " 8":
                    this.Handvalue = this.Handvalue + 8;
                    break;
                case " 9":
                    this.Handvalue = this.Handvalue + 9;
                    break;
                case "10":
                    this.Handvalue = this.Handvalue + 10;
                    break;
                case " J":
                    this.Handvalue = this.Handvalue + 10;
                    break;
                case " Q":
                    this.Handvalue = this.Handvalue + 10;
                    break;
                case " K":
                    this.Handvalue = this.Handvalue + 10;
                    break;
                case " A":
                    this.Handvalue = this.Handvalue + 11;
                    break;
                default:
                    break;
            }

            // write handvalue without first card
            GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft, this.PlayfieldPositionTop + 6, $"{this.Name} got {this.Handvalue}", 16);
            Thread.Sleep(1000);

        }


        // draws first card faced down and second card faced up
        private void GUIDrawDealersFirstTwoCards()
        {
            // GUI draw first card faced down
            int move = 0;
            GUI.DrawBorder(this.PlayfieldPositionLeft + 1 + move, this.PlayfieldPositionTop + 2, 5, 7, 1, 16);
            GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1 + move, this.PlayfieldPositionTop + 2, "░░░░░", 16);
            GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1 + move, this.PlayfieldPositionTop + 3, "░░░░░", 16);
            GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1 + move, this.PlayfieldPositionTop + 4, "░░░░░", 16);
            GUI.PlayDrawCardSound();
            Thread.Sleep(500);

            // GUI draw second card faced up
            move = 8;
            GUI.DrawBorder(this.PlayfieldPositionLeft + 1 + move, this.PlayfieldPositionTop + 2, 5, 7, 1, 16);
            if (this.HandcardSuit[1] == "♦" | this.HandcardSuit[1] == "♥")
            {
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 5 + move, this.PlayfieldPositionTop + 2, this.HandcardSuit[1], 13);
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1 + move, this.PlayfieldPositionTop + 4, this.HandcardSuit[1], 13);
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 2 + move, this.PlayfieldPositionTop + 3, this.HandcardNumber[1], 13);
            }
            else if (this.HandcardSuit[1] == "■")
            {
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 5 + move, this.PlayfieldPositionTop + 2, this.HandcardSuit[1], 3);
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1 + move, this.PlayfieldPositionTop + 4, this.HandcardSuit[1], 3);
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 2 + move, this.PlayfieldPositionTop + 3, this.HandcardNumber[1], 3);
            }
            else
            {
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 5 + move, this.PlayfieldPositionTop + 2, this.HandcardSuit[1], 16);
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1 + move, this.PlayfieldPositionTop + 4, this.HandcardSuit[1], 16);
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 2 + move, this.PlayfieldPositionTop + 3, this.HandcardNumber[1], 16);
            }
            GUI.PlayDrawCardSound();
            this.CalculateOnlySecondCardAndSayHandValue();
        }

    }
}
