using MediatR;
using Shared.Requests.Auth.PostRegister;

namespace Finate.Application.Features.Commands.Auth.PostRegister;

public class PostRegisterCommand(PostRegisterRequest? request)
    : PostRegisterRequest(request), 
        IRequest<PostRegisterResponse>;