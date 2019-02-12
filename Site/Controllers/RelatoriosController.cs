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
using Site.Models;

namespace Site.Controllers
{
    public class RelatoriosController : Controller
    {
        private ModeldnaPrint db = new ModeldnaPrint();
        List<ArquivoImpresso> arqImpre = new List<ArquivoImpresso>();

        // GET: Relatorios
        public ActionResult Index(string valor,DateTime? DataInicial,DateTime? DataFinal)
        {
            if (!String.IsNullOrEmpty(valor))
            {
                arqImpre = db.ArquivoImpresso.Where(x => x.PrinterName.Contains(valor) || x.NotifyUserName.Contains(valor)).ToList();
                
            }
            
            if (!DataInicial.Equals(null) && !DataFinal.Equals(null))
            {
                DataFinal.Value.AddDays(1);
                arqImpre = db.ArquivoImpresso.Where(x=>x.Submitted>=DataInicial && x.Submitted<= DataFinal).ToList();
            }





            ViewBag.dbArquivosImpressos =  arqImpre;

            //string sqlString = "select c.UF,b.cidade,d.descricao 'local', e.descricao 'setor', a.serie,a.nome 'fila',a.ip" +
            //    " , (f.total_pf_color + f.total_pf_mono + f.total_gf_color + f.total_gf_mono + total_pf_mono_simples + total_pf_mono_duplex) 'Contador'  " +
            //    " , CASE                                                                                                                                 " +
            //    "  WHEN f.black is not null THEN f.black                                                                                                 " +
            //    "  WHEN f.toner_total_pr = 0 and f.black is null THEN 0                                                                                  " +
            //    "  ELSE (cast(f.toner_atual_pr as float) / cast(f.toner_total_pr as float) ) * 100                                                       " +
            //    " END AS 'qtdTonerPr'                                                                                                                    " +
            //    " , CASE                                                                                                                                 " +
            //    "  WHEN f.cyan is not null THEN f.cyan                                                                                                   " +
            //    "  WHEN f.toner_total_ci = 0 and f.cyan is null THEN 0                                                                                   " +
            //    "  ELSE (cast(f.toner_atual_ci as float) / cast(f.toner_total_ci as float) ) * 100                                                       " +
            //    " END AS 'qtdTonerCi'                                                                                                                    " +
            //    " , CASE                                                                                                                                 " +
            //    "  WHEN f.yellow is not null THEN f.yellow                                                                                               " +
            //    "  WHEN f.toner_total_am = 0 and f.yellow is null THEN 0                                                                                 " +
            //    "  ELSE (cast(f.toner_atual_am as float) / cast(f.toner_total_am as float) ) * 100                                                       " +
            //    " END AS 'qtdTonerAm'                                                                                                                    " +
            //    " , CASE                                                                                                                                 " +
            //    "  WHEN f.magenta is not null THEN f.magenta                                                                                             " +
            //    "  WHEN f.toner_total_ma = 0 and f.magenta is null THEN 0                                                                                " +
            //    "  ELSE (cast(f.toner_atual_ma as float) / cast(f.toner_total_ma as float) ) * 100                                                       " +
            //    " END AS 'qtdTonerMa'                                                                                                                    " +
            //    " , CASE                                                                                                                                 " +
            //    "  WHEN f.cilindro_total = 0 THEN 0                                                                                                      " +
            //    "  ELSE (cast(f.cilindro_atual as float) / cast(f.cilindro_total as float) ) * 100                                                       " +
            //    " END AS 'qtdCilindro'                                                                                                                   " +
            //    " ,f.data                                                                                                                                " +
            //    " from CadastroEquipamentos as a                                                                                                         " +
            //    " left join CadastroCidade as b on a.idCidade=b.idCidade                                                                                 " +
            //    " left join CadastroEstado as c on a.idEstado=c.idEstado                                                                                 " +
            //    " left join CadastroUnidade as d on a.idLocalidade=d.idLocalidade                                                                        " +
            //    " left join  CadastroSetor as e on a.idSetor=e.idSetor                                                                                   " +
            //    " left join                                                                                                                              " +
            //    " (                                                                                                                                      " +
            //    "  select * from DadosDisparos where idDisparo in                                                                                        " +
            //    "  (select max(idDisparo) from DadosDisparos  group by idEquipamento)                                                                    " +
            //    " ) as f on a.serie=f.serie                                                                                                              " +
            //    ")                                                                                                                                       " ;
            

            //using (var con = new EntityConnection("name=ModeldnaPrint"))
            //{
            //    con.Open();
            //    EntityCommand cmd = con.CreateCommand();
            //    cmd.CommandText = sqlString;
            //    Dictionary<int, string> dict = new Dictionary<int, string>();
            //    using (EntityDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection))
            //    {
            //        while (rdr.Read())
            //        {
            //            int a = rdr.GetInt32(0);
            //            var b = rdr.GetString(1);
            //            dict.Add(a, b);
            //        }
            //    }
            //}


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
