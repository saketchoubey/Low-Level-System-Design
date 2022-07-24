using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var snakes = new List<Jumper>() { new Jumper(20, 1), new Jumper(30, 15), new Jumper(40, 10), new Jumper(50, 10), new Jumper(60, 10) };
            var ladder = new List<Jumper>() { new Jumper(10, 20), new Jumper(30, 60), new Jumper(40, 99), new Jumper(50, 60), new Jumper(60, 80) };

           
            Board b = new Board(100, snakes, ladder, 1);
            b.AddNewPlayer("Atharva");
            b.AddNewPlayer("Saket");
            b.AddNewPlayer("Ashish");

            b.StartGame();
        }
    }
}
