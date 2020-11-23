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

    public class ListaItemController : ControllerBase
    {
        private readonly IUnitOfWork _context;
         private readonly IMapper _mapper;
        public ListaItemController(IUnitOfWork contexto, IMapper mapper)
            {   
                 _context = contexto;
                 _mapper = mapper;
            }
        [HttpGet]
        public ActionResult<IEnumerable<ListaItemDTO>> Get([FromQuery] ListaItemParameters listaItemParameters)
            {
                var listaItem = _context.ListaItemRepository.GetListaItems(listaItemParameters);
            
               var metadata = new
           {
               listaItem.TotalCount, 
               listaItem.PageSize,
               listaItem.CurrentPage,
               listaItem.TotalPages,
               listaItem.HasNext,
               listaItem.HasPrevious
               
           };
        
         Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata)); 

                var listaItemDto = _mapper.Map<List<ListaItemDTO>>(listaItem);
                return listaItemDto;
            }

        [HttpGet("{id}")]
        public ActionResult<ListaItemDTO> Get(int id)
        {
            var listaitem = _context.ListaItemRepository.GetById(l => l.idlistaitem == id);
            if (listaitem == null)
            {
                return NotFound();
            }
            var listaItemDto = _mapper.Map<ListaItemDTO>(listaitem);
            return listaItemDto;
        }

        [HttpPost]
        public ActionResult Post([FromBody]ListaItemDTO ListaItemDto)
        {
            var listaItem = _mapper.Map<ListaItem>(ListaItemDto);

            _context.ListaItemRepository.Add(listaItem);
            _context.Commit();

            var listaItemDTO = _mapper.Map<ListaItemDTO>(listaItem);

            return new CreatedAtRouteResult("ObterLista",
            new { id = listaItem.idlistaitem }, listaItemDTO);
        }
        [HttpPut("{id}")]
        public ActionResult Put (int id,[FromBody] ListaItemDTO ListaItemDto)
        {
            if (id != ListaItemDto.iditem)
            {
                return BadRequest();
            }

            var listaItem = _mapper.Map<ListaItem>(ListaItemDto);

            _context.ListaItemRepository.Update(listaItem);
            _context.Commit();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<ListaItemDTO> Delete(int id)
        {
            var listaItem = _context.ListaItemRepository.GetById(l => l.idlistaitem == id);
            if (listaItem == null)
            {
                return NotFound();
            }
            _context.ListaItemRepository.Delete(listaItem);
            _context.Commit();

            var listaItemDto = _mapper.Map<ListaItemDTO>(listaItem);
            return listaItemDto;
        }
    }
}