using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorAppForArduino.Model
{
    public interface IOptimalBoostRepository
    {
        OptimalBoost GetOptimalVoltage(double Psi);
        IEnumerable<OptimalBoost> GetAll();
        OptimalBoost Add(OptimalBoost opt);
        OptimalBoost Update(OptimalBoost opt);
        OptimalBoost Delete(double newPsi);
        OptimalBoost GetById(int id);

    }
}
