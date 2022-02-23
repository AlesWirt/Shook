using System.Collections.Generic;

namespace iTechArt.Shook.WebApp.ViewModels
{
    public class SurveyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<QuestionViewModel> Questions { get; set; }
    }
}
