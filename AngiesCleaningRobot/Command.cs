using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngiesCleaningRobot
{
    public class Command
    {
        public Command(Direction direction, int steps = 0)
        {
            Steps = steps;
            Direction = direction;
        }

        public int Steps { get; set; }
        public Direction Direction { get; set; }
    }


    public enum Direction { 
        E,
        W, 
        N,
        S,
        DontMove
    }
}

