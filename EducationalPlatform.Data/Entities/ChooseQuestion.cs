namespace EducationalPlatform.Data.Entities
{
    public class ChooseQuestion : Question
    {

        public ICollection<Answer> ChoiceList { get; set; }

    }
}
