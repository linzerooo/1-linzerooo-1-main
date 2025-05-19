using MediatR;
using Shared.Requests.Contact.PostSendEmail;

namespace Finate.Application.Features.Commands.Contact.PostSendEmail;

public class PostSendEmailCommand(PostSendEmailRequest request)
    : PostSendEmailRequest(request),
        IRequest<PostSendEmailResponse>;
