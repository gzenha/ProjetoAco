using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Orcamento.API.Context;
using Orcamento.API.DTOs;
using Orcamento.API.Models;
using Orcamento.API.Pagination;
using Orcamento.API.Repository;

namespace Orcamento.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[Controller]")]
    [ApiController]
    public class TbOrcamentoController : ControllerBase
    {
        private readonly IUnitOfWork _context;
         private readonly IMapper _mapper;
        public TbOrcamentoController(IUnitOfWork contexto, IMapper mapper)
        {
            _context = contexto;
            _mapper = mapper;
        }

        [HttpGet("{OrcamentoMenor}")]
        public ActionResult<IEnumerable<TbOrcamentoDTO>> GetOrcamentoPorPreco()
        {   
            var tborcamentos = _context.TbOrcamentoRepository.GetTbOrcamentoPorPreco().ToList();
            var tborcamentosDto = _mapper.Map<List<TbOrcamentoDTO>>(tborcamentos);
            return tborcamentosDto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbOrcamentoDTO>> Get([FromQuery] TbOrcamentoParameters tbOrcamentoParameters) 
        {
            var tborcamentos = _context.TbOrcamentoRepository.GetTborcamentos(tbOrcamentoParameters);

                        
               var metadata = new
           {
               tborcamentos.TotalCount, 
               tborcamentos.PageSize,
               tborcamentos.CurrentPage,
               tborcamentos.TotalPages,
               tborcamentos.HasNext,
               tborcamentos.HasPrevious
               
           };
        
         Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata)); 



            var tborcamentosDto = _mapper.Map<List<TbOrcamentoDTO>>(tborcamentos);
            return tborcamentosDto;
  
        }
        [HttpGet("{id}")]
        public ActionResult<TbOrcamentoDTO> Get(int id)
        {
            var Tborcamento = _context.TbOrcamentoRepository.GetById(o => o.idorcamento == id);
            if (Tborcamento == null)
            {
                return NotFound();
            }
            var tborcamentoDto = _mapper.Map<TbOrcamentoDTO>(Tborcamento);
            return tborcamentoDto;
        }
        [HttpPost]
        public ActionResult Post([FromBody] TbOrcamentoDTO tbOrcamentoDto)
        {
            var Tborcamento = _mapper.Map<Tborcamento>(tbOrcamentoDto);

            _context.TbOrcamentoRepository.Add(Tborcamento);
            _context.Commit();

            var tborcamentoDto = _mapper.Map<TbOrcamentoDTO>(Tborcamento);

            return new CreatedAtRouteResult("ObterOrcamento",
            new {id = Tborcamento.idorcamento}, tbOrcamentoDto);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TbOrcamentoDTO tbOrcamentoDto)
        {
            if (id != tbOrcamentoDto.idorcamento)

            {
                return BadRequest();
            }
            var tborcamento = _mapper.Map<Tborcamento>(tbOrcamentoDto);

            _context.TbOrcamentoRepository.Update(tborcamento);
            _context.Commit();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<TbOrcamentoDTO> Delete(int id)
        {
            var tborcamento = _context.TbOrcamentoRepository.GetById(o => o.idorcamento == id);
            if (tborcamento == null)
            {
                return NotFound();
            }
            _context.TbOrcamentoRepository.Delete(tborcamento);
            _context.Commit();
            
            var tbOrcamentoDto = _mapper.Map<TbOrcamentoDTO>(tborcamento);
            return tbOrcamentoDto;
        }
           
    }
}