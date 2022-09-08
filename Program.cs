using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollTheDiceLearn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("this is a game where you will roll 2 dices, then I will roll 2 dices.");
            Console.WriteLine("We will evaluate the dices:");
            Console.WriteLine("- if only one of us has to dices showing equal eyes, then we have a winner");
            Console.WriteLine("- if we both has to dices showing equal eyes, then the one having largets will win");
           


            int dice_1_1;
            int dice_1_2;
            int dice_2_1;
            int dice_2_2;

            Random rand = new Random();
            bool cont = true;
            string outmessage;

            while (cont)
            {
                Console.WriteLine("You roll the dices - press <Return> to continue:");
                Console.ReadLine();

                dice_1_1 = rand.Next(1, 7);
                dice_1_2 = rand.Next(1, 7);
                bool player_equal = dice_1_1 == dice_1_2 ? true : false;
                outmessage = string.Format("Your roll: {0} - {1}", dice_1_1.ToString(), dice_1_2.ToString());
                Console.WriteLine(outmessage);

                dice_2_1 = rand.Next(1, 7);
                dice_2_2 = rand.Next(1, 7);
                bool opponent_equal = dice_2_1 == dice_2_2 ? true : false;
                outmessage = string.Format("My roll: {0} - {1}", dice_2_1.ToString(), dice_2_2.ToString());
                Console.WriteLine(outmessage);

                if(player_equal && opponent_equal)
                {
                    Console.WriteLine("Draw! Continuing");
                    Console.ReadLine();
                }

                if (player_equal && !opponent_equal)
                {
                    Console.WriteLine("You win!");
                    Console.ReadLine();
                    cont = false;
                }

                if (!player_equal && opponent_equal)
                {
                    Console.WriteLine("I win!");
                    Console.ReadLine();
                    cont = false;
                }

            }
        }
    }
}
