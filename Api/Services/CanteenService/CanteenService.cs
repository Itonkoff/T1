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
            var canteenPriceList = await _unitOfWork.CanteenPriceListRepository.GetByIdAsync(bill.Amount);

            var canteenBalances =
                CanteenBalances(studentByRefAsync);
            var calculatedBalance = await CalculateBalance(canteenBalances);
            if (calculatedBalance - Double.Parse(canteenPriceList.Price) >= 0)
            {
                var canteenBalance = new CanteenBalance();
                canteenBalance.Student = studentByRefAsync.Id;
                canteenBalance.Date = DateTime.Now;
                canteenBalance.Dr = Double.Parse(canteenPriceList.Price);
                await _unitOfWork.CanteenBalanceRepository.AddAsync(canteenBalance);
                await _unitOfWork.CommitAsync();
                return bill;
            }

            return null;
        }

        public IEnumerable<CanteenBalance> CanteenBalances(Student studentByRefAsync)
        {
            return _unitOfWork.CanteenBalanceRepository.Find(c => c.Student == studentByRefAsync.Id);
        }

        public async Task<double> CalculateBalance(IEnumerable<CanteenBalance> canteenBalances)
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

            return credit - debit;
        }

        public async Task<CanteenBalance> TopUpStudentAsync(CanteenBalance canteenBalance)
        {
            await _unitOfWork.CanteenBalanceRepository.AddAsync(canteenBalance);
            var commitAsync = await _unitOfWork.CommitAsync();
            if (commitAsync > 0)
                return canteenBalance;
            return null;
        }
    }
}