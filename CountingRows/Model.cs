using System.Collections.Generic;

namespace CountingRows
{
    class Model
    {
        private Dictionary<string, int> dictionaryErrors = new Dictionary<string, int>();

        public Dictionary<string, int> DictionaryErrors { get => dictionaryErrors; set => dictionaryErrors = value; }
    }
}
