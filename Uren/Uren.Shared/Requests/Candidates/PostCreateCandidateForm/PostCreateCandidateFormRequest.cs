using Shared.Abstractions;
using Shared.Common;

namespace Shared.Requests.Candidates.PostCreateCandidateForm;

public class PostCreateCandidateFormRequest : BasePostCreateFormRequest
{
    public PostCreateCandidateFormRequest()
    {
    }
    
    public PostCreateCandidateFormRequest(PostCreateCandidateFormRequest request): base(request)
    {
    }

    public List<ExperienceDto> Experiences { get; set; }
}