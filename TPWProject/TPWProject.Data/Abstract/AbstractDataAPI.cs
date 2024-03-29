﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWProject.Data.Abstract
{
    public abstract class AbstractDataAPI
    {
        public Boundary Boundary { get; set; }
        public static AbstractDataAPI CreateAPI()
        {
            return new DataAPI();
        }
        public abstract List<IBall> GetBalls();
        public abstract void RemoveAllBalls();
        public abstract void CreateSimulation(double height, double width, int ballCount);
        public abstract Boundary GetBoundary();
        public abstract void EnableLogging(ILogger logger);
    }
}
