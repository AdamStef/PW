using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWProject.Data.Abstract
{
    public abstract class AbstractDataAPI
    {
        protected IBallRepository ballRepository;
        //public abstract int Height { get; set; }
        //public abstract int Width { get; set; }
        public static AbstractDataAPI CreateAPI()
        {
            return new DataAPI();
        }
        public abstract Shape GenerateBall(double height, double width);
        public abstract IList<Shape> GetShapes();
        public abstract void RemoveAllShapes();
    }
}
