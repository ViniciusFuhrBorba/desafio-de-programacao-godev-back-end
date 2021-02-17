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
    public class salasController : ApiController
    {
        // GET: api/salas
        public IEnumerable<dynamic> Get()
        {
            using (desafioProgEntities bd = new desafioProgEntities())
            {
                var salas = from sal in bd.salas
                            select new { sal.id, sal.nome, sal.lotacao };
                return salas.ToList();
            }
        }

        // GET: api/salas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/salas
        public string Post([FromBody] salas sala)
        {
            using(desafioProgEntities bd = new desafioProgEntities())
            {
                bd.salas.Add(sala);
                bd.SaveChanges();
                return "Sala salva com sucesso";
            }
        }

        // PUT: api/salas/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/salas/5
        public void Delete(int id)
        {
        }
    }
}
