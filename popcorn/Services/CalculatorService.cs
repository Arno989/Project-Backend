using System;
using System.Threading.Tasks;

namespace popcorn.Services
{
    public interface ICalculatorService
    {
        int add(int n1, int n2);
    }

    public class CalculatorService : ICalculatorService
    {
        public int add(int n1, int n2)
        {
            return n1 + n2;
        }
    }
}
