using Recibos.Core.Entities;
using Recibos.Core.Exceptions;
using Recibos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recibos.Core.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReceiptService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IEnumerable<Receipt> GetReceipt()
        {
            var result = _unitOfWork.ReceiptRepository.GetAll();
            return result;
        }

        public async Task<Receipt> GetReceipt(int id)
        {
            var result = await _unitOfWork.ReceiptRepository.GetById(id);
            return result;
        }

        public async Task AddReceipt(Receipt receipt)
        {
            var user = _unitOfWork.UserRepository.GetById(receipt.UserId);
            ValidationRules(receipt, user.Result);
            await _unitOfWork.ReceiptRepository.Add(receipt);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateReceipt(Receipt receipt)
        {
            var user = _unitOfWork.UserRepository.GetById(receipt.UserId);
            ValidationRules(receipt, user.Result);
            _unitOfWork.ReceiptRepository.Update(receipt);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteReceipt(int id)
        {
            await _unitOfWork.ReceiptRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        void ValidationRules(Receipt receipt, User user)
        {
            if (user == null)
            {
                throw new Exception("The user does not exist");
            }

            if (receipt.Amount <= 0)
            {
                throw new BusinessException("Amount must be greater $0");
            }

            if (receipt.Comments.Length > 200)
            {
                throw new BusinessException("Comments exceed 200 chars");
            }

            if (receipt.CurrencyId <= 0)
            {
                throw new BusinessException("Select a currency");
            }

            if (receipt.SupplierId <= 0)
            {
                throw new BusinessException("Select a supplier");
            }

            if (receipt.Date == null)
            {
                throw new BusinessException("Select a date");
            }
        }
    }
}
