using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Models;

namespace Api.Services.CanteenService {
    public interface ICanteenService {
        Task<IEnumerable<CanteenPriceList>> GetAllPricesAsync();
        Task<CanteenPriceList> CreatePriceListItemAsync(CanteenPriceList item);
        Task<CanteenPriceList> UpdatePriceAsync(CanteenPriceList toUpdate);
        Task<BillStudentResourceDto> BillStudent(BillStudentResourceDto bill);
    }
}