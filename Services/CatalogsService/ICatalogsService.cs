namespace tech_store.Services.CatalogsService
{
    public interface ICatalogsService
    {
        Task<ServiceResponse<List<ProductTypeGetDto>>> getProductTypes();
        Task<ServiceResponse<List<ProductTypeGetDto>>> getCountries();
        Task<ServiceResponse<List<ProductTypeGetDto>>> getCitiesByParams(int? id);
        Task<ServiceResponse<List<ProductTypeGetDto>>> getModelsByParams(int? id);
        Task<ServiceResponse<List<ProductTypeGetDto>>> getBrands();
        Task<ServiceResponse<List<ProductTypeGetDto>>> addProductType(ProductTypeAddDto request);
        Task<ServiceResponse<List<ProductTypeGetDto>>> removeProductType(int id);
        Task<ServiceResponse<List<ProductTypeGetDto>>> addModel(ModelAddDto request);
        Task<ServiceResponse<List<ProductTypeGetDto>>> removeModel(int id);
        Task<ServiceResponse<List<ProductTypeGetDto>>> addBrand(BrandAddDto request);
        Task<ServiceResponse<List<ProductTypeGetDto>>> removeBrand(int id);
        Task<ServiceResponse<List<ProductTypeGetDto>>> addCountry(CountryAddDto request);
        Task<ServiceResponse<List<ProductTypeGetDto>>> removeCountry(int id);
        Task<ServiceResponse<List<ProductTypeGetDto>>> addCity(CityAddDto request);
        Task<ServiceResponse<List<ProductTypeGetDto>>> removeCity(int id);
    }
}
