using MediatR;

namespace Application.Handeler.Queries.ProjectDetails.Queries
{
    public class GetProjectDetailsQuery : IRequest<GetProjectDetailsViewModel>
    {
        public int Id { get; set; }

    }
}
