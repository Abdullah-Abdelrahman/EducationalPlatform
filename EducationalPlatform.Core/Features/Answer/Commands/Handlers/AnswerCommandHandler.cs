using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Answer.Commands.Models;
using EducationalPlatform.Service.Abstracts;
using MediatR;

using An = EducationalPlatform.Data.Entities;
namespace EducationalPlatform.Core.Features.Answer.Commands.Handlers
{
    public class AnswerCommandHandler : ResponseHandler,
        IRequestHandler<AddAnswerCommand, Response<string>>,
        IRequestHandler<DeleteAnswerCommand, Response<string>>,
        IRequestHandler<EditAnswerCommand, Response<string>>
    {

        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;
        public AnswerCommandHandler(IMapper mapper, IAnswerService answerService)
        {
            _answerService = answerService;
            _mapper = mapper;
        }



        public async Task<Response<string>> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            var answerMapper = _mapper.Map<An.Answer>(request);
            var result = await _answerService.AddAnswer(answerMapper);

            if (result == "Success")
            {
                return Created<string>("Added successfuly");
            }
            else
            {
                return BadRequest<string>("Somthing bad happened");
            }
        }

        public async Task<Response<string>> Handle(EditAnswerCommand request, CancellationToken cancellationToken)
        {

            var courseInDB = await _answerService.GetAnswerByIdAsync(request.AnswerId);


            if (courseInDB == null)
            {
                return NotFound<string>("There is no Answer with this id");
            }
            else
            {
                var AnswerMapper = _mapper.Map<An.Answer>(request);
                var result = await _answerService.UpdateAsync(AnswerMapper);

                if (result == "Success")
                {
                    return Success<string>($"Updated successfuly {AnswerMapper.AnswerId}");
                }
                else
                {
                    return BadRequest<string>("Error Equired");
                }
            }
        }

        public async Task<Response<string>> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            var courseInDB = await _answerService.GetAnswerByIdAsync(request.Id);


            if (courseInDB == null)
            {
                return NotFound<string>("There is no Answer with this id");
            }
            else
            {

                var result = await _answerService.DeleteAsync(courseInDB);

                if (result == "Success")
                {
                    return Deleted<string>();
                }
                else
                {
                    return BadRequest<string>("Error Equired");
                }



            }
        }




    }
}
