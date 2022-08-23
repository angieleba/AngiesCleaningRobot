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
            Commands.AddRange(commands);
            Robot = robot;
            Robot.PositionVisited += CheckIfAlreadyCleaned;
        }

        /// <summary>
        /// Internally set the robot to clean his starting point
        /// </summary>
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
            Robot.CheckToClean(new Position(Robot.CurrentXPosition, Robot.CurrentYPosition)); //Clean starting position

            foreach (var command in Commands)
            {
                Robot.MoveToArea(command);
            }

            return "Cleaned: " + CleanedTotal;
        }
    }
}
