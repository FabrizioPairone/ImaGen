using ImaGen.Extensions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace ImaGen.ImageTemplates
{

    /// <summary>
    /// Template of Image based on Image Loaded
    /// </summary>
    /// <typeparam name="TPixel"></typeparam>
    public class TemplateFromImage<TPixel> : ImageTemplate<TPixel> where TPixel : struct, IPixel<TPixel>
    {

        #region Attributes

        /// <summary>
        /// Image used as based Image of Template
        /// </summary>
        public Image<TPixel> Image { get; }

        #endregion


        #region Constructor

        /// <summary>
        /// Constructor of TemplateFromImage passing the Image to start with the Template.
        /// </summary>
        /// <param name="image">Image to set as base of Template</param>
        public TemplateFromImage(Image<TPixel> image)
        {
            Image = image;
        }

        /// <summary>
        /// Constructor of TemplateFromImage passing the path of the Image used as base of Template
        /// </summary>
        /// <param name="pathImage">String that rappresent the path of the image to set as base of Template</param>
        public TemplateFromImage(string pathImage)
        {
            Image = SixLabors.ImageSharp.Image.Load<TPixel>(path: pathImage);
        }

        #endregion


        #region Methods

        /// <summary>
        /// Override method of abstract class for genereate image from 'FromImage' Temmplate
        /// </summary>
        /// <returns></returns>
        public override Image<TPixel> GenerateImageFromTemplate()
        {
            // Create new Image
            Image<TPixel> imgTemplate = Image.Clone();

            // Render Child
            imgTemplate.DrawDefaultImageContent(this);

            // Return the Image
            return Image;
        }

        #endregion

    }
}
