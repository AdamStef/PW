using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWProject.Data.Abstract;

namespace TPWProject.Logic.Abstract
{
    public abstract class AbstractLogicAPI
    {
        public static AbstractLogicAPI CreateAPI(double height, double width)
        {
            return new LogicAPI(height, width);
        }
        public abstract void StartBallMovement();
        public abstract void StopMovement();
        public abstract void ClearRepository();
        public abstract void SetHeight(double height);
        public abstract void SetWidth(double width);
        public abstract void GenerateBalls(int ballsCount);
        public abstract IList<IBall> GetBalls();
    }
}
