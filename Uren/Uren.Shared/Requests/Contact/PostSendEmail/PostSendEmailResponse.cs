namespace Shared.Requests.Contact.PostSendEmail;

public class PostSendEmailResponse
{
    public bool WasSentToCandidate { get; set; }
    
    public Guid SentToFormId { get; set; }
}