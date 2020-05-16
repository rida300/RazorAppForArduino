
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorAppForArduino.Model
{
    public interface IOptimalBoostRepository
    {
        /// <summary>
        /// Gets the OptiamlBoost object for Psi 
        /// </summary>
        /// <param name="Psi"></param>
        /// <returns></returns>
        OptimalBoost GetOptimalVoltage(double Psi);

        /// <summary>
        /// gets all entries from db
        /// </summary>
        /// <returns></returns>
        IEnumerable<OptimalBoost> GetAll();

        /// <summary>
        /// Adds an entry to db
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        OptimalBoost Add(OptimalBoost opt);

        /// <summary>
        /// replaces object with new object constructed with uodated values
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        OptimalBoost Update(OptimalBoost opt);

        /// <summary>
        /// Deletes object
        /// </summary>
        /// <param name="newPsi"></param>
        /// <returns></returns>
        OptimalBoost Delete(double newPsi);

        /// <summary>
        /// gets entry using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OptimalBoost GetById(int id);

    }
}
