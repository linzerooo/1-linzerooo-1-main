namespace Finate.Application.Constants;

/// <summary>
/// Сообщения для ошибок связанных с Auth
/// </summary>
public static class AuthErrorMessages
{
    public const string UserWithThisEmailNotFound = "User with this Email not found";

    public const string InvalidPasswordLength = "Password need to be more then 8 symbols";

    public const string WrongPassword = "Wrong password";

    public const string PasswordIsNotConfirmed = "Password and Password Confirm must be equals";

    public const string UserWithSameEmailAlreadyExist = "User with same Email already exist";

    public static string EmptyField(string fieldName) => $"{fieldName} can not be empty";

    public const string WrongUserConfirmationToken = "Wrong user confirmation token";
}