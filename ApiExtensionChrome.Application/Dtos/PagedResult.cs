using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiExtensionChrome.Application.Dtos
{
    public class PagedResult<T>
    {
        public Task<List<T>> Items { set; get; }
        public int TotalRecord { get; set; }
    }
}
