

namespace ProvasEnem.Core.Requests;

public abstract class PagedRequest : BasedRequest
{
    public int PagedNumber { get; set; } = Configuration.DefaultPageNumber;
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
}
