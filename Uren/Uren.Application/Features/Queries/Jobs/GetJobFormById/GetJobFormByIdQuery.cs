using MediatR;
using Shared.Requests.Jobs.GetJobFormById;

namespace Finate.Application.Features.Queries.Jobs.GetJobFormById;

public class GetJobFormByIdQuery(Guid jobFormId) : IRequest<GetJobFormByIdResponse>
{
    public Guid JobFormId { get; set; } = jobFormId;
}