using AutoMapper;
using FinalProject.Core.Application.Interfaces.Repositories;
using FinalProject.Core.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinalProject.Core.Application.Services
{
    public class GenericService<Model, SaveViewModel, ViewModel> : IGenericService<Model, SaveViewModel, ViewModel>
        where Model : class
        where SaveViewModel : class
        where ViewModel : class
    {
        private readonly IGenericRepository<Model> _genericRepository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Model> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<SaveViewModel> CreateAsync(SaveViewModel model)
        {
            var entity = _mapper.Map<Model>(model);
            var saveView = await _genericRepository.CreateAsync(entity);
            return _mapper.Map<SaveViewModel>(saveView);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            await _genericRepository.DeleteAsync(entity);
        }

        public async Task<List<ViewModel>> GetAllAsync()
        {
            var entities = _mapper.Map<List<ViewModel>>(await _genericRepository.GetAllAsync());
            return entities;
        }

        public async Task<ViewModel> GetByIdAsync(int id)
        {
            var entity = _mapper.Map<ViewModel>(await _genericRepository.GetByIdAsync(id));
            return entity;
        }

        public async Task UpdateAsync(SaveViewModel model, int id)
        {
            var entity = _mapper.Map<Model>(model);
            await _genericRepository.UpdateAsync(entity, id);
        }
    }
}
