using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngiesCleaningRobot.Interfaces
{
    public interface IClean
    {
        void CheckToClean(Position position);
    }
}
