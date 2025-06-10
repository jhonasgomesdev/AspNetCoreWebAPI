using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchoolWebAPI.Helpers
{
    public class PageParams
    {
        public const int MaxPageSize = 50;
        public int pageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public int? Matricula { get; set; } = null;
        public string Nome { get; set; } = string.Empty;
        public int? Ativo { get; set; } = null;
        public bool? OrderByMatricula { get; set; } = true;
        public bool? OrderByNome { get; set; } = null;
        public bool? OrderByAtivo { get; set; } = null;
    }
}