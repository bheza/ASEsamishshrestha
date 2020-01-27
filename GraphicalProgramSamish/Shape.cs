using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgramSamish
{
    public abstract class Shape
    {
        /// <summary>
        /// Passing graphical value to shapes
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw(Graphics g);

        /// <summary>
        /// passing the painting value to the to shapes
        /// </summary>
        /// <param name="texturestyle">define texture</param>
        /// <param name="bb">define properties of brush</param>
        /// <param name="c">define color</param>
        /// <param name="list">list of parameter</param>
        public abstract void set(int texturestyle, Brush bb, Color c, params int[] list);
    }
}
