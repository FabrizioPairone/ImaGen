using ImaGen.ImageTemplates;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;

namespace ImaGen.ImageContents
{

    /// <summary>
    /// Abstract class of Image Contents
    /// </summary>
    public abstract class ImageContent<TPixel> where TPixel : struct, IPixel<TPixel>
    {

        /// <summary>
        /// Virtual method that draw the single content on the image
        /// </summary>
        /// <param name="imageToDraw">Image that will be draw</param>
        /// <param name="imageTemplate">Template of the Image. Can be null.</param>
        /// <returns></returns>
        public virtual Image<TPixel> RenderContent(Image<TPixel> imageToDraw, ImageTemplate<TPixel> imageTemplate) 
        {
            throw new Exception("For the type '" + typeof(TPixel).Name + "' the override method is not implemented yet!");
        }

    }

}
