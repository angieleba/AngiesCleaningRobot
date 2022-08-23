using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngiesCleaningRobot.Interfaces
{
    public interface IWalk
    {
        void MoveOneStep(Direction direction);
        void MoveToArea(Command command);
    }
}
