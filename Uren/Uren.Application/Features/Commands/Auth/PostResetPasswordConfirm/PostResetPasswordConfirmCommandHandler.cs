using Finate.Application.Constants;
using Finate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Common;
using Shared.Requests.Auth.PostResetPasswordConfirm;

namespace Finate.Application.Features.Commands.Auth.PostResetPasswordConfirm;

public class PostResetPasswordConfirmCommandHandler(UserManager<User> userManager) :
    IRequestHandler<PostResetPasswordConfirmCommand, PostResetPasswordConfirmResponse>
{
    public async Task<PostResetPasswordConfirmResponse> Handle(PostResetPasswordConfirmCommand request, CancellationToken cancellationToken)
    {
        var response = new PostResetPasswordConfirmResponse { IsSuccessful = false };
        
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            response.ErrorMessages.Add(new ResponseErrorMessageItem( nameof(request.Email),
                AuthErrorMessages.UserWithThisEmailNotFound));
            return response;
        }
        
        var resetPasswordResult =
            await userManager.ResetPasswordAsync(user, request.UserResetPasswordToken, request.NewPassword);
        
        if (!resetPasswordResult.Succeeded)
        {
            response.ErrorMessages.Add(new ResponseErrorMessageItem(nameof(request.UserResetPasswordToken),
                AuthErrorMessages.WrongUserConfirmationToken));
            return response;
        }

        response.IsSuccessful = true;
        return response;
    }
}