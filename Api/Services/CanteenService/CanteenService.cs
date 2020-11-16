using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Models;
using Api.Repositories.Base;
using AutoMapper;

namespace Api.Services.CanteenService {
    public class CanteenService : ICanteenService {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CanteenService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CanteenPriceList>> GetAllPricesAsync()
        {
            return await _unitOfWork.CanteenPriceListRepository.GetAllAsync();
        }

        public async Task<CanteenPriceList> CreatePriceListItemAsync(CanteenPriceList item)
        {
            await _unitOfWork.CanteenPriceListRepository.AddAsync(item);
            await _unitOfWork.CommitAsync();
            return item;
        }

        public async Task<CanteenPriceList> UpdatePriceAsync(CanteenPriceList toUpdate)
        {
            var byIdAsync = await _unitOfWork.CanteenPriceListRepository.GetByIdAsync(toUpdate.Id);
            byIdAsync.Price = toUpdate.Price;
            await _unitOfWork.CommitAsync();
            return byIdAsync;
        }

        public async Task<BillStudentResourceDto> BillStudent(BillStudentResourceDto bill)
        {   
            var studentByRefAsync = await _unitOfWork.Students.GetStudentByRefAsync(bill.StudentRef);
            
            var canteenBalances =
                _unitOfWork.CanteenBalanceRepository.Find(c => c.Student == studentByRefAsync.Id);
            var calculatedBalance = await CalculateBalance(canteenBalances);
            if (calculatedBalance - bill.Amount >= 0)
            {                
                var canteenBalance = _mapper.Map<BillStudentResourceDto, CanteenBalance>(bill);
                canteenBalance.Student = studentByRefAsync.Id;
                canteenBalance.Date = DateTime.Now;
                await _unitOfWork.CanteenBalanceRepository.AddAsync(canteenBalance);
                await _unitOfWork.CommitAsync();
                return bill;
            }            

            return null;
        }

        private async Task<double> CalculateBalance(IEnumerable<CanteenBalance> canteenBalances)
        {
            double debit = 0;
            double credit = 0;

            var enumerable = canteenBalances.ToList();
            var orderedEnumerable = enumerable.OrderBy(c => c.Date);

            foreach (var canteenBalance in orderedEnumerable)
            {
                if (canteenBalance.Cr != null)
                    credit = credit + canteenBalance.Cr.Value;
                else if (canteenBalance.Dr != null)
                    debit = debit + canteenBalance.Dr.Value;
            }

            return debit - credit;
        }
    }
}