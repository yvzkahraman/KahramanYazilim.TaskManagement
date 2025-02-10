using KahramanYazilim.TaskManagement.Application.Dtos;
using MediatR;

namespace KahramanYazilim.TaskManagement.Application.Requests
{

    public record LoginRequest(string? Username, string? Password, bool RememberMe = false) : IRequest<Result<LoginResponseDto?>>;

    public record RegisterRequest(string? Username, string? Password, string? ConfirmPassword, string? Name, string? Surname) : IRequest<Result<NoData>>;


    public record MemberListRequest() : IRequest<Result<List<MemberListDto>>>;

    public record MemberGetByIdRequest(int Id) : IRequest<Result<MemberListDto>>;

    public record MemberListPagedRequest :PagedRequest, IRequest<PagedResult<MemberListDto>>
    {
        public MemberListPagedRequest(int activePage, string s) : base(activePage)
        {
            S = s;
        }
        public string? S { get; set; }
    };

    public record MemberCreateRequest(string? Username, string? Name, string? Surname) : IRequest<Result<NoData>>;
    public record MemberUpdateRequest(int Id, string? Name, string? Surname) : IRequest<Result<NoData>>;
    public record MemberResetPasswordRequest(int Id) : IRequest<Result<NoData>>;

    public record MemberDeleteRequest(int Id) : IRequest<Result<NoData>>;



}
