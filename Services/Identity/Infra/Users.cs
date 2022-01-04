using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Users;
using Microsoft.Azure.CosmosRepository;

namespace Infra
{
    public class Users : IUsers
    {
        readonly IRepository<UserModel> _repository;
        readonly IMapper _mapper;

        public Users(IRepository<UserModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(User user)
        {
            var model = _mapper.Map<User, UserModel>(user);
            await _repository.CreateAsync(model);
        }

        public async Task Delete(User user)
        {
            var model = _mapper.Map<User, UserModel>(user);
            await _repository.DeleteAsync(model);
        }

        public async Task<User> Get(Guid id)
        {
            var user = await _repository.GetAsync(id.ToString());
            return _mapper.Map<UserModel, User>(user);
        }

        public async Task<User> Get(string email)
        {
            var user = (await _repository.GetAsync(x => x.Email == email)).FirstOrDefault();
            return _mapper.Map<UserModel, User>(user);
        }

        public async Task Update(User user)
        {
            var model = _mapper.Map<User, UserModel>(user);
            await _repository.UpdateAsync(model);
        }
    }
}