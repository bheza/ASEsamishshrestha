using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgramSamish
{
    class Rectangle : Shape
    {
        int xPos, yPos, size, size1;
        int texturestyle;
        Brush brush;
        Color color;

        /// <summary>
        /// implemented from shape class to draw rectangle
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            Pen p = new Pen(color, 3);
            if (texturestyle == 0)
            {
                g.DrawRectangle(p, xPos, yPos, size, size1);
            }
            else
            {
                g.FillRectangle(brush, xPos, yPos, size, size1);
            }
        }


        public override void set(int texturestyle, Brush brush, Color color, params int[] list)
        {
            this.texturestyle = texturestyle;
            this.brush = brush;
            this.color = color;
            this.xPos = list[0];
            this.yPos = list[1];
            this.size = list[2];
            this.size1 = list[3];
        }
    }
}

