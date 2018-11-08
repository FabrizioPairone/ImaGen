using ImaGen.ImageContents;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;

namespace ImaGen.ImageTemplates
{

    /// <summary>
    /// Class that contain the Template of the image
    /// </summary>
    public abstract class ImageTemplate<TPixel> where TPixel : struct, IPixel<TPixel>
    {

        #region Attributes

        /// <summary>
        /// Default font of text present in the Template
        /// </summary>
        public Font DefaultFont { get; set; }

        /// <summary>
        /// Default color of text present in the Template
        /// </summary>
        public TPixel? DefaultColorText { get; set; }

        /// <summary>
        /// List of Default Image Content present in the Template
        /// </summary>
        public List<ImageContent<TPixel>> ListDefaultImageContents { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ImageTemplate()
        {
            DefaultFont = SystemFonts.CreateFont("Arial", 10);
            // TO DO : SET DEFAULT COLOR HERE ! CONVERT COLOR IN TPIXEL [HOW TO DO IT?]
            DefaultColorText = null;
            ListDefaultImageContents = new List<ImageContent<TPixel>>();
        }

        #endregion


        #region Methods

        /// <summary>
        /// Virtual method that generate the image from the template
        /// </summary>
        /// <returns></returns>
        public virtual Image<TPixel> GenerateImageFromTemplate()
        {
            throw new Exception("For the type '" + typeof(TPixel).Name + "' the override method is not implemented yet!");
        }

        #endregion

    }

}
