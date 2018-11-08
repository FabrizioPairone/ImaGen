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

        #endregion


        #region Constructor

        /// <summary>
        /// Constructor of Position Custom
        /// </summary>
        public PositionCustom()
        {
            X = 0;
            Y = 0;
        }

        #endregion

    }

}
