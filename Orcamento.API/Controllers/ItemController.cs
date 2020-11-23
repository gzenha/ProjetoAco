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
    public class ItemController : ControllerBase
    {
         private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
         public ItemController(IUnitOfWork contexto, IMapper mapper)
        {
             _context = contexto;
             _mapper = mapper;
        }


        [HttpGet("{ItemMenorValor}")]
        public ActionResult<IEnumerable<ItemDTO>> GetItemMenorValor()
        {
            var items = _context.ItemRepository.GetItemPorPreco().ToList();
            var itemDto = _mapper.Map<List<ItemDTO>>(items);
            return itemDto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemDTO>> Get([FromQuery] ItemParameters itemParameters )
        {
            var items = _context.ItemRepository.GetItems(itemParameters);

             var metadata = new
           {
               items.TotalCount, 
               items.PageSize,
               items.CurrentPage,
               items.TotalPages,
               items.HasNext,
               items.HasPrevious
               
           };
        
         Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));



            var itemsDto = _mapper.Map<List<ItemDTO>>(items);
            return itemsDto;
        }
        
        [HttpGet("{id}")]
        public ActionResult<ItemDTO> Get(int id)
        {
            var item = _context.ItemRepository.GetById(i => i.Iditem == id);
            if (item == null) 
            {
                return NotFound();
            }
            var itemDto = _mapper.Map<ItemDTO>(item);
            return itemDto;
        }
        [HttpPost]
        public ActionResult Post([FromBody]ItemDTO ItemDto)
        {
            var item = _mapper.Map<Item>(ItemDto);

            _context.ItemRepository.Add(item);
            _context.Commit();

            var itemDTO = _mapper.Map<ItemDTO>(item);

            return new CreatedAtRouteResult ("ObterItem", 
            new {id = item.Iditem}, itemDTO);
        }
        [HttpPut("{id}")]
        public ActionResult Put( int id, [FromBody] ItemDTO ItemDto)
        { 
            if ( id != ItemDto.Iditem)
            {
                return NotFound();
            }

            var item = _mapper.Map<Item>(ItemDto);

            _context.ItemRepository.Update(item);
            _context.Commit();
             return Ok();

        }
        [HttpDelete("{id}")]
        public ActionResult<ItemDTO> Delete(int id)
        {
            var item = _context.ItemRepository.GetById(i => i.Iditem == id);
            if (item == null)
            {
                return NotFound();
            }
            _context.ItemRepository.Delete(item);
            _context.Commit();

            var ItemDto = _mapper.Map<ItemDTO>(item);
            return ItemDto;
        }

    }
}