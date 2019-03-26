using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Site.Models;

namespace Site.Controllers
{
    public class RelatoriosController : Controller
    {
        private ModeldnaPrint db = new ModeldnaPrint();

        List<ArquivoImpresso> arqImpre = new List<ArquivoImpresso>();
        private static DateTime? dtFinal;
        private static DateTime? dtInicial;
        private static DateTime? dtIniFat;
        private static DateTime? dtFimFat;
        private static string Valor;

        #region OldIndex
        // GET: Relatorios
        //public ActionResult Index(int? page,string valor,DateTime? DataInicial,DateTime? DataFinal)
        //{
        //    int paginaIni;
        //    int paginaFim;

        //    if (page.Equals(null))
        //    {
        //        paginaIni = 1;
        //        paginaFim = 10;
        //    }
        //    else
        //    {
        //        paginaIni = (int) page;
        //        paginaFim = 10;
        //    }

        //    if (!DataInicial.Equals(null) && !DataFinal.Equals(null) && !String.IsNullOrEmpty(valor))
        //    {
        //        DataFinal.Value.AddDays(1);
        //        arqImpre = db.ArquivoImpresso.Where(x => x.Submitted >= DataInicial && x.Submitted <= DataFinal && x.PrinterName.Contains(valor) || x.NotifyUserName.Contains(valor)).ToList();

        //        Valor = valor;
        //        dtFinal = DataFinal;
        //        dtInicial = DataInicial;

        //        ViewBag.dtIni = dtInicial.Value.ToString("yyyy-MM-dd");
        //        ViewBag.dtFin = dtFinal.Value.ToString("yyyy-MM-dd");
        //        ViewBag.valor = Valor;

        //        return View(arqImpre.ToPagedList(paginaIni, paginaFim));
        //    }else
        //    if (!dtInicial.Equals(null) && !dtFinal.Equals(null) && !String.IsNullOrEmpty(Valor))
        //    {
        //        arqImpre = db.ArquivoImpresso.Where(x => x.Submitted >= dtInicial && x.Submitted <= dtFinal && x.PrinterName.Contains(Valor) || x.NotifyUserName.Contains(Valor)).ToList();

        //        ViewBag.dtIni = dtInicial.Value.ToString("yyyy-MM-dd");
        //        ViewBag.dtFin = dtFinal.Value.ToString("yyyy-MM-dd");
        //        ViewBag.valor = Valor;

        //        return View(arqImpre.ToPagedList(paginaIni, paginaFim));
        //    }

        //    arqImpre = db.ArquivoImpresso.Take(100).ToList();


        //    return View(arqImpre.ToPagedList(paginaIni, paginaFim));



        //}
        #endregion

