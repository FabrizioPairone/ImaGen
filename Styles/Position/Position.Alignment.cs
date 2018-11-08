using SixLabors.Fonts;

namespace ImaGen.Styles
{

    /// <summary>
    /// Alignment Position of ImageContent
    /// </summary>
    public class PositionAlignment : Position 
    {

        #region Attributes

        /// <summary>
        /// Horizontal alignment of ImageContent
        /// </summary>
        public HorizontalAlignment HorizontalPosition { get; set; }

        /// <summary>
        /// Vertical alignment of ImageContent
        /// </summary>
        public VerticalAlignment VerticalPosition { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Constructor of Position Alignment
        /// </summary>
        public PositionAlignment()
        {
            HorizontalPosition = HorizontalAlignment.Left;
            VerticalPosition = VerticalAlignment.Top;
        }

        #endregion

    }
}
