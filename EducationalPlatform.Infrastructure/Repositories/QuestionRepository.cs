using EducationalPlatform.Data.Dto;
using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Infrastructure.Bases;
using EducationalPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Infrastructure.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        private readonly DbSet<Question> _questions;
        private readonly DbSet<WriteQuestion> _writeQuestions;
        private readonly DbSet<TrueOrFalseQuestion> _trueOrFalseQuestions;
        private readonly DbSet<ChooseQuestion> _chooseQuestions;
        //private readonly DbSet<Answer> _answers;


        public QuestionRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _questions = dbContext.Set<Question>();
            _writeQuestions = dbContext.Set<WriteQuestion>();
            _trueOrFalseQuestions = dbContext.Set<TrueOrFalseQuestion>();
            _chooseQuestions = dbContext.Set<ChooseQuestion>();
            // _answers = dbContext.Set<Answer>();
        }

        public async Task<string> AddChooseQuestionAsync(ChooseQuestion question)
        {
            var result = await _chooseQuestions.AddAsync(question);
            await _dbContext.SaveChangesAsync();
            if (result == null)
            {
                return "Cant Add";
            }
            else
            {
                return "Success";
            }
        }

        public async Task<string> AddTrueOrFalseQuestionAsync(TrueOrFalseQuestion question)
        {
            var result = await _trueOrFalseQuestions.AddAsync(question);
            await _dbContext.SaveChangesAsync();
            if (result == null)
            {
                return "Cant Add";
            }
            else
            {
                return "Success";
            }
        }

        public async Task<string> AddWritenQuestionAsync(WriteQuestion question)
        {
            var result = await _writeQuestions.AddAsync(question);
            await _dbContext.SaveChangesAsync();
            if (result == null)
            {
                return "Cant Add";
            }
            else
            {
                return "Success";
            }
        }

        public async Task<List<Answer>> GetChoiceListAsyncFor(string Questiontype, int id)
        {
            var exist = await _questions.FindAsync(id);
            List<Answer> ChoiceList = new List<Answer>();


            if (exist == null)
            {
                return ChoiceList;
            }
            if (Questiontype == "Writen")
            {
                var question = await _writeQuestions.Include(x => x.Answer).Where(x => x.QuestionId == id).FirstOrDefaultAsync();
                ChoiceList.Add(question.Answer);
                return ChoiceList;
            }
            else if (Questiontype == "TrueOrFalse")
            {


                // ChoiceList.AddRange(_answers.Take(2));
                return ChoiceList;

            }
            else if (Questiontype == "Choose")
            {
                var question = await _chooseQuestions.Include(x => x.ChoiceList).Where(x => x.QuestionId == id).FirstOrDefaultAsync();
                ChoiceList.AddRange(question.ChoiceList);
                return ChoiceList;

            }
            else
            {
                //Not a type
                return ChoiceList;

            }
        }

        public async Task<string> UpdateByTypeAsync(EditQuestionResult request)
        {
            if (request.QuestionType == "Writen")
            {
                var writenQuestion = new WriteQuestion()
                {
                    QuestionId = request.QuestionId,
                    QuestionText = request.QuestionText,
                    QuestionImage = request.QuestionImage,
                    CorrectAnswerId = (int)request.correctAnswerId,
                    QuestionType = request.QuestionType

                };

                var result = _writeQuestions.Update(writenQuestion);
                await _dbContext.SaveChangesAsync();

                return "Success";

            }
            else if (request.QuestionType == "TrueOrFalse")
            {
                return "Not Emplemented";

            }
            else if (request.QuestionType == "Choose")
            {
                return "Not Emplemented";

            }
            else
            {
                return $"There is no question type = {request.QuestionType}";
            }
        }
    }
}
