using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Authors
{
    public interface IAuthorAppService : IApplicationService
    {
        Task<AuthorDto> GetAsync(Guid id);
        //PagedResultDto是ABP框架中的预定义DTO类。它具有一个Items集合和一个TotalCount属性以返回分页结果。
        Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input);

        //Task<PagedResultDto<AuthorDto>> GetListLikeAsync(GetAuthorListDto input);
        Task<List<AuthorDto>> GetListAuthorAsync(GetAuthorListDto input);
        Task<AuthorDto> CreateAsync(CreateAuthorDto input);

        Task UpdateAsync(Guid id, UpdateAuthorDto input);

        Task DeleteAsync(Guid id);
    }
}
