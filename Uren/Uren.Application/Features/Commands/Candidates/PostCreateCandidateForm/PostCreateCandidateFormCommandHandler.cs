using MediatR;
using Shared.Common;

namespace Finate.Application.Features.Commands.Candidates.PostCreateCandidateForm;

public class PostCreateCandidateFormCommandHandler 
    : IRequestHandler<PostCreateCandidateFormCommand, BasePostCreateFormResponse>
{
    public Task<BasePostCreateFormResponse> Handle(
        PostCreateCandidateFormCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}