using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

class OvalPictureBox : PictureBox
{
    // Used to rounded edges of picturebox(pieces), or the pictureboxes will cover the lines
    public OvalPictureBox()
    {
        this.BackColor = Color.DarkGray;
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        using (var gp = new GraphicsPath())
        {
            gp.AddEllipse(new Rectangle(0, 0, this.Width - 2/3, this.Height - 2/3));
            this.Region = new Region(gp);
        }
    }
}