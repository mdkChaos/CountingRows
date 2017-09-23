using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CountingRows
{
    class Controller
    {
        Model model = new Model();
        public List<Grid> AnalyseLogFile()
        {
            List<Grid> result = new List<Grid>();
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "log files (*.log)|*.log";
            bool? search = open.ShowDialog();

            if (search == true)
            {
                string lines = open.FileName;
                string searchMask = "[ERROR]";
                foreach (string line in File.ReadLines(lines))
                {
                    int? indexOfString = line.IndexOf(searchMask);
                    if (indexOfString >= 0)
                    {
                        string lineParse = line.Replace(searchMask, "");
                        lineParse = lineParse.Trim();
                        string[] errorsParse = lineParse.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string errorParse in errorsParse)
                        {
                            if (model.dictionaryErrors.ContainsKey(errorParse.Trim()))
                            {
                                model.dictionaryErrors[errorParse.Trim()]++;
                            }
                            else
                            {
                                model.dictionaryErrors.Add(errorParse.Trim(), 1);
                            }
                        }
                    }
                }
            }
            result.Add(new Grid("Error", 0));
            foreach (var pair in model.dictionaryErrors.OrderByDescending(pair => pair.Value))
            {
                result.Add(new Grid(pair.Key, pair.Value));
            }   
            return result;
        }
    }
}
