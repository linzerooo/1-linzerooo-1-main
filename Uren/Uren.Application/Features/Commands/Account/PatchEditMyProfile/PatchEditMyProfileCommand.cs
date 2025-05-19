using MediatR;
using Shared.Requests.Account.PatchEditMyProfile;

namespace Finate.Application.Features.Commands.Account.PatchEditMyProfile;

public class PatchEditMyProfileCommand(PatchEditMyProfileRequest request)
    : PatchEditMyProfileRequest(request), IRequest;