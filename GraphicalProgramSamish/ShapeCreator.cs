using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgramSamish
{
    abstract class ShapeCreator
    {
        /// <summary>
        /// This method is used for shaping an objects
        /// </summary>
        /// <param name="ShapeType"></param>
        /// <returns></returns>
        public abstract Shape getShape(string ShapeType);

    }
}
