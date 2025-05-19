using Finate.Application.Constants;
using Finate.Application.Interfaces;
using Finate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Common;
using Shared.Requests.Auth.PostRegister;

namespace Finate.Application.Features.Commands.Auth.PostRegister;

public class PostRegisterCommandHandler(UserManager<User> userManager, IEmailSender emailSender)
    : IRequestHandler<PostRegisterCommand, PostRegisterResponse>
{
    public async Task<PostRegisterResponse> Handle(PostRegisterCommand request, CancellationToken cancellationToken)
    {
        var response = new PostRegisterResponse { IsSuccessful = false };
        
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is not null)
        {
            response.ErrorMessages.Add(new ResponseErrorMessageItem(nameof(request.Email),
                AuthErrorMessages.UserWithSameEmailAlreadyExist));
            return response;
        }
        
        if (request.Password != request.PasswordConfirm)
        {
            response.ErrorMessages.Add(new ResponseErrorMessageItem(nameof(request.Password),
                AuthErrorMessages.PasswordIsNotConfirmed));
            response.ErrorMessages.Add(new ResponseErrorMessageItem(nameof(request.PasswordConfirm),
                AuthErrorMessages.PasswordIsNotConfirmed));
            return response;
        }

        user = new User { Email = request.Email, UserName = request.UserName };

        await userManager.CreateAsync(user, request.Password);

        await userManager.AddToRoleAsync(user, request.Role.ToUpper());
        
        //var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        //var confirmLink = BaseUrls.ConfirmEmailLink(token, user.Email);
        
        //await emailSender.SendEmailAsync(user.Email,
            //AuthEmailMessages.ConfirmEmailMessage(user.UserName, confirmLink), cancellationToken);
        
        response.IsSuccessful = true;
        return response;
    }
}