using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public interface ICalculatorAsync
    {
        Task<int> AddAsync(int start, int amount);
        Task<int> SubtractAsync(int start, int amount);
        Task<int> MultiplyAsync(int start, int by);
        Task<int> DivideAsync(int start, int by);
    }
}
