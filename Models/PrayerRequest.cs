using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AshburtonCocWebsite.Models
{
    public class PrayerRequest
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Requestor { get; set; }
        public string Request { get; set; }
    }
}
