using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Model;

namespace WebApplication1.BLL.AccountService
{
    public class AccountService : IAccountService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;

        }
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _unitOfWork.accountRepository.GetAccounts();
        }

        public async Task CreateAccountAsync(AccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);

            var contact = _mapper.Map<Contact>(accountDto);

            contact.AccountId = await _unitOfWork.accountRepository.Add(account);

             await _unitOfWork.contactRepository.Add(contact);

        }
    }
}
