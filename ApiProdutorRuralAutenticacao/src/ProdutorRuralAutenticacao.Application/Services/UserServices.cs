using AutoMapper;
using ProdutorRuralAutenticacao.Application.Common;
using ProdutorRuralAutenticacao.Application.Dtos.Requests;
using ProdutorRuralAutenticacao.Application.Dtos.Response;
using ProdutorRuralAutenticacao.Application.Repository;
using ProdutorRuralAutenticacao.Application.Services.Interfaces;
using ProdutorRuralAutenticacao.Application.Validations.User;
using ProdutorRuralAutenticacao.Domain.Entities.Identity;

namespace ProdutorRuralAutenticacao.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserServices(IUserRepository userRepository, IMapper mapper )
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));          
        }

        public async Task BlockUserAsync(BlockUserRequest request)
        {
            var resultValidate = new BlockUserRequestValidator().Validate(request);
            if (resultValidate.IsValid is false)
            {
                var messages = string.Concat("Message is invalid, validation errors: ", resultValidate.Errors.ConvertToString());
                throw new Exception(messages);
            }

            var data = await _userRepository.GetByIdAsync(request.Id);
            if (data is null)
            {
                throw new Exception("Usuario não encontrado.");
            }

            await _userRepository.BlockUserAsync(data, request.EnableBlocking);
        }

        public async Task CreateAsync(CreateUserRequest request)
        {
            var persistence = _mapper.Map<UsersEntitie>(request);
            var userId = await _userRepository.CreateAsync(persistence, request.Password);
        }

        public async Task DeleteAsync(DeleteUserRequest request)
        {
            var resultValidate = new DeleteUserRequestValidator().Validate(request);
            if (resultValidate.IsValid is false)
            {
                var messages = string.Concat("Message is invalid, validation errors: ", resultValidate.Errors.ConvertToString());
                throw new Exception(messages);
            }

            var data = await _userRepository.GetByIdAsync(request.Id);
            if (data is null)
            {
                throw new Exception("Usuario não encontrado.");
            }

            await _userRepository.DeleteAsync(data);
        }

        public async Task<UserResponse> GetByEmailAsync(GetUserByEmailRequest request)
        {
            var resultValidate = new GetUserByEmailRequestValidator().Validate(request);
            if (resultValidate.IsValid is false)
            {
                var messages = string.Concat("Message is invalid, validation errors: ", resultValidate.Errors.ConvertToString());
                throw new Exception(messages);
            }

            var data = await _userRepository.GetByEmailAsync(request.Email);
            return _mapper.Map<UserResponse>(data);
        }

        public async Task<UserResponse> GetByIdAsync(GetUserByIdRequest request)
        {
            var resultValidate = new GetUserByIdRequestValidator().Validate(request);
            if (resultValidate.IsValid is false)
            {
                var messages = string.Concat("Message is invalid, validation errors: ", resultValidate.Errors.ConvertToString());
                throw new Exception(messages);
            }

            var data = await _userRepository.GetByIdAsync(request.Id);
            return _mapper.Map<UserResponse>(data);
        }

        public async Task<UserResponse> GetByNickNameAsync(GetUserByNickNameRequest request)
        {
            var resultValidate = new GetUserByNickNameRequestValidator().Validate(request);
            if (resultValidate.IsValid is false)
            {
                var messages = string.Concat("Message is invalid, validation errors: ", resultValidate.Errors.ConvertToString());
                throw new Exception(messages);
            }

            var data = await _userRepository.GetByNicknameAsync(request.NickName);
            return _mapper.Map<UserResponse>(data);
        }

        public async Task<List<UserResponse>> ListUsersNoTwoFactor()
        {
            var data = await _userRepository.ListUsersNoTwoFactor();
            List<UserResponse> result = _mapper.Map<List<UserResponse>>(data);
            return result;
        }

    }
}

