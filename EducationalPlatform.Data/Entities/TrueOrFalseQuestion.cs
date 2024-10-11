namespace EducationalPlatform.Data.Entities
{
    public class TrueOrFalseQuestion : Question
    {

        public ICollection<Answer> ChoiceList { get; set; }
    }
}
