using System;
using System.Threading;

namespace BlackJack
{
    class Program
    {
        static void Main()
        {
            // version and author of the game for easy change
            string version = "version 1.0.0";
            string author = "alpha-kappa";
            string versionshort = "v" + version.Substring(8);

            Console.Title = $"BlackJack {versionshort}";

            // create dealer and player
            Dealer Dealer = new Dealer();
            Player Player1 = new Player() { PlayfieldPositionLeft = 5, PlayfieldPositionTop = 13 };

            // draw welcome to blackjack screen
            GUI.DrawWelcomeScreenBlackJack(version, author);

            GUI.DrawDisclaimer();
            if (PlayOrExit())
            {
                // ask player for name and balance
                Player1.AskForName();
                Player1.AskForBalance();

                // player can play as long as he got money. If he wants to play another round, let him pay in and start another round
                PlayUntilPlayerRunsOutOfMoneyThenReplayOrQuit(Player1, Dealer);

                // draws thanksforplayingblackjack screen and quits
                GUI.DrawThanksForPlayingBlackJackScreen(version, author);
            }
        }


        // returns true if Chooseoption should repeat, returns false if can go further
        private static bool ChooseOption(Player Player, Dealer Dealer)
        {
            GUI.WhatDoYouWantToDoTextBox(47, 21, 1, 9, 9);
            ConsoleKeyInfo whichbutton = Console.ReadKey(true);
            if (whichbutton.Key == ConsoleKey.H)
            {
                Player.DrawCard();
                if (CheckIfPlayerBust(Player, Dealer) == true)
                {
                    return false;
                }
                //let player choose another option if he didn't bust
                return true;
            }
            else if (whichbutton.Key == ConsoleKey.S)
            {
                EndGame(Player, Dealer);
                return false;
            }
            else if (whichbutton.Key == ConsoleKey.D)
            {
                if (Player.Money >= Player.CurrentBet)
                {
                    // delete old balance text 
                    int Playerbalancelenght = $"Your Balance is {Player.Money}$".Length;
                    Console.SetCursorPosition(Player.PlayfieldPositionLeft + 85, Player.PlayfieldPositionTop);
                    for (int x = 0; x < Playerbalancelenght; x++)
                    {
                        Console.Write(" ");
                    }

                    // calculate new balance and bet
                    Player.Money = Player.Money - Player.CurrentBet;
                    Player.CurrentBet = Player.CurrentBet * 2;

                    // redraw balance text
                    GUI.ConsoleWriteInColorWithPosition(Player.PlayfieldPositionLeft + 85, Player.PlayfieldPositionTop, $"Your Balance is {Player.Money}$", 11);

                    //draw last card
                    Player.DrawCard();
                    if (CheckIfPlayerBust(Player, Dealer) == true)
                    {
                        return false;
                    }
                    else
                    {
                        EndGame(Player, Dealer);
                        return false;
                    }
                } //if Player has enough money to double his bet, then let him do that, draw one last card and end his turn
                else
                {
                    GUI.FlashText("You don't have enough Money", 46, 19, 400, 2, 13);
                    return true;
                } //if Player doesn't have enough money go back to chooseoption
            }
            else
            {
                return ChooseOption(Player, Dealer);
            }

        }


        // if player has blackjack it says "blackjack", gives money and resets and gives back true , else returns false
        private static bool CheckIfPlayerBlackjack(Player Player, Dealer Dealer)
        {
            if (Player.Handvalue == 21)
            {
                Dealer.RevealFirstCard();
                GUI.ConsoleWriteInColorWithPosition(54, 19, "BlackJack!", 13);
                GUI.PlayRoundWinSound();
                Console.ReadKey(true);

                Player.Money = Player.Money + (2.5f * Player.CurrentBet);

                return true;
            }
            else return false;
        }


        // if handvalue of player is more than 21 it says "bust", resets and gives back true , else returns false
        private static bool CheckIfPlayerBust(Player Player, Dealer Dealer)
        {
            if (Player.Handvalue > 21)
            {
                Thread.Sleep(200);
                Dealer.RevealFirstCard();
                GUI.ConsoleWriteInColorWithPosition(57, 19, "Bust!", 13);
                GUI.PlayRoundLoseSound();
                Console.ReadKey(true);
                return true;
            }
            else return false;
        }


        // if player won, writes "You won!", plays win sound, gives player money and returns true, else false
        private static bool CheckIfPlayerWon(Player Player, Dealer Dealer)
        {
            // dealer bust or player hand is more than dealer hand => You Won
            if (Dealer.Handvalue > 21 | Dealer.Handvalue < Player.Handvalue)
            {
                GUI.ConsoleWriteInColorWithPosition(55, 19, "You won!", 11);
                GUI.PlayRoundWinSound();
                Player.Money = Player.Money + 2 * Player.CurrentBet;
                Console.ReadKey(true);
                return true;
            }
            else return false;
        }


