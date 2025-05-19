namespace Finate.Application.Interfaces;

public interface ICurrentUser
{
    public Guid UserId { get; }
    
    public string Role { get; }
}