using System;

namespace delegatesAndEvents
{
    public delegate void RaceWinnerDelegate(int winner);

    public class Race
    {
        //delegate event obj
        public event RaceWinnerDelegate RaceWinnerEvent;

        public void Racing(int contestants, int laps)
        {
            Console.WriteLine("Ready\nSet\nGo!");
            Random r = new Random();
            int[] participants = new int[contestants];
            bool done = false;
            int champ = -1;

            while (!done)
            {
                for (int i = 0; i < contestants; i++)
                {
                    if (participants[i] <= laps)
                    {
                        participants[i] += r.Next(1, 5);
                    }
                    else
                    {
                        champ = i;
                        done = true;
                        continue;
                    }
                }
            }

            TheWinner(champ);
        }

        private void TheWinner(int champ)
        {
            Console.WriteLine("We have a winner!");
            //invoking event obj
            RaceWinnerEvent?.Invoke(champ);
        }
    }

    class Program
    {
        public static void Main()
        {
            Race round1 = new Race();

            round1.RaceWinnerEvent += footRace;

            round1.Racing(5, 50);

            round1.RaceWinnerEvent -= footRace;
            round1.RaceWinnerEvent += carRace;

            round1.Racing(5, 50);

            //bike race event using lambda
            round1.RaceWinnerEvent -= carRace;
            round1.RaceWinnerEvent += (int winner) => { Console.WriteLine($"Biker number {winner} is the winner."); };

            round1.Racing(5, 50);
        }

        public static void carRace(int winner)
        {
            Console.WriteLine($"Car number {winner} is the winner.");
        }
        public static void footRace(int winner)
        {
            Console.WriteLine($"Racer number {winner} is the winner.");
        }
    }
}
