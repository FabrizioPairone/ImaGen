using ImaGen.ImageStyles;

using System.Drawing;

using System;
using System.Collections.Generic;
using System.Text;

namespace ImaGen.ImageContents
{
    public abstract class ImageContent
    {
        // Attributes
        public Margin Margin { get; set; }
        // TO DO : ADD WIDTH
        // TO DO : ADD HEIGHT
        // IF NOT SET WIDTH OR HEIGHT IS THE VALUE OF IMAGETEMPALTE
        // IF WIDTH OR HEIGHT VALUE ARE MORE THAN VALUES OF TEMPLATE SET TEMPLATE VALUES

        // Constructor
        public ImageContent()
        {
            Margin = new Margin();
        }


        // Methods
        protected Rectangle GenerateRectangle()
        {
            int x = Margin.Left;
            throw new Exception("");    // TO DO:
        }
    }
}
