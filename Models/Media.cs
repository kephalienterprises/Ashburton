using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AshburtonCocWebsite.Models
{
    public class Media : IValidatableObject
    {
        public int Id { get; set; }

        [DisplayName("Speaker")]
        public string SpeakerName { get; set; } //Preacher or teacher name or name of group (for singings, etc.)

        [Required]
        public string Title { get; set; }
        public string Tags { get; set; }
        public string Scriptures { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        public string Service { get; set; } //Sunday AM, PM, Wednesday, Other
        
        [DisplayName("Type")]
        public string Activity { get; set; } //Sermon, Class, Singing, Other

        [DisplayName("Video Path")]
        public string VideoPath { get; set; }

        [DisplayName("Audio Path")]
        public string AudioPath { get; set; }

        [DisplayName("Materials Path")]
        public string MaterialsPath { get; set; } //Powerpoint, etc.

        [DisplayName("Image Path")]
        public string ImagePath { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (1 != 1 && Title == SpeakerName)
            {
                yield return new ValidationResult(
                    "Error",
                    new[] {nameof(Title), nameof(SpeakerName)}  //the view will display "Error" next to both the Title and SpeakerName areas
                    );
            }
        }
    }
}
