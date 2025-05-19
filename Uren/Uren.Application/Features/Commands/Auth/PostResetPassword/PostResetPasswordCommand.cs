using MediatR;
using Shared.Requests.Auth.PostResetPassword;

namespace Finate.Application.Features.Commands.Auth.PostResetPassword;

public class PostResetPasswordCommand(PostResetPasswordRequest? request) 
    : PostResetPasswordRequest(request),
        IRequest<PostResetPasswordResponse>;