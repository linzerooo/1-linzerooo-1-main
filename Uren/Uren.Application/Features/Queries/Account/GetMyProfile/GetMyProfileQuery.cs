using MediatR;
using Shared.Requests.Account.GetMyProfile;

namespace Finate.Application.Features.Queries.Account.GetMyProfile;

public class GetMyProfileQuery : IRequest<GetMyProfileResponse>;