using ImaGen.ImageTemplates;
using ImaGen.Styles;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Primitives;
using SixLabors.ImageSharp.Processing;
using System;

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

        /// <summary>
        /// Position of Text
        /// </summary>
        public Position Position { get; set; }

        // TO DO : ADD PADDING

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
            Position = new PositionAlignment()
            {
                HorizontalPosition = HorizontalAlignment.Left,
                VerticalPosition = VerticalAlignment.Top
            };
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
            Font textFont = Font;
            TPixel? textColor = TextColor;
            if (textFont == null) textFont = imageTemplate.DefaultFont;
            if (textColor == null) textColor = imageTemplate.DefaultColorText;

            if(textFont != null && TextColor != null)
            {
                if (Position is PositionAlignment positionAlignment)
                {
                    int xPosition = GetXPositionAlignment(imageToDraw.Width, positionAlignment.HorizontalPosition);
                    int yPosition = GetYPositionAlignment(imageToDraw.Height, positionAlignment.VerticalPosition);
                    TextGraphicsOptions textGraphicsOptions = new TextGraphicsOptions(true)
                    {
                        HorizontalAlignment = positionAlignment.HorizontalPosition,
                        VerticalAlignment = positionAlignment.VerticalPosition
                    };
                    imageToDraw.Mutate(m => m.DrawText(textGraphicsOptions, Text, textFont, (TPixel)textColor, new PointF(xPosition, yPosition)));
                }
                else if (Position is PositionCustom positionCustom)
                {
                    int xPosition = GetXPositionCustom(imageToDraw.Width, positionCustom.X);
                    int yPosition = GetYPositionCustom(imageToDraw.Height, positionCustom.Y);
                    imageToDraw.Mutate(m => m.DrawText(Text, textFont, (TPixel)textColor, new PointF(xPosition, yPosition)));
                }
            }
            

            return imageToDraw;
        }


        // Private Methods
        private int GetXPositionAlignment(int widthImage, HorizontalAlignment horizontalPosition)
        {
            switch(horizontalPosition)
            {
                case HorizontalAlignment.Left: return 0;
                case HorizontalAlignment.Center: return (widthImage / 2);
                case HorizontalAlignment.Right: return widthImage;
            }

            throw new Exception("Horizontal Position not supported!");
        }
        private int GetYPositionAlignment(int heightImage, VerticalAlignment verticalPosition)
        {
            switch(verticalPosition)
            {
                case VerticalAlignment.Top: return 0;
                case VerticalAlignment.Center: return (heightImage / 2);
                case VerticalAlignment.Bottom: return heightImage;
            }

            throw new Exception("Vertical Position not supported!");
        }
        private int GetXPositionCustom(int widthImage, int xPosition)
        {
            return widthImage < xPosition ? widthImage : xPosition;
        }
        private int GetYPositionCustom(int heightImage, int yPosition)
        {
            return heightImage < yPosition ? heightImage : yPosition;
        }

        #endregion

    }
}
