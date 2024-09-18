using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica02.Models;
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
        public IActionResult GetFacturas()
        {
            try
            {
                List<Factura> facturas = facturaRepository.GetFacturasByQueries();
                return Ok(facturas);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error. Error: {ex.Message}");
            }
        }
    }
}
