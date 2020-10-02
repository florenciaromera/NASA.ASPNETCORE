using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NASA.Entities
{
    [Table("temperature")]
    public class Temperature
    {
        [Key]
        [Column("temperature_id")]
        public int TemperatureId { get; set; }

        [Column("temperature_year")]
        public int TemperatureYear { get; set; }

        public double Degrees { get; set; }

        [Column("country_code")]
        public int CountryCode { get; set; }

        public Country Country { get; set; }

    }
}
