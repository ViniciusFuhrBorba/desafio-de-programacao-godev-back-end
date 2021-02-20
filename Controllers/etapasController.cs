using desafioProg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace desafioProg.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class etapasController : ApiController
    {
        // GET: api/etapas
        public IEnumerable<dynamic> Get()
        {
            using(desafioProgEntities bd = new desafioProgEntities())
            {
                var etapas = from etap in bd.etapas
                             select new { etap.id, etap.nome, etap.situacao };
                return etapas.ToList();
            }
        }

        // GET: api/etapas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/etapas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/etapas/5
        public string Put(int id, [FromBody]etapas etapa)
        {
            using(desafioProgEntities bd = new desafioProgEntities())
            {
                etapas etapaAlterar = bd.etapas.Find(id);
                etapaAlterar.situacao = etapa.situacao;
                bd.SaveChanges();
                return "Alterado com sucesso";
            }
        }

        // DELETE: api/etapas/5
        public void Delete(int id)
        {
        }
    }
}
