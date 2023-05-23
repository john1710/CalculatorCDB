using API.Models;

namespace API.Interfaces.Services
{
    public interface ICalculatorCDBService
    {
        Task<CalculatedCDB> CalculateCDB(CalculateCDBQuery query);
    }
}
