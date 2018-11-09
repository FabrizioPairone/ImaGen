using SixLabors.Fonts;

namespace ImaGen.Styles
{

    /// <summary>
    /// Custom Position of ImageContent
    /// </summary>
    public class PositionCustom : Position
    {

        #region Attributes

        /// <summary>
        /// X position of ImageContent
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y position of ImageContent
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Horizontal Text Alignment
        /// </summary>
        public HorizontalAlignment HorizontalTextAlignment { get; set; }

        /// <summary>
        /// Vertical Text Alignment
        /// </summary>
        public VerticalAlignment VerticalTextAlignment { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Constructor of Position Custom
        /// </summary>
        public PositionCustom()
        {
            X = 0;
            Y = 0;
            HorizontalTextAlignment = HorizontalAlignment.Left;
            VerticalTextAlignment = VerticalAlignment.Top;
        }

        #endregion

    }

}
