using API.Contracts.Brand;
using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandsRepo.GetAllAsync();
            var brandsResponse = brands.Select(b => new BrandResponse(b.Id, b.Name));
            return Ok(brandsResponse);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var brand = await _brandsRepo.GetByIdAsync(id);
            if (brand == null) return NotFound();
            var brandResponse = new BrandResponse(brand.Id, brand.Name);
            return Ok(brandResponse);
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Create([FromBody] CreateBrandRequest brandRequest)
        {
            var brand = await _brandsRepo.CreateAsync(new Brand { Name = brandRequest.Name });
            if (brand == null) return BadRequest(nameof(brand));
            return CreatedAtAction(nameof(Create), new BrandResponse(brand.Id, brand.Name));
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBrandRequest brandRequest)
        {
            var brand = await _brandsRepo.UpdateAsync(id, new Brand { Name = brandRequest.Name });
            if (brand == null) return BadRequest(nameof(brand));
            return Ok(new BrandResponse(brand.Id, brand.Name));
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _brandsRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
