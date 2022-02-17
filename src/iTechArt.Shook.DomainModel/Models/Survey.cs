namespace iTechArt.Shook.DomainModel.Models
{
    public class Survey
    {
        public const int SurveyMinLength = 20;
        public const int SurveyMaxLength = 60;

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
