namespace Italo.Customer.Api
{
    public class WeatherForecast
    {
        /// <summary>
        /// Date of forecast
        /// </summary>
        /// <example>Test example</example>
        public DateTime Date { get; set; }

        /// <summary>
        /// Temperature C
        /// </summary>
        /// <example>2</example>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Temperature F
        /// </summary>
        /// <example>3</example>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// Summary 
        /// </summary>
        /// <example>Test example</example>
        public string? Summary { get; set; }
    }
}