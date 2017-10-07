using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CountingRows
{
    class Controller
    {
        Model model = new Model();
        public List<Grid> AnalyseLogFile()
        {
            List<Grid> result = new List<Grid>();
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "log files (*.log)|*.log"
            };
            bool? search = open.ShowDialog();

            if (search == true)
            {
                string searchMask = "[ERROR]";
                foreach (string line in File.ReadLines(open.FileName))
                {
                    int indexOfString = line.IndexOf(searchMask);
                    if (indexOfString != -1)
                    {
                        string lineParse = line.Replace(searchMask, "").Trim();
                        string[] errorsParse = lineParse.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string errorParse in errorsParse)
                        {
                            if (model.DictionaryErrors.ContainsKey(errorParse.Trim()))
                            {
                                model.DictionaryErrors[errorParse.Trim()]++;
                            }
                            else
                            {
                                model.DictionaryErrors.Add(errorParse.Trim(), 1);
                            }
                        }
                    }
                }
            }
            foreach (var pair in model.DictionaryErrors.OrderByDescending(pair => pair.Value))
            {
                result.Add(new Grid(pair.Key, pair.Value));
            }   
            return result;
        }
    }
}
