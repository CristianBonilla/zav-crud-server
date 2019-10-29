using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using AutoMapper;
using Crud.Domain;

namespace Crud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitaController : ControllerBase
    {
        readonly IMapper mapper;
        readonly IVisitaService visitaService;

        public VisitaController(IMapper mapper, IVisitaService visitaService)
        {
            this.visitaService = visitaService;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VisitaEntity>> Get()
        {
            var visitas = visitaService.Read();

            return Ok(visitas);
        }

        [HttpGet("{idVisita}")]
        public ActionResult<VisitaEntity> Get(int idVisita)
        {
            VisitaEntity visitaFind = visitaService.Find(idVisita);
            if (visitaFind == null)
                return NotFound();

            return Ok(visitaFind);
        }

        [HttpPost]
        public async Task<ActionResult<VisitaEntity>> Post([FromBody] VisitaModel visitaModel)
        {
            VisitaEntity visita = mapper.Map<VisitaEntity>(visitaModel);
            VisitaEntity visitaCreate = await visitaService.Create(visita);

            return Ok(visitaCreate);
        }

        [HttpPut("{idVisita}")]
        public async Task<ActionResult<VisitaEntity>> Put(int idVisita, [FromBody] VisitaModel visitaModel)
        {
            VisitaEntity visitaFind = visitaService.Find(idVisita);
            if (visitaFind == null)
                return NotFound();
            VisitaEntity visitaChange = mapper.Map(visitaModel, visitaFind);
            VisitaEntity visitaUpdate = await visitaService.Update(visitaChange);

            return Ok(visitaUpdate);
        }

        [HttpDelete("{idVisita}")]
        public async Task<ActionResult<VisitaEntity>> Delete(int idVisita)
        {
            VisitaEntity visitaFind = visitaService.Find(idVisita);
            if (visitaFind == null)
                return NotFound();
            VisitaEntity visitaDelete = await visitaService.Delete(visitaFind);

            return Ok(visitaDelete);
        }
    }
}
