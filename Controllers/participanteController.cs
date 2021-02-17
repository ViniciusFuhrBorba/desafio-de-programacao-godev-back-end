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
    public class participanteController : ApiController
    {
        // GET: api/participante
        public IEnumerable<dynamic> Get()
        {
            using (desafioProgEntities bd = new desafioProgEntities())
            {
                var participante = from part in bd.participante
                                   select new { part.id, part.nome, part.sobrenome, part.sala1, part.sala2, part.cafe1, part.cafe2 };
                return participante.ToList();
            }
        }

        // GET: api/participante/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/participante
        public string Post([FromBody] participante part)
        {
            using(desafioProgEntities bd = new desafioProgEntities())
            {
                bd.participante.Add(part);
                bd.SaveChanges();
                return "Participante salvo com sucesso";
            }
        }

        // PUT: api/participante/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/participante/5
        public void Delete(int id)
        {
        }
    }
}
