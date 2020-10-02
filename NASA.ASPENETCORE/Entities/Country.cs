using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NASA.Entities
{
    [Table("country")]
    public class Country
    {
        [Key]
        [Column("country_code")]
        public int CountryCode { get; set; }
        
        [Column("nombre")]
        public string Name { get; set; }

        public List<Temperature> Temperatures { get; set; } = new List<Temperature>();

    }
}
