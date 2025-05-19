namespace Finate.Application.Constants;

public static class ContactEmailMessages
{
    public static string ContactEmailMessage(string name, string fromEmail, string message)
        => $"{name}, {fromEmail}: {message}";
}