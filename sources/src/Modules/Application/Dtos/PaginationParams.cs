using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class PaginationParams
    {
        public int? PageSize { get; set; }

        public int? Limit { get; set; }
    }
}
