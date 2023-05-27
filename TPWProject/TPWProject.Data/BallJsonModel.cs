using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWProject.Data
{
    public class BallJsonModel
    {
        public BallJsonModel(int id, double top, double left)
        {
            Id = id;
            Top = top;
            Left = left;
        }

        public int Id { get; set; }
        public double Top { get; set; }
        public double Left { get; set; }
    }
}
