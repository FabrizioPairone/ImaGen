using ImaGen.ImageContents;
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
