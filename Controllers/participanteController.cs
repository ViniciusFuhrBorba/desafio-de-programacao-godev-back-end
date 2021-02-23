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
                                   select new { part.id, part.nome, part.sobrenome, part.salaEtapa1, nomeSala1 = part.salas.nome, part.salaEtapa2,nomeSala2 = part.salas1.nome, part.cafeEtapa1,nomeCafe1 = part.cafes.nome, part.cafeEtapa2, nomeCafe2 = part.cafes1.nome };
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
        public string Put(int id, [FromBody] participante part)
        {
            using(desafioProgEntities bd = new desafioProgEntities())
            {
                participante partAlterar = bd.participante.Find(id);
                partAlterar.salaEtapa1 = part.salaEtapa1;
                partAlterar.salaEtapa2 = part.salaEtapa2;
                bd.SaveChanges();
                return "Alterado com sucesso";
            }
        }

        // DELETE: api/participante/5
        public void Delete(int id)
        {
        }
    }
}
