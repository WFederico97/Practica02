using Microsoft.AspNetCore.Mvc;
using Practica02.DTOs.Factura;
using Practica02.Repositories.Implementations;
using Practica02.Repositories.Interfaces;

namespace Practica02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private IFacturaAplicacion facturaRepository;

        public FacturaController()
        {
            facturaRepository = new FacturasRepository();
        }

        [HttpGet]
        public IActionResult GetFacturas([FromHeader] DateTime payday, [FromHeader] int paymentMethod)
        {
            try
            {
                FacturaReadDTO factura = facturaRepository.GetFacturaByQueries(payday, paymentMethod);
                return Ok(factura);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error. Error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateFacturas([FromBody] FacturaCreateDTO factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                facturaRepository.AgregarFactura(factura);
                return Ok($"La factura para el cliente  {factura.Cliente} fue creada correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error. Error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult EditFacturas([FromHeader] int Id, [FromBody] FacturaUpdateDTO factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                facturaRepository.EditarFactura(Id,factura) ;
                return Ok($"La factura con el id: {Id} fue editada correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error. Error: {ex.Message}");
            }
        }
    }
}
