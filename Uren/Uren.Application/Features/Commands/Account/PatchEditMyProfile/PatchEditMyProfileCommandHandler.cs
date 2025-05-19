using System.Net;
using Finate.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Finate.Application.Features.Commands.Account.PatchEditMyProfile;

public class PatchEditMyProfileCommandHandler(IS3Service s3Service, IDbContext dbContext, ICurrentUser currentUser)
    : IRequestHandler<PatchEditMyProfileCommand>
{
    public async Task Handle(PatchEditMyProfileCommand request, CancellationToken cancellationToken)
    {
        var userId = currentUser.UserId;

        var user = await dbContext.Users.FirstAsync(x => x.Id == userId, cancellationToken: cancellationToken);

        if (user is null)
            throw new BadHttpRequestException($"User with id : {userId} was not found");

        if (request.PhotoFileStream is not null)
        {
            var updateUserPhotoResult = user.UserPhotoUrl == null
                ? await s3Service
                    .UploadFileAsync($"{user.Id}-user-photo", request.PhotoFileStream.OpenReadStream(), cancellationToken)
                : await s3Service
                    .UpdateFileAsync($"{userId}-user-photo", request.PhotoFileStream.OpenReadStream(), cancellationToken);

            if (updateUserPhotoResult == 0)
                throw new HttpRequestException("Cannot update user photo",
                    null, HttpStatusCode.InternalServerError);

            user.UserPhotoUrl = $"{user.Id}-user-photo";
        }

        user.UserName = string.IsNullOrWhiteSpace(request.UserName) ? user.UserName : request.UserName;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}