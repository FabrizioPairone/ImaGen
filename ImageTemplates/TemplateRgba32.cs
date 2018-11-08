using ImaGen.Extensions;
using ImaGen.ImageContents;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;

namespace ImaGen.ImageTemplates
{

    /// <summary>
    /// Template of Image based on Rgba32 Pixel
    /// </summary>
    public class TemplateRgba32 : ImageTemplate<Rgba32>
    {

        #region Attributes 

        /// <summary>
        /// Width of Image
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Height of Image
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Background Color of Image
        /// </summary>
        public Rgba32? BackgrounColor { get; set; }

        /// <summary>
        /// Background Image of Image
        /// </summary>
        public ImageContentImage<Rgba32> BackgroundImage { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Constructor of Image Template with Rgba32 Pixel
        /// </summary>
        /// <param name="width">width of image</param>
        /// <param name="height">height of image</param>
        public TemplateRgba32(int width, int height)
        {
            if (width <= 0) throw new Exception("Width param can't be less than or equal 0!");
            if (height <= 0) throw new Exception("Height param can't be less than or equal 0!");

            Width = width;
            Height = height;
            BackgrounColor = Rgba32.White;
            BackgroundImage = null;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Override method of abstract class for genereate image from Rgba32 Temmplate
        /// </summary>
        /// <returns></returns>
        public override Image<Rgba32> GenerateImageFromTemplate()
        {
            // Create Image
            Image<Rgba32> imgTemplate = new Image<Rgba32>(Width, Height);

            // Add Background Info
            imgTemplate.DrawBackground(backgroundColor: BackgrounColor, backgroundImage: BackgroundImage);

            // Render Child
            imgTemplate.DrawDefaultImageContent(this);

            // Return the Image
            return imgTemplate;
        }

        #endregion

    }
}
