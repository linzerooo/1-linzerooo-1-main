namespace Shared.Abstractions;

public abstract class PaginationDto
{
    private int _pageSize = 9;
    
    private int _pageNumber = 0;

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 0 
            ? 0
            : value;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value < 0 
            ? 0
            : value;
    }
}