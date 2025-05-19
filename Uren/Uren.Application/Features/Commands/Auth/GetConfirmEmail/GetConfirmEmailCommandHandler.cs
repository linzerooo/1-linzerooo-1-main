using Finate.Application.Constants;
using Finate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Common;
using Shared.Requests.Auth.GetConfirmEmail;

namespace Finate.Application.Features.Commands.Auth.GetConfirmEmail;

public class GetConfirmEmailCommandHandler(UserManager<User> userManager,
    SignInManager<User> signInManager)
    : IRequestHandler<GetConfirmEmailCommand, GetConfirmEmailResponse>
{
    public async Task<GetConfirmEmailResponse> Handle(GetConfirmEmailCommand request,
        CancellationToken cancellationToken)
    {
        var response = new GetConfirmEmailResponse { IsSuccessful = false };

        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            response.ErrorMessages.Add(new ResponseErrorMessageItem(nameof(request.Email),
                AuthErrorMessages.UserWithThisEmailNotFound));
            return response;
        }

        var confirmEmailResult = await userManager.ConfirmEmailAsync(user, request.UserConfirmEmailToken);

        if (!confirmEmailResult.Succeeded)
        {
            response.ErrorMessages.Add(new ResponseErrorMessageItem(nameof(request.UserConfirmEmailToken),
                AuthErrorMessages.WrongUserConfirmationToken));
            return response;
        }
        
        user.EmailConfirmed = true;
        await userManager.UpdateAsync(user);
        await signInManager.SignInAsync(user, false);
        
        response.IsSuccessful = true;
        return response;
    }
}