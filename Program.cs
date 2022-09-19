using System;

namespace RollTheDiceLearn
{
    internal class Program
    {
        /// <summary>
        ///  Use args[] to test the application
        ///  - exact 4 args, all int, 0 < value < 7
        ///  - Example: RollTheDiceLearn.exe 4 4 4 5
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string mode = "Random";

            // this could be segragated in a method called Validate()
            // the return of this method could be a boolean: true if validation succeeded.
            if (args.Length == 4)
            {
                //http://www.java2s.com/Tutorial/Cpp/0040__Data-Types/Logicaloperators.htm
                if (
                    (int.Parse(args[0]) > 0 && int.Parse(args[0]) < 7) &&
                    (int.Parse(args[1]) > 0 && int.Parse(args[1]) < 7) &&
                    (int.Parse(args[2]) > 0 && int.Parse(args[2]) < 7) &&
                    (int.Parse(args[3]) > 0 && int.Parse(args[3]) < 7)
                   )
                {
                    mode = "Test";
                }
                else
                {
                    Console.WriteLine("!--> one or more arguments not within range (1-6)");
                    Console.WriteLine("!--> game runs in random mode");
                }
            }

            Console.WriteLine("this is a game where you will roll 2 dices, then I will roll 2 dices.");
            Console.WriteLine("We will evaluate the dices:");
            Console.WriteLine("- if only one of us has to dices showing equal eyes, then we have a winner");
            Console.WriteLine("- if we both has to dices showing equal eyes, then the one having largets will win");
            Console.WriteLine("You are running the game in " + mode + " mode");
           
            Random rand = new Random();
            bool cont = true;
            
            int dice_1_1 = 0;
            int dice_1_2 = 0;
            int dice_2_1 = 0;
            int dice_2_2 = 0;
            while (cont)
            {
                Console.WriteLine("You roll the dices - press <Return> to continue:");
                Console.ReadLine();

                if (mode == "Random")
                {
                    dice_1_1 = rand.Next(1, 7);
                    dice_1_2 = rand.Next(1, 7);
                    dice_2_1 = rand.Next(1, 7);
                    dice_2_2 = rand.Next(1, 7);
                }
                else if (mode == "Test")
                {
                    dice_1_1 = int.Parse(args[0]);
                    dice_1_2 = int.Parse(args[1]);
                    dice_2_1 = int.Parse(args[2]);
                    dice_2_2 = int.Parse(args[3]);
                }
                Console.WriteLine(string.Format("Your roll: {0} - {1}", dice_1_1.ToString(), dice_1_2.ToString()));
                Console.WriteLine(string.Format("My roll: {0} - {1}", dice_2_1.ToString(), dice_2_2.ToString()));

                cont = GameRuler(dice_1_1, dice_1_2, dice_2_1, dice_2_2);
                Console.ReadLine();
            }
        }
        /// <summary>
        ///  this method applies gamerules and makes decission to continue,
        ///  - this method also takes care of the out messaging
        /// </summary>
        /// <returns>true if continue</returns>
        static bool GameRuler(int dice_1_1, int dice_1_2,int dice_2_1,int dice_2_2)
        {
            //prepare
            bool player_equal;
            bool opponent_equal;
            int countEquals = 0;
            player_equal = dice_1_1 == dice_1_2;
            opponent_equal = dice_2_1 == dice_2_2;
            if (player_equal)
            {
                countEquals++;
            }
            if (opponent_equal)
            {
                countEquals++;
            }

            //execute
            bool gamecontinues = true;
            if (countEquals == 1)
            {
                if (player_equal)
                {
                    Console.WriteLine("You win!");
                }
                if (opponent_equal)
                {
                    Console.WriteLine("I win!");
                }
                gamecontinues = false;
            }

            if (countEquals == 2)
            {
                if ((dice_1_1 + dice_1_2) > (dice_2_1 + dice_2_2))
                {
                    Console.WriteLine("You win!");
                    gamecontinues = false;
                }
                if ((dice_1_1 + dice_1_2) < (dice_2_1 + dice_2_2))
                {
                    Console.WriteLine("I win!");
                    gamecontinues = false;
                }
                if ((dice_1_1 + dice_1_2) == (dice_2_1 + dice_2_2))
                {
                    Console.WriteLine("Draw! Continuing");
                }
            }

            //terminate
            return gamecontinues;
        }
    }
}
