using System;

namespace pa2_blstonge
{
    class Program
    {
        static void Main(string[] args)
        {
            // while this is true, the app will continue to make new games
            bool continuePlaying = true;

            while (continuePlaying == true)
            {
                // creates character 1
                Character player1 = CreatePlayerOne();
                Console.Clear();
                
                // creates character 2
                Character player2 = CreatePlayerOne();
                Console.Clear();

                // gives stats to the characters
                player1.GenerateStats();
                player2.GenerateStats();

                // displays stats of both characters
                Console.WriteLine("Characters:");
                player1.ViewStats();
                player2.ViewStats();
                Console.ReadKey();
                Console.Clear();

                // compares speed stats to see who is faster and attacks first
                //starts battle rotation if player 1 is faster
                if (player1.Speed.CompareTo(player2.Speed) > 0)
                {
                    Console.WriteLine($"{player1.Name} is faster than {player2.Name} and will attack first.");
                    Console.ReadKey();
                    Console.Clear(); 
                    while (player1.Health > 0 && player2.Health > 0)
                    {
                        //player 1 attacks, player 2 defends and shows player 2's stats
                        player1.attackBehavior.Attack(player1, player2);
                        player2.ViewStats();
                        Console.ReadKey();
                        Console.Clear();

                        // breaks if player 2 is defeated and can't finish the rotation
                        if (player2.Health <= 0)
                        {
                            break;
                        }

                        //player 2 attacks, player 1 defends and shows player 1's stats
                        player2.attackBehavior.Attack(player2, player1);
                        player1.ViewStats();
                        Console.ReadKey();
                        Console.Clear();
                    }

                    Console.Clear();

                    // states who was defeated and who won
                    if (player1.Health <= 0)
                    {
                        Console.WriteLine($"{player1.Name} was defeated.\n{player2.Name} is the winner!");
                    }
                    else
                    {
                        Console.WriteLine($"{player2.Name} was defeated.\n{player1.Name} is the winner!");
                    }
                }
                //starts battle rotation if player 1 is faster
                else
                {
                    Console.WriteLine($"{player2.Name} is faster than {player1.Name} and will attack first.");
                    Console.ReadKey();
                    Console.Clear(); 
                    while (player1.Health > 0 && player2.Health > 0)
                    {
                        //player 2 attacks, player 1 defends and shows player 1's stats
                        player2.attackBehavior.Attack(player2, player1);
                        player1.ViewStats();
                        Console.ReadKey();
                        Console.Clear();

                        // breaks if player 1 is defeated and can't finish the rotation
                        if (player1.Health <= 0)
                        {
                            break;
                        }

                        //player 1 attacks, player 2 defends and shows player 2's stats
                        player1.attackBehavior.Attack(player1, player2);
                        player2.ViewStats();
                        Console.ReadKey();
                        Console.Clear();
                    }

                    Console.Clear();

                    // states who was defeated and who won
                    if (player1.Health <= 0)
                    {
                        Console.WriteLine($"{player1.Name} was defeated.\n{player2.Name} is the winner!");
                    }
                    else
                    {
                        Console.WriteLine($"{player2.Name} was defeated.\n{player1.Name} is the winner!");
                    }
                }
                
                Console.ReadKey();
                Console.Clear();

                string decision = " ";
                
                // asks the user if they want to play again and either starts a new game or closes the program
                while (decision == " ")
                {
                    Console.Clear();
                    Console.WriteLine("Would you like to play again? (YES/NO)");
                    try
                    {
                        decision = Console.ReadLine();
                        decision.ToUpper(); 
                        if((decision != "YES") || (decision != "NO"))
                        {
                            throw new Exception("Not a valid menu choice");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        if (decision == "YES")
                        {
                            continuePlaying = true;
                        }
                        else if (decision == "NO")
                        {
                            continuePlaying = false;
                        }
                    }
                }
                
            }

            Console.Clear();
            Console.WriteLine("Goodbye!");
            Console.ReadKey();

        }

        // Creates player 1
        public static Character CreatePlayerOne()
        {
            string name;
            int userInput = 0;
            Character generatedCharacter = null;
            
            // gets player's name
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            Console.Clear();

            // Asks for their element and makes sure they choose a valid element
            while (userInput > 3 || userInput < 1)
            {
                Console.Clear();
                Console.WriteLine($"{name}, choose your element:\n1)Earth\n2)Fire\n3)Air");
                try
                {
                    userInput = int.Parse(Console.ReadLine());
                    if(userInput < 1 || userInput > 3)
                    {
                        throw new Exception("Not a valid menu choice");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    // creates a character of the corresponding element choosen and uses the name the user entered
                    if (userInput == 1)
                    {
                        generatedCharacter = new EarthCharacter(){Name = name};
                    }
                    else if (userInput == 2)
                    {
                        generatedCharacter = new FireCharacter(){Name = name};
                    }
                    else if (userInput == 3)
                    {
                        generatedCharacter = new AirCharacter(){Name = name};
                    }
                }
            }

            // returns the generated character of the choosen type
            return generatedCharacter;
            
        }
    }
}
