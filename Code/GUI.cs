using System;
using System.Threading;

namespace BlackJack
{
    static class GUI
    {
        // color switch
        /// <COLOR_CODES>
        ///     1  =   Black
        ///     2  =   DarkBlue
        ///     3  =   DarkGreen
        ///     4  =   DarkCyan
        ///     5  =   DarkRed
        ///     6  =   DarkMagenta
        ///     7  =   DarkYellow
        ///     8  =   Gray
        ///     9  =   DarkGray
        ///    10  =   Blue
        ///    11  =   Green
        ///    12  =   Cyan
        ///    13  =   Red
        ///    14  =   Magenta
        ///    15  =   Yellow
        ///    16  =   White
        /// </COLOR_CODES>
        private static void SwitchColor(int color)
        {


            switch (color)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 11:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 12:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 13:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 14:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 15:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 16:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    break;
            }
        }        


        // draw things
        public static void DrawBorder(int PositionLeft, int PositionTop, int SizeVertical, int SizeHorizontal, int SinglelineOrDoubleLine, int color)
        {
            //change color
            switch (color)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 11:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 12:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 13:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 14:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 15:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 16:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    break;
            }

            //declare and initialize strings
            string BorderEdge1 = null;
            string BorderEdge2 = null;
            string BorderEdge3 = null;
            string BorderEdge4 = null;
            string BorderHorizontal = null;
            string BorderVertical = null;

            //check which bordertype should be used
            if (SinglelineOrDoubleLine == 1)
            {
                BorderEdge1 = "┌";
                BorderEdge2 = "┐";
                BorderEdge3 = "└";
                BorderEdge4 = "┘";
                BorderHorizontal = "─";
                BorderVertical = "│";
            } 
            
            else if (SinglelineOrDoubleLine == 2)
            {
                BorderEdge1 = "╔";
                BorderEdge2 = "╗";
                BorderEdge3 = "╚";
                BorderEdge4 = "╝";
                BorderHorizontal = "═";
                BorderVertical = "║";
            }

            //draw first line of border
            Console.SetCursorPosition(PositionLeft - 1, PositionTop - 1);
            Console.Write(BorderEdge1);
            for (int i = 0; i < (SizeHorizontal - 2); i++)
            {
                Console.Write(BorderHorizontal);
            }
            Console.Write(BorderEdge2 + "\n");

            //draw middle lines of border
            for (int i = 0; i < (SizeVertical - 2) ; i++)
            {
                Console.SetCursorPosition(PositionLeft -1, (PositionTop + i));
                Console.Write(BorderVertical);
                Console.SetCursorPosition((PositionLeft -1 + SizeHorizontal -1), (PositionTop + i));
                Console.Write(BorderVertical + "\n");
            }

