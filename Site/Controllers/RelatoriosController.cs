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
    public class RelatoriosController : Controller
    {
        private ModeldnaPrint db = new ModeldnaPrint();
        List<ArquivoImpresso> arqImpre = new List<ArquivoImpresso>();

        // GET: Relatorios
        public ActionResult Index(string valor)
        {
            if (!String.IsNullOrEmpty(valor))
            {
                arqImpre = db.ArquivoImpresso.Where(x => x.PrinterName.Contains(valor) || x.NotifyUserName.Contains(valor)).ToList();
                
            }
            ViewBag.dbArquivosImpressos =  arqImpre;

           

            
            
            
            
            return View();
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
