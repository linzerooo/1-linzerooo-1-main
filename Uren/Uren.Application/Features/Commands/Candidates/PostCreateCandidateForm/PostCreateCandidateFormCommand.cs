using MediatR;
using Shared.Common;
using Shared.Requests.Candidates.PostCreateCandidateForm;

namespace Finate.Application.Features.Commands.Candidates.PostCreateCandidateForm;

public class PostCreateCandidateFormCommand(PostCreateCandidateFormRequest request, Guid createdFormId)
    : PostCreateCandidateFormRequest(request), IRequest<BasePostCreateFormResponse>
{
    public Guid CreatedFormId { get; set; } = createdFormId;
}