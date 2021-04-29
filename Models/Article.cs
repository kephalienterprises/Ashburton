using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AshburtonCocWebsite.Models
{
    public class Article
    {
        public int Id { get; set; }

        [DisplayName("Author")]
        public string AuthorName { get; set; }

        public string Title { get; set; }
        public string Tags { get; set; }
        public string Scriptures { get; set; }
        public string Body { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
