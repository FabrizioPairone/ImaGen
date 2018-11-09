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

        /// <summary>
        /// If is true scaled image to targetSize
        /// </summary>
        public bool Scaled { get; set; }

        /// <summary>
        /// If the image will be resized, it will be resized through this choose.
        /// </summary>
        public ResizeMethod ResizeMethod { get; set; }

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
            Scaled = false;
            ResizeMethod = ResizeMethod.KeepProportions;
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
            Scaled = false;
            ResizeMethod = ResizeMethod.KeepProportions;
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
            // Calculate Offsets and x, y value of image and get base information
            int xStartDraw = Location.X + Padding.Right;
            int yStartDraw = Location.Y + Padding.Top;
            int targetWidth = imageToDraw.Width - xStartDraw - Padding.Right;
            int targetHeight = imageToDraw.Height - yStartDraw - Padding.Bottom;

            if (targetWidth > 0) throw new Exception("The target width it's biggest than width of image!");
            if (targetHeight > 0) throw new Exception("The target height it's biggest than height of image!");

            // Get correct image to render
            Image<TPixel> imageToRender = GetImageToRender(targetWidth, targetHeight);

            // Change Location Point adding Padding
            Point location = GetCorrectLocation();

            // Draw Image
            imageToDraw.Mutate(m => m.DrawImage(imageToRender, location, GraphicsOptions));

            // Return Image Drawn
            return imageToDraw;
        }

        // Private Methods
        private Image<TPixel> GetImageToRender(int targetWidth, int targetHeight)
        {
            Image<TPixel> image = Image.Clone();
            bool needResize = false;
            int widthResize = image.Width;
            int heightResize = image.Height;

            // Check if need resize and calculate width and height or resize.
            if (Scaled)
            {
                widthResize = targetWidth;
                heightResize = targetHeight;
                needResize = true;
            }
            else if (image.Width > targetWidth || image.Height > targetHeight)
            {
                needResize = true;

                switch (ResizeMethod)
                {
                    case ResizeMethod.KeepProportions:

                        // TO DO : CALCULATE X, Y PROPORTION

                        break;
                    case ResizeMethod.Scaled:
                        widthResize = (image.Width < targetWidth ? image.Width : targetWidth);
                        heightResize = (image.Height < targetHeight ? image.Height : targetHeight);
                        break;
                    default: throw new Exception("The Enum of ResizeMethod '" + ResizeMethod.ToString() + "' not implemented in ImageContent.Image.cs.GetImageToRender(); yet!");
                }
            }


            // If need to resize the image, I resize the image.
            if (needResize) image.Mutate(m => m.Resize(widthResize, heightResize));


            // Return Correct Image to Draw
            return image;
        }
        private Point GetCorrectLocation()
        {
            int xLocation = Location.X;
            int yLocation = Location.Y;

            // Adding Padding space
            xLocation += Padding.Right;
            yLocation += Padding.Top;

            // Return the Point
            return new Point(xLocation, yLocation);
        }

        #endregion

    }
}
