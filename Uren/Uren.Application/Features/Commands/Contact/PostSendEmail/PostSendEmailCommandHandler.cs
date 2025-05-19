using Finate.Application.Constants;
using Finate.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Requests.Contact.PostSendEmail;

namespace Finate.Application.Features.Commands.Contact.PostSendEmail;

public class PostSendEmailCommandHandler(IEmailSender emailSender, IDbContext dbContext)
    : IRequestHandler<PostSendEmailCommand, PostSendEmailResponse>
{
    public async Task<PostSendEmailResponse> Handle(PostSendEmailCommand request, CancellationToken cancellationToken)
    {
        Tuple<Guid, string>? toEmail;
        
        if(request.NeedSendToCandidate) 
            toEmail = await dbContext.CandidateFormExtensions
            .Include(x => x.CandidateForm)
            .ThenInclude(x => x.User)
            .Select(x => new Tuple<Guid, string>(x.Id, x.CandidateForm.User.Email!))
            .FirstOrDefaultAsync(x => x.Item1 == request.FormId,
                cancellationToken: cancellationToken);
        else
            toEmail = await dbContext.JobFormExtensions
                .Include(x => x.JobForm)
                .ThenInclude(x => x.User)
                .Select(x => new Tuple<Guid, string>(x.Id, x.JobForm.User.Email!))
                .FirstOrDefaultAsync(x => x.Item1 == request.FormId,
                    cancellationToken: cancellationToken);

        //await emailSender.SendEmailAsync(toEmail!.Item2,
        //    ContactEmailMessages.ContactEmailMessage(request.Name, request.FromEmail, request.Message),
        //    cancellationToken);

        return new PostSendEmailResponse
        {
            SentToFormId = toEmail.Item1,
            WasSentToCandidate = request.NeedSendToCandidate
        };
    }
}