using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TPWProject.Data;
using TPWProject.Data.Abstract;

namespace TPWProject.Logic.Abstract
{
    public abstract class AbstractLogicAPI
    {
        public bool IsRunning { get; protected set; }

        public static AbstractLogicAPI CreateAPI()
        {
            return new LogicAPI();
        }
        public abstract void StartSimulation(double height, double width, int ballCount);
        public abstract void StopSimulation();
        public abstract List<IBall> GetBalls();
        public abstract void SetHeight(double height);
        public abstract void SetWidth(double width);
    }
}
