using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tech_store.DbModels.Catalogs;
using tech_store.Dtos;
using tech_store.Filters;

namespace tech_store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogsService _catalogsService;
        public CatalogController(ICatalogsService catalogService)
        {
            _catalogsService = catalogService;
        }

        [HttpGet("ProductTypes")]
        public async Task<ActionResult<ServiceResponse<List<ProductTypeGetDto>>>> getProductTypes()
        {
            return await _catalogsService.getProductTypes();
        }

        [HttpGet("Countries")]
        public async Task<ActionResult<ServiceResponse<List<CountryGetDto>>>> getCountries()
        {
            return await _catalogsService.getCountries();
        }

        [HttpGet("Cities")]
        public async Task<ActionResult<ServiceResponse<List<CityGetDto>>>> getCities(int? countryId)
        {
            return await _catalogsService.getCitiesByParams(countryId);
        }

        [HttpGet("Models")]
        public async Task<ActionResult<ServiceResponse<List<ModelGetDto>>>> getModels(int? brandId)
        {
            return await _catalogsService.getModelsByParams(brandId);
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<ServiceResponse<List<BrandGetDto>>>> getBrands()
        {
            return await _catalogsService.getBrands();
        }

        //ADMIN
        [Authorize]
        [RoleFilter("admin")]
        [HttpPost("AddProductType")]
        public async Task<ActionResult<ServiceResponse<List<ProductTypeGetDto>>>> addProductType(ProductTypeAddDto request)
        {
            return await _catalogsService.addProductType(request);
        }

        [Authorize]
        [RoleFilter("admin")]
        [HttpDelete("RemoveProductType")]
        public async Task<ActionResult<ServiceResponse<List<ProductTypeGetDto>>>> removeProductType(int id)
        {
            return await _catalogsService.removeProductType(id);
        }

        [Authorize]
        [RoleFilter("admin")]
        [HttpPost("AddModel")]
        public async Task<ActionResult<ServiceResponse<List<ModelGetDto>>>> addModel(ModelAddDto request)
        {
            return await _catalogsService.addModel(request);
        }

        [Authorize]
        [RoleFilter("admin")]
        [HttpDelete("RemoveModel")]
        public async Task<ActionResult<ServiceResponse<List<ModelGetDto>>>> removeModel(int id)
        {
            return await _catalogsService.removeModel(id);
        }

        [Authorize]
        [RoleFilter("admin")]
        [HttpPost("AddBrand")]
        public async Task<ActionResult<ServiceResponse<List<BrandGetDto>>>> addBrand(BrandAddDto request)
        {
            return await _catalogsService.addBrand(request);
        }

        [Authorize]
        [RoleFilter("admin")]
        [HttpDelete("RemoveBrand")]
        public async Task<ActionResult<ServiceResponse<List<BrandGetDto>>>> removeBrand(int id)
        {
            return await _catalogsService.removeBrand(id);
        }

        [Authorize]
        [RoleFilter("admin")]
        [HttpPost("AddCountry")]
        public async Task<ActionResult<ServiceResponse<List<CountryGetDto>>>> addCountry(CountryAddDto request)
        {
            return await _catalogsService.addCountry(request);
        }

        [Authorize]
        [RoleFilter("admin")]
        [HttpDelete("RemoveCountry")]
        public async Task<ActionResult<ServiceResponse<List<CountryGetDto>>>> removeCountry(int id)
        {
            return await _catalogsService.removeCountry(id);
        }

        [Authorize]
        [RoleFilter("admin")]
        [HttpPost("AddCity")]
        public async Task<ActionResult<ServiceResponse<List<CityGetDto>>>> addCity(CityAddDto request)
        {
            return await _catalogsService.addCity(request);
        }

        [Authorize]
        [RoleFilter("admin")]
        [HttpDelete("RemoveCity")]
        public async Task<ActionResult<ServiceResponse<List<CityGetDto>>>> removeCity(int id)
        {
            return await _catalogsService.removeCity(id);
        }

    }
}
