using ImaGen.ImageTemplates;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ImaGen.ImageContents
{

    /// <summary>
    /// Rappresent Image object in ImageContent collection
    /// </summary>
    public class ImageContentImage<TPixel> : ImageContent<TPixel> where TPixel : struct, IPixel<TPixel>
    {

        #region Attributes

        // Private Attrivute for opacity
        private float _opacity { get; set; }


        /// <summary>
        /// The Image of TPixel Type
        /// </summary>
        public Image<TPixel> Image { get; }

        /// <summary>
        /// Opacity of Image. Value must be between 0 and 1
        /// </summary>
        public float Opacity
        {
            get { return _opacity; }
            set { _opacity = (value < 0 ? 0 : value > 1 ? 1 : value); }
        }

        // TO DO : ADD POSITION !

        // TO DO : ADD SIZE !

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor of ImageContent: Image
        /// </summary>
        /// <param name="image">Image to Add</param>
        public ImageContentImage(Image<TPixel> image)
        {
            Opacity = 1;
            Image = image;
        }

        /// <summary>
        /// Constructor of ImageContent: Image
        /// </summary>
        /// <param name="pathImage">path of the image to add</param>
        public ImageContentImage(string pathImage)
        {
            Opacity = 1;
            Image = SixLabors.ImageSharp.Image.Load<TPixel>(pathImage);
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
            // TO DO : MANAGE POSITION AND SIZE !
            imageToDraw.Mutate(m => m.DrawImage(Image, Opacity));
            return imageToDraw;
        }

        #endregion

    }
}
