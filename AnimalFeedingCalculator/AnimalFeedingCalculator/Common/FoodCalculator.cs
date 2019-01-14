using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace AnimalFeedingCalculator.Common
{
    public class FoodCalculator
    {
        public double GetFoodRate(string foodType)
        {
            double total = 0;
            try
            {
                CommonTasks cm = new CommonTasks();
                XmlDocument doc = cm.LoadXmlDoc();
                DataTable dt = cm.ConvertCSVtoDatatable();
                string[] priceArray = cm.ReadTextFile();
                double foodprice = Convert.ToDouble(priceArray.Where(x => x.ToLower().Contains(foodType)).FirstOrDefault().Split('=')[1]);
                Dictionary<string, double> AnimalWithRate = new Dictionary<string, double>();
                double weight = 0;

                double foodPercent;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        XmlNodeList elemList = doc.GetElementsByTagName(dr["Animal"].ToString());
                        if (elemList.Count > 0)
                        {
                            for (int i = 0; i < elemList.Count; i++)

                            {
                                double rate = 0;
                                weight = Convert.ToDouble(elemList[i].Attributes["kg"].Value)!=0 ? Convert.ToDouble(elemList[i].Attributes["kg"].Value) :0;
                                if (weight > 0)
                                {
                                    if (dr["Eats"].ToString().ToLower() == foodType)
                                    {
                                        rate = weight * Convert.ToDouble(dr["Rate"].ToString()) * foodprice;
                                    }

                                    else if (dr["Eats"].ToString().ToLower() == "both" && foodType == "fruit")
                                    {
                                        foodPercent = (100 - Convert.ToDouble(dr["Percent"].ToString())) * 0.01;
                                        rate = (weight * Convert.ToDouble(dr["Rate"].ToString()) * foodprice * foodPercent);
                                    }
                                    else if (dr["Eats"].ToString().ToLower() == "both" && foodType == "meat")
                                    {
                                        foodPercent = Convert.ToDouble(dr["Percent"].ToString()) * 0.01;
                                        rate = (weight * Convert.ToDouble(dr["Rate"].ToString()) * foodprice * foodPercent);
                                    }
                                }
                                else
                                {
                                    Console.Write("Incorrect weight");
                                }
                                if (rate > 0)
                                    {
                                        if (!AnimalWithRate.ContainsKey(dr["Animal"].ToString()))
                                            AnimalWithRate.Add(dr["Animal"].ToString(), rate);
                                        else
                                            AnimalWithRate[dr["Animal"].ToString()] = AnimalWithRate[dr["Animal"].ToString()] + rate;
                                    }
                               
                            }
                        }

                    }
                }
                foreach (KeyValuePair<string, double> kv in AnimalWithRate)
                {
                    total = total + kv.Value;
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return total;
        }
    }
}
