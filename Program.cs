using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
Copyright (c) 2023 PiglinPotatoes?

This software is provided 'as-is', without any express or implied warranty. In no event will the authors be held liable for any damages arising from the use of this software.

Permission is granted to anyone to use this software for any purpose, including commercial applications, and to alter it and redistribute it freely, subject to the following restrictions:

1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software. If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.

2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.

3. This notice may not be removed or altered from any source distribution.
ZLIB LICENSE*/

namespace Potatodl
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "help" or "/?":
                        Console.WriteLine("Welcome to Potatodownload command-line help!\nCommand-line usage (case-sensitive):\n\n [help], [/?]: Shows this help screen.\n\n [dl (url) (file path)], [/d (url) (file path)]: Downloads the contents of (url) to (file path).\n\n [head (url)], [/h (url)]: Gets the headers and information sent by (url).\n\n [myhead], [/H]: Modify your headers/device information in a text user interface.\n\n [schedule (minutes) (url) (file path)], [/s (minutes) (url) (file path)]: Schedule a download of (url) to occur every (minutes) minutes to (file path).\n\n [archive (minutes) (url) (file path)], [/a (minutes) (url) (file path)]: Like schedule and /s, except it saves earlier copies of the file with the filename going up numerically, like:\n File1.html, File2.html, etc.\n\n no arguments: Hides the console and loads the GUI application.\nIf you are going to save to a file path with spaces in the name, type surround your file path in double quotes \"Like this\"");
                        return; // bart  303002
                    case "dl" or "/d":
                        try
                        {
                            var Webs = new System.Net.WebClient();
                            File.WriteAllBytes(args[2], Webs.DownloadData(args[1]));
                            if (Properties.Settings.Default.headers.Contains("\n"))
                            {
                                foreach (string xz in Properties.Settings.Default.headers.Split('\n'))
                                {
                                    if (!string.IsNullOrWhiteSpace(xz))
                                        Webs.Headers.Add(xz);
                                }
                            }
                            Console.WriteLine($"Successfully downloaded {args[1]} to {args[2]}.");
                        }
                        catch (Exception Xe) { Console.WriteLine("oh no, " + Xe.Message); }
                        return;
                    case "head" or "/h":
                        try
                        {
                            var Bingo = new System.Net.Http.HttpClient();
                            Console.WriteLine(Bingo.GetAsync(args[1], System.Net.Http.HttpCompletionOption.ResponseHeadersRead).Result.Headers.ToString());
                        }
                        catch (Exception Xe) { Console.WriteLine("oh no, " + Xe.Message); }
                        return;
                    case "myhead" or "/H":
                        if (string.IsNullOrWhiteSpace(Properties.Settings.Default.headers))
                            Console.WriteLine("You currently have no headers.");
                        else
                            Console.WriteLine("These are your current headers:\n" + Properties.Settings.Default.headers);
                        Console.Write("Change them? (y/n): ");
                        if (Console.ReadKey().KeyChar == 'y')
                        {
                            var bill = "aa";
                            Console.Clear();
                            Console.WriteLine("Write headers below (Leave a line blank to exit):");
                            Properties.Settings.Default.headers = "";
                            while (bill != "")
                            {
                                bill = Console.ReadLine();
                                Properties.Settings.Default.headers += "\n" + bill;
                            }
                            Properties.Settings.Default.Save();
                        }
                        return;
                    case "schedule" or "/s":
                        try
                        {
                            var Webs = new System.Net.WebClient();
                            for (; ; )
                            {
                                File.WriteAllBytes(args[3], Webs.DownloadData(args[2]));
                                Console.WriteLine($"Successfully downloaded {args[2]} to {args[3]}.");
                                System.Threading.Thread.Sleep(Convert.ToInt32(args[1]) * 60000);
                            }
                        }
                        catch (Exception Xe) { Console.WriteLine("oh no, " + Xe.Message); }
                        return;
                    case "archive" or "/a":
                        try
                        {
                            var hting = 0;
                            string folder;
                            string extension;
                            string fileName;
                            var Webs = new System.Net.WebClient();
                            for (; ; )
                            {
                                folder = Path.GetDirectoryName(args[3]);
                                fileName = Path.GetFileNameWithoutExtension(args[3]);
                                extension = Path.GetExtension(args[3]);
                                File.WriteAllBytes(Path.Combine(folder, $"{fileName}{hting++}{extension}"), Webs.DownloadData(args[2]));
                                Console.WriteLine($"Successfully downloaded {args[2]} to {Path.Combine(folder, $"{fileName}{hting}{extension}")}.");
                                System.Threading.Thread.Sleep(Convert.ToInt32(args[1]) * 60000);
                            }
                        }
                        catch (Exception Xe) { Console.WriteLine("oh no, " + Xe.Message); }
                        return;
                }
            }
            else
            {
                Consoleb.Hide();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
