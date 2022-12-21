using System;
using System.Collections.Generic;
using System.Text;

namespace ApiExtensionChrome.Application.Dtos
{
    public class PagingRequestBase
    {
        public int PageIndex { set; get; }
        public int PageSize { get; set; }
    }
}
