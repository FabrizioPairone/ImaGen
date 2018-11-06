using ImaGen.ImageContents;
using ImaGen.ImageTemplates;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Generic;

namespace ImaGen
{

    /// <summary>
    /// Image Generator class
    /// </summary>
    public class ImageGenerator<TPixel> where TPixel : struct, IPixel<TPixel>
    {

        #region Attributes

        /// <summary>
        /// Image Template that Image Generator will be based
        /// </summary>
        private ImageTemplate<TPixel> ImageTemplate { get; }

        #endregion


        #region Constructor

        /// <summary>
        /// Constructor of Image Generator
        /// </summary>
        /// <param name="imageTemplate"></param>
        public ImageGenerator(ImageTemplate<TPixel> imageTemplate)
        {
            ImageTemplate = imageTemplate;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Method that generate the Image based only on ImageTemplate and draw on it the list of image content passed
        /// </summary>
        public Image<TPixel> GenerateImage(List<ImageContent> listImageContentToDraw)
        {
            Image<TPixel> imageRet = ImageTemplate.GenerateImageFromTemplate();
            // TO DO : Draw Contents
            return imageRet;
        }

        /// <summary>
        /// Method that generate the Image based only on ImageTemplate
        /// </summary>
        public Image<TPixel> GenerateImageTemplate()
        {
            return ImageTemplate.GenerateImageFromTemplate();
        }

        #endregion

    }
}
