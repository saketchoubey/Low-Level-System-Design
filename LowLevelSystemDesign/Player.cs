using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Player
    {
        public Player(string _name)
        {
            Console.WriteLine("{0} is added as a player", _name);
            Name = _name;
            Position = 0;
        }
        //public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }

        public int RollDices(int numberOfDices)
        {
            Console.WriteLine("{0} is rolling dice", Name);
            int min = 1;
            int max = numberOfDices * 6;
            Random rd = new Random();
            return rd.Next(min, max);
        }


        public int GetPlayerNewPosition(int NewPosition, List<Jumper> _snakes, List<Jumper> _ladder)
        
        {
            int i = 0;
            //Check for Snake or ladder
            bool bitten = false;
            bool isladder = false;
            string message = string.Empty;

            if (NewPosition + Position > 100)
            {
                i = NewPosition;
                message = String.Format("{0} is staying on the same position {1}", Name, Position);
            }
            else
            {
                i = NewPosition + Position;
                message = String.Format("{0} moved from {1} to {2}", Name, Position, i);
            }


            _snakes.ForEach((c) =>
            {
                if (c.start == i)
                {
                    bitten = true;
                    i = c.end;
                }
            });


            _ladder.ForEach((c) =>
            {
                if (c.start == i)
                {
                    isladder = true;
                    i = c.end;
                }
            });

            
            if (bitten)
                message = String.Format("{0} is bitten and moved from {1} to {2}", Name, Position, i);
            else if (isladder)
                message = String.Format("{0} got a ladder and moved from {1} to {2}", Name, Position, i);
            //else
            //    message = String.Format("{0} moved from {1} to {2}", Name, Position, i);

            Console.WriteLine(message);

            Position = i;
            return i;
        }
    }
}
