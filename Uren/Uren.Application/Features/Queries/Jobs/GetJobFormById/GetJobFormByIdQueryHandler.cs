using System.Net;
using Finate.Application.Interfaces;
using Finate.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shared.Requests.Jobs.GetJobFormById;

namespace Finate.Application.Features.Queries.Jobs.GetJobFormById;

public class GetJobFormByIdQueryHandler(IDbContext dbContext)
    : IRequestHandler<GetJobFormByIdQuery, GetJobFormByIdResponse>
{
    public async Task<GetJobFormByIdResponse> Handle(GetJobFormByIdQuery request, CancellationToken cancellationToken)
    {
        var form = await dbContext.JobFormExtensions
            .Include(form => form.JobForm)
            .ThenInclude(form => form.User)
            .Include(form => form.JobForm.Skills)
            .Include(form => form.DescriptionParts)
            .FirstOrDefaultAsync(form => form.JobForm.Id == request.JobFormId && !form.JobForm.IsBlocked,
                cancellationToken: cancellationToken);

        if (form is null)
            throw new BadHttpRequestException("Job form with this id doesn't exist",
                (int)HttpStatusCode.BadRequest);
        
        var socialNetworks = new Dictionary<string, string>();
        foreach (var socialNetwork in form.JobForm.User.SocialNetworks)
            socialNetworks[socialNetwork.SocialNetworkType.ToString()] = socialNetwork.Link;

        form.JobForm.Views += 1;
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return new GetJobFormByIdResponse
        {
            JobFormImagePath = form.JobForm.User.UserPhotoUrl ?? "",
            JobFormId = form.JobForm.Id,
            CompanyName = form.JobForm.User.UserName!,
            Address = form.JobForm.PlaceAddress,
            JobName = form.JobForm.ProfessionName,
            Category = form.JobForm.ProfessionName,
            CreatedDate = form.JobForm.CreateDate,
            ApplicationEnd = form.ApplicationEndDate,
            ExperienceInYears = form.JobForm.ExperienceInYears,
            Rating = form.JobForm.Rating,
            Gender = form.JobForm.Gender.ToString(),
            Level = form.JobForm.Level.ToString()!,
            Applied = form.Applied,
            JobType = form.JobType.ToString(),
            Salary = form.JobForm.Salary,
            PhoneNumber = form.JobForm.User.PhoneNumber ?? "",
            Views = form.JobForm.Views,
            Description = form.JobForm.Description!,
            Responsibilities = form.DescriptionParts
                .Where(x => x.DescriptionPartType == DescriptionPartType.Responsibilities)
                .Select(x => x.Content)
                .ToList(),
            WorkRequirements = form.DescriptionParts
                .Where(x => x.DescriptionPartType == DescriptionPartType.Requirements)
                .Select(x => x.Content)
                .ToList(),
            EducationalRequirements = form.DescriptionParts
                .Where(x => x.DescriptionPartType == DescriptionPartType.EducationalRequirements)
                .Select(x => x.Content)
                .ToList(),
            WorkingHours = form.DescriptionParts
                .Where(x => x.DescriptionPartType == DescriptionPartType.WorkingHours)
                .Select(x => x.Content)
                .ToList(),
            Benefits = form.DescriptionParts
                .Where(x => x.DescriptionPartType == DescriptionPartType.Benefits)
                .Select(x => x.Content)
                .ToList(),
            Tags = form.JobForm.Tags.Select(x => x.TagName).ToList(),
            SocialNetworksAndLinks = socialNetworks
        };
    }
}