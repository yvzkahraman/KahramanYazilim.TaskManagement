namespace KahramanYazilim.TaskManagement.Application.Dtos
{
    public record Result<T>(T Data, bool IsSuccess, string? ErrorMessage, List<ValidationError>? Errors);

    public record ValidationError(string PropertyName, string ErrorMessage);
    public record NoData();

    /* 
           public int ActivePage { get; set; }
        public int PageSize { get; set; }

        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }

     */
    public record PagedResult<T>(List<T> Data, int ActivePage, int PageSize, int TotalPage);

    public record PagedData<T>
       where T : class, new()
    {
        public int ActivePage { get; set; }
        public int PageSize { get; set; }

        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }

        public List<T> Data { get; set; }

        public PagedData(List<T> data, int activePage, int totalRecords, int pageSize)
        {
            this.Data = data;
            this.ActivePage = activePage;
            this.PageSize = pageSize;
            this.TotalRecords = totalRecords;
            this.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        }
    }
}
