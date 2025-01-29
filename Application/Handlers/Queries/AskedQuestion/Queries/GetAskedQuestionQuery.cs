using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.AskedQuestion.Queries
{
    public class GetAskedQuestionQuery : IRequest<List<AskedQuestionsViewModel>>
    {
    }
}
