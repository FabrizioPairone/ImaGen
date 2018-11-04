namespace ImaGen.ImageStyles
{
    public class Margin
    {
        // Private Attributes
        private int _top { get; set; }
        private int _left { get; set; }
        private int _right { get; set; }
        private int _bottom { get; set; }
        

        // Public Attributes
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
                _right = value;
                _bottom = value;
                _left = value;
            }
        }
        public int Top
        {
            get { return _top; }
            set { _top = value; }
        }
        public int Left
        {
            get { return _left; }
            set { _left = value; }
        }
        public int Right
        {
            get { return _right; }
            set { _right = value; }
        }
        public int Bottom
        {
            get { return _bottom; }
            set { _bottom = value; }
        }


        // Constructor
        public Margin()
        {
            All = 0;
        }

    }
}
