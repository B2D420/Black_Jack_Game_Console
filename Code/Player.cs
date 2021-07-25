using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BlackJack
{
    class Player
    {
        public string Name;
        public float Money;
        public float TotalMoneyPaidInThisSession;
        public bool IsDealer = false;
        public float CurrentBet;
        public int Handvalue;
        public int AceCounter;
        public int PlayfieldPositionLeft;
        public int PlayfieldPositionTop;

        public List<String> HandcardNumber = new List<String>();
        public List<String> HandcardSuit = new List<String>();

        // draws a card, calculates handvalue, draws own playfield, plays drawing sound and sleeps
        public void DrawCard()
        {
            this.HandcardNumber.Add(Cards.GenerateCardValue());
            this.HandcardSuit.Add(Cards.GenerateCardSuit());
            this.CalculateHandvalue();
            this.DrawPlayfield();
            GUI.PlayDrawCardSound();
            Thread.Sleep(500);
        }

        // draws a specific card. used for debugging. specific cards are neither red nor black cards, instead they are differently colored and have an own suit (■)
        public void DrawSpecificCard(string card)
        {
            switch (card)
            {
                case "2":
                    this.HandcardNumber.Add(" 2");
                    break;
                case "3":
                    this.HandcardNumber.Add(" 3");
                    break;
                case "4":
                    this.HandcardNumber.Add(" 4");
                    break;
                case "5":
                    this.HandcardNumber.Add(" 5");
                    break;
                case "6":
                    this.HandcardNumber.Add(" 6");
                    break;
                case "7":
                    this.HandcardNumber.Add(" 7");
                    break;
                case "8":
                    this.HandcardNumber.Add(" 8");
                    break;
                case "9":
                    this.HandcardNumber.Add(" 9");
                    break;
                case "10":
                    this.HandcardNumber.Add("10");
                    break;
                case "J":
                    this.HandcardNumber.Add(" J");
                    break;
                case "Q":
                    this.HandcardNumber.Add(" Q");
                    break;
                case "K":
                    this.HandcardNumber.Add(" K");
                    break;
                case "A":
                    this.HandcardNumber.Add(" A");
                    break;
                default:
                    break;
            }
            this.HandcardSuit.Add("■");
            this.CalculateHandvalue();
            this.DrawPlayfield();
            GUI.PlayDrawCardSound();
            Thread.Sleep(500);
        }

        // calculates the players handvalue. ace is either 1 or 11. depends on what is better for the player
        public void CalculateHandvalue()
        {
            this.Handvalue = 0;
            this.AceCounter = 0;

            for (int i = 0; i < this.HandcardNumber.Count; i++)
            {
                switch (this.HandcardNumber[i])
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
                        this.AceCounter++;
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < this.AceCounter; i++)
            {
                if (this.Handvalue <= 10)
                {
                    this.Handvalue = this.Handvalue + 11;
                }
                else
                {
                    this.Handvalue = this.Handvalue + 1;
                }
            }

            
        }

        // resets handvalue, acecounter, handcards and current bet
        public void ResetHand()
        {
            this.Handvalue = 0;
            this.AceCounter = 0;
            this.HandcardNumber.Clear();
            this.HandcardSuit.Clear();
            this.CurrentBet = 0;
        }

        // draws the players playfield
        public void DrawPlayfield()
        {
            // draw text
            GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft, this.PlayfieldPositionTop, $"{this.Name}'s Hand", 13);

            if (this.Handvalue > 0)
            {
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft, this.PlayfieldPositionTop + 6, $"{this.Name} got {this.Handvalue}", 16);
            }

            
            // gui draw cards
            int move = 0;
            for (int i = 0; i < this.HandcardNumber.Count(); i++, move = move + 8)
            {
                GUI.DrawBorder(this.PlayfieldPositionLeft + 1 + move, this.PlayfieldPositionTop + 2, 5, 7, 1, 16);

                // if suit is ♦ or ♥ it draws them red
                // else if suit is ■ (Specific Card) it draws it green
                // else it draws them white
                if (this.HandcardSuit[i] == "♦" | this.HandcardSuit[i] == "♥")
                {
                    GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 5 + move, this.PlayfieldPositionTop + 2, this.HandcardSuit[i], 13);
                    GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1 + move, this.PlayfieldPositionTop + 4, this.HandcardSuit[i], 13);
                    GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 2 + move, this.PlayfieldPositionTop + 3, this.HandcardNumber[i], 13);
                }
                else if (this.HandcardSuit[i] == "■")
                {
                    GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 5 + move, this.PlayfieldPositionTop + 2, this.HandcardSuit[i], 3);
                    GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1 + move, this.PlayfieldPositionTop + 4, this.HandcardSuit[i], 3);
                    GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 2 + move, this.PlayfieldPositionTop + 3, this.HandcardNumber[i], 3);
                }
                else
                {
                    GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 5 + move, this.PlayfieldPositionTop + 2, this.HandcardSuit[i], 16);
                    GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 1 + move, this.PlayfieldPositionTop + 4, this.HandcardSuit[i], 16);
                    GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 2 + move, this.PlayfieldPositionTop + 3, this.HandcardNumber[i], 16);
                }

            }

            // draw balance, bet and money spent in this session if is not dealer
            if (this.IsDealer == false)
            {
                // draw current bet
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 45, this.PlayfieldPositionTop, $"Current bet is {this.CurrentBet}$", 3);

                // draw balance text
                GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 85, this.PlayfieldPositionTop, $"Your Balance is {this.Money}$", 11);

                // draw money which was spent in this session
                GUI.ConsoleWriteInColorWithPosition(5, 1 , $"Total money spent in this session: {this.TotalMoneyPaidInThisSession}$", 12);
            }
        }

        // player draws to handcards
        public void Start()
        {
            this.DrawCard();
            this.DrawCard();
        }

        // asks for players bet.
        public void AskForBet()
        {
            // draw asking for bet window above current round bet
            Console.CursorVisible = false;
            GUI.DrawBorder(this.PlayfieldPositionLeft + 37, this.PlayfieldPositionTop, 4, 38, 1, 16);
            GUI.ConsoleWriteInColorWithPosition(this.PlayfieldPositionLeft + 38, this.PlayfieldPositionTop, "How much money do you want to bet?", 9);
            Console.SetCursorPosition(this.PlayfieldPositionLeft + 38, this.PlayfieldPositionTop + 1);
            Console.CursorVisible = true;

            //reads what amount player wants to bet
            string PlayerInput = Console.ReadLine();

            // if player writes a float, check his money and set bet
                // if player has enough money, let him bet and lower his money, 
                // else say not enough money and ask again
            // else, say that it is not a number and repeat the question
            if (float.TryParse(PlayerInput, out float ConvertedPlayerInput) & ConvertedPlayerInput >= 0.01f)
            {
                Console.CursorVisible = false;

                if (this.Money >= ConvertedPlayerInput)
                {
                    
                    this.CurrentBet = ConvertedPlayerInput;
                    this.Money = this.Money - this.CurrentBet;
                }
                else
                {
                    DeletePlayersBetInputAndAskAgain(PlayerInput.Length, "Cash Issue");
                }
            }
            else
            {
                DeletePlayersBetInputAndAskAgain(PlayerInput.Length, "Not a Number");
            } 
        }

        // asks for players name. if name is longer than 16 characters, says name is too long and asks again
        public void AskForName()
        {
            // draw standard border
            Console.CursorVisible = false;
            GUI.DrawStandardBorder();

            // asks for players name
            PlayerInputTextBox(1);
            this.Name = Console.ReadLine();

            // if name is longer than 16 characters, ask again
            if (this.Name.Length > 16)
            {
                GUI.WriteSameStringMultipleTimesWithPosition(" ", this.Name.Length, 7, 15);
                Console.CursorVisible = false;
                GUI.DrawStandardBorder();
                PlayerInputTextBox(1);
                GUI.FlashText("That's too long. Try again", 10, 17, 400, 3, 13);
                this.AskForName();
            }
            else
            {
                this.Name = this.Name.Trim();
            }
        }

        // asks for players balance
        public void AskForBalance()
        {
            // redraw ask for name
            Console.CursorVisible = false;
            GUI.DrawStandardBorder();
            PlayerInputTextBox(1);
            Console.CursorVisible = false;
            Console.Write(this.Name);

            //draw player balance textbox
            PlayerInputTextBox(2);

            // create player - actually ask the player for balance
            Console.CursorVisible = true;
            string PlayerInput = Console.ReadLine();
            Console.CursorVisible = false;
            float ConvertedPlayerInput;

            // if playerinput is a float, add to players money and add to totalmoneypaidinthissession, else delete input, give error message and ask again
            if (float.TryParse(PlayerInput, out ConvertedPlayerInput) & ConvertedPlayerInput >= 0.01f)
            {
                if (ConvertedPlayerInput > 1000000)
                {
                    GUI.WriteSameStringMultipleTimesWithPosition(" ", PlayerInput.Length, 81, 15);
                    GUI.DrawStandardBorder();
                    PlayerInputTextBox(1);
                    Console.WriteLine(this.Name);
                    PlayerInputTextBox(2);
                    GUI.FlashText("That's too much. Try again!", 83, 17, 400, 2, 13);
                    this.AskForBalance();
                }
                else
                {
                    this.TotalMoneyPaidInThisSession = this.TotalMoneyPaidInThisSession + ConvertedPlayerInput;
                    this.Money = ConvertedPlayerInput;
                }
            }
            else
            {
                GUI.WriteSameStringMultipleTimesWithPosition(" ", PlayerInput.Length, 81, 15);
                GUI.DrawStandardBorder();
                PlayerInputTextBox(1);
                Console.WriteLine(this.Name);
                PlayerInputTextBox(2);
                GUI.FlashText("That's not a Number. Try again!", 81, 17, 400, 2, 13);
                this.AskForBalance();
            }
        }

        // deletes Players Input in question for bet and asks again for bet
        private void DeletePlayersBetInputAndAskAgain(int PlayerInputLength, string MessageType)
        {
            Console.SetCursorPosition(this.PlayfieldPositionLeft + 38, this.PlayfieldPositionTop + 1);
            for (int i = 0; i < PlayerInputLength; i++)
            {
                Console.Write(" ");
            }

            if (MessageType == "Cash Issue")
            {
                GUI.FlashText("You don't have enough Money. Try again.", 40, 16, 400, 3, 13);
            }
            else if (MessageType == "Not a Number")
            {
                GUI.FlashText("That's not a Number. Try again.", 44, 16, 400, 3, 13);
            }

            GUI.DrawStandardBorder();
            AskForBet();

        }

        // draws player input textboxes.
        // 1 for name textbox
        // 2 for balance textbox
        // 3 for currentbet textbox
        private void PlayerInputTextBox(int textboxtype)
        {
            if (textboxtype == 1)
            {
                GUI.DrawBorder(6, 14, 4, 35, 1, 16);
                Console.SetCursorPosition(11, 14);
                Console.Write("Please enter your name:");
                Console.SetCursorPosition(7, 15);

            }
            else if (textboxtype == 2)
            {
                GUI.DrawBorder(80, 14, 4, 35, 1, 16);
                Console.SetCursorPosition(80, 14);
                Console.Write("How much money are you paying in?");
                Console.SetCursorPosition(81, 15);
            }
            Console.CursorVisible = true;
        }
    }
}
