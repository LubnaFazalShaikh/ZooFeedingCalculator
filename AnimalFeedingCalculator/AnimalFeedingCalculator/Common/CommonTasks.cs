using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Xml;

namespace AnimalFeedingCalculator.Common
{
    class CommonTasks
    {


       string Path = Directory.GetCurrentDirectory() + @"\Files\";

      
       public DataTable ConvertCSVtoDatatable()
        {
            DataTable dt = new DataTable();
            try
            {
            string csvPath = Path + "animals.csv";
            dt.Columns.AddRange(new DataColumn[4] {
            new DataColumn("Animal", typeof(string)),
            new DataColumn("Rate", typeof(double)),
            new DataColumn("Eats", typeof(string)),
            new DataColumn("Percent", typeof(string))
             });

                //Read the contents of CSV file.  
                string csvData = File.ReadAllText(csvPath);

                //Execute a loop over the rows.  
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        dt.Rows.Add();
                        int i = 0;

                        //Execute a loop over the columns.  
                        foreach (string cell in row.Split(';'))
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell == "\r" ? "" : cell.Replace("%", "").Trim();
                            i++;
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            return dt;
        }

        public XmlDocument LoadXmlDoc ()
        {
            string xmlPath = Path +"zoo.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            return doc;
        }

        public string[] ReadTextFile()
        {
            string txtPath = Path +"prices.txt";
            string[] lines = System.IO.File.ReadAllLines(txtPath);
            return lines;

        }
    }
}
