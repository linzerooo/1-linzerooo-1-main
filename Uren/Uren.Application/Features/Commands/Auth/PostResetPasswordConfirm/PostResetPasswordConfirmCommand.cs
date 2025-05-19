using MediatR;
using Shared.Requests.Auth.PostResetPasswordConfirm;

namespace Finate.Application.Features.Commands.Auth.PostResetPasswordConfirm;

public class PostResetPasswordConfirmCommand(PostResetPasswordConfirmRequest? request)
    : PostResetPasswordConfirmRequest(request),
        IRequest<PostResetPasswordConfirmResponse>;