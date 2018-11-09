using ImaGen.ImageTemplates;
using ImaGen.Styles;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System;

namespace ImaGen.ImageContents
{

    /// <summary>
    /// Rappresent Image object in ImageContent collection
    /// </summary>
    public class ImageContentImage<TPixel> : ImageContent<TPixel> where TPixel : struct, IPixel<TPixel>
    {

        #region Attributes

        /// <summary>
        /// The Image of TPixel Type
        /// </summary>
        public Image<TPixel> Image { get; }

        /// <summary>
        /// Padding Space of Image
        /// </summary>
        public Padding Padding { get; set; }

        /// <summary>
        /// Location of Image. Default is x = 0, y = 0
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Graphics Options of Image
        /// </summary>
        public GraphicsOptions GraphicsOptions { get; set; }

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor of ImageContent: Image
        /// </summary>
        /// <param name="image">Image to Add</param>
        public ImageContentImage(Image<TPixel> image)
        {
            Image = image;
            Padding = new Padding() { All = 0 };
            Location = new Point(0, 0);
            GraphicsOptions = new GraphicsOptions();
        }

        /// <summary>
        /// Constructor of ImageContent: Image
        /// </summary>
        /// <param name="pathImage">path of the image to add</param>
        public ImageContentImage(string pathImage)
        {
            Image = SixLabors.ImageSharp.Image.Load<TPixel>(pathImage);
            Padding = new Padding() { All = 0 };
            Location = new Point(0, 0);
            GraphicsOptions = new GraphicsOptions();
        }

        #endregion


        #region Methods

        /// <summary>
        /// Draw ImageContent.Image
        /// </summary>
        /// <param name="imageToDraw">Image that will be draw</param>
        /// <param name="imageTemplate">Image Template</param>
        /// <returns></returns>
        public override Image<TPixel> RenderContent(Image<TPixel> imageToDraw, ImageTemplate<TPixel> imageTemplate)
        {
            // Params Draw Image:
            // 1) ImageToDraw - Control if the image is not so big for the targetSize (targetWidth, targetHeight) [Size - Padding]
            // 2) Location - Default is 0, 0 of target size. If is set control that it's ok the position (If the Image can be contained)
            // 3) Graphics Options - Are ok, user can set it.

            // OLD WAY 
            // imageToDraw.Mutate(m => m.DrawImage(Image, Opacity));
            // return imageToDraw;
            throw new Exception("Render Content of ImageContent.Image not implemented yet.");
        }

        #endregion

    }
}
