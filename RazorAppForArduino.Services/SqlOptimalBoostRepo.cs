using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorAppForArduino.Model
{
    public class SqlOptimalBoostRepo : IOptimalBoostRepository
    {
        /// <summary>
        /// context from startup
        /// </summary>
        private readonly AppDBContext context;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public SqlOptimalBoostRepo(AppDBContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// adds new object entry
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        public OptimalBoost Add(OptimalBoost opt)
        {
            context.OptimalBoost.Add(opt);
            context.SaveChanges();
            return opt;
        }

        /// <summary>
        /// Delets object 
        /// </summary>
        /// <param name="newPsi"></param>
        /// <returns></returns>
        public OptimalBoost Delete(double newPsi)
        {
            OptimalBoost o = context.OptimalBoost.Find(newPsi);
            if (o != null)
            {
                context.OptimalBoost.Remove(o);
                context.SaveChanges();
            }
            return o;
        }

        /// <summary>
        /// gets object by Psi value
        /// </summary>
        /// <param name="Psi"></param>
        /// <returns></returns>
        public OptimalBoost GetOptimalVoltage(double Psi)
        {
            //IEnumerable<OptimalBoost> query = context.OptimalBoost;
            //query = query.Where(o => o.Psi == Psi);
            //return query.GroupBy(e=> e.Psi).Select()
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets object by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OptimalBoost GetById(int id)
        {
            OptimalBoost o = context.OptimalBoost.Find(id);
            if (o != null)
            {
                return o;
            }
            return null;//idk
        }

        /// <summary>
        /// Gets all objects from db
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OptimalBoost> GetAll()
        {
            IEnumerable<OptimalBoost> som = context.OptimalBoost;
            return som;
        }

        /// <summary>
        /// replaces object
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        public OptimalBoost Update(OptimalBoost opt)
        {
            var boostie = context.OptimalBoost.Attach(opt);
            boostie.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return opt;
        }
    }
}
