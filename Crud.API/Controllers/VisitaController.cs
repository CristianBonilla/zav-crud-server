using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Crud.Domain;

namespace Crud.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VisitaController : ControllerBase
    {
        readonly IMapper mapper;
        readonly IVisitaService visitaService;

        public VisitaController(IMapper mapper, IVisitaService visitaService) =>
            (this.mapper, this.visitaService) = (mapper, visitaService);

        [HttpGet]
        public async IAsyncEnumerable<VisitaEntity> Get()
        {
            var visitas = visitaService.Read();
            await foreach (VisitaEntity visita in visitas)
                yield return visita;
        }

        [HttpGet("{idVisita}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VisitaEntity>> Get(int idVisita)
        {
            VisitaEntity visitaFind = await visitaService.Find(idVisita);
            if (visitaFind == null)
                return NotFound();

            return Ok(visitaFind);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VisitaEntity>> Post([FromBody] VisitaModel visitaModel)
        {
            VisitaEntity visita = mapper.Map<VisitaEntity>(visitaModel);
            VisitaEntity visitaCreate = await visitaService.Create(visita);

            return Ok(visitaCreate);
        }

        [HttpPut("{idVisita}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VisitaEntity>> Put(int idVisita, [FromBody] VisitaModel visitaModel)
        {
            VisitaEntity visitaFind = await visitaService.Find(idVisita);
            if (visitaFind == null)
                return NotFound();
            VisitaEntity visitaChange = mapper.Map(visitaModel, visitaFind);
            VisitaEntity visitaUpdate = await visitaService.Update(visitaChange);

            return Ok(visitaUpdate);
        }

        [HttpDelete("{idVisita}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VisitaEntity>> Delete(int idVisita)
        {
            VisitaEntity visitaFind = await visitaService.Find(idVisita);
            if (visitaFind == null)
                return NotFound();
            VisitaEntity visitaDelete = await visitaService.Delete(visitaFind);

            return Ok(visitaDelete);
        }
    }
}
