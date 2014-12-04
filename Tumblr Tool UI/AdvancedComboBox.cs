﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Tumblr_Tool
{
    public class AdvancedComboBox : ComboBox
    {
        new public System.Windows.Forms.DrawMode DrawMode { get; set; }

        public Color HighlightBackColor { get; set; }

        public Color HighlightForeColor { get; set; }

        public System.Windows.Forms.ComboBoxStyle Style { get { return this.DropDownStyle; } set { this.DropDownStyle = value; } }

        public AdvancedComboBox()
        {
            base.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.HighlightBackColor = Color.Black;
            this.HighlightForeColor = Color.White;
            this.DrawItem += new DrawItemEventHandler(AdvancedComboBox_DrawItem);
            // this.SetStyle(ControlStyles.UserPaint, true);
        }

        private void AdvancedComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            ComboBox combo = sender as ComboBox;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(HighlightBackColor),
                                         e.Bounds);
                e.Graphics.DrawString(combo.Items[e.Index].ToString(), e.Font,
                                  new SolidBrush(HighlightForeColor),
                                  new Point(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(combo.BackColor),
                                         e.Bounds);

                e.Graphics.DrawString(combo.Items[e.Index].ToString(), e.Font,
                                      new SolidBrush(combo.ForeColor),
                                      new Point(e.Bounds.X, e.Bounds.Y));
            }

            e.DrawFocusRectangle();


            
          
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            e.Graphics.DrawString(this.Items[this.SelectedIndex].ToString(), this.Font,
                                      new SolidBrush(this.ForeColor),
                                      new Point(this.Bounds.X, this.Bounds.Y));

            int buttonWidth = SystemInformation.VerticalScrollBarWidth;
            Color highColor = Color.White;
            Color lowColor = Color.White;
            Rectangle itemRect = new Rectangle(this.Width - buttonWidth, 0, buttonWidth, this.Height);

            //Create the brushes.            
            LinearGradientBrush gradientBrush = new LinearGradientBrush(itemRect, highColor,
                    lowColor, LinearGradientMode.Vertical);

            ////Fill the rectangle background.
            //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //e.Graphics.FillRectangle(gradientBrush, itemRect);
            //gradientBrush.Dispose();

            ////Draw the button outline.
            //Pen outlinePen = new Pen(SystemColors.ButtonShadow, 0.0f);
            //e.Graphics.DrawRectangle(outlinePen, itemRect.X, itemRect.Y, itemRect.Width - 2, itemRect.Height - 2);
            //outlinePen.Dispose();

            //Draw the arrow.
            SolidBrush arrowBrush = new SolidBrush(Color.Black);
            Point[] points = new Point[3];
            points[0] = new Point(this.Width - (int)((double)itemRect.Width * .125) - 2, (int)((double)itemRect.Height * .333));
            points[1] = new Point(this.Width - (int)((double)itemRect.Width * .875) - 2, (int)((double)itemRect.Height * .333));
            points[2] = new Point(this.Width - (int)((double)itemRect.Width * .5) - 2, (int)((double)itemRect.Height * .666));

            e.Graphics.FillPolygon(arrowBrush, points);
            arrowBrush.Dispose();

            
        }        
    

            
    }
}