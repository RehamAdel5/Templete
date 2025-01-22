using MediatR;

namespace Application.Handeler.CQRS.ProjectDetails.Queries
{
    public class GetProjectDetailsQuery : IRequest<GetProjectDetailsViewModel>
    {
        public int Id { get; set; }

    }
}
