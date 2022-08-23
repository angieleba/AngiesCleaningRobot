using AngiesCleaningRobot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngiesCleaningRobot
{
    public class MyRobot : IWalk, IClean
    {
        public MyRobot(int currentXPosition, int currentYPosition)
        {
            CurrentXPosition = currentXPosition;
            CurrentYPosition = currentYPosition;
        }

        public int CurrentXPosition { get; private set; }
        public int CurrentYPosition { get; private set; }

        public event EventHandler<OnPositionVisitedEventArgs> PositionVisited;

        protected virtual void OnPositionVisited(OnPositionVisitedEventArgs args)
        {
            EventHandler<OnPositionVisitedEventArgs> handler = PositionVisited;
            handler?.Invoke(this, args);
        }

        public void MoveToArea(Command command)
        {
            for (int i = 1; i <= command.Steps; i++)
            {
                MoveOneStep(command.Direction);
                CheckVisitedPosition(new Position(CurrentXPosition, CurrentYPosition));

            }
        }

        public void CheckVisitedPosition(Position position)
        {
            OnPositionVisited(new OnPositionVisitedEventArgs(position));
        }

        public void Clean(Position position)
        {
            //actual cleaning
        }

        public void MoveOneStep(Direction direction)
        {
            switch (direction)
            {
                case Direction.E:
                    CurrentXPosition--;
                    break;
                case Direction.W:
                    CurrentXPosition++;
                    break;
                case Direction.N:
                    CurrentYPosition--;
                    break;
                case Direction.S:
                    CurrentYPosition++;
                    break;
            }
        }
    }

    /// <summary>
    /// Contains arguments to be sent to the event OnBeforeCleaned
    /// </summary>
    public class OnPositionVisitedEventArgs : EventArgs
    {
        public OnPositionVisitedEventArgs(Position visited)
        {
            CurrentPosition = visited;
        }

        public Position CurrentPosition { get; set; }
    }
}
