

namespace ProvasEnem.Core.Requests;

public abstract class PagedRequest : BasedRequest
{
    public int PagedNumber { get; set; } = 1;
    public int PageSize { get; set; } = 25;
}
