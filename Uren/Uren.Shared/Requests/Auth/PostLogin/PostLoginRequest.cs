using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.Auth.PostLogin;

/// <summary>
/// Запрос на логин
/// </summary>
public class PostLoginRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">PostLoginRequest</param>
    public PostLoginRequest(PostLoginRequest? request)
    {
        if (request is null) return;
        
        Email = request.Email;
        Password = request.Password;
        RememberMe = request.RememberMe;
    }
    
    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public PostLoginRequest()
    {
    }
    
    /// <summary>
    /// Почта
    /// </summary>
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Пароль
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Запомнить ли
    /// </summary>
    public bool RememberMe { get; set; }
}