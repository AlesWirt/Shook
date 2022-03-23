using System.Collections.Generic;

namespace iTechArt.Shook.DomainModel.Models
{
    public class Survey
    {
        public const int SurveyMinLength = 10;
        public const int SurveyMaxLength = 60;


        public int Id { get; set; }

        public string Title { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }

        public List<Question> Questions { get; set; }
    }
}
