using DataAccess.DTOs.Brand;
using DataAccess.Interfaces;
using DataAccess.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandsRepository _brandsRepo;

        public BrandsController(IBrandsRepository brandsRepo)
        {
            _brandsRepo = brandsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandsRepo.GetAllAsync();
            var brandDTOs = brands.Select(b => b.ToDTO());
            return Ok(brandDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var brand = await _brandsRepo.GetByIdAsync(id);
            if (brand == null) return NotFound();
            var brandDTO = brand.ToDTO();
            return Ok(brandDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandRequest brandDTO)
        {
            var brand = await _brandsRepo.CreateAsync(brandDTO.ToBrand());
            if (brand == null) return BadRequest(nameof(brand));
            return CreatedAtAction(nameof(Create), brand.ToDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBrandRequest brandDTO)
        {
            var brand = await _brandsRepo.UpdateAsync(id, brandDTO.ToBrand());
            if (brand == null) return BadRequest(nameof(brand));
            return Ok(brand.ToDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _brandsRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
