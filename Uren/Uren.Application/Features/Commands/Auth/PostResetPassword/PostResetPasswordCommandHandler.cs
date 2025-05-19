using Finate.Application.Constants;
using Finate.Application.Interfaces;
using Finate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Common;
using Shared.Requests.Auth.PostResetPassword;

namespace Finate.Application.Features.Commands.Auth.PostResetPassword;

public class PostResetPasswordCommandHandler(UserManager<User> userManager,
    IEmailSender emailSender)
    : IRequestHandler<PostResetPasswordCommand, PostResetPasswordResponse>
{
    public async Task<PostResetPasswordResponse> Handle(PostResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var response = new PostResetPasswordResponse { IsSuccessful = false };

        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            response.ErrorMessages.Add(new ResponseErrorMessageItem(nameof(request.Email),
                AuthErrorMessages.UserWithThisEmailNotFound));
            return response;
        }
        
        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var confirmLink = BaseUrls.ConfirmPasswordResetLink(token, user.Email!);
        
        //await emailSender.SendEmailAsync(user.Email!,
        //    AuthEmailMessages.ResetPasswordConfirmMessage(user.UserName!, confirmLink), cancellationToken);

        response.IsSuccessful = true;
        return response;
    }
}