using MediatR;
using Shared.Requests.Auth.GetConfirmEmail;

namespace Finate.Application.Features.Commands.Auth.GetConfirmEmail;

public class GetConfirmEmailCommand(GetConfirmEmailRequest? request)
    : GetConfirmEmailRequest(request),
        IRequest<GetConfirmEmailResponse>;