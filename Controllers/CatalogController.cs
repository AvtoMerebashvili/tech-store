using Microsoft.AspNetCore.Mvc;
using tech_store.DbModels.Catalogs;


namespace tech_store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogsService _catalogsService;
        public CatalogController(CatalogsService catalogService)
        {
            _catalogsService = catalogService;
        }

        [HttpGet]
        [Route("ProductTypes")]
        public async Task<ActionResult<List<ProductType>>> getProductTypes()
        {
            return null;
        }

        [HttpGet]
        [Route("Countries")]
        public async Task<ActionResult<List<CountryGetDto>>> getCountries()
        {
            return null;
        }

        [HttpGet]
        [Route("Cities")]
        public async Task<ActionResult<List<CityGetDto>>> getCities(int? countryId)
        {
            return null;
        }

        [HttpGet]
        [Route("Models")]
        public async Task<ActionResult<List<ModelGetDto>>> getModels(int? brandId)
        {
            return null;
        }

        [HttpGet]
        [Route("Brands")]
        public async Task<ActionResult<List<BrandGetDto>>> getBrands()
        {
            return null;
        }

        //ADMIN
        [HttpPost]
        [Route("AddProductType")]
        public async Task<ActionResult<Boolean>> addProductType(ProductTypeAddDto request)
        {
            return null;
        }

        [HttpDelete]
        [Route("RemoveProductType")]
        public async Task<ActionResult<Boolean>> removeProductType(int id)
        {
            return null;
        }

        [HttpPost]
        [Route("AddModel")]
        public async Task<ActionResult<Boolean>> addModel(ModelAddDto request)
        {
            return null;
        }

        [HttpDelete]
        [Route("RemoveModel")]
        public async Task<ActionResult<Boolean>> removeModel(int id)
        {
            return null;
        }


        [HttpPost]
        [Route("AddBrand")]
        public async Task<ActionResult<Boolean>> addBrand(BrandAddDto request)
        {
            return null;
        }

        [HttpDelete]
        [Route("RemoveBrand")]
        public async Task<ActionResult<Boolean>> removeBrand(int id)
        {
            return null;
        }

        [HttpPost]
        [Route("AddCountry")]
        public async Task<ActionResult<Boolean>> addCountry(CountryAddDto request)
        {
            return null;
        }

        [HttpDelete]
        [Route("RemoveCountry")]
        public async Task<ActionResult<Boolean>> removeCountry(int id)
        {
            return null;
        }

        [HttpPost]
        [Route("AddCity")]
        public async Task<ActionResult<Boolean>> addCity(CityAddDto request)
        {
            return null;
        }

        [HttpDelete]
        [Route("RemoveCity")]
        public async Task<ActionResult<Boolean>> removeCity(int id)
        {
            return null;
        }

    }
}
