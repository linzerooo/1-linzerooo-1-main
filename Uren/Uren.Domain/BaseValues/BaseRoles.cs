using Finate.Domain.Entities;

namespace Finate.Domain.BaseValues;

/// <summary>
/// Базовые роли для БД
/// </summary>
public static class BaseRoles
{
    /// <summary>
    /// Роль Админа
    /// </summary>
    public static readonly Role AdminRole = new()
    {
        Id = new Guid("4B960FC2-23BC-4003-A03D-552FBA0E579E"),
        Name = AdminRoleName,
        NormalizedName = AdminRoleName.ToUpper()
    };

    public const string AdminRoleName = "Admin";
    
    /// <summary>
    /// Роль кандидата
    /// </summary>
    public static readonly Role CandidateRole = new()
    {
        Id = new Guid("33F3F505-60E8-4656-AA3D-5F427192C489"),
        Name = CandidateRoleName,
        NormalizedName = CandidateRoleName.ToUpper()
    };

    public const string CandidateRoleName = "Candidate";

    /// <summary>
    /// Роль работодателя
    /// </summary>
    public static readonly Role EmployerRole = new() 
    {
        Id = new Guid("6D8E2FFC-8500-407B-9FEE-0312CACBFB48"),
        Name = EmployerRoleName,
        NormalizedName = EmployerRoleName.ToUpper()
    };

    public const string EmployerRoleName = "Employer";
}