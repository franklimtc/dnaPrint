using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Site.Models;


namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private ModeldnaPrint db = new ModeldnaPrint();
        private static int nFalhas = 0;
        private static int nSupriBaixo = 0;
        private static int nDisponibilidade = 0;

        public ActionResult Index()
        {
            ViewBag.Title = "Dashboard";
            int quantDisponibilidade = db.vw_disponibilidade3.Where(x => x.qtdDias == 0).Count();
            ViewBag.Disponibilidade = $"{quantDisponibilidade}/{db.vw_disponibilidade3.Count()}";
            #region Alerta de Disponibilidade 
                if (nDisponibilidade < quantDisponibilidade)
                {
                    ViewBag.alertaDisponibilidade = "DisponibilidadeOffline";
                }
                else if (nDisponibilidade > quantDisponibilidade)
                {
                    ViewBag.alertaDisponibilidade = "DisponibilidadeOnline";
                }
                nDisponibilidade = quantDisponibilidade;
            #endregion

            int quantSupri = db.vw_suprimentos2.Where(x => x.Toner < 20).Count();
            ViewBag.Suprimentos = $"{quantSupri}";
            #region Alerta de Toner Baixo
                if (nSupriBaixo < quantSupri && nSupriBaixo > 0)
                {
                    ViewBag.alertaSuprimento = "Suprimento";
                }
                nSupriBaixo = quantSupri;
            #endregion

            ViewBag.Volume = $"{db.vw_bilhetagemAtual.First().VolumeTotal}";
            try
            {
                int quantFalha = db.vw_ErrosEquipamentos.Sum(x => x.Erros).Value;
                ViewBag.Falhas = $"{quantFalha}";
                #region Alerta de Falha
                    if (nFalhas < quantFalha && nFalhas == 0 || nFalhas < quantFalha && nFalhas > 0)
                    {
                        ViewBag.alertaFalha = "Falha";
                    }
                    nFalhas = quantFalha;
                #endregion
            }
            catch 
            {
                ViewBag.Falhas = $"0";
            }

            var tempBilhetagemSemanal = db.tempBilhetagemSemanal;
            //var tempBilhetagemSemanal = db.CadastroEquipamentos.Include(c => c.)
            string usuuario = User.Identity.Name;
            usuuario = usuuario.Split('@').First();
            ViewBag.Usuario = usuuario;
            



            

            return View(tempBilhetagemSemanal.ToList());
        }
        public ActionResult TopFiveEquipamentos()
        {

            List<string> TopEquipNames = db.vw_bilhetagemAtual.OrderBy(x => x.Initotal - x.Fintotal).Select(x => x.nome).Take(5).ToList();
            List<int?> TopEquipValues = db.vw_bilhetagemAtual.OrderBy(x => x.Initotal - x.Fintotal).Select(x => x.Fintotal - x.Initotal).Take(5).ToList();

            List<object> TopFive = new List<object>();
            TopFive.Add(TopEquipNames);
            TopFive.Add(TopEquipValues);

            var json = new JavaScriptSerializer().Serialize(TopFive);

            return Json(json);
        }

        public ActionResult TopFiveUsuario()
        {
            var results = from p in db.ArquivoImpresso.ToList() 
                          group p.TotalPages by p.UserName into g
                          select new { Usuario = g.Key , Total = g.ToList().Sum(x => x.Value)};

            results = results.OrderByDescending(x => x.Total).Take(5).ToList();

            List<string> TopEquipNames = results.Select(x=>x.Usuario).ToList();
            List<int> TopEquipValues = results.Select(x=>x.Total).ToList();

            var resultPrinter = from p in db.ArquivoImpresso.ToList().Where(x=>x.UserName.Equals("printer"))
                                group p by p.MachineName into h
                                select new { Usuario = h.Key,Total = h.Sum(x=>x.TotalPages)};



            resultPrinter = resultPrinter.OrderByDescending(x=>x.Total).Take(5).ToList();

            List<string> TopPrinterNames = resultPrinter.Select(x => x.Usuario).ToList();
            List<int?> TopPrinterValues = resultPrinter.Select(x => x.Total).ToList();

            List<object> TopFive = new List<object>();
            TopFive.Add(TopEquipNames);
            TopFive.Add(TopEquipValues);

            TopFive.Add(TopPrinterNames);
            TopFive.Add(TopPrinterValues);



            var json = new JavaScriptSerializer().Serialize(TopFive);

            return Json(json);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}