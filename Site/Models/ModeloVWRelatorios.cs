using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Site.Models
{
    public class ModeloVWRelatorios
    {
        public IPagedList<vw_bilhetagemAtual> Faturamento { get; set; }
        public IPagedList<ArquivoImpresso> ArquivosImpressos { get; set; }
        public IPagedList<vw_suprimentos2> vw_Suprimentos2 { get; set; }
    }
}