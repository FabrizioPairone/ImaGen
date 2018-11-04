using System;
using System.Collections.Generic;
using System.Text;

namespace ImaGen
{
    public class ImageGenerator
    {

        // Private Attributes
        private ImageTemplate ImageTemplate { get; }
        

        // Constructor
        public ImageGenerator(ImageTemplate imageTemplate)
        {
            ImageTemplate = imageTemplate;
        }

    }
}
