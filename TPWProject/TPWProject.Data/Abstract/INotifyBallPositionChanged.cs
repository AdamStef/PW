using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWProject.Data.Abstract
{
    public interface INotifyBallPositionChanged
    {
        event BallPositionChangedEventHandler BallPositionChanged;
    }
}
