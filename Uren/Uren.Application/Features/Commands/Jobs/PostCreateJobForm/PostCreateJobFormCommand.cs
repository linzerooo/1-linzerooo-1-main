using MediatR;
using Shared.Common;
using Shared.Requests.Jobs.PostCreateJobForm;

namespace Finate.Application.Features.Commands.Jobs.PostCreateJobForm;

public class PostCreateJobFormCommand(PostCreateJobFormRequest request, Guid createdFormId)
    : PostCreateJobFormRequest(request),
        IRequest<BasePostCreateFormResponse>
{
    public Guid CreatedFormId { get; set; } = createdFormId;
}