            //draw last line of border
            Console.SetCursorPosition((PositionLeft -1 ), (PositionTop + SizeVertical -2));
            Console.Write(BorderEdge3);
            for (int i = 0; i < (SizeHorizontal -2); i++)
            {
                Console.Write(BorderHorizontal);
            }
            Console.Write(BorderEdge4 + "\n");
            Console.ResetColor();
        }
        public static void DrawStandardBorder()
        {
            DrawBorder(4, 4, 24, 113, 2, 16);
        }
        public static void DrawWelcomeScreenBlackJack(string version, string author)
        {
            // set cursor to invisible and draw standard border
            Console.Clear();
            Console.CursorVisible = false;
            DrawStandardBorder();

            // draw welcome, gamename, versioninfo and authorinfo
            DrawPixelWelcomeTo(7, 7, 16);
            DrawPixelBlackJackBold(40, 15, 13);
            ConsoleWriteInColorWithPosition(100, 20, version, 9);
            ConsoleWriteInColorWithPosition(6, 25, "Written by " + author, 9);

            // play melody and wait for keypress
            PlayStartSound();
            FlashingTextAndWaitingForKeyPress("Press any Key to start the game", 42, 23, 500, 16);

            // Clear Screen
            Console.Clear();
        }
        public static void DrawGameOverScreenBlackJack()
        {
            Console.Clear();
            Console.CursorVisible = false;
            DrawStandardBorder();
            DrawPixelGameBold(5, 5, 5);
            DrawPixelOverBold(60, 13, 5);
            PlayGameOverSound();
            ConsoleWriteInColorWithPosition(39, 24, "Press \"r\" for replay or press \"x\" to exit", 16);
        }
        public static void DrawThanksForPlayingBlackJackScreen(string version, string author)
        {
            Console.Clear();
            Console.CursorVisible = false;
            DrawStandardBorder();
            DrawPixelThanksBold(6, 5, 16);
            DrawPixelForBold(83, 5, 16);
            DrawPixelPlayingBold(24, 12, 16);
            DrawPixelBlackJackBold(25, 19, 13);
            ConsoleWriteInColorWithPosition(85, 24, version, 9);
            ConsoleWriteInColorWithPosition(6, 25, "Written by " + author, 9);
            PlayGoodByeSound();
            Thread.Sleep(1000);
        }
        public static void WhatDoYouWantToDoTextBox(int PositionLeft, int PositionTop, int SingleLineOrDoubleLine, int ColorBorder, int ColorText)
        {
            GUI.DrawBorder(PositionLeft, PositionTop, 6, 27, SingleLineOrDoubleLine, ColorBorder);
            GUI.ConsoleWriteInColorWithPosition(PositionLeft + 1, PositionTop, "What do you want to do?", ColorText);
            GUI.ConsoleWriteInColorWithPosition(PositionLeft + 3, PositionTop + 1, "Press \"h\" for    hit", ColorText);
            GUI.ConsoleWriteInColorWithPosition(PositionLeft + 3, PositionTop + 2, "Press \"s\" for  stand", ColorText);
            GUI.ConsoleWriteInColorWithPosition(PositionLeft + 3, PositionTop + 3, "Press \"d\" for double", ColorText);
        }
        public static void DrawDisclaimer()
        {
            int TypingSpeed = 1;

            Console.Clear();
            Console.CursorVisible = false;
            DrawStandardBorder();
            DrawPixelDisclaimerBold(30, 5, 9);

            TypeLetterByLetter("I wrote this game to learn coding in C#. You can't play this game with real money.", TypingSpeed, 18, 14, 9);
            Thread.Sleep(200);
            TypeLetterByLetter("Nonetheless should you, or a loved one might be dealing with a gambling problem,", TypingSpeed, 19, 16, 9);
            Thread.Sleep(200);
            TypeLetterByLetter("I highly recommend to look for help.", TypingSpeed, 40, 17, 9);
            Thread.Sleep(200);
            TypeLetterByLetter("You should play responsibly, and not risk money that you can't afford to lose.", TypingSpeed, 20, 18, 9);
            Thread.Sleep(200);
            TypeLetterByLetter("If you're under the age of 21, please close this game. This is not a game for kids.", TypingSpeed, 18, 20, 9);
            Thread.Sleep(1000);


            ConsoleWriteInColorWithPosition(47, 23, "Press \"C\" to continue", 16);
            ConsoleWriteInColorWithPosition(49, 24, "Press \"X\" to exit", 16);
        }

        // draw pixel text
        private static void DrawPixelDisclaimerBold(int PositionLeft, int PositionTop, int color)
        {
            SwitchColor(color);

            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write("▓▓▓▓   ▓  ▓▓▓▓▓  ▓▓▓▓▓  ▓       ▓▓▓   ▓  ▓▓ ▓▓  ▓▓▓▓▓  ▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 1);
            Console.Write("▓  ▓▓  ▓  ▓      ▓      ▓      ▓   ▓  ▓  ▓▓ ▓▓  ▓      ▓   ▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 2);
            Console.Write("▓   ▓  ▓  ▓      ▓      ▓      ▓   ▓  ▓  ▓▓ ▓▓  ▓      ▓   ▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 3);
            Console.Write("▓   ▓  ▓  ▓▓▓▓▓  ▓      ▓      ▓▓▓▓▓  ▓  ▓ ▓ ▓  ▓▓▓    ▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 4);
            Console.Write("▓   ▓  ▓      ▓  ▓      ▓      ▓   ▓  ▓  ▓   ▓  ▓      ▓▓   ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 5);
            Console.Write("▓  ▓▓  ▓      ▓  ▓      ▓      ▓   ▓  ▓  ▓   ▓  ▓      ▓ ▓▓ ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 6);
            Console.Write("▓▓▓▓   ▓  ▓▓▓▓▓  ▓▓▓▓▓  ▓▓▓▓▓  ▓   ▓  ▓  ▓   ▓  ▓▓▓▓▓  ▓   ▓");
            Console.ResetColor();
        }
        private static void DrawPixelWelcomeTo(int PositionLeft, int PositionTop, int color)
        {
            SwitchColor(color);

            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write("░  ░  ░   ░░░░   ░       ░░░░    ░░░    ░░   ░░   ░░░░      ░░░░░    ░░░ ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 1);
            Console.Write("░  ░  ░   ░      ░      ░░      ░░ ░░   ░ ░ ░ ░   ░           ░     ░░ ░░");
            Console.SetCursorPosition(PositionLeft, PositionTop + 2);
            Console.Write("░  ░  ░   ░░░    ░      ░       ░   ░   ░ ░ ░ ░   ░░░         ░     ░   ░");
            Console.SetCursorPosition(PositionLeft, PositionTop + 3);
            Console.Write("░  ░  ░   ░      ░      ░░      ░░ ░░   ░ ░ ░ ░   ░           ░     ░░ ░░");
            Console.SetCursorPosition(PositionLeft, PositionTop + 4);
            Console.Write(" ░░ ░░    ░░░░   ░░░░    ░░░░    ░░░    ░  ░  ░   ░░░░        ░      ░░░ ");
            Console.ResetColor();
        }
        private static void DrawPixelBlackJackBold(int PositionLeft, int PositionTop, int color)
        {
            SwitchColor(color);

            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write("▓▓▓▓    ▓         ▓      ▓▓▓▓   ▓  ▓▓      ▓▓▓▓▓     ▓      ▓▓▓▓   ▓  ▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 1);
            Console.Write("▓   ▓   ▓        ▓ ▓    ▓▓      ▓ ▓▓           ▓    ▓ ▓    ▓▓      ▓ ▓▓ ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 2);
            Console.Write("▓▓▓▓    ▓       ▓▓▓▓▓   ▓       ▓▓             ▓   ▓▓▓▓▓   ▓       ▓▓   ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 3);
            Console.Write("▓   ▓   ▓       ▓   ▓   ▓▓      ▓ ▓▓          ▓▓   ▓   ▓   ▓▓      ▓ ▓▓ ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 4);
            Console.Write("▓▓▓▓    ▓▓▓▓▓   ▓   ▓    ▓▓▓▓   ▓  ▓▓      ▓▓▓▓    ▓   ▓    ▓▓▓▓   ▓  ▓▓");
            Console.ResetColor();
        }
        private static void DrawPixelYouBold(int PositionLeft, int PositionTop, int color)
        {
            SwitchColor(color);

            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write("▓▓▓▓      ▓▓▓▓        ▓▓▓▓▓▓▓▓          ▓▓▓▓    ▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 1);
            Console.Write("▓▓▓▓      ▓▓▓▓      ▓▓▓▓▓▓▓▓▓▓▓▓        ▓▓▓▓    ▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 2);
            Console.Write("  ▓▓▓▓  ▓▓▓▓        ▓▓▓▓    ▓▓▓▓        ▓▓▓▓    ▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 3);
            Console.Write("   ▓▓▓▓▓▓▓▓         ▓▓▓▓    ▓▓▓▓        ▓▓▓▓    ▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 4);
            Console.Write("     ▓▓▓▓           ▓▓▓▓    ▓▓▓▓        ▓▓▓▓    ▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 5);
            Console.Write("     ▓▓▓▓           ▓▓▓▓    ▓▓▓▓        ▓▓▓▓    ▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 6);
            Console.Write("     ▓▓▓▓           ▓▓▓▓▓▓▓▓▓▓▓▓         ▓▓▓▓▓▓▓▓▓▓ ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 7);
            Console.Write("     ▓▓▓▓             ▓▓▓▓▓▓▓▓             ▓▓▓▓▓▓   ");
            Console.ResetColor();
        }
        private static void DrawPixelLostBold(int PositionLeft, int PositionTop, int color)
        {
            SwitchColor(color);

            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write("▓▓▓▓                  ▓▓▓▓▓▓▓▓            ▓▓▓▓▓▓▓▓▓▓        ▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 1);
            Console.Write("▓▓▓▓                ▓▓▓▓▓▓▓▓▓▓▓▓        ▓▓▓▓▓▓▓▓▓▓▓▓        ▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 2);
            Console.Write("▓▓▓▓                ▓▓▓▓    ▓▓▓▓        ▓▓▓▓                     ▓▓▓▓     ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 3);
            Console.Write("▓▓▓▓                ▓▓▓▓    ▓▓▓▓        ▓▓▓▓▓▓▓▓▓▓               ▓▓▓▓     ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 4);
            Console.Write("▓▓▓▓                ▓▓▓▓    ▓▓▓▓          ▓▓▓▓▓▓▓▓▓▓             ▓▓▓▓     ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 5);
            Console.Write("▓▓▓▓                ▓▓▓▓    ▓▓▓▓                ▓▓▓▓             ▓▓▓▓     ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 6);
            Console.Write("▓▓▓▓▓▓▓▓▓▓▓▓▓▓      ▓▓▓▓▓▓▓▓▓▓▓▓        ▓▓▓▓▓▓▓▓▓▓▓▓             ▓▓▓▓     ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 7);
            Console.Write("▓▓▓▓▓▓▓▓▓▓▓▓▓▓        ▓▓▓▓▓▓▓▓          ▓▓▓▓▓▓▓▓▓▓               ▓▓▓▓     ");
            Console.ResetColor();
        }
        private static void DrawPixelThanksBold(int PositionLeft, int PositionTop, int color)
        {
            SwitchColor(color);

            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write("▓▓▓▓▓▓▓▓   ▓      ▓     ▓▓▓▓     ▓▓     ▓   ▓     ▓▓   ▓▓▓▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 1);
            Console.Write("   ▓       ▓      ▓   ▓▓▓  ▓▓▓   ▓ ▓▓   ▓   ▓   ▓▓     ▓       ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 2);
            Console.Write("   ▓       ▓▓▓▓▓▓▓▓   ▓      ▓   ▓  ▓▓  ▓   ▓▓▓▓       ▓▓▓▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 3);
            Console.Write("   ▓       ▓      ▓   ▓▓▓▓▓▓▓▓   ▓   ▓▓ ▓   ▓   ▓▓            ▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 4);
            Console.Write("   ▓       ▓      ▓   ▓      ▓   ▓     ▓▓   ▓     ▓▓   ▓▓▓▓▓▓▓▓");
            Console.ResetColor();
        }
        private static void DrawPixelForBold(int PositionLeft, int PositionTop, int color)
        {
            SwitchColor(color);

            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write("▓▓▓▓▓▓▓▓   ▓▓▓▓▓▓▓▓   ▓▓▓▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 1);
            Console.Write("▓          ▓      ▓   ▓      ▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 2);
            Console.Write("▓▓▓▓▓      ▓      ▓   ▓▓▓▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 3);
            Console.Write("▓          ▓      ▓   ▓▓▓▓    ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 4);
            Console.Write("▓          ▓▓▓▓▓▓▓▓   ▓   ▓▓▓▓");
            Console.ResetColor();
        }
        private static void DrawPixelPlayingBold(int PositionLeft, int PositionTop, int color)
        {
            SwitchColor(color);

            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write("▓▓▓▓▓▓▓▓   ▓            ▓▓▓▓     ▓▓    ▓▓      ▓▓      ▓▓     ▓   ▓▓▓▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 1);
            Console.Write("▓      ▓   ▓          ▓▓▓  ▓▓▓    ▓▓  ▓▓       ▓▓      ▓ ▓▓   ▓   ▓       ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 2);
            Console.Write("▓▓▓▓▓▓▓▓   ▓          ▓      ▓      ▓▓         ▓▓      ▓  ▓▓  ▓   ▓    ▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 3);
            Console.Write("▓          ▓          ▓▓▓▓▓▓▓▓      ▓▓         ▓▓      ▓   ▓▓ ▓   ▓      ▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 4);
            Console.Write("▓          ▓▓▓▓▓▓▓▓   ▓      ▓      ▓▓         ▓▓      ▓     ▓▓   ▓▓▓▓▓▓▓▓");
            Console.ResetColor();
        }
        private static void DrawPixelGameBold(int PositionLeft, int PositionTop, int color)
        {
            SwitchColor(color);

            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write("▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓▓▓  ▓▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 1);
            Console.Write("▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 2);
            Console.Write("▓▓▓           ▓▓▓      ▓▓▓  ▓▓▓ ▓▓▓▓ ▓▓▓  ▓▓▓         ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 3);
            Console.Write("▓▓▓           ▓▓▓      ▓▓▓  ▓▓▓ ▓▓▓▓ ▓▓▓  ▓▓▓         ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 4);
            Console.Write("▓▓▓   ▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓  ▓▓  ▓▓▓  ▓▓▓▓▓▓▓▓▓   ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 5);
            Console.Write("▓▓▓   ▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓  ▓▓  ▓▓▓  ▓▓▓▓▓▓▓▓▓   ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 6);
            Console.Write("▓▓▓      ▓▓▓  ▓▓▓      ▓▓▓  ▓▓▓      ▓▓▓  ▓▓▓         ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 7);
            Console.Write("▓▓▓      ▓▓▓  ▓▓▓      ▓▓▓  ▓▓▓      ▓▓▓  ▓▓▓         ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 8);
            Console.Write("▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓      ▓▓▓  ▓▓▓      ▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 9);
            Console.Write("▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓      ▓▓▓  ▓▓▓      ▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.ResetColor();
        }
        private static void DrawPixelOverBold(int PositionLeft, int PositionTop, int color)
        {
            SwitchColor(color);

            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write("▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓      ▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 1);
            Console.Write("▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓      ▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 2);
            Console.Write("▓▓▓      ▓▓▓  ▓▓▓      ▓▓▓  ▓▓▓           ▓▓▓      ▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 3);
            Console.Write("▓▓▓      ▓▓▓  ▓▓▓      ▓▓▓  ▓▓▓           ▓▓▓      ▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 4);
            Console.Write("▓▓▓      ▓▓▓  ▓▓▓      ▓▓▓  ▓▓▓▓▓▓▓▓▓     ▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 5);
            Console.Write("▓▓▓      ▓▓▓  ▓▓▓      ▓▓▓  ▓▓▓▓▓▓▓▓▓     ▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.SetCursorPosition(PositionLeft, PositionTop + 6);
            Console.Write("▓▓▓      ▓▓▓   ▓▓▓    ▓▓▓   ▓▓▓           ▓▓▓▓▓▓      ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 7);
            Console.Write("▓▓▓      ▓▓▓    ▓▓▓  ▓▓▓    ▓▓▓           ▓▓▓  ▓▓▓    ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 8);
            Console.Write("▓▓▓▓▓▓▓▓▓▓▓▓     ▓▓▓▓▓▓     ▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓    ▓▓▓  ");
            Console.SetCursorPosition(PositionLeft, PositionTop + 9);
            Console.Write("▓▓▓▓▓▓▓▓▓▓▓▓       ▓▓       ▓▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓      ▓▓▓");
            Console.ResetColor();
        }


        // draw console text with extra variables
        public static void ConsoleWriteInColorWithPosition(int PositionLeft, int PositionTop, string Text, int color)
        {
            SwitchColor(color);

            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write(Text);
            Console.ResetColor();
        }
        public static void FlashingTextAndWaitingForKeyPress(string Text, int PositionLeft, int PositionTop, int BlinkInterval, int color)
        {
            SwitchColor(color);

            do
            {
                FlashText(Text, PositionLeft, PositionTop, BlinkInterval, 1, color);

                if (Console.KeyAvailable == true)
                {
                    Console.ReadKey(true);
                    break;
                }
            } while (Console.KeyAvailable == false);
            Console.ResetColor();
            
        }
        public static void FlashText (string Text, int PositionLeft, int PositionTop, int BlinkInterval, int BlinkAmount, int color)
        {
            Console.CursorVisible = false;
            switch (color)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 11:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 12:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 13:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 14:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 15:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 16:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    break;
            }

            for (int i = 0; i < BlinkAmount; i++)
            {
                int TextLenght = Text.Length;

                Console.SetCursorPosition(PositionLeft, PositionTop);
                Console.Write(Text);
                Console.SetCursorPosition(PositionLeft, PositionTop);
                Thread.Sleep(BlinkInterval);

                for (int x = 0; x < TextLenght; x++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(PositionLeft, PositionTop);
                Thread.Sleep(BlinkInterval);
            }

            Console.ResetColor();
        }
        public static void ConsoleWriteInColor(string Text, int color)
        {
            SwitchColor(color);
            Console.Write(Text);
            Console.ResetColor();
        }
        public static void ConsoleWriteLineInColor(string Text, int color)
        {
            SwitchColor(color);
            Console.WriteLine(Text);
            Console.ResetColor();
        }
        public static void WriteSameStringMultipleTimesWithPosition(string String, int RepeatAmount, int PositionLeft, int PositionTop)
        {
            Console.SetCursorPosition(PositionLeft, PositionTop);
            for (int i = 0; i < RepeatAmount; i++)
            {
                Console.Write(String);
            }
        }
        public static void TypeLetterByLetter(string String, int TypingSpeed, int PositionLeft, int PositionTop, int color)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < String.Length; i++)
            {
                ConsoleWriteInColorWithPosition(PositionLeft, PositionTop, Convert.ToString(String[i]), color);
                Thread.Sleep(TypingSpeed);
                PositionLeft++;
            }
        }
        public static void TypeLetterByLetterAndMakeSound(string String, int TypingSpeed, int SoundFrequenzy, int PositionLeft, int PositionTop, int color)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < String.Length; i++)
            {
                ConsoleWriteInColorWithPosition(PositionLeft, PositionTop, Convert.ToString(String[i]), color);
                Console.Beep(SoundFrequenzy, 1);
                Thread.Sleep(TypingSpeed);
                PositionLeft++;
            }
        }

        // play sound
        public static void PlayStartSound()
        {
            Console.Beep(130, 200);
            Console.Beep(165, 200);
            Console.Beep(196, 200);
            Console.Beep(261, 400);
        }
        public static void PlayDrawCardSound()
        {
            Console.Beep(300, 100);
        }
        public static void PlayRevealCardSound()
        {
            Console.Beep(275, 25);
            Console.Beep(275, 25);
        }
        public static void PlayRoundWinSound()
        {
            Console.Beep(150, 75);
            Console.Beep(175, 50);
            Console.Beep(200, 50);
            Console.Beep(350, 300);
        }
        public static void PlayRoundLoseSound()
        {
            Console.Beep(200, 75);
            Console.Beep(175, 50);
            Console.Beep(150, 50);
            Console.Beep(100, 300);
        }
        public static void PlayRoundPushSound()
        {
            Console.Beep(200, 75);
            Console.Beep(200, 75);
            Console.Beep(200, 75);
        }
        public static void PlayGameOverSound()
        {
            Console.Beep(200, 300);
            Console.Beep(175, 150);
            Console.Beep(150, 150);
            Console.Beep(100, 750);
        }
        public static void PlayGoodByeSound()
        {
            Console.Beep(200, 300);
            Console.Beep(250, 200);
            Console.Beep(300, 200);
            Console.Beep(200, 300);
            Console.Beep(175, 150);
            Console.Beep(150, 150);
            Console.Beep(100, 750);
        }
    }
}
