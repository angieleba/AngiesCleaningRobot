using AngiesCleaningRobot.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngiesCleaningRobot
{
    public class RobotCommander
    {
        private int CleanedTotal = 0;

        public RobotCommander(MyRobot robot, List<Command> commands)
        {
            Commands = commands;
            Robot = robot;
            Robot.PositionVisited += CheckIfAlreadyCleaned;
        }

        public List<Command> Commands { get; private set; } = new List<Command>();
        public MyRobot Robot { get; private set; }
        private HashSet<Position> CleanedAlready { get; set; } = new HashSet<Position>();

        private void CheckIfAlreadyCleaned(object sender, OnPositionVisitedEventArgs e)
        {
            if (!CleanedAlready.Contains(e.CurrentPosition, new PositionComparer()))
            {
                Robot.Clean(e.CurrentPosition);
                CleanedAlready.Add(e.CurrentPosition);
                this.CleanedTotal++;
            }
        }

        public string CleanAll()
        {
            foreach (var command in Commands)
            {
                Robot.VisitArea(command);
            }

            return "Cleaned: " + CleanedTotal;
        }
    }
}
