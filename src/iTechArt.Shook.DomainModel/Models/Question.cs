namespace iTechArt.Shook.DomainModel.Models
{
    public class Question
    {
        public const int QuestionMinLength = 10;
        public const int QuestionMaxLength = 250;

        public int Id { get; set; }

        public string Title { get; set; }

        public Survey Survey { get; set; }
    }
}
