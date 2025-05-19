using System.Net;
using Finate.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shared.Common;
using Shared.Requests.Candidates.GetCandidateFormById;

namespace Finate.Application.Features.Queries.Candidates.GetCandidateFormById;

public class GetCandidateFormByIdQueryHandler(IDbContext dbContext) 
    : IRequestHandler<GetCandidateFormByIdQuery, GetCandidateFormByIdResponse>
{
    public async Task<GetCandidateFormByIdResponse> Handle(
        GetCandidateFormByIdQuery request,
        CancellationToken cancellationToken)
    {
        var form = await dbContext.CandidateFormExtensions
            .Include(form => form.CandidateForm)
            .ThenInclude(form => form.User)
            .Include(form => form.Experiences)
            .Include(form => form.CandidateForm.Skills)
            .FirstOrDefaultAsync(form => form.CandidateFormId == request.CandidateFormId,
                cancellationToken: cancellationToken);
        
        if(form is null)
            throw new BadHttpRequestException("Job form with this id doesn't exist",
                (int)HttpStatusCode.BadRequest);
        
        var socialNetworks = new Dictionary<string, string>();
        foreach (var socialNetwork in form.CandidateForm.User.SocialNetworks)
            socialNetworks[socialNetwork.SocialNetworkType.ToString()] = socialNetwork.Link;
        
        form.CandidateForm.Views += 1;
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return new GetCandidateFormByIdResponse
        {
            CandidateImagePath = form.CandidateForm.User.UserPhotoUrl ?? "",
            CandidateFormId = form.CandidateFormId,
            FullName = form.CandidateForm.User.UserName!,
            Category = form.CandidateForm.ProfessionName,
            ExperienceInYears = form.CandidateForm.ExperienceInYears,
            Rating = form.CandidateForm.Rating,
            Gender = form.CandidateForm.Gender.ToString(),
            Level = form.CandidateForm.Level.ToString()!,
            Salary = form.CandidateForm.Salary,
            PhoneNumber = form.CandidateForm.User.PhoneNumber ?? "",
            AboutCandidate = form.CandidateForm.Description!,
            Tags = form.CandidateForm.Tags.Select(x => x.TagName).ToList(),
            SocialNetworksAndLinks = socialNetworks,
            CandidateEmail = form.CandidateForm.User.Email!,
            Views = form.CandidateForm.Views,
            PlaceAddress = form.CandidateForm.PlaceAddress,
            ProfessionName = form.CandidateForm.ProfessionName,
            Languages = form.CandidateForm.Languages.Select(language => language.Language).ToList(),
            Experiences = form.Experiences.Select(x => new ExperienceDto
            {
                Description = x.About!,
                EndYear = x.EndDate?.Year ?? 0,
                ExperienceType = x.ExperienceType.ToString(),
                PlaceName = x.PlaceName,
                StartYear = x.StartDate.Year,
                ProfessionName = x.ProfessionName
            }).ToList()
        };
    }
}