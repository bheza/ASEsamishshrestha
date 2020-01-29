using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgramSamish
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
                
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            Regex regex2 = new Regex(@"drawto (.*[\d])([,])(.*[\d]) rectangle (.*[\d])([,])(.*[\d])");
            Regex regex3 = new Regex(@"drawto (.*[\d])([,])(.*[\d]) circle (.*[\d])");
            Regex regex4 = new Regex(@"drawto (.*[\d])([,])(.*[\d]) triangle (.*[\d])([,])(.*[\d])([,])(.*[\d])");


            Regex regexClear = new Regex(@"clear");
            Regex regexReset = new Regex(@"reset");
            Regex regexMT = new Regex(@"moveto (.*[\d])([,])(.*[\d])");

            Regex regexR = new Regex(@"rectangle (.*[\d])([,])(.*[\d])");
            Regex regexC = new Regex(@"circle (.*[\d])");
            Regex regexT = new Regex(@"triangle (.*[\d])([,])(.*[\d])([,])(.*[\d])");



            Match match2 = regex2.Match(richTextBox1.Text.ToLower());
            Match match3 = regex3.Match(richTextBox1.Text.ToLower());
            Match match4 = regex4.Match(richTextBox1.Text.ToLower());

            Match matchClear = regexClear.Match(richTextBox1.Text.ToLower());
            Match matchReset = regexReset.Match(richTextBox1.Text.ToLower());
            Match matchMT = regexMT.Match(richTextBox1.Text.ToLower());

            Match matchR = regexR.Match(richTextBox1.Text.ToLower());
            Match matchC = regexC.Match(richTextBox1.Text.ToLower());
            Match matchT = regexT.Match(richTextBox1.Text.ToLower());


            //----------------RECTANGLE WITH DrawTo-----------------------//
            if (match2.Success)
            {
                try
                {
                    g = draw_panel.CreateGraphics();
                    _size1 = int.Parse(match2.Groups[1].Value);
                    _size2 = int.Parse(match2.Groups[3].Value);
                    _size3 = int.Parse(match2.Groups[4].Value);
                    _size4 = int.Parse(match2.Groups[6].Value);



                    ShapeFactory shapeFactory = new ShapeFactory();
                    Shape c = shapeFactory.GetShape("rectangle");

                    c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3, _size4);
                    c.Draw(g);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            //----------------RECTANGLE-----------------------//

            else if (matchR.Success)
            {
                try
                {
                    g = draw_panel.CreateGraphics();
                    _size1 = int.Parse(label_posX.Text);
                    _size2 = int.Parse(label_posY.Text);
                    _size3 = int.Parse(matchR.Groups[1].Value);
                    _size4 = int.Parse(matchR.Groups[3].Value);

                    ShapeFactory shapeFactory = new ShapeFactory();
                    Shape c = shapeFactory.GetShape("rectangle");
                    c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3, _size4);

                    c.Draw(g);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            //----------------CIRCLE-----------------------//
            else if (matchC.Success)
            {
                try
                {
                    g = draw_panel.CreateGraphics();
                    _size1 = int.Parse(label_posX.Text);
                    _size2 = int.Parse(label_posY.Text);
                    _size3 = int.Parse(matchC.Groups[1].Value);


                    ShapeFactory shapeFactory = new ShapeFactory();
                    Shape c = shapeFactory.GetShape("circle");
                    c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3 * 2, _size3 * 2);
                    //c.draw(set);
                    c.Draw(g);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            // ----------------TRIANGLE WITH DrawTo---------------------- -//
            else if (match4.Success)
            {
                try
                {
                    g = draw_panel.CreateGraphics();
                    _size1 = int.Parse(match4.Groups[1].Value);
                    _size2 = int.Parse(match4.Groups[3].Value);

                    _size3 = int.Parse(match4.Groups[4].Value);
                    _size4 = int.Parse(match4.Groups[6].Value);
                    _size5 = int.Parse(match4.Groups[8].Value);


                    xi1 = _size1;
                    yi1 = _size2;
                    xi2 = Math.Abs(_size3);
                    yi2 = _size2;

                    xii1 = _size1;
                    yii1 = _size2;
                    xii2 = _size1;
                    yii2 = Math.Abs(_size4);

                    xiii1 = Math.Abs(_size3);
                    yiii1 = _size2;
                    xiii2 = _size1;
                    yiii2 = Math.Abs(_size4);

                    ShapeFactory shapeFactory = new ShapeFactory();
                    Shape c = shapeFactory.GetShape("triangle");
                    c.set(texturestyle, bb, paintcolor, xi1, yi1, xi2, yi2, xii1, yii1, xii2, yii2, xiii1, yiii1, xiii2, yiii2);
                    //=============================== 
                    c.Draw(g);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // ----------------TRIANGLE---------------------- -//

            else if (matchT.Success)
            {
                try
                {
                    g = draw_panel.CreateGraphics();
                    _size1 = int.Parse(label_posX.Text);
                    _size2 = int.Parse(label_posY.Text);

                    _size3 = int.Parse(matchT.Groups[1].Value);
                    _size4 = int.Parse(matchT.Groups[3].Value);
                    _size5 = int.Parse(matchT.Groups[5].Value);


                    xi1 = _size1;
                    yi1 = _size2;
                    xi2 = Math.Abs(_size3);
                    yi2 = _size2;

                    xii1 = _size1;
                    yii1 = _size2;
                    xii2 = _size1;
                    yii2 = Math.Abs(_size4);

                    xiii1 = Math.Abs(_size3);
                    yiii1 = _size2;
                    xiii2 = _size1;
                    yiii2 = Math.Abs(_size4);

                    ShapeFactory shapeFactory = new ShapeFactory();
                    Shape c = shapeFactory.GetShape("triangle"); //new rectangles();
                    c.set(texturestyle, bb, paintcolor, xi1, yi1, xi2, yi2, xii1, yii1, xii2, yii2, xiii1, yiii1, xiii2, yiii2);
                    c.Draw(g);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // ----------------CLEAR------------------------//

            else if (matchClear.Success)
            {
                draw_panel.Refresh();
                this.draw_panel.BackgroundImage = null;
            }


            // ----------------RESET------------------------//
            else if (matchReset.Success)
            {
                _size1 = 0;
                _size2 = 0;
                label_posX.Text = _size1.ToString();
                label_posY.Text = _size2.ToString();

            }

            // ----------------MOVETO------------------------//

            else if (matchMT.Success)
            {
                try
                {
                    _size1 = int.Parse(matchMT.Groups[1].Value);
                    _size2 = int.Parse(matchMT.Groups[3].Value);

                    label_posX.Text = _size1.ToString();
                    label_posY.Text = _size2.ToString();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
        public int _size1, _size2, _size3, _size4, _size5, _size6, _size7, _size8, _size9, _size10, _size11, _size12;

        private void textBoxCmd_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Text Document(*.txt) | *.txt";
            if (of.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(of.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(sv.FileName,richTextBox1.Text);
            }
        }

        private void draw_panel_MouseClick(object sender, MouseEventArgs e)
        {
            label_posX.Text = (e.X).ToString();
            label_posY.Text = (e.Y).ToString();
        }

        public int xi1, yi1, xi2, yi2, xii1, yii1, xii2, yii2, xiii1, yiii1, xiii2, yiii2;
        Color paintcolor = Color.Blue;
        //Brush bb = new HatchBrush(HatchStyle.Wave, Color.Red, Color.FromArgb(255, 128, 255, 255));
        Brush bb = new SolidBrush(Color.Red);
        int texturestyle = 5;
        Graphics g;
        private void RunButton_Click(object sender, EventArgs e)
        {
            Regex regex2 = new Regex(@"drawto (.*[\d])([,])(.*[\d]) rectangle (.*[\d])([,])(.*[\d])");
            Regex regex3 = new Regex(@"drawto (.*[\d])([,])(.*[\d]) circle (.*[\d])");
            Regex regex4 = new Regex(@"drawto (.*[\d])([,])(.*[\d]) triangle (.*[\d])([,])(.*[\d])([,])(.*[\d])");


            Regex regexClear = new Regex(@"clear");
            Regex regexReset = new Regex(@"reset");
            Regex regexMT = new Regex(@"moveto (.*[\d])([,])(.*[\d])");

            Regex regexR = new Regex(@"rectangle (.*[\d])([,])(.*[\d])");
            Regex regexC = new Regex(@"circle (.*[\d])");
            Regex regexT = new Regex(@"triangle (.*[\d])([,])(.*[\d])([,])(.*[\d])");



            Match match2 = regex2.Match(richTextBox1.Text.ToLower());
            Match match3 = regex3.Match(richTextBox1.Text.ToLower());
            Match match4 = regex4.Match(richTextBox1.Text.ToLower());

            Match matchClear = regexClear.Match(richTextBox1.Text.ToLower());
            Match matchReset = regexReset.Match(richTextBox1.Text.ToLower());
            Match matchMT = regexMT.Match(richTextBox1.Text.ToLower());

            Match matchR = regexR.Match(richTextBox1.Text.ToLower());
            Match matchC = regexC.Match(richTextBox1.Text.ToLower());
            Match matchT = regexT.Match(richTextBox1.Text.ToLower());


            //----------------RECTANGLE WITH DrawTo-----------------------//
            if (match2.Success)
            {
                try
                {
                    g = draw_panel.CreateGraphics();
                    _size1 = int.Parse(match2.Groups[1].Value);
                    _size2 = int.Parse(match2.Groups[3].Value);
                    _size3 = int.Parse(match2.Groups[4].Value);
                    _size4 = int.Parse(match2.Groups[6].Value);



                    ShapeFactory shapeFactory = new ShapeFactory();
                    Shape c = shapeFactory.GetShape("rectangle");

                    c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3, _size4);
                    c.Draw(g);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            //----------------RECTANGLE-----------------------//

            else if (matchR.Success)
            {
                try
                {
                    g = draw_panel.CreateGraphics();
                    _size1 = int.Parse(label_posX.Text);
                    _size2 = int.Parse(label_posY.Text);
                    _size3 = int.Parse(matchR.Groups[1].Value);
                    _size4 = int.Parse(matchR.Groups[3].Value);

                    ShapeFactory shapeFactory = new ShapeFactory();
                    Shape c = shapeFactory.GetShape("rectangle");
                    c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3, _size4);

                    c.Draw(g);
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message);
                }
            }

            //----------------CIRCLE-----------------------//
            else if (matchC.Success)
            {
                try
                {
                    g = draw_panel.CreateGraphics();
                    _size1 = int.Parse(label_posX.Text);
                    _size2 = int.Parse(label_posY.Text);
                    _size3 = int.Parse(matchC.Groups[1].Value);


                    ShapeFactory shapeFactory = new ShapeFactory();
                    Shape c = shapeFactory.GetShape("circle");
                    c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3 * 2, _size3 * 2);
                    //c.draw(set);
                    c.Draw(g);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            // ----------------TRIANGLE WITH DrawTo---------------------- -//
            else if (match4.Success)
            {
                try
                {
                    g = draw_panel.CreateGraphics();
                    _size1 = int.Parse(match4.Groups[1].Value);
                    _size2 = int.Parse(match4.Groups[3].Value);

                    _size3 = int.Parse(match4.Groups[4].Value);
                    _size4 = int.Parse(match4.Groups[6].Value);
                    _size5 = int.Parse(match4.Groups[8].Value);


                    xi1 = _size1;
                    yi1 = _size2;
                    xi2 = Math.Abs(_size3);
                    yi2 = _size2;

                    xii1 = _size1;
                    yii1 = _size2;
                    xii2 = _size1;
                    yii2 = Math.Abs(_size4);

                    xiii1 = Math.Abs(_size3);
                    yiii1 = _size2;
                    xiii2 = _size1;
                    yiii2 = Math.Abs(_size4);

                    ShapeFactory shapeFactory = new ShapeFactory();
                    Shape c = shapeFactory.GetShape("triangle");
                    c.set(texturestyle, bb, paintcolor, xi1, yi1, xi2, yi2, xii1, yii1, xii2, yii2, xiii1, yiii1, xiii2, yiii2);
                    //=============================== 
                    c.Draw(g);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // ----------------TRIANGLE---------------------- -//

            else if (matchT.Success)
            {
                try
                {
                    g = draw_panel.CreateGraphics();
                    _size1 = int.Parse(label_posX.Text);
                    _size2 = int.Parse(label_posY.Text);

                    _size3 = int.Parse(matchT.Groups[1].Value);
                    _size4 = int.Parse(matchT.Groups[3].Value);
                    _size5 = int.Parse(matchT.Groups[5].Value);


                    xi1 = _size1;
                    yi1 = _size2;
                    xi2 = Math.Abs(_size3);
                    yi2 = _size2;

                    xii1 = _size1;
                    yii1 = _size2;
                    xii2 = _size1;
                    yii2 = Math.Abs(_size4);

                    xiii1 = Math.Abs(_size3);
                    yiii1 = _size2;
                    xiii2 = _size1;
                    yiii2 = Math.Abs(_size4);

                    ShapeFactory shapeFactory = new ShapeFactory();
                    Shape c = shapeFactory.GetShape("triangle"); //new rectangles();
                    c.set(texturestyle, bb, paintcolor, xi1, yi1, xi2, yi2, xii1, yii1, xii2, yii2, xiii1, yiii1, xiii2, yiii2);
                    c.Draw(g);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // ----------------CLEAR------------------------//

            else if (matchClear.Success)
            {
                draw_panel.Refresh();
                this.draw_panel.BackgroundImage = null;
            }


            // ----------------RESET------------------------//
            else if (matchReset.Success)
            {
                _size1 = 0;
                _size2 = 0;
                label_posX.Text = _size1.ToString();
                label_posY.Text = _size2.ToString();

            }

            // ----------------MOVETO------------------------//

            else if (matchMT.Success)
            {
                try
                {
                    _size1 = int.Parse(matchMT.Groups[1].Value);
                    _size2 = int.Parse(matchMT.Groups[3].Value);

                    label_posX.Text = _size1.ToString();
                    label_posY.Text = _size2.ToString();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
