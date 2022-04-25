namespace JsonComparer
{
    internal class LevellessCompare
    {
        public string leftPath, rightPath;
        public object left, right;

        public LevellessCompare(string jPathLeft, string jPathRight, object _left, object _right)
        {
            this.leftPath = jPathLeft;
            this.rightPath = jPathRight;
            this.left = _left;
            this.right = _right;
        }
    }
}
