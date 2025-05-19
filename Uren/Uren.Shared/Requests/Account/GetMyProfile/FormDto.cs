namespace Shared.Requests.Account.GetMyProfile;

public class FormDto
{
    public string FormName { get; set; }
    
    public Guid FormId { get; set; }
    
    public int Views { get; set; }
    
    public double Rating { get; set; }
}