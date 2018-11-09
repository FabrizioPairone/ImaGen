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

        /// <summary>
        /// Padding of Text
        /// </summary>
        public Padding Padding { get; set; }

        /// <summary>
        /// Set if Font will be scaled or not
        /// </summary>
        public bool ScaledFont { get; set; }

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
            Padding = new Padding();
            ScaledFont = false;
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
            // Calculate Offsets and x, y value of image and get base information
            Font textFont = Font;
            TPixel? textColor = TextColor;
            int xOffset = GetXOffset();
            int yOffset = GetYOffset();
            int xStartDraw = GetXStartDraw(imageToDraw.Width);
            int yStartDraw = GetYStartDraw(imageToDraw.Height);
            int targetWidth = imageToDraw.Width - xStartDraw - Padding.Right;
            int targetHeight = imageToDraw.Height - yStartDraw - Padding.Bottom;
            if (textFont == null) textFont = imageTemplate.DefaultFont;
            if (textColor == null) textColor = imageTemplate.DefaultColorText;

            // Execute Control
            if ((imageToDraw.Width - Padding.Left - Padding.Right) <= 0) throw new Exception("Padding set it's biggest than width of image!");
            if ((imageToDraw.Height - Padding.Top - Padding.Bottom) <= 0) throw new Exception("Padding set it's biggest than height of image!");
            if (targetWidth > 0) throw new Exception("The target width it's biggest than width of image!");
            if (targetHeight > 0) throw new Exception("The target height it's biggest than height of image!");

            // Wrap Font
            textFont = WrapFont(textFont, targetWidth, targetHeight);

            // Draw Text
            TextGraphicsOptions textGraphicsOptions = new TextGraphicsOptions(true)
            {
                HorizontalAlignment = GetHorizontalTextAlignment(),
                VerticalAlignment = GetVerticalTextAlignment(),
                WrapTextWidth = targetWidth
            };

            imageToDraw.Mutate(m => m.DrawText(textGraphicsOptions, Text, textFont, (TPixel)textColor, new PointF(xStartDraw, yStartDraw)));


            // Return Image
            return imageToDraw;
        }

        // Private Methods
        private int GetXOffset()
        {
            if (Position is PositionCustom positionCustom) return positionCustom.X;
            return 0;
        }
        private int GetYOffset()
        {
            if (Position is PositionCustom positionCustom) return positionCustom.Y;
            return 0;
        }
        private int GetXStartDraw(int imageWidth)
        {
            if (Position is PositionAlignment positionAlignment)
            {
                switch (positionAlignment.HorizontalPosition)
                {
                    case HorizontalAlignment.Left: return Padding.Left;
                    case HorizontalAlignment.Center: return ((imageWidth - Padding.Left - Padding.Right) / 2) + Padding.Left;
                    case HorizontalAlignment.Right: return imageWidth - Padding.Right;
                }

                throw new Exception("Horizontal Position not supported!");
            }

            if (Position is PositionCustom positionCustom) return positionCustom.X + Padding.Left;

            throw new Exception("Position object '" + Position.GetType().Name + "' not implemented in ImageContent.Text.cs.GetXStartDraw();");
        }
        private int GetYStartDraw(int imageHeight)
        {
            if (Position is PositionAlignment positionAlignment)
            {
                switch (positionAlignment.VerticalPosition)
                {
                    case VerticalAlignment.Top: return Padding.Top;
                    case VerticalAlignment.Center: return ((imageHeight - Padding.Top - Padding.Bottom) / 2) + Padding.Top;
                    case VerticalAlignment.Bottom: return imageHeight - Padding.Bottom;
                }

                throw new Exception("Vertical Position not supported!");
            }

            if (Position is PositionCustom positionCustom) return positionCustom.Y + Padding.Top;

            throw new Exception("Position object '" + Position.GetType().Name + "' not implemented in ImageContent.Text.cs.GetYStartDraw();");
        }

        private HorizontalAlignment GetHorizontalTextAlignment()
        {
            if (Position is PositionAlignment positionAlignment) return positionAlignment.HorizontalPosition;
            if (Position is PositionCustom positionCustom) return positionCustom.HorizontalTextAlignment;

            throw new Exception("Position object '" + Position.GetType().Name + "' not implemented in ImageContent.Text.cs.GetHorizontalTextAlignment();");
        }
        private VerticalAlignment GetVerticalTextAlignment()
        {
            if (Position is PositionAlignment positionAlignment) return positionAlignment.VerticalPosition;
            if (Position is PositionCustom positionCustom) return positionCustom.VerticalTextAlignment;

            throw new Exception("Position object '" + Position.GetType().Name + "' not implemented in ImageContent.Text.cs.GetVerticalTextAlignment();");
        }

        private Font WrapFont(Font font, int targetWidth, int targetHeight)
        {
            SizeF s = new SizeF(float.MaxValue, float.MaxValue);
            float scaleFactor = (font.Size / 2); // everytime we change direction we half this size
            int trapCount = (int)font.Size * 2;
            if (trapCount < 10) trapCount = 10;
            bool isTooSmall = false;

            while ((s.Height != targetHeight) && trapCount > 0)
            {
                // If i decide to scaled font i will scale it
                if (ScaledFont)
                {
                    if (s.Height > targetHeight)
                    {
                        if (isTooSmall) scaleFactor = scaleFactor / 2;
                        font = new Font(font, font.Size - scaleFactor);
                        isTooSmall = false;
                    }

                    if (s.Height < targetHeight)
                    {
                        if (!isTooSmall) scaleFactor = scaleFactor / 2;
                        font = new Font(font, font.Size + scaleFactor);
                        isTooSmall = true;
                    }
                }

                // Measure Text
                s = TextMeasurer.Measure(Text, new RendererOptions(font) { WrappingWidth = targetWidth });

                trapCount--;                
            }

            // Return Font Wrapped
            return font;
        }

        #endregion

    }
}
