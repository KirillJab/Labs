using System;
using System.Drawing;   
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;


//  COMMANDS TO USE:
//  Draw Rectangle x;y;w;h
//  Draw Ellipse x;y;w;h
//  Draw image x;y;w;h
//  Clear
//  Exit.

class Program
{
    [DllImport("User32.dll")]
    public static extern IntPtr GetDC(IntPtr hwnd);
    [DllImport("User32.dll")]
    public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

    static void DrawRectangle(Rectangle rect, Brush brush, ref Graphics gr)
    {
        gr.FillRectangle(brush, rect);
    }
    static void DrawEllipse(Rectangle rect, Brush brush, ref Graphics gr)
    {
        gr.FillEllipse(brush, rect);
    }
    static void CustomDrawImage(Rectangle rect, ref Graphics gr)
    {
        gr.DrawImage(Image.FromFile("SampleImage.jpg"), rect);
    }

    static void Main(string[] args)
    {
        Random rand = new Random();
        IntPtr desktopPtr = GetDC(IntPtr.Zero);
        Graphics gr = Graphics.FromHdc(desktopPtr);
        SolidBrush brush = new SolidBrush(Color.YellowGreen);
        Regex rgx = new Regex(@"\d+;\d+;\d+;\d+");
        MatchCollection matches;
        while (true)
        {
            Console.WriteLine("Enter the command: ");
            string cmd = Console.ReadLine();
            string[] words = cmd.Split(' ');
            if (words[0].ToLower() == "draw")
            {
                matches = rgx.Matches(words[2]);
                if (matches.Count == 1)
                {
                    string[] cords = matches[0].ToString().Split(';');
                    int x = Convert.ToInt32(cords[0]);
                    int y = Convert.ToInt32(cords[1]);
                    int w = Convert.ToInt32(cords[2]);
                    int h = Convert.ToInt32(cords[3]);
                    if (words[1].ToLower() == "rectangle")
                    {
                        DrawRectangle(new Rectangle(x, y, w, h), brush, ref gr);
                    }
                    if (words[1].ToLower() == "ellipse")
                    {

                        DrawEllipse(new Rectangle(x, y, w, h), brush, ref gr);
                    }
                    if (words[1].ToLower() == "image")
                    {
                        CustomDrawImage(new Rectangle(x, y, w, h), ref gr);
                    }
                    brush.Color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                }
            }
            if (words[0].ToLower() == "clear")
            {
                gr.Clear(Color.White);
            }
            if (words[0].ToLower() == "exit")
            {
                gr.Dispose();
                ReleaseDC(IntPtr.Zero, desktopPtr);
                return;
            }
        }
    }
}