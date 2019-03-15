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
    }
}