        // if player lost, writes "You lost!", plays lose sound and returns true, else false
        private static bool CheckIfPlayerLost(Player Player, Dealer Dealer)
        {
            //dealer hand is more than player hand => You Lost
            if (Dealer.Handvalue > Player.Handvalue)
            {
                GUI.ConsoleWriteInColorWithPosition(55, 19, "You lost!", 13);
                GUI.PlayRoundLoseSound();
                Console.ReadKey(true);
                return true;
            }
            else return false;
        }


        // if player won, writes "Push", plays push sound, gives player money and returns true, else false
        private static bool CheckIfPush(Player Player, Dealer Dealer)
        {
            //dealer hand is same like player hand => Push
            if (Dealer.Handvalue == Player.Handvalue)
            {
                GUI.ConsoleWriteInColorWithPosition(57, 19, "Push", 13);
                GUI.PlayRoundPushSound();
                Player.Money = Player.Money + Player.CurrentBet;
                Console.ReadKey(true);
                return true;
            }
            else return false;
        }


        // dealer makes his turn, game checks who won and returns true when check is done.
        private static void EndGame(Player Player, Dealer Dealer)
        {
            // let dealer draw cards until 17
            Dealer.DoDealerThing();

            // check who won
            if (CheckIfPlayerWon(Player, Dealer))
            {
                goto End;
            }
            else if (CheckIfPlayerLost(Player, Dealer))
            {
                goto End;
            }
            else if (CheckIfPush(Player, Dealer))
            {
                goto End;
            }

            End:
            //reset hands
            Reset(Player, Dealer);
        }


        // reset all hands
        private static void Reset(Player Player, Dealer Dealer)
        {
            Player.ResetHand();
            Dealer.ResetHand();
        }


        // draw everything, ask for bet, let player and dealer draw two cards. If round is already over now returns true, else false
        private static bool RoundStart(Player Player, Dealer Dealer)
        {
            Console.Clear();
            GUI.DrawStandardBorder();
            Dealer.DrawPlayfield();
            Player.DrawPlayfield();
            Player.AskForBet();

            Console.Clear();
            GUI.DrawStandardBorder();
            Dealer.DrawPlayfield();
            Player.DrawPlayfield();

            // player draws two cards
            Player.Start();

            // dealer draws two cards and game checks if round is already over
            if (Dealer.DealerStart())
            {
                CheckIfPush(Player, Dealer);
                CheckIfPlayerLost(Player, Dealer);
                return true;
            }
            else return false;
        }


        // returns true if player wants to play another game, returns false if player wants to exit
        private static bool ReplayOrExit()
        {
            ConsoleKeyInfo replayorexit = Console.ReadKey(true);
            if (replayorexit.Key == ConsoleKey.R)
            {
                Console.Clear();
                return true;
            }
            else if (replayorexit.Key == ConsoleKey.X)
            {
                return false;
            }
            else
            {
                return ReplayOrExit();
            }
        }


        // game base. player can play as long as he got money, then asks if player wants to play another round. if yes returns true. if he wants to exit returns false
        private static void PlayUntilPlayerRunsOutOfMoneyThenReplayOrQuit(Player Player, Dealer Dealer)
        {

            while (Player.Money > 0)
            {

                // start the round
                if (RoundStart(Player, Dealer))
                {
                    goto endofround;
                }

                if (CheckIfPlayerBlackjack(Player, Dealer))
                {
                    goto endofround;
                }

                // as long as it's possible for player, he can choose an option
                while (ChooseOption(Player, Dealer))
                {
                }

            endofround:
                Reset(Player, Dealer);
            }

            // when player runs out of money : ask for another game
            GUI.DrawGameOverScreenBlackJack();
            if (ReplayOrExit())
            {
                Player.AskForBalance();
                PlayUntilPlayerRunsOutOfMoneyThenReplayOrQuit(Player, Dealer);
            }

        }


        // returns true if player wants to play, returns false if player wants to exit
        private static bool PlayOrExit()
        {
            ConsoleKeyInfo playorexit = Console.ReadKey(true);
            if (playorexit.Key == ConsoleKey.C)
            {
                Console.Clear();
                return true;
            }
            else if (playorexit.Key == ConsoleKey.X)
            {
                return false;
            }
            else
            {
                return PlayOrExit();
            }
        }
    }
}



