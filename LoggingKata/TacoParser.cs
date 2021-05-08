namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public static ITrackable Parse(string line)
        {
            //logger.LogInfo("Begin parsing");
            if (line == null)
            {
                return null;
            } 

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            var latitude = double.Parse(cells[0]);  
            var longitude = double.Parse(cells[1]); 
            var name = cells[2];

            var tacoBell = new TacoBell(name, latitude, longitude);
            
            return tacoBell; 
        }
    }
}