using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica02.DTOs.Articulo;
using Practica02.Models;
using Practica02.Repositories.Implementations;
using Practica02.Repositories.Interfaces;

namespace Practica02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private IArticuloAplicacion articuloRepository;

        public ArticulosController()
        {
            articuloRepository = new ArticuloRepository();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Articulo> articulos = articuloRepository.GetArticulos();
                return Ok(articulos);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error. Error: {ex.Message}");
            }
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                var articulo = articuloRepository.GetArticuloById(Id);
                if(articulo == null)
                {
                    return NotFound();
                }
                return Ok(articulo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error. Error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductCreateDTO articulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                articuloRepository.AgregarArticulo(articulo);
                return Ok($"El articulo: {articulo.Nombre} fue creado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error. Error: {ex.Message}");
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Edit([FromBody] ProductUpdateDTO articulo, [FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Articulo scopedArticulo = articuloRepository.GetArticuloById(Id);
                if(scopedArticulo.Id == 0)
                {
                    return NotFound($"No se encontro el articulo con el id: {Id}");
                }

                articuloRepository.EditarArticulo(Id, articulo);
                return Ok("Articulo editado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error. Error: {ex.Message}");
            }
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            if(Id < 1)
            {
                return BadRequest("El id de producto a eliminar es requerido");
            }
            try
            {
                Articulo targetedArticulo = articuloRepository.GetArticuloById(Id);
                if(targetedArticulo.Id == 0)
                {
                    return NotFound($"No se encontro el articulo con el id: {Id}");
                }
                articuloRepository.EliminarArticulo(Id);
                return Ok($"El articulo con el Id: {Id} fue eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error. Error: {ex.Message}");
            }
        }


        
    }
}
