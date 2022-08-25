using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        //static int count = 0;

        //static byte[] num_byte = new byte[8] { 0x00, 0x38, 0x44, 0x04, 0x08, 0x10, 0x20, 0x7c };

        //static byte[,] num_byte_2 = new byte[10, 8] {
        //        {0x00,0x38,0x44,0x4c,0x54,0x64,0x44,0x38},
        //        {0x00,0x10,0x30,0x50,0x10,0x10,0x10,0x7c},
        //        {0x00,0x38,0x44,0x04,0x08,0x10,0x20,0x7c},
        //        {0x00,0x38,0x44,0x04,0x18,0x04,0x44,0x38},
        //        {0x00,0x08,0x18,0x28,0x48,0x7c,0x08,0x08},
        //        {0x00,0x7c,0x40,0x78,0x04,0x04,0x44,0x38},
        //        {0x00,0x38,0x40,0x40,0x78,0x44,0x44,0x38},
        //        {0x00,0x7c,0x04,0x08,0x10,0x20,0x20,0x20},
        //        {0x00,0x38,0x44,0x44,0x38,0x44,0x44,0x38},
        //        {0x00,0x38,0x44,0x44,0x3c,0x04,0x44,0x38}
        //    };

        static byte[,,] block_L = new byte[4, 4, 4] {
                                                    { {0,0,0,0},
                                                      {0,1,0,0},
                                                      {0,1,1,1},
                                                      {0,0,0,0} },

                                                    { {0,0,0,0},
                                                      {0,1,1,0},
                                                      {0,1,0,0},
                                                      {0,1,0,0} },

                                                    { {0,0,0,0},
                                                      {1,1,1,0},
                                                      {0,0,1,0},
                                                      {0,0,0,0} },

                                                    { {0,0,1,0},
                                                      {0,0,1,0},
                                                      {0,1,1,0},
                                                      {0,0,0,0} }};
        static byte[,] background = new byte[22, 12]    {
                                {1,1,1,1,1,1,1,1,1,1,1,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,0,0,0,0,0,0,0,0,0,0,1},
                                {1,1,1,1,1,1,1,1,1,1,1,1}
                                                         };

        static int x = 3;
        static int y = 1;
        static int rotate = 0;

        static void make_background()
        {
            int x_pos = 0;
            int y_pos = 0;
            for (int j = 0; j < 22; j++)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (background[j, i] == 1)
                    {
                        Console.SetCursorPosition(i + x_pos, j + y_pos);
                        Console.Write("*");
                    }
                    else
                    {
                        Console.SetCursorPosition(i + x_pos, j + y_pos);
                        Console.Write("_");
                    }
                }
            }
        }

        static void make_block()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (block_L[rotate, j, i] == 1)
                    {
                        Console.SetCursorPosition(i + x, j + y);
                        Console.Write("*");
                    }
                    //else
                    //{
                    //    Console.SetCursorPosition(i + x, j + y);
                    //    Console.Write("_");
                    //}
                }
            }
        }

        static void delete_block()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (block_L[rotate, j, i] == 1)
                    {
                        Console.SetCursorPosition(i + x, j + y);
                        Console.Write("_");
                    }
                }
            }
        }

        static int overlap_check(int tmp_x, int tmp_y)
        {
            int overlap_cnt = 0;

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (block_L[rotate, j, i] == 1 && background[j + y + tmp_y, i + x + tmp_x] == 1)
                    {
                        overlap_cnt++;
                    }

                }
            }

            return overlap_cnt;
        }
        static int overlap_check_rotate()
        {
            int overlap_cnt = 0;
            int tmp_rotate = rotate;

            tmp_rotate++;
            if (tmp_rotate > 3) tmp_rotate = 0;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (block_L[tmp_rotate, j, i] == 1 && background[j + y, i + x] == 1)
                    {
                        overlap_cnt++;
                    }

                }
            }

            return overlap_cnt;
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo key_value;
            //byte num = 0x23;
            //byte num1 = 0x37;
            int cnt = 0;
            String ch;

            make_background();
            make_block();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    key_value = Console.ReadKey(true);
                    ch = key_value.Key.ToString();

                    if (ch == "W")
                    {
                        //Console.WriteLine("w");
                    }
                    else if (ch == "A")
                    {
                        if (overlap_check(-1, 0) == 0)
                        {
                            delete_block();
                            x--;
                            make_block();
                        }
                    }
                    else if (ch == "S")
                    {
                        if (overlap_check(0, 1) == 0)
                        {
                            delete_block();
                            y++;
                            make_block();
                        }
                    }
                    if (ch == "D")
                    {
                        if (overlap_check(1, 0) == 0)
                        {
                            delete_block();
                            x++;
                            make_block();
                        }
                    }
                    if (ch == "R")
                    {
                        if (overlap_check_rotate() == 0)
                        {
                            delete_block();
                            rotate++;
                            if (rotate > 3) rotate = 0;
                            make_block();
                        }
                    }
                }

                if (cnt >= 100)
                {
                    cnt = 0;
                    if (overlap_check(0, 1) == 0)
                    {
                        delete_block();
                        y++;
                        make_block();
                    }
                }
                Thread.Sleep(10);
                cnt++;
            }



            //Console.WriteLine("Hello World");
            //Thread.Sleep(1000);
            //Console.Clear();
            //Console.WriteLine("Hi !!!");

            //while(true)
            //{
            //    for (int k = 0; k < 10; k++)
            //    {
            //        for (int j = 0; j < 8; j++)
            //        {
            //            for (int i = 0; i < 8; i++)
            //            {
            //                if ((num_byte_2[cnt, j] & (0x80 >> i)) > 0)
            //                {
            //                    Console.Write("*");
            //                }
            //                else
            //                {
            //                    Console.Write(" ");
            //                }
            //            }

            //            Console.Write("  ");

            //            for (int i = 0; i < 8; i++)
            //            {
            //                if ((num_byte_2[k, j] & (0x80 >> i)) > 0)
            //                {
            //                    Console.Write("*");
            //                }
            //                else
            //                {
            //                    Console.Write(" ");
            //                }
            //            }

            //            Console.WriteLine();
            //        }
            //        Thread.Sleep(100);
            //        Console.Clear();
            //    }
            //    if(cnt == 9)
            //    {
            //        cnt = 0;
            //    }
            //    else
            //    {
            //        cnt++;
            //    }
            //}

            //for (int i = 0; i < 8; i++)
            //{
            //    if ((num & (0x80 >> i)) > 0)
            //    {
            //        Console.Write("*");
            //    }
            //    else
            //    {
            //        Console.Write("_");
            //    }
            //}

            //if ((num & 0x01) > 0)
            //{
            //    Console.WriteLine("True");
            //}
            //else
            //{
            //    Console.WriteLine("false");
            //}

            //Console.ReadLine();

            //while(true)
            //{
            //    count++;

            //    Thread.Sleep(1000);
            //    Console.Clear();
            //}
        }
    }
}