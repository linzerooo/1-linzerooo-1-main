using Microsoft.AspNetCore.Identity;

namespace Finate.Domain.Entities;

/// <summary>
/// Роль юзера
/// </summary>
public class Role : IdentityRole<Guid>;