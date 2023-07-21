using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using tech_store.DbModels.Catalogs;
using tech_store.Dtos;


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

        [HttpGet]
        [Route("ProductTypes")]
        public async Task<ActionResult<ServiceResponse<List<ProductTypeGetDto>>>> getProductTypes()
        {
            return await _catalogsService.getProductTypes();
        }

        [HttpGet]
        [Route("Countries")]
        public async Task<ActionResult<ServiceResponse<List<CountryGetDto>>>> getCountries()
        {
            return await _catalogsService.getCountries();
        }

        [HttpGet]
        [Route("Cities")]
        public async Task<ActionResult<ServiceResponse<List<CityGetDto>>>> getCities(int? countryId)
        {
            return await _catalogsService.getCitiesByParams(countryId);
        }

        [HttpGet]
        [Route("Models")]
        public async Task<ActionResult<ServiceResponse<List<ModelGetDto>>>> getModels(int? brandId)
        {
            return await _catalogsService.getModelsByParams(brandId);
        }

        [HttpGet]
        [Route("Brands")]
        public async Task<ActionResult<ServiceResponse<List<BrandGetDto>>>> getBrands()
        {
            return await _catalogsService.getBrands();
        }

        //ADMIN
        [HttpPost]
        [Route("AddProductType")]
        public async Task<ActionResult<ServiceResponse<List<ProductTypeGetDto>>>> addProductType(ProductTypeAddDto request)
        {
            return await _catalogsService.addProductType(request);
        }

        [HttpDelete]
        [Route("RemoveProductType")]
        public async Task<ActionResult<ServiceResponse<List<ProductTypeGetDto>>>> removeProductType(int id)
        {
            return await _catalogsService.removeProductType(id);
        }

        [HttpPost]
        [Route("AddModel")]
        public async Task<ActionResult<ServiceResponse<List<ModelGetDto>>>> addModel(ModelAddDto request)
        {
            return await _catalogsService.addModel(request);
        }

        [HttpDelete]
        [Route("RemoveModel")]
        public async Task<ActionResult<ServiceResponse<List<ModelGetDto>>>> removeModel(int id)
        {
            return await _catalogsService.removeModel(id);
        }


        [HttpPost]
        [Route("AddBrand")]
        public async Task<ActionResult<ServiceResponse<List<BrandGetDto>>>> addBrand(BrandAddDto request)
        {
            return await _catalogsService.addBrand(request);
        }

        [HttpDelete]
        [Route("RemoveBrand")]
        public async Task<ActionResult<ServiceResponse<List<BrandGetDto>>>> removeBrand(int id)
        {
            return await _catalogsService.removeBrand(id);
        }

        [HttpPost]
        [Route("AddCountry")]
        public async Task<ActionResult<ServiceResponse<List<CountryGetDto>>>> addCountry(CountryAddDto request)
        {
            return await _catalogsService.addCountry(request);
        }

        [HttpDelete]
        [Route("RemoveCountry")]
        public async Task<ActionResult<ServiceResponse<List<CountryGetDto>>>> removeCountry(int id)
        {
            return await _catalogsService.removeCountry(id);
        }

        [HttpPost]
        [Route("AddCity")]
        public async Task<ActionResult<ServiceResponse<List<CityGetDto>>>> addCity(CityAddDto request)
        {
            return await _catalogsService.addCity(request);
        }

        [HttpDelete]
        [Route("RemoveCity")]
        public async Task<ActionResult<ServiceResponse<List<CityGetDto>>>> removeCity(int id)
        {
            return await _catalogsService.removeCity(id);
        }

    }
}
