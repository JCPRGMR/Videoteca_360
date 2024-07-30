using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Videoteca.Componentes
{
    class PictureBoxRJ : PictureBox
    {
        // Atributos
        private int Grosor;
        private Color BorderColor = Color.RoyalBlue;
        private Color BorderColor_2 = Color.LightGray;
        private DashStyle Dash_Style = DashStyle.Solid;
        private DashCap Dash_cap = DashCap.Flat;
        private float GradientAngle = 50F;

        // Constructor
        public PictureBoxRJ()
        {
            this.Size = new Size(100, 100);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public int Grosor1
        {
            get
            {
                return Grosor;
            }

            set
            {
                Grosor = value;
                this.Invalidate();
            }
        }

        public Color BorderColor1
        {
            get
            {
                return BorderColor;
            }

            set
            {
                BorderColor = value;
                this.Invalidate();
            }
        }

        public Color BorderColor_21
        {
            get
            {
                return BorderColor_2;
            }

            set
            {
                BorderColor_2 = value;
                this.Invalidate();
            }
        }

        public DashStyle Dash_Style1
        {
            get
            {
                return Dash_Style;
            }

            set
            {
                Dash_Style = value;
                this.Invalidate();
            }
        }

        public DashCap Dash_cap1
        {
            get
            {
                return Dash_cap;
            }

            set
            {
                Dash_cap = value;
                this.Invalidate();
            }
        }

        public float GradientAngle1
        {
            get
            {
                return GradientAngle;
            }

            set
            {
                GradientAngle = value;
                this.Invalidate();
            }
        }

        // Overrides
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = new Size(this.Width, this.Height);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            // CAMPOS
            var graph = pe.Graphics;
            var RectContourSmooth = Rectangle.Inflate(this.ClientRectangle, -1, -1);
            var RectBorder = Rectangle.Inflate(this.ClientRectangle, -Grosor, Grosor);
            var smoothSize = Grosor > 0 ? Grosor * 3 : 1;
            using (var BorderGColor  = new LinearGradientBrush(RectBorder, BorderColor, BorderColor_2, GradientAngle))
            using (var pathRegion = new GraphicsPath())
            using (var penSmooth = new Pen(this.Parent.BackColor, smoothSize))
            using (var penBorder = new Pen(BorderColor, Grosor))
            {
                penBorder.DashStyle = Dash_Style;
                penBorder.DashCap = Dash_cap;
                pathRegion.AddEllipse(RectContourSmooth);
                this.Region = new Region(pathRegion);
                graph.SmoothingMode = SmoothingMode.AntiAlias;

                // Drawing
                graph.DrawEllipse(penSmooth, RectContourSmooth);
                if (Grosor > 0)
                    graph.DrawEllipse(penBorder, RectBorder);
            }
        }
    }
}
