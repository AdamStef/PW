using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWProject.Data.Abstract
{
    public abstract class AbstractDataAPI
    {
        public static AbstractDataAPI CreateAPI()
        {
            return new DataAPI();
        }
        public abstract IBall GenerateBall(double height, double width);
        public abstract IList<IBall> GetBalls();
        public abstract void RemoveAllBalls();
    }
}
