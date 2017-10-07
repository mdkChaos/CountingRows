namespace CountingRows
{
    class Grid
    {
        public string TextError { get; set; }
        public int CountError { get; set; }

        public Grid(string textError, int countError)
        {
            TextError = textError;
            CountError = countError;
        }
    }
}
