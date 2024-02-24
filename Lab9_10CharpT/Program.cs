using Lab9_10CharpT;
using System;
using System.Collections;
using System.Drawing;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Lab8CSharp {
    internal class Program {
        static void Main(string[] args) {
            int number = 1;

            while (number != 0) {
                Console.Write("Input task number [1-5], [0] to exit: ");

                try {
                    string? input = Console.ReadLine();

                    if (input != null) {
                        number = int.Parse(input);

                        switch (number) {
                            case 0:
                                return;

                            case 1:
                                task1(); // Testing task 1
                                break;

                            case 2:
                                task2(); // Testing task
                                break;

                            case 3:
                                task3(); // Testing task 3
                                break;

                            case 4:
                                task4(); // Testing task 4
                                break;

                            default:
                                break;
                        }
                    } else {
                        Console.WriteLine("Nothing provided. Exiting...");
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                }

                Console.WriteLine();
            }
        }



        static void task1() {
            Console.WriteLine("|===~        Testing task 1.1        ~===|");

            try {
                string inputFile = "input.txt";
                string outputFile = "output.txt";

                // Read numbers from input file and push them onto a stack
                Stack<int> numbersStack = new Stack<int>();

                StreamReader reader = new StreamReader(inputFile);
                while (!reader.EndOfStream) {
                    string? line = reader.ReadLine();

                    if (line != null) {
                        string[] numbers = line.Split(" ");

                        foreach(string number in numbers) {
                            try {
                                numbersStack.Push(int.Parse(number));
                            } catch (Exception ex) { }
                        }
                    }
                }
                reader.Close();


                // Write numbers from stack to output file in reverse order
                StreamWriter writer = new StreamWriter(outputFile);
                while (numbersStack.Count > 0) {
                    int number = numbersStack.Pop();
                    writer.WriteLine(number);
                }
                writer.Close();

                Console.WriteLine("Numbers reversed and written to output file successfully.");
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }

            Console.WriteLine();
        }

        static void task2() {
            Console.WriteLine("|===~        Testing task 2.1        ~===|");

            try {
                string inputFile = "input2.txt";

                // Initialize queues for non-digits and digits
                Queue<char> nonDigitQueue = new Queue<char>();
                Queue<char> digitQueue = new Queue<char>();

                // Read characters from input file and enqueue them based on type
                StreamReader reader = new StreamReader(inputFile);
                    int currentCharInt;
                    while ((currentCharInt = reader.Read()) != -1) {
                        char currentChar = (char)currentCharInt;
                        if (char.IsDigit(currentChar)) {
                            digitQueue.Enqueue(currentChar);
                        } else {
                            nonDigitQueue.Enqueue(currentChar);
                        }
                    }
                reader.Close();

                // Print characters in the required order
                Console.WriteLine("\n  Characters:");
                while (nonDigitQueue.Count > 0) {
                    Console.Write(nonDigitQueue.Dequeue());
                }
                Console.WriteLine("\n\n  Digits:");
                while (digitQueue.Count > 0) {
                    Console.Write(digitQueue.Dequeue());
                }
                Console.WriteLine();
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine();
        }

        static void task3() {
            Console.WriteLine("|===~        Testing task 3.1        ~===|");

            // Task 1
            try {
                string inputFile = "input.txt";
                string outputFile = "output.txt";

                // Read numbers from input file and push them onto a stack (ArrayList)
                ArrayList list = new ArrayList();

                StreamReader reader = new StreamReader(inputFile);
                while (!reader.EndOfStream) {
                    string? line = reader.ReadLine();

                    if (line != null) {
                        string[] numbers = line.Split(" ");

                        foreach (string number in numbers) {
                            try {
                                list.Insert(list.Count, (int.Parse(number)));
                            } catch (Exception ex) { }
                        }
                    }
                }
                reader.Close();


                // Write numbers from stack (ArrayList) to output file in reverse order
                StreamWriter writer = new StreamWriter(outputFile);
                while (list.Count > 0) {
                    int number = (int)list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);
                    writer.WriteLine(number);
                }
                writer.Close();

                Console.WriteLine("Numbers reversed and written to output file successfully.");
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }

            // Task 2
            try {
                string inputFile = "input2.txt";

                // Initialize ArrayLists for non-digits and digits
                ArrayList nonDigitList = new ArrayList();
                ArrayList digitList = new ArrayList();

                // Read characters from input file and add them to the ArrayLists based on type
                using (StreamReader reader = new StreamReader(inputFile)) {
                    int currentCharInt;
                    while ((currentCharInt = reader.Read()) != -1) {
                        char currentChar = (char)currentCharInt;
                        if (char.IsDigit(currentChar)) {
                            digitList.Add(currentChar);
                        } else {
                            nonDigitList.Add(currentChar);
                        }
                    }
                }

                // Print characters in the required order
                Console.WriteLine("\n  Characters:");
                foreach (char c in nonDigitList) {
                    Console.Write(c);
                }

                Console.WriteLine("\n\n  Digits:");
                foreach (char c in digitList) {
                    Console.Write(c);
                }
                Console.WriteLine();
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void task4() {
            Console.WriteLine("|===~        Testing task 4.1        ~===|");

            MusicCatalog catalog = new MusicCatalog();

            // Adding CDs to the catalog
            Console.WriteLine("Adding CDs to the catalog");
            catalog.AddCD("Greatest Hits", "Artist A");
            catalog.AddCD("Rock Classics", "Artist B");

            // Adding songs to CDs
            Console.WriteLine("\n\nAdding songs to CDs");
            catalog.AddSong("Greatest Hits", "Song 1");
            catalog.AddSong("Greatest Hits", "Song 2");
            catalog.AddSong("Rock Classics", "Song 3");

            // Viewing the catalog
            Console.WriteLine("\n\nViewing the catalog:\n");
            Console.WriteLine("Current Catalog:");
            catalog.ViewCatalog();

            // Searching for CDs by artist
            Console.WriteLine("\n\nSearching for CDs by artist:\n");
            Console.WriteLine("CDs by Artist A:");
            catalog.SearchByArtist("Artist A");

            // Removing all
            Console.WriteLine("\n\nRemoving CD \"Greatest Hits\"\n");
            catalog.RemoveCD("Greatest Hits");
            catalog.ViewCatalog();

            Console.WriteLine();
        }
    }
}