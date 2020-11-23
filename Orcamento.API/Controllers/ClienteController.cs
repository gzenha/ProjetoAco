using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orcamento.API.Context;
using Orcamento.API.DTOs;
using Orcamento.API.Models;
using Orcamento.API.Pagination;
using Orcamento.API.Repository;
using Newtonsoft.Json;

namespace Orcamento.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[Controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
         private readonly IUnitOfWork _context;
         private readonly IMapper _mapper;
         public ClienteController(IUnitOfWork contexto, IMapper mapper)
        {
             _context = contexto;
             _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ClienteDTO>> Get([FromQuery] ClienteParameters clienteParameters)
        {
            
           var clientes = _context.ClienteRepository.GetClientes(clienteParameters);

           var metadata = new
           {
               clientes.TotalCount, 
               clientes.PageSize,
               clientes.CurrentPage,
               clientes.TotalPages,
               clientes.HasNext,
               clientes.HasPrevious
               
           };
        
         Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

           var clientesDto = _mapper.Map<List<ClienteDTO>>(clientes);
           return clientesDto;
        }
        [HttpGet ("{id}")]
        public ActionResult<ClienteDTO> Get(int id)
        {
            var cliente = _context.ClienteRepository.GetById(c => c.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }
            var clienteDto = _mapper.Map<ClienteDTO>(cliente);
            return clienteDto;
             
        }
        [HttpPost]
        public ActionResult Post([FromBody] ClienteDTO ClienteDto)
        {

            var cliente =_mapper.Map<Cliente>(ClienteDto);

            _context.ClienteRepository.Add(cliente);
            _context.Commit();

            var clienteDTO = _mapper.Map<ClienteDTO>(cliente);

            return new CreatedAtRouteResult("ObterCliente",
            new { id = cliente.IdCliente}, clienteDTO);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ClienteDTO ClienteDto)
        {
            if( id != ClienteDto.IdCliente)
            {
                return BadRequest();
            }
            var cliente = _mapper.Map<Cliente>(ClienteDto);
            _context.ClienteRepository.Update(cliente);
            _context.Commit();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<ClienteDTO> Delete(int id)
        {
            var cliente = _context.ClienteRepository.GetById(c => c.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.ClienteRepository.Delete(cliente);
            _context.Commit();

            var clienteDto = _mapper.Map<ClienteDTO>(cliente);
            return clienteDto;
        }
    }
}