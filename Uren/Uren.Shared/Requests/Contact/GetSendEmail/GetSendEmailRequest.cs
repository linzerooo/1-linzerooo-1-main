namespace Shared.Requests.Contact.GetSendEmail;

public class GetSendEmailRequest
{
    public Guid FormId { get; set; }
    
    public bool IsCandidateForm { get; set; }
}