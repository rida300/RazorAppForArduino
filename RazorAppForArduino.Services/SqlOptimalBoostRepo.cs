using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorAppForArduino.Model
{
    public class SqlOptimalBoostRepo : IOptimalBoostRepository
    {
        private readonly AppDBContext context;
        public SqlOptimalBoostRepo(AppDBContext context)
        {
            this.context = context;
        }
        public OptimalBoost Add(OptimalBoost opt)
        {
            context.OptimalBoost.Add(opt);
            context.SaveChanges();
            return opt;
        }

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

        public OptimalBoost GetOptimalVoltage(double Psi)
        {
            //OptimalBoost q = context.OptimalBoosts.Where(e => e.Psi == Psi);
            //OptimalBoost res = q as Object as OptimalBoost;
            //return res;
            throw new NotImplementedException();
        }

        public IEnumerable<OptimalBoost> GetAll()
        {
            IEnumerable<OptimalBoost> som = context.OptimalBoost;
            return som;
        }



        public OptimalBoost Update(OptimalBoost opt)
        {
            var boostie = context.OptimalBoost.Attach(opt);
            boostie.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return opt;
        }
    }
}
