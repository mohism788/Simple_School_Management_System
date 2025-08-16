using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.DTOs.SuppliesDtos;
using School_Management_System.Models;
using School_Management_System.Repositories.SuppliesRepository;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        private readonly ISuppliesRepository _suppliesRepo;

        public SuppliesController(ISuppliesRepository suppliesRepo)
        {
            _suppliesRepo = suppliesRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetSupplies()
        {
           
            return Ok(await _suppliesRepo.GetAllAsync());
        }
        
        [HttpPost]
        public async Task<IActionResult> AddSupply([FromBody] CreateNewSupplyDto newSupply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var supply = new Supply()
            {
                StudentId = newSupply.StudentId,
                ItemName = newSupply.ItemName,
                Price = newSupply.Price,
                QuantityAvailable = newSupply.QuantityAvailable
            };
            await _suppliesRepo.AddAsync(supply);
            return Ok("Supply Added");
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupply([FromRoute]int id)
        {
           
            if (!await _suppliesRepo.FindEntityAsync(s => s.ItemId == id))
            {
                return NotFound($"Supply with id:{id} not found");
            }

            _suppliesRepo.DeleteAsync(id);

            return Ok("Supply Deleted!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupply([FromRoute] int id, [FromBody] UpdateSupplyDto updateSupply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _suppliesRepo.FindEntityAsync(s => s.ItemId == id))
            {
                return NotFound($"Supply with id:{id} not found");
            }
            var supply = new Supply()
            {
                StudentId = updateSupply.StudentId,
                ItemName = updateSupply.ItemName,
                Price = updateSupply.Price,
                QuantityAvailable = updateSupply.QuantityAvailable
            };
            _suppliesRepo.UpdateAsync(supply);
            return Ok("Supply Updated!");
        }
    }
}
