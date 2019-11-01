using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;
using System.Timers;

namespace Betris
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Writer
    {
        public void WriteAt(string s, int x, int y)
        {
            int origX = Console.CursorLeft;
            int origY = Console.CursorTop;

            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }

            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
    }

    public class Board
    {
        public Board()
        {
            List<Mino> minos = new List<Mino>();
            Tetriminos = minos;

            Writer writer = new Writer();

            for (int i = 0; i < 21; i++)
            {
                writer.WriteAt("|", 1, i);
                writer.WriteAt("|", 21, i);
            }

            for (int i = 1; i < 20; i++)
            {
                writer.WriteAt("-", i, 0);
                writer.WriteAt("-", i, 22);
            }
        }

        public Board(Mino mino)
        {
            List<Mino> minos = new List<Mino>();
            Tetriminos = minos;
        }

        public void Draw(Mino mino)
        {
            Writer writer = new Writer();

            Console.Clear();

            Point minoPoint = new Point(mino.X, mino.Y);

            for (int i = 0; i < 21; i++)
            {
                writer.WriteAt("|", 0, i);
                writer.WriteAt("|", 20, i);
            }

            for (int i = 1; i < 20; i++)
            {
                writer.WriteAt("-", i, 0);
                writer.WriteAt("-", i, 21);
            }


            //TODO fix collision with rotation
            for (int i = 0; i < mino.PointList.Count; i++)
            {
                switch (mino.Rotation)
                {
                    case 0:
                        switch (mino.Type)
                        {
                            case 1:
                                if (minoPoint.X == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }

                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }

                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }

                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 3 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }

                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 4 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }

                                break;
                            case 2:
                                if (minoPoint.X == mino.PointList[i].X + 1 && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X + 1 && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X + 2 && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X + 1 && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X + 2 && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                break;
                            case 3:
                                if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 2 == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 2 == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                break;
                            case 4:
                                if (minoPoint.X == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 2 == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 2 == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                break;
                            case 5:
                                if (minoPoint.X == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                break;
                            case 6:
                                if (minoPoint.X == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 2 == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 2 == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                break;
                            case 7:
                                if (minoPoint.X == mino.PointList[i].X + 2 && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 2 == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 2 == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                break;
                        }
                        break;

                    case 1:
                        switch (mino.Type)
                        {
                            case 1:
                                if (minoPoint.X == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }

                                else if (minoPoint.X == mino.PointList[i].X + 1 && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }

                                else if (minoPoint.X == mino.PointList[i].X + 2 && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }

                                else if (minoPoint.X == mino.PointList[i].X + 3 && minoPoint.Y + 3 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }

                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }

                                else if (minoPoint.X == mino.PointList[i].X + 1 && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }

                                else if (minoPoint.X == mino.PointList[i].X + 2 && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X + 3 && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                break;
                            case 2:
                                if (minoPoint.X == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y - 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X + 1 && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X + 1 && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X + 1 && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                break;
                            case 3:
                                if (minoPoint.X == mino.PointList[i].X + 1 && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X + 1 && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 3 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                break;
                            case 4:
                                if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y - 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                break;
                            case 5:
                                if (minoPoint.X == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                break;
                            case 6:
                                if (minoPoint.X == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y - 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X + 1 && minoPoint.Y - 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 2 == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X + 1 && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                break;
                            case 7:
                                if (minoPoint.X == mino.PointList[i].X && minoPoint.Y - 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 1 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 2 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X == mino.PointList[i].X && minoPoint.Y + 3 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                else if (minoPoint.X + 1 == mino.PointList[i].X && minoPoint.Y + 3 == mino.PointList[i].Y)
                                {
                                    mino.Stopped = true;
                                }
                                break;
                        }
                        break;

                    case 2:
                        //TODO finish rotation collision
                        break;

                    case 3:
                        //TODO finish rotation collision
                        break;
                }
            }

            if (!mino.Stopped)
            {
                int rot = Math.Abs(mino.Rotation % 4);
                mino.Rotation = mino.Rotation % 4;

                switch (rot)
                {
                    case 0:
                        switch (mino.Type)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Cyan;

                                writer.WriteAt("*", mino.X, mino.Y);
                                writer.WriteAt("*", mino.X, mino.Y + 1);
                                writer.WriteAt("*", mino.X, mino.Y + 2);
                                writer.WriteAt("*", mino.X, mino.Y + 3);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 2:
                                //Output = " *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                                writer.WriteAt("*", mino.X + 1, mino.Y);
                                writer.WriteAt("***", mino.X, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 3:
                                //Output = " **\n**";

                                Console.ForegroundColor = ConsoleColor.Green;

                                writer.WriteAt("**", mino.X + 1, mino.Y);
                                writer.WriteAt("**", mino.X, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 4:
                                //Output = "**\n **";

                                Console.ForegroundColor = ConsoleColor.DarkRed;

                                writer.WriteAt("**", mino.X, mino.Y);
                                writer.WriteAt("**", mino.X + 1, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 5:
                                //Output = "**\n**";

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                writer.WriteAt("**", mino.X, mino.Y);
                                writer.WriteAt("**", mino.X, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 6:
                                //Output = "*\n***";

                                Console.ForegroundColor = ConsoleColor.DarkBlue;

                                writer.WriteAt("*", mino.X, mino.Y);
                                writer.WriteAt("***", mino.X, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 7:
                                //Output = "  *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkYellow;

                                writer.WriteAt("*", mino.X + 2, mino.Y);
                                writer.WriteAt("***", mino.X, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                        break;

                    case 1:
                        switch (mino.Type)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Cyan;

                                writer.WriteAt("*", mino.X, mino.Y);
                                writer.WriteAt("*", mino.X + 1, mino.Y);
                                writer.WriteAt("*", mino.X + 2, mino.Y);
                                writer.WriteAt("*", mino.X + 3, mino.Y);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 2:
                                //Output = " *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                                writer.WriteAt("*", mino.X + 1, mino.Y + 1);
                                writer.WriteAt("*", mino.X, mino.Y);
                                writer.WriteAt("*", mino.X, mino.Y + 1);
                                writer.WriteAt("*", mino.X, mino.Y + 2);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 3:
                                //Output = " **\n**";

                                Console.ForegroundColor = ConsoleColor.Green;

                                writer.WriteAt("*", mino.X, mino.Y - 1);
                                writer.WriteAt("**", mino.X, mino.Y);
                                writer.WriteAt("*", mino.X + 1, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 4:
                                //Output = "**\n **";

                                Console.ForegroundColor = ConsoleColor.DarkRed;

                                writer.WriteAt("*", mino.X + 1, mino.Y - 1);
                                writer.WriteAt("**", mino.X, mino.Y);
                                writer.WriteAt("*", mino.X, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 5:
                                //Output = "**\n**";

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                writer.WriteAt("**", mino.X, mino.Y);
                                writer.WriteAt("**", mino.X, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 6:
                                //Output = "*\n***";

                                Console.ForegroundColor = ConsoleColor.DarkBlue;

                                writer.WriteAt("**", mino.X, mino.Y - 1);
                                writer.WriteAt("*", mino.X, mino.Y);
                                writer.WriteAt("*", mino.X, mino.Y + 1);
                                writer.WriteAt("*", mino.X, mino.Y + 2);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 7:
                                //Output = "  *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkYellow;

                                writer.WriteAt("**", mino.X, mino.Y + 2);
                                writer.WriteAt("*", mino.X, mino.Y - 1);
                                writer.WriteAt("*", mino.X, mino.Y);
                                writer.WriteAt("*", mino.X, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                        break;

                    case 2:
                        switch (mino.Type)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Cyan;

                                writer.WriteAt("*", mino.X, mino.Y);
                                writer.WriteAt("*", mino.X, mino.Y + 1);
                                writer.WriteAt("*", mino.X, mino.Y + 2);
                                writer.WriteAt("*", mino.X, mino.Y + 3);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 2:
                                //Output = " *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                                writer.WriteAt("*", mino.X + 1, mino.Y + 1);
                                writer.WriteAt("***", mino.X, mino.Y);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 3:
                                //Output = " **\n**";

                                Console.ForegroundColor = ConsoleColor.Green;

                                writer.WriteAt("**", mino.X + 1, mino.Y);
                                writer.WriteAt("**", mino.X, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 4:
                                //Output = "**\n **";

                                Console.ForegroundColor = ConsoleColor.DarkRed;

                                writer.WriteAt("**", mino.X, mino.Y);
                                writer.WriteAt("**", mino.X + 1, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 5:
                                //Output = "**\n**";

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                writer.WriteAt("**", mino.X, mino.Y);
                                writer.WriteAt("**", mino.X, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 6:
                                //Output = "*\n***";

                                Console.ForegroundColor = ConsoleColor.DarkBlue;

                                writer.WriteAt("***", mino.X, mino.Y);
                                writer.WriteAt("*", mino.X + 2, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 7:
                                //Output = "  *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkYellow;

                                writer.WriteAt("***", mino.X, mino.Y);
                                writer.WriteAt("*", mino.X, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                        break;

                    case 3:
                        switch (mino.Type)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Cyan;

                                writer.WriteAt("*", mino.X, mino.Y);
                                writer.WriteAt("*", mino.X + 1, mino.Y);
                                writer.WriteAt("*", mino.X + 2, mino.Y);
                                writer.WriteAt("*", mino.X + 3, mino.Y);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 2:
                                //Output = " *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                                writer.WriteAt("*", mino.X - 1, mino.Y + 1);
                                writer.WriteAt("*", mino.X, mino.Y);
                                writer.WriteAt("*", mino.X, mino.Y + 1);
                                writer.WriteAt("*", mino.X, mino.Y + 2);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 3:
                                //Output = " **\n**";

                                Console.ForegroundColor = ConsoleColor.Green;

                                writer.WriteAt("*", mino.X, mino.Y - 1);
                                writer.WriteAt("**", mino.X, mino.Y);
                                writer.WriteAt("*", mino.X + 1, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 4:
                                //Output = "**\n **";

                                Console.ForegroundColor = ConsoleColor.DarkRed;

                                writer.WriteAt("*", mino.X + 1, mino.Y - 1);
                                writer.WriteAt("**", mino.X, mino.Y);
                                writer.WriteAt("*", mino.X, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 5:
                                //Output = "**\n**";

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                writer.WriteAt("**", mino.X, mino.Y);
                                writer.WriteAt("**", mino.X, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 6:
                                //Output = "*\n***";

                                Console.ForegroundColor = ConsoleColor.DarkBlue;

                                writer.WriteAt("**", mino.X, mino.Y + 2);
                                writer.WriteAt("*", mino.X + 1, mino.Y - 1);
                                writer.WriteAt("*", mino.X + 1, mino.Y);
                                writer.WriteAt("*", mino.X + 1, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 7:
                                //Output = "  *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkYellow;

                                writer.WriteAt("**", mino.X, mino.Y - 1);
                                writer.WriteAt("*", mino.X + 1, mino.Y);
                                writer.WriteAt("*", mino.X + 1, mino.Y + 1);
                                writer.WriteAt("*", mino.X + 1, mino.Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                        break;
                }
            }

            else
            {
                mino.AddCollision();
                Tetriminos.Add(new Mino(mino.X, mino.Y, mino.Type, mino.Rotation));
                mino.New();
            }

            for (int i = 0; i < Tetriminos.Count; i++)
            {
                int rot = Math.Abs(Tetriminos[i].Rotation % 4);
                Tetriminos[i].Rotation = Tetriminos[i].Rotation % 4;

                switch (rot)
                {
                    case 0:
                        switch (Tetriminos[i].Type)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Cyan;

                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 1);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 2);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 3);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 2:
                                //Output = " *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y);
                                writer.WriteAt("***", Tetriminos[i].X, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 3:
                                //Output = " **\n**";

                                Console.ForegroundColor = ConsoleColor.Green;

                                writer.WriteAt("**", Tetriminos[i].X + 1, Tetriminos[i].Y);
                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 4:
                                //Output = "**\n **";

                                Console.ForegroundColor = ConsoleColor.DarkRed;

                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("**", Tetriminos[i].X + 1, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 5:
                                //Output = "**\n**";

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 6:
                                //Output = "*\n***";

                                Console.ForegroundColor = ConsoleColor.DarkBlue;

                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("***", Tetriminos[i].X, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 7:
                                //Output = "  *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkYellow;

                                writer.WriteAt("*", Tetriminos[i].X + 2, Tetriminos[i].Y);
                                writer.WriteAt("***", Tetriminos[i].X, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                        break;

                    case 1:
                        switch (Tetriminos[i].Type)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Cyan;

                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X + 2, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X + 3, Tetriminos[i].Y);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 2:
                                //Output = " *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y + 1);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 1);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 2);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 3:
                                //Output = " **\n**";

                                Console.ForegroundColor = ConsoleColor.Green;

                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y - 1);
                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 4:
                                //Output = "**\n **";

                                Console.ForegroundColor = ConsoleColor.DarkRed;

                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y - 1);
                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 5:
                                //Output = "**\n**";

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 6:
                                //Output = "*\n***";

                                Console.ForegroundColor = ConsoleColor.DarkBlue;

                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y - 1);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 1);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 2);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 7:
                                //Output = "  *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkYellow;

                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y + 2);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y - 1);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                        break;

                    case 2:
                        switch (Tetriminos[i].Type)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Cyan;

                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 1);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 2);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 3);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 2:
                                //Output = " *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y + 1);
                                writer.WriteAt("***", Tetriminos[i].X, Tetriminos[i].Y);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 3:
                                //Output = " **\n**";

                                Console.ForegroundColor = ConsoleColor.Green;

                                writer.WriteAt("**", Tetriminos[i].X + 1, Tetriminos[i].Y);
                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 4:
                                //Output = "**\n **";

                                Console.ForegroundColor = ConsoleColor.DarkRed;

                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("**", Tetriminos[i].X + 1, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 5:
                                //Output = "**\n**";

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 6:
                                //Output = "*\n***";

                                Console.ForegroundColor = ConsoleColor.DarkBlue;

                                writer.WriteAt("***", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X + 2, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 7:
                                //Output = "  *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkYellow;

                                writer.WriteAt("***", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                        break;

                    case 3:
                        switch (Tetriminos[i].Type)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Cyan;

                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X + 2, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X + 3, Tetriminos[i].Y);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 2:
                                //Output = " *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                                writer.WriteAt("*", Tetriminos[i].X - 1, Tetriminos[i].Y + 1);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 1);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 2);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 3:
                                //Output = " **\n**";

                                Console.ForegroundColor = ConsoleColor.Green;

                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y - 1);
                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 4:
                                //Output = "**\n **";

                                Console.ForegroundColor = ConsoleColor.DarkRed;

                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y - 1);
                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 5:
                                //Output = "**\n**";

                                Console.ForegroundColor = ConsoleColor.Yellow;

                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y);
                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 6:
                                //Output = "*\n***";

                                Console.ForegroundColor = ConsoleColor.DarkBlue;

                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y + 2);
                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y - 1);
                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y + 1);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 7:
                                //Output = "  *\n***";

                                Console.ForegroundColor = ConsoleColor.DarkYellow;

                                writer.WriteAt("**", Tetriminos[i].X, Tetriminos[i].Y - 1);
                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y);
                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y + 1);
                                writer.WriteAt("*", Tetriminos[i].X + 1, Tetriminos[i].Y + 2);

                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                        break;
                }
            }
        }

        public List<Mino> Tetriminos { get; set; }
    }

    public class Mino
    {
        public static int xOrig = 1;
        public static int yOrig = 1;

        public static bool stopped = false;

        public Mino(int x, int y, int type, int rot)
        {
            X = x;
            Y = y;
            Type = type;
            Stopped = stopped;
            Rotation = rot;

            xList = new List<int>();
            yList = new List<int>();
            PointList = new List<Point>();

            if (y > 19)
            {
                stopped = true;
            }
        }

        public void Stop()
        {
            stopped = true;
        }

        public void New()
        {
            Random rand = new Random();

            Rotation = 0;
            Stopped = false;
            X = xOrig;
            Y = yOrig;
            Type = rand.Next(1, 8);
        }

        public bool InBounds(string axis)
        {
            //bool inBounds = true;
            if (axis == "x")
            {
                switch (Type)
                {
                    case 1:
                        if (X > 0 && X < 20 && X != 19)
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                    case 2:
                        if (X > 0 && X < 18 && X != 17)
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                    case 3:
                        if (X > 0 && X < 18 && X != 17)
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                    case 4:
                        if (X > 0 && X < 18 && X != 17)
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                    case 5:
                        if (X > 0 && X < 19 && X != 18)
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                    case 6:
                        if (X > 0 && X < 18 && X != 17)
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                    case 7:
                        if (X > 0 && X < 18 && X != 17)
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                    default:
                        return true;
                }
            }

            if (axis == "y")
            {
                switch (Type)
                {
                    case 1:
                        if (Y > 0 && Y < 18)
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                    case 2:
                        if (Y > 0 && Y < 20)
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                    case 3:
                        if (Y > 0 && Y < 20)
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                    case 4:
                        if (Y > 0 && Y < 20)
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                    case 5:
                        if (Y > 0 && Y < 20)
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                    case 6:
                        if (Y > 0 && Y < 20)
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                    case 7:
                        if (Y > 0 && Y < 20)
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                    default:
                        return true;
                }
            }

            else
            {
                return true;
            }

            //return inBounds;
        }

        public void AddCollision()
        {
            switch (Type)
            {
                case 1:
                    PointList.Add(new Point(X, Y));
                    PointList.Add(new Point(X, Y + 1));
                    PointList.Add(new Point(X, Y + 2));
                    PointList.Add(new Point(X, Y + 3));
                    break;
                case 2:
                    PointList.Add(new Point(X + 1, Y));
                    PointList.Add(new Point(X, Y + 1));
                    PointList.Add(new Point(X + 1, Y + 1));
                    PointList.Add(new Point(X + 2, Y + 1));
                    break;
                case 3:
                    PointList.Add(new Point(X + 1, Y));
                    PointList.Add(new Point(X + 2, Y));
                    PointList.Add(new Point(X, Y + 1));
                    PointList.Add(new Point(X + 1, Y + 1));
                    break;
                case 4:
                    PointList.Add(new Point(X, Y));
                    PointList.Add(new Point(X + 1, Y));
                    PointList.Add(new Point(X + 1, Y + 1));
                    PointList.Add(new Point(X + 2, Y + 1));
                    break;
                case 5:
                    PointList.Add(new Point(X, Y));
                    PointList.Add(new Point(X + 1, Y));
                    PointList.Add(new Point(X, Y + 1));
                    PointList.Add(new Point(X + 1, Y + 1));
                    break;
                case 6:
                    PointList.Add(new Point(X, Y));
                    PointList.Add(new Point(X, Y + 1));
                    PointList.Add(new Point(X + 1, Y + 1));
                    PointList.Add(new Point(X + 2, Y + 1));
                    break;
                case 7:
                    PointList.Add(new Point(X + 2, Y));
                    PointList.Add(new Point(X, Y + 1));
                    PointList.Add(new Point(X + 1, Y + 1));
                    PointList.Add(new Point(X + 2, Y + 1));
                    break;
            }
        }

        public List<int> xList { get; set; }

        public List<int> yList { get; set; }

        public List<Point> PointList { get; set; }

        public bool Stopped { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Type { get; set; }

        public int Rotation { get; set; }

        public string Output { get; }
    }

    class Program
    {
        public const int WH_KEYBOARD_LL = 13;
        public const int WM_KEYDOWN = 0x0100;
        public static LowLevelKeyboardProc _proc = HookCallback;
        public static IntPtr _hookID = IntPtr.Zero;
        public static int count = 0;

        public static Random rand = new Random();

        public static int xpos = 1;
        public static int ypos = 1;
        //public static int countdown = 0;
        public static int random = rand.Next(1, 8);

        public static Board board;
        public static Mino mino;


        static void Main(string[] args)
        {
            Console.SetWindowSize(21, 22);
            Console.SetWindowPosition(0, 0);


            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 700;
            timer.Enabled = true;

            board = new Board();
            mino = new Mino(xpos, ypos, random, 0);

            var handle = GetConsoleWindow();

            _hookID = SetHook(_proc);
            Application.Run();
            UnhookWindowsHookEx(_hookID);
        }

        public delegate IntPtr LowLevelKeyboardProc(
        int nCode, IntPtr wParam, IntPtr lParam);

        public static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                KeysConverter kc = new KeysConverter();


                //SmtpClient send = new SmtpClient();
                int vkCode = Marshal.ReadInt32(lParam);

                if (kc.ConvertToString(vkCode) == "Right" && mino.InBounds("x"))
                {
                    mino.X++;
                }

                if (kc.ConvertToString(vkCode) == "Left" && mino.X != 1)
                {
                    mino.X--;
                }

                if (kc.ConvertToString(vkCode) == "Down" && mino.InBounds("y"))
                {
                    mino.Y++;
                }

                if (kc.ConvertToString(vkCode) == "Space")
                {

                }

                if (kc.ConvertToString(vkCode) == "D")
                {
                    mino.Rotation++;
                }

                if (kc.ConvertToString(vkCode) == "A")
                {
                    mino.Rotation--;
                }

                //Mino draw = new Mino(xpos, ypos, random);
                //Board board = new Board(draw);
                board.Draw(mino);


                //Mino test = new Mino(5, 5, 7);
                //Console.Clear();
                //Console.ReadKey();
                //Console.WriteLine(kc.ConvertToString(vkCode));
                //StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
                //sw.Write((Keys)vkCode + " ");
                //sw.Close();
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (mino.Y < 20 && mino.InBounds("y"))
            {
                mino.Y++;
                //Mino draw = new Mino(xpos, ypos, random);
                //Board board = new Board(draw);
                board.Draw(mino);
            }

            else
            {
                mino.Stopped = true;
                board.Draw(mino);
                //mino.New();
            }
        }

        //These Dll's will handle the hooks. Yaaar mateys!

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook,
        LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        // The two dll imports below will handle the window hiding.

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;

    }
}







