using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngiesCleaningRobot
{
    public class MyRobot
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

        public void VisitArea(Command command)
        {
            if(command.Direction == Direction.DontMove)
                OnPositionVisited(new OnPositionVisitedEventArgs(new Position(CurrentXPosition, CurrentYPosition)));
            else
            {
                for (int i = 1; i <= command.Steps; i++)
                {
                    MoveOneStep(command);
                    OnPositionVisited(new OnPositionVisitedEventArgs(new Position(CurrentXPosition, CurrentYPosition)));
                }
            }         
        }

        public void Clean(Position position)
        {
            //Cleaned position
        }

        private void MoveOneStep(Command command)
        {
            switch (command.Direction)
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
