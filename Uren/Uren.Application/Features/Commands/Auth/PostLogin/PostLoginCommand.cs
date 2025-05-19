using MediatR;
using Shared.Requests.Auth.PostLogin;

namespace Finate.Application.Features.Commands.Auth.PostLogin;

public class PostLoginCommand(PostLoginRequest request)
    : PostLoginRequest(request),
        IRequest<PostLoginResponse>;