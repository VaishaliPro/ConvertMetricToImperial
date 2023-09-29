using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UnitsNet;


namespace ConvertMetricToImperial.Controllers
{
    [Route("api/convertsion")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private readonly ConversionContext _context;

        public ConversionController(ConversionContext context)
        {
            _context = context;
        }

        [HttpGet("metric-to-imperial")]
        public ActionResult<string> MetricToImperial(double value, string fromUnit, string toUnit)
        {
            var conversionRate = _context.ConversionRates
                .FirstOrDefault(rate => rate.FromUnit == fromUnit && rate.ToUnit == toUnit);

            if (conversionRate == null)
            {
                return BadRequest("Unsupported conversion.");
            }

            var convertedValue = value * conversionRate.Rate;

            return Ok($"{value} {fromUnit} is approximately {convertedValue} {toUnit}.");
        }
    }
}
