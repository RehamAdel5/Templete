using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.AskedQuestion.Queries
{
    public class GetAskedQuestionQuery : IRequest<List<AskedQuestionsViewModel>>
    {
    }
}
