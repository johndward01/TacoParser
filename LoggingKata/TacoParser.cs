using LoggingKata.Logging;
using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {        
        public static ITrackable Parse(string line)
        {
            LogHelper.Log(LogHelper.LogTarget.File, line);

            if (line == null)
            {
                LogHelper.Log(LogHelper.LogTarget.File, "Line was null");
                return null;
            } 

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                LogHelper.Log(LogHelper.LogTarget.File, "1 of the cells was null");
                return null; 
            }

            var latitude = double.Parse(cells[0]);  
            var longitude = double.Parse(cells[1]); 
            var name = cells[2];

            var tacoBell = new TacoBell(name, latitude, longitude);
            
            return tacoBell; 
        }
    }
}