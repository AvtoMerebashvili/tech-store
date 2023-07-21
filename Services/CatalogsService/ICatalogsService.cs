namespace tech_store.Services.CatalogsService
{
    public interface ICatalogsService
    {
        Task<ServiceResponse<List<ProductTypeGetDto>>> getProductTypes();
        Task<ServiceResponse<List<CountryGetDto>>> getCountries();
        Task<ServiceResponse<List<CityGetDto>>> getCitiesByParams(int? id);
        Task<ServiceResponse<List<ModelGetDto>>> getModelsByParams(int? brandId);
        Task<ServiceResponse<List<BrandGetDto>>> getBrands();
        Task<ServiceResponse<List<ProductTypeGetDto>>> addProductType(ProductTypeAddDto newProductType);
        Task<ServiceResponse<List<ProductTypeGetDto>>> removeProductType(int id);
        Task<ServiceResponse<List<ModelGetDto>>> addModel(ModelAddDto newModel);
        Task<ServiceResponse<List<ModelGetDto>>> removeModel(int id);
        Task<ServiceResponse<List<BrandGetDto>>> addBrand(BrandAddDto newBrand);
        Task<ServiceResponse<List<BrandGetDto>>> removeBrand(int id);
        Task<ServiceResponse<List<CountryGetDto>>> addCountry(CountryAddDto newCountry);
        Task<ServiceResponse<List<CountryGetDto>>> removeCountry(int id);
        Task<ServiceResponse<List<CityGetDto>>> addCity(CityAddDto newCity);
        Task<ServiceResponse<List<CityGetDto>>> removeCity(int id);
    }
}
