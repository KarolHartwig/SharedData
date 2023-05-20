using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net;

namespace HangMan
{
    class Program
    {
        static void Main()
        {
            ConsoleKey userInput;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Wciśnij dowolny klawisz aby rozpocząć.\nESC wby wyjść.");
                userInput = Console.ReadKey().Key;

                if (userInput == ConsoleKey.Escape)
                    Environment.Exit(0);

                string word = DrawWord();

                Game new_game = new(word);

                while (new_game.Lives >= 0)
                {
                    Console.Clear();
                    Console.WriteLine(Gallow.ReturnStage(new_game.Lives));

                    new_game.Draw();

                    if (new_game.CheckIfWin())
                    {
                        Console.WriteLine("\n\nGRATULACJE! WYGRANA!");
                        Console.WriteLine("Naciśnij dowolny klawisz aby powrócić");
                        Console.Write("> ");
                        Console.ReadKey();
                        break;
                    }

                    Console.Write("\n> ");
                    char input = Console.ReadKey().KeyChar;

                    if (!new_game.CheckCanBeUsed(input))
                        continue;

                    if (new_game.CheckLetter(input))
                        new_game.ShowGuessed(input);
                    else
                        new_game.RemoveLife();

                    new_game.RemoveLetter(input);
                }
                if (new_game.Lives < 0) { 
                    Console.WriteLine($"\n\nPORAŻKA! HASŁO TO: {word}\n");
                    Console.WriteLine("Naciśnij dowolny klawisz aby powrócić");
                    Console.Write("> ");
                    Console.ReadKey();
                }
	    }
        }

        static string DrawWord()
        {
            string word;
    	    //LocalVersion
	    /*
	    string fileName = "words.txt";
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
            string lines = File.ReadAllText(path);
	    */

            //github version
			var url = "https://raw.githubusercontent.com/KarolHartwig/SharedData/np_project/c%23/words.txt";
            var lines = (new WebClient()).DownloadString(url);
	    lines = Regex.Replace(lines, @"[,\n]", String.Empty); //relaces \n with \r
            lines = Regex.Replace(lines, @"\r\r", " ");

            string[] words = lines.Split();
            Random randomIndex = new ();
            word = words[randomIndex.Next(1, words.Length - 1)];
            return word;
        }
    }
}
