using CRUD.Backend.Data;
using CRUD.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DataContext _context;


        public ProductosController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Productos.ToListAsync());

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Producto producto)
        {
            try
            {

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return Ok(producto);


            }
            catch (DbUpdateException e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.InnerException!.Message);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);


            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
                   
        
        }

    }
}
