using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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
            if (nDisponibilidade < quantDisponibilidade && nDisponibilidade ==0 || nDisponibilidade < quantDisponibilidade && nDisponibilidade > 0)
            {
                ViewBag.alertaDisponibilidade = "DisponibilidadeOnline";
            }else
            if (nDisponibilidade > quantDisponibilidade && nDisponibilidade == 0 || nDisponibilidade > quantDisponibilidade && nDisponibilidade > 0)
            {
                ViewBag.alertaDisponibilidade = "DisponibilidadeOffline";
            }
            nDisponibilidade = quantDisponibilidade;
            #endregion

            int quantSupri = db.vw_suprimentos2.Where(x => x.Toner < 20).Count();
            ViewBag.Suprimentos = $"{quantSupri}";
            #region Alerta de Toner Baixo
                if (nSupriBaixo < quantSupri && nSupriBaixo == 0 || nSupriBaixo < quantSupri && nSupriBaixo > 0)
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

            return View(tempBilhetagemSemanal.ToList());
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