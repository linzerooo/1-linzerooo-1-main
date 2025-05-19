namespace Shared.Requests.Contact.PostSendEmail;

public class PostSendEmailRequest
{
    public PostSendEmailRequest()
    {
    }

    public PostSendEmailRequest(PostSendEmailRequest request)
    {
        if (request is null)
            return;

        Name = request.Name;
        FromEmail = request.FromEmail;
        Message = request.Message;
        FormId = request.FormId;
        NeedSendToCandidate = request.NeedSendToCandidate;
    }

    public bool NeedSendToCandidate { get; set; }
    
    public Guid FormId { get; set; }
    
    public string Name { get; set; }

    public string FromEmail { get; set; }

    public string Message { get; set; }
}