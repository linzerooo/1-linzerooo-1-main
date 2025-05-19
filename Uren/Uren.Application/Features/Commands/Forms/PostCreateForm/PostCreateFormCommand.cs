using MediatR;
using Shared.Abstractions;
using Shared.Common;

namespace Finate.Application.Features.Commands.Forms.PostCreateForm;

public class PostCreateFormCommand(BasePostCreateFormRequest request) 
    : BasePostCreateFormRequest(request),
        IRequest<BasePostCreateFormResponse>;
