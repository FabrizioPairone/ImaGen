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

        /// <summary>
        /// List of Image Contents to draw
        /// </summary>
        public List<ImageContent<TPixel>> ListImageContent { get; set; }

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
        /// Method that generate the Image based only on ImageTemplate
        /// </summary>
        public Image<TPixel> GenerateImageTemplate()
        {
            return ImageTemplate.GenerateImageFromTemplate();
        }

        /// <summary>
        /// Method that generate the Image based only on ImageTemplate and draw on it the list of image content passed
        /// </summary>
        public Image<TPixel> GenerateImageComplete()
        {
            // Create adn Draw Template
            Image<TPixel> imageRet = ImageTemplate.GenerateImageFromTemplate();

            // Draw Content 
            foreach (ImageContent<TPixel> content in ListImageContent)
                imageRet = content.RenderContent(imageRet, ImageTemplate);

            // Return Image
            return imageRet;
        }

        #endregion

    }
}
