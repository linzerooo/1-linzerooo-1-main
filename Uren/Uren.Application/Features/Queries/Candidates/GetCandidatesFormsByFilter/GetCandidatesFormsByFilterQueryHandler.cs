using Finate.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Requests.Candidates.GetCandidatesFormsByFilter;

namespace Finate.Application.Features.Queries.Candidates.GetCandidatesFormsByFilter;

public class GetCandidatesFormsByFilterQueryHandler(IDbContext dbContext)
    : IRequestHandler<GetCandidatesFormsByFilterQuery, GetCandidatesFormsByFilterResponse>
{
    public async Task<GetCandidatesFormsByFilterResponse> Handle(
        GetCandidatesFormsByFilterQuery request,
        CancellationToken cancellationToken)
    {
        var query = dbContext.CandidateFormExtensions
            .Include(form => form.CandidateForm)
            .ThenInclude(form => form.User)
            .Where(form => !form.IsClosed);

        if (!string.IsNullOrWhiteSpace(request.SearchValue))
            query = query
                .Where(form => form.CandidateForm.User.UserName!.ToLower().Contains(request.SearchValue));

        var orderedQuery = query
            .OrderByDescending(form => form.CandidateForm.Views)
            .ThenByDescending(form => form.CandidateForm.Rating)
            .Select(form => new GetCandidatesFormsByFilterResponseItem
            {
                CandidateImagePath =
                    form.CandidateForm.User.UserPhotoUrl == null
                        ? ""
                        : form.CandidateForm.User.UserPhotoUrl,
                CandidateFormId = form.CandidateFormId,
                FullName = form.CandidateForm.User.UserName!,
                Category = form.CandidateForm.ProfessionName,
                TopSkills = form.CandidateForm.Skills
                    .Where(x => x.IsTopSkill)
                    .Select(x => x.SkillName)
                    .ToList(),
                Rating = form.CandidateForm.Rating,
            });

        return new GetCandidatesFormsByFilterResponse
        {
            CandidatesForms = await orderedQuery
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken),

            TotalCount = await orderedQuery.CountAsync(cancellationToken)
        };
    }
}