namespace Shared.Requests.Account.GetMyProfile;

public class GetMyProfileResponse
{
    public string UserPhotoUrl { get; set; } = default!;

    public string UserName { get; set; } = default!;

    public List<FormDto> Forms { get; set; } = default!;
}