using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Authors
{
    public class GetAuthorListDto : PagedAndSortedResultRequestDto
    {
        //Filter用于搜索作者。可以是null（或为空字符串）以获取所有作者。
        public string Filter { get; set; }
    }
}