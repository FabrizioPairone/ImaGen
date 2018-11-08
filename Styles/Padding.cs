namespace ImaGen.Styles
{

    /// <summary>
    /// Padding of ImageContent
    /// </summary>
    public class Padding
    {

        #region Attributes

        // Private Attributes
        private int _all { get; set; }
        private int _top { get; set; }
        private int _left { get; set; }
        private int _right { get; set; }
        private int _bottom { get; set; }
             
        /// <summary>
        /// All Padding Space
        /// </summary>
        public int All
        {
            get
            {
                if (_top == _left && _left == _right && _right == _bottom)
                    return _top;
                return 0;
            }
            set
            {
                _top = value;
                _left = value;
                _right = value;
                _bottom = value;
            }
        }

        /// <summary>
        /// Top Padding Space
        /// </summary>
        public int Top
        {
            get { return _top; }
            set { _top = value; }
        }

        /// <summary>
        /// Left Padding Space
        /// </summary>
        public int Left
        {
            get { return _left; }
            set { _left = value; }
        }

        /// <summary>
        /// Right Padding Space
        /// </summary>
        public int Right
        {
            get { return _right; }
            set { _right = value; }
        }

        /// <summary>
        /// Bottom Padding Space
        /// </summary>
        public int Bottom
        {
            get { return _bottom; }
            set { _bottom = value; }
        }


        #endregion


        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public Padding()
        {
            All = 0;
        }

        #endregion

    }
}
