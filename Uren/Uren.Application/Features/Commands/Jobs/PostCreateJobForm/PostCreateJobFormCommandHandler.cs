using MediatR;
using Shared.Common;

namespace Finate.Application.Features.Commands.Jobs.PostCreateJobForm;

public class PostCreateJobFormCommandHandler 
    : IRequestHandler<PostCreateJobFormCommand, BasePostCreateFormResponse>
{
    public Task<BasePostCreateFormResponse> Handle(
        PostCreateJobFormCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}