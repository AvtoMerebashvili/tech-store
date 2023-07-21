using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using tech_store.DbModels;
using tech_store.DbModels.Catalogs;
using tech_store.Dtos;

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
            await _context.AddAsync(dbBrand);
            await _context.SaveChangesAsync();
            var dbBrands = _context.brands.ToList();
            var getBrandsDto = dbBrands.Select(x => _mapper.Map<BrandGetDto>(x)).ToList();            
            response.result = getBrandsDto;
            return response;
        }

        public async Task<ServiceResponse<List<CityGetDto>>> addCity(CityAddDto newCity)
        {
            var response = new ServiceResponse<List<CityGetDto>>();
            var dbCity = _mapper.Map<City>(newCity);
            await _context.AddAsync(dbCity);
            await _context.SaveChangesAsync();
            var dbCities = _context.cities.ToList();
            var getCitiesDto = dbCities.Select(x => _mapper.Map<CityGetDto>(x)).ToList();
            response.result = getCitiesDto;
            return response;
        }

        public async Task<ServiceResponse<List<CountryGetDto>>> addCountry(CountryAddDto newCountry)
        {
            var response = new ServiceResponse<List<CountryGetDto>>();
            var dbCountry = _mapper.Map<Country>(newCountry);
            await _context.AddAsync(dbCountry);
            await _context.SaveChangesAsync();
            var dbCountries = await _context.countries.ToListAsync();
            var getCountriesDto = dbCountries.Select(x => _mapper.Map<CountryGetDto>(x)).ToList();
            response.result = getCountriesDto;
            return response;
        }

        public async Task<ServiceResponse<List<ModelGetDto>>> addModel(ModelAddDto newModel)
        {
            var response = new ServiceResponse<List<ModelGetDto>>();
            var dbModel = _mapper.Map<Model>(newModel);
            await _context.AddAsync(dbModel);
            await _context.SaveChangesAsync();
            var dbModels = _context.models.ToList();
            var getModelsDto = dbModels.Select(x => _mapper.Map<ModelGetDto>(x)).ToList();
            response.result = getModelsDto;
            return response;
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> addProductType(ProductTypeAddDto newProductType)
        {
            var response = new ServiceResponse<List<ProductTypeGetDto>>();
            var dbProductType = _mapper.Map<ProductType>(newProductType);
            await _context.AddAsync(dbProductType);
            await _context.SaveChangesAsync();
            var dbProductTypes = _context.product_types.ToList();
            var getProductTypesDto = dbProductTypes.Select(x => _mapper.Map<ProductTypeGetDto>(x)).ToList();
            response.result = getProductTypesDto;
            return response;
        }

        public async Task<ServiceResponse<List<BrandGetDto>>> getBrands()
        {
            var response = new ServiceResponse<List<BrandGetDto>>();
            var dbBrands = _context.brands.ToList();
            var brandsDto = dbBrands.Select(x => _mapper.Map<BrandGetDto>(x)).ToList();
            response.result = brandsDto;
            return response;
        }

        public async Task<ServiceResponse<List<CityGetDto>>> getCitiesByParams(int? id)
        {
            var response = new ServiceResponse<List<CityGetDto>>();
            var dbAllCities = _context.cities.Where(city =>
                string.IsNullOrEmpty(id.ToString()) || city.country_id == id
            ).ToList();
            var citiesDto = dbAllCities.Select(x => _mapper.Map<CityGetDto>(x)).ToList();
            response.result = citiesDto;
            return response;
        }

        public async Task<ServiceResponse<List<CountryGetDto>>> getCountries()
        {
            var response = new ServiceResponse<List<CountryGetDto>>();
            var dbCountries = _context.countries.ToList();
            var countriesDto = dbCountries.Select(x => _mapper.Map<CountryGetDto>(x)).ToList();
            response.result = countriesDto;
            return response;
        }

        public async Task<ServiceResponse<List<ModelGetDto>>> getModelsByParams(int? brandId)
        {
            var response = new ServiceResponse<List<ModelGetDto>>();
            var dbModels = _context.models.Where(model =>
                string.IsNullOrEmpty(brandId.ToString()) || model.brand_id == brandId
                ).ToList();
            var modelsDto = dbModels.Select(x => _mapper.Map<ModelGetDto>(x)).ToList();
            response.result = modelsDto;
            return response;
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> getProductTypes()
        {
            var response = new ServiceResponse<List<ProductTypeGetDto>>();
            var dbProductTypes = _context.product_types.ToList();
            var productTypesDto = dbProductTypes.Select(x => _mapper.Map<ProductTypeGetDto>(x)).ToList();
            response.result = productTypesDto;
            return response;
        }

        public async Task<ServiceResponse<List<BrandGetDto>>> removeBrand(int id)
        {
            var response = new ServiceResponse<List<BrandGetDto>>();
            var dbBrand = await _context.brands.FirstOrDefaultAsync(x => x.id == id);
            if (dbBrand != null)
            {
                _context.brands.Remove(dbBrand);
                await _context.SaveChangesAsync();
            }
            var dbBrands = _context.brands.ToList();
            var brandsDto = dbBrands.Select(x=>_mapper.Map<BrandGetDto>(x)).ToList();
            response.result = brandsDto;
            return response;
        }

        public async Task<ServiceResponse<List<CityGetDto>>> removeCity(int id)
        {
            var response = new ServiceResponse<List<CityGetDto>>();
            var dbCity = await _context.cities.FirstOrDefaultAsync(x=> x.id == id);
            if(dbCity != null)
            {
                _context.cities.Remove(dbCity);
                await _context.SaveChangesAsync();
            }
            var dbCities = _context.cities.ToList();
            var citiesDto = dbCities.Select(x => _mapper.Map<CityGetDto>(x)).ToList();
            response.result = citiesDto;
            return response;
        }

        public async Task<ServiceResponse<List<CountryGetDto>>> removeCountry(int id)
        {
            var response = new ServiceResponse<List<CountryGetDto>>();
            var dbCountry = await _context.countries.FirstOrDefaultAsync(x => x.id == id);
            if( dbCountry != null)
            {
                _context.countries.Remove(dbCountry);
                await _context.SaveChangesAsync();
            }
            var dbCountries = _context.countries.ToList();
            var countriesDto = dbCountries.Select(x => _mapper.Map<CountryGetDto>(x)).ToList();
            response.result = countriesDto;
            return response;
        }

        public async Task<ServiceResponse<List<ModelGetDto>>> removeModel(int id)
        {
            var response = new ServiceResponse<List<ModelGetDto>>();
            var dbModel = await _context.models.FirstOrDefaultAsync(x=>x.id == id);
            if( dbModel != null)
            {
                _context.models.Remove(dbModel);
                await _context.SaveChangesAsync();
            }
            var dbModels = _context.models.ToList();
            var modelsDto = dbModels.Select(x=>_mapper.Map<ModelGetDto>(x)).ToList();
            response.result = modelsDto;
            return response;
        }

        public async Task<ServiceResponse<List<ProductTypeGetDto>>> removeProductType(int id)
        {
            var response = new ServiceResponse<List<ProductTypeGetDto>>();
            var dbProductType = await _context.product_types.FirstOrDefaultAsync(x=> x.id == id);
            if ( dbProductType != null)
            {
                _context.product_types.Remove(dbProductType);
                await _context.SaveChangesAsync();
            }
            var dbProductTypes = _context.product_types.ToList();
            var productTypesDto = dbProductTypes.Select(x=> _mapper.Map<ProductTypeGetDto>(x)).ToList();
            response.result = productTypesDto;
            return response;

        }
    }
}
