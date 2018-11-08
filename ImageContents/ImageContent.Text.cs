using ImaGen.ImageTemplates;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Primitives;
using SixLabors.ImageSharp.Processing;

namespace ImaGen.ImageContents
{

    /// <summary>
    /// Rappresent the Text object in ImageContent Collection
    /// </summary>
    /// <typeparam name="TPixel"></typeparam>
    public class ImageContentText<TPixel> : ImageContent<TPixel> where TPixel : struct, IPixel<TPixel>
    {

        #region Attributes

        /// <summary>
        /// Color of Text. If is null, take default color of Image Template.
        /// </summary>
        public TPixel? TextColor { get; set; }

        /// <summary>
        /// Font of the Text. If is null, take default color of Image Template.
        /// </summary>
        public Font Font { get; set; }

        /// <summary>
        /// The Text to draw on Image.
        /// </summary>
        public string Text { get; set; }

        
        // TO DO : ADD POSITION

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor of ImageContent.Text
        /// </summary>
        /// <param name="text">Text to Draw</param>
        public ImageContentText(string text)
        {
            Text = text;
            TextColor = null;
            Font = null;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Draw ImageContent.Text
        /// </summary>
        /// <param name="imageToDraw">Image that will be draw</param>
        /// <param name="imageTemplate">Image Template</param>
        /// <returns></returns>
        public override Image<TPixel> RenderContent(Image<TPixel> imageToDraw, ImageTemplate<TPixel> imageTemplate)
        {
            Font fontText = Font;
            TPixel? textColor = TextColor;
            if (fontText == null) fontText = imageTemplate.DefaultFont;
            if (textColor == null) textColor = imageTemplate.DefaultColorText;

            if (fontText != null && TextColor != null)
                imageToDraw.Mutate(m => m.DrawText(Text, fontText, (TPixel)textColor, new PointF(0, 0)));   // TO DO : ADD ALIGNMENT AND POINT ! [POSITION] - BASED ON POINT

            return imageToDraw;
        }

    }
}
