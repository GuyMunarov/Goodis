using AutoMapper;
using Goodis.Dtos;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Interfaces;
using Models.Specifications;

namespace Goodis.Controllers
{
    public class UsersController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IHashingService _hashingService;
        private readonly IMapper _mapper;

        public UsersController(IUnitOfWork unitOfWork, ITokenService tokenService, IHashingService hashingService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _hashingService = hashingService;
            _mapper = mapper;
        }

        //the method you have asked for
        [HttpPost("login")]
        public async Task<ActionResult<UserToReturnDto>> Login(LoginDto loginUser)
        {

            AppUser user = await _unitOfWork.Repository<AppUser>().GetFirstOrDefaultBySpecAsync(new UserSpecification(loginUser.UserName, loginUser.Password));

            if (user == null) return NotFound();
            
            return Ok(new UserToReturnDto() { Token = _tokenService.CreateToken(user), FullName = user.FullName, Id = user.Id, IsActive = user.IsActive, UserName = user.UserName });
        }


        //registration and login in a more secure way
        [HttpPost("loginProtected")]
        public async Task<ActionResult<UserToReturnDto>> LoginProtected(LoginDto loginUser)
        {

            AppUser user = await _unitOfWork.Repository<AppUser>().GetFirstOrDefaultBySpecAsync(new UserSpecification(loginUser.UserName));

            if (user == null) return NotFound();

            if (_hashingService.CheckHashEquality(loginUser.Password, user.PasswordHash, user.PasswordSalt))
            {
                UserToReturnDto userToReturn = _mapper.Map<AppUser, UserToReturnDto>(user);
                userToReturn.Token = _tokenService.CreateToken(user);
                return Ok(userToReturn);
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToReturnDto>> Post(RegisterDto userToCreate)
        {

            AppUser userWithSameUserName = await _unitOfWork.Repository<AppUser>().GetFirstOrDefaultBySpecAsync(new UserSpecification(userToCreate.UserName));

            if (userWithSameUserName != null) return BadRequest();

            //wouldnt really save the password in its raw form, but only the hash and salt. cant do it because of the assignment requirments
            AppUser user = _mapper.Map<RegisterDto, AppUser>(userToCreate);

            _hashingService.HashPassword(userToCreate.Password, out byte[] hash, out byte[] salt);
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.IsActive = true;
            await _unitOfWork.Repository<AppUser>().AddAsync(user);
            await _unitOfWork.Complete();

            UserToReturnDto userToReturn = _mapper.Map<AppUser,UserToReturnDto >(user);
            userToReturn.Token = _tokenService.CreateToken(user);
            return Ok(userToReturn);
        }


    }
}