        // Get: Relatorios Com Paginação
        public ActionResult Index(DateTime? DtIniArq , DateTime? DtFimArq,string valorArq, DateTime? DtIniFatura, DateTime? DtFimFatura,
            int? pageFaturamento = 1,int? pageArquivoImpr = 1 , int? pageRelatSupri = 1)
        {
            ModeloVWRelatorios retorno = new ModeloVWRelatorios();
            
            #region Arquivos Impressos 

            if (!DtIniArq.Equals(null) && !DtFimArq.Equals(null) && !String.IsNullOrEmpty(valorArq))
            {
                DtFimArq.Value.AddDays(1);
                arqImpre = db.ArquivoImpresso.Where(x => x.Submitted >= DtIniArq 
                                                    && x.Submitted <= DtFimArq 
                                                    && (x.PrinterName.Contains(valorArq) || x.NotifyUserName.Contains(valorArq))
                                                    ).ToList();

                retorno.ArquivosImpressos = arqImpre.ToPagedList((int)pageArquivoImpr, 10);

                ViewBag.dtIni = DtIniArq.Value.ToString("yyyy-MM-dd");
                ViewBag.dtFin = DtFimArq.Value.ToString("yyyy-MM-dd");
                ViewBag.valor = valorArq;

                dtFinal = DtFimArq;
                dtInicial = DtIniArq;
                Valor = valorArq;
            }else
            if (!dtFinal.Equals(null) && !dtInicial.Equals(null) && !String.IsNullOrEmpty(Valor))
            {
                
                arqImpre = db.ArquivoImpresso.Where(x => x.Submitted >= dtInicial 
                                                && x.Submitted <= dtFinal 
                                                && (x.PrinterName.Contains(Valor) || x.NotifyUserName.Contains(Valor))
                                                ).ToList();

                retorno.ArquivosImpressos = arqImpre.ToPagedList((int)pageArquivoImpr, 10);

                ViewBag.dtIni = dtInicial.Value.ToString("yyyy-MM-dd");
                ViewBag.dtFin = dtFinal.Value.ToString("yyyy-MM-dd");
                ViewBag.valor = Valor;

            }
            else
            {
                retorno.ArquivosImpressos = db.ArquivoImpresso.Take(1000).ToList().ToPagedList((int)pageArquivoImpr, 10);
            }
            #endregion

            #region Faturamento
            retorno.Faturamento = db.vw_bilhetagemAtual.ToList().ToPagedList((int)pageFaturamento, 10);

            if (!DtIniFatura.Equals(null) && !DtFimFatura.Equals(null))
            {
                DtFimFatura.Value.AddDays(1);
                retorno.Faturamento = db.vw_bilhetagemAtual.ToList().ToPagedList((int)pageFaturamento, 10);


                ViewBag.DtIniFatura = DtIniFatura.Value.ToString("yyyy-MM-dd");
                ViewBag.DtFimFatura = DtIniFatura.Value.ToString("yyyy-MM-dd");

                dtIniFat = DtIniFatura;
                dtFimFat = DtFimFatura;

            }
            else if (!dtIniFat.Equals(null) && !dtFimFat.Equals(null))
            {
                retorno.Faturamento = db.vw_bilhetagemAtual.ToList().ToPagedList((int)pageFaturamento, 10);


                ViewBag.DtIniFatura = dtIniFat.Value.ToString("yyyy-MM-dd");
                ViewBag.DtFimFatura = dtFimFat.Value.ToString("yyyy-MM-dd");

            }
            else
            {
                retorno.Faturamento = db.vw_bilhetagemAtual.Take(1000).ToList().ToPagedList((int)pageFaturamento, 10);
            }
            #endregion

            #region Suprimentos
            retorno.vw_Suprimentos2 = db.vw_suprimentos2.ToList().ToPagedList((int)pageRelatSupri, 10);
            #endregion



            return View(retorno);
        }
        
        // GET: Relatorios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_bilhetagemAtual vw_bilhetagemAtual = db.vw_bilhetagemAtual.Find(id);
            if (vw_bilhetagemAtual == null)
            {
                return HttpNotFound();
            }
            return View(vw_bilhetagemAtual);
        }

        // GET: Relatorios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Relatorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEquipamento,Tipo,UF,cidade,local,CC,setor,serie,nome,ip,Iniimpressoes,Inicopias,Inifax,Initotal,Finimpressoes,Fincopias,Finfax,Fintotal,Modelo,franquia,valor,Volume,VolumeTotal")] vw_bilhetagemAtual vw_bilhetagemAtual)
        {
            if (ModelState.IsValid)
            {
                db.vw_bilhetagemAtual.Add(vw_bilhetagemAtual);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vw_bilhetagemAtual);
        }

        // GET: Relatorios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_bilhetagemAtual vw_bilhetagemAtual = db.vw_bilhetagemAtual.Find(id);
            if (vw_bilhetagemAtual == null)
            {
                return HttpNotFound();
            }
            return View(vw_bilhetagemAtual);
        }

        // POST: Relatorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEquipamento,Tipo,UF,cidade,local,CC,setor,serie,nome,ip,Iniimpressoes,Inicopias,Inifax,Initotal,Finimpressoes,Fincopias,Finfax,Fintotal,Modelo,franquia,valor,Volume,VolumeTotal")] vw_bilhetagemAtual vw_bilhetagemAtual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vw_bilhetagemAtual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vw_bilhetagemAtual);
        }

        // GET: Relatorios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_bilhetagemAtual vw_bilhetagemAtual = db.vw_bilhetagemAtual.Find(id);
            if (vw_bilhetagemAtual == null)
            {
                return HttpNotFound();
            }
            return View(vw_bilhetagemAtual);
        }

        // POST: Relatorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vw_bilhetagemAtual vw_bilhetagemAtual = db.vw_bilhetagemAtual.Find(id);
            db.vw_bilhetagemAtual.Remove(vw_bilhetagemAtual);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
