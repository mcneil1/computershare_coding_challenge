using System;

namespace Computershare
{
    class Program
    {
        static void Main(string[] args)
        {
            //path to txt file
            string filepath = "ChallengeSampleDataSet2.txt";

            //Array for holding the stock values for each day
            float[] stocks = new float[30];
            
            int day = 1;

            //Read each line from text file
            string[] lines = System.IO.File.ReadAllLines(filepath);
            foreach(string line in lines)
            {
                //split each line into columns
                string[] column = line.Split(',');
                for(int i = 0; i < stocks.Length; i++)
                {
                    //parse each string and place into the stocks array
                    float stock = float.Parse(column[i]);
                    stocks[i] = stock;
                }
            }

            //store best buy/sell dates
            float bestBuyPrice = 0;
            int buysDay = 0;

            float bestSellsPrice = 0; 
            int sellsDay = 0;

            float bestDifference = 0; //store the current best profit margin



            //For each potential buy date compare the profit margin against each potential sell date
            //save the buy and sell dates with the highest profit margin
            foreach(float value in stocks)
            {
                float buysPrice = value; //buy value we are comparing 
                int buyDay = day;
                for(int i = day+1; i <= stocks.Length; i++) //make sure that sell date is after the buy date
                {
                    float sellsPrice = stocks[i-1]; //sell value we are comparing
                    int sellDay = i;

                    float difference = sellsPrice - buysPrice; //calculate profit and compare against best profit so far
                    if (difference > bestDifference)
                    {
                        bestBuyPrice = buysPrice;
                        buysDay = buyDay;

                        bestSellsPrice = sellsPrice;
                        sellsDay = sellDay;

                        bestDifference = difference;
                    }
                }

                day++;
            }     

            Console.WriteLine(buysDay+"("+bestBuyPrice+"),"+sellsDay+"("+bestSellsPrice+")");
        }
    }
}
