using Microsoft.EntityFrameworkCore;
using tech_store.DbModels;
using tech_store.DbModels.Catalogs;

namespace tech_store.Services.CatalogsService
{
    public class CatalogsService : ICatalogsService
    {
        private readonly TechStoreContext _context;
        private readonly IMapper _mapper;
        public CatalogsService(TechStoreContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<BrandGetDto>>> addBrand(BrandAddDto newBrand)
        {
            var response = new ServiceResponse<List<BrandGetDto>>();
            var dbBrand = _mapper.Map<Brand>(newBrand);
            _context.Add(dbBrand);
            _context.SaveChanges();
            var dbBrands = await _context.brands.ToListAsync();
            var getBrandDto = dbBrands.Select(x => _mapper.Map<BrandGetDto>(dbBrand)).ToList();            
            response.result = getBrandDto;
            return response;
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> addCity(CityAddDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> addCountry(CountryAddDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> addModel(ModelAddDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> addProductType(ProductTypeAddDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> getBrands()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> getCitiesByParams(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> getCountries()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> getModelsByParams(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> getProductTypes()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> removeBrand(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> removeCity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> removeCountry(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> removeModel(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> removeProductType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
