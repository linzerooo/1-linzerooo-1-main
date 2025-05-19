using System.Net;
using Finate.Application.Interfaces;
using Finate.Domain.BaseValues;
using Finate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shared.Common;

namespace Finate.Application.Features.Commands.Forms.PostCreateForm;

public class PostCreateFormCommandHandler(ICurrentUser currentUser, IDbContext dbContext)
    : IRequestHandler<PostCreateFormCommand, BasePostCreateFormResponse>
{
    public async Task<BasePostCreateFormResponse> Handle(PostCreateFormCommand request,
        CancellationToken cancellationToken)
    {
        var userId = currentUser.UserId;
        var userRole = currentUser.Role;

        if (userRole == BaseRoles.CandidateRoleName)
        {
            var userFormsCount = await dbContext.Forms
                .Include(x => x.User)
                .Where(x => x.User.Id == userId)
                .CountAsync(cancellationToken: cancellationToken);

            if (userFormsCount > 0)
                throw new BadHttpRequestException("User can not have more then 1 form",
                    (int)HttpStatusCode.Forbidden);
        }

        var languages = await dbContext.UserLanguages.Select(x => x.Language)
            .ToListAsync(cancellationToken: cancellationToken);

        var needToAddLanguages = request.Languages
            .Where(x => !languages.Contains(x, StringComparer.OrdinalIgnoreCase))
            .Select(x => new UserLanguage
            {
                Language = x
            })
            .ToList();

        request.Languages = request.Languages.Select(x => x.ToLower()).ToList();
        var userLanguagesFromDb = await dbContext.UserLanguages
            .Where(x => request.Languages.Contains(x.Language.ToLower()))
            .ToListAsync(cancellationToken: cancellationToken);

        await dbContext.UserLanguages.AddRangeAsync(needToAddLanguages, cancellationToken);
        
        var tags = await dbContext.Tags.Select(x => x.TagName)
            .ToListAsync(cancellationToken: cancellationToken);
        
        var needToAddTags = request.Tags
            .Where(x => !tags.Contains(x, StringComparer.OrdinalIgnoreCase))
            .Select(x => new Tag
            {
                TagName = x
            })
            .ToList();

        request.Tags = request.Tags.Select(x => x.ToLower()).ToList();
        var userTagsFromDb = await dbContext.Tags
            .Where(x => request.Tags.Contains(x.TagName.ToLower()))
            .ToListAsync(cancellationToken: cancellationToken);

        await dbContext.Tags.AddRangeAsync(needToAddTags, cancellationToken);

        var skills = request.Skills.Select(x => new Skill
        {
            IsTopSkill = x.IsTopSkill,
            SkillName = x.Name
        }).ToList();

        var form = new Form
        {
            CreateDate = DateTime.UtcNow,
            Description = request.Description,
            ExperienceInYears = request.ExperienceInYears,
            Gender = request.Gender,
            IsActive = true,
            IsBlocked = false,
            PlaceAddress = request.PlaceAddress,
            Level = request.Level,
            Languages = userLanguagesFromDb,
            Tags = userTagsFromDb,
            Salary = request.Salary,
            ProfessionName = request.ProfessionName,
            Skills = skills
        };

        var addResult = await dbContext.Forms.AddAsync(form, cancellationToken);

        return new BasePostCreateFormResponse
        {
            CreatedFormId = addResult.Entity.Id
        };
    }
}