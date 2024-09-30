using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Service.Abstracts;

namespace EducationalPlatform.Service.Implementations
{
    public class AnswerService : IAnswerService
    {

        private readonly IAnswerRepository _AnswerRepository;
        public AnswerService(IAnswerRepository AnswerRepository)
        {
            _AnswerRepository = AnswerRepository;
        }

        public async Task<string> AddAnswer(Answer Answer)
        {


            await _AnswerRepository.AddAsync(Answer);
            return "Success";

        }

        public async Task<string> DeleteAsync(Answer Answer)
        {
            await _AnswerRepository.DeleteAsync(Answer);
            return "Success";
        }

        public async Task<Answer> GetAnswerByIdAsync(int id)
        {
            var Answer = _AnswerRepository.GetTableNoTracking().Where(x => x.AnswerId == id).SingleOrDefault();

            return Answer;
        }

        public async Task<List<Answer>> GetAnswersListAsync()
        {
            return await _AnswerRepository.GetAnswersListAsync();
        }

        public async Task<string> UpdateAsync(Answer Answer)
        {

            var transact = _AnswerRepository.BeginTransaction();
            try
            {
                await _AnswerRepository.UpdateAsync(Answer);

                await transact.CommitAsync();
                return "Success";

            }
            catch
            {
                await transact.RollbackAsync();
                return "Falied";
            }

        }



    }
}
