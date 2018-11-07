using ImaGen.ImageContents;
using ImaGen.ImageTemplates;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ImaGen.Extensions
{

    /// <summary>
    /// Static class that extend the method for ImageTemplate
    /// </summary>
    public static class ImageTemplateExtensions
    {

        /// <summary>
        /// Draw the background of Image based on param received
        /// </summary>
        /// <typeparam name="TPixel">Type of Pixel of Image</typeparam>
        /// <param name="imageFromTemplate">The image generated from template</param>
        /// <param name="backgroundColor">The Background Color under TPixel format</param>
        /// <param name="backgroundImage">The Background Image</param>
        /// <returns>Return Image with background information drawn</returns>
        public static Image<TPixel> DrawBackground<TPixel>(this Image<TPixel> imageFromTemplate, TPixel? backgroundColor = null, ImageContentImage<TPixel> backgroundImage = null) where TPixel : struct, IPixel<TPixel>
        {
            if (backgroundColor != null) imageFromTemplate.Mutate(m => m.BackgroundColor((TPixel)backgroundColor));
            if (backgroundImage != null) imageFromTemplate.Mutate(m => m.DrawImage(backgroundImage.Image, backgroundImage.Opacity));

            return imageFromTemplate;
        }

        /// <summary>
        /// Draw the Image Contents of Image Template
        /// </summary>
        /// <typeparam name="TPixel">Type of Pixel of image</typeparam>
        /// <param name="imageFromTemplate">The image generated from template</param>
        /// <param name="imageTemplate">The Image Template object</param>
        /// <returns></returns>
        public static Image<TPixel> DrawDefaultImageContent<TPixel>(this Image<TPixel> imageFromTemplate, ImageTemplate<TPixel> imageTemplate) where TPixel : struct, IPixel<TPixel>
        {
            if(imageTemplate.ListDefaultImageContents != null)
            {
                foreach (ImageContent<TPixel> content in imageTemplate.ListDefaultImageContents)
                    imageFromTemplate = content.RenderContent(imageFromTemplate, imageTemplate);
            }

            return imageFromTemplate;
        }

    }
}
