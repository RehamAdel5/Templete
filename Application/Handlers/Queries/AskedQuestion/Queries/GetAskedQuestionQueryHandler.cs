using Domain.Abstractions;
using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.AskedQuestion.Queries
{
    public class GetAskedQuestionQueryHandler : IRequestHandler<GetAskedQuestionQuery, List<AskedQuestionsViewModel>>
    {
        private readonly IAskedQuestionRepository _AskedQuestionRepository; 
        public GetAskedQuestionQueryHandler(IAskedQuestionRepository AskedQuestionRepository)
        {
            _AskedQuestionRepository = AskedQuestionRepository;
        }
        public async Task<List<AskedQuestionsViewModel>> Handle(GetAskedQuestionQuery request, CancellationToken cancellationToken)
        {
            return await _AskedQuestionRepository.GetAskedQuestionAsync();
        }
    }
}
