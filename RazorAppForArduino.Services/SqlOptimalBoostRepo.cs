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
            //IEnumerable<OptimalBoost> query = context.OptimalBoost;
            //query = query.Where(o => o.Psi == Psi);
            //return query.GroupBy(e=> e.Psi).Select()
            throw new NotImplementedException();
        }

        public OptimalBoost GetById(int id)
        {
            OptimalBoost o = context.OptimalBoost.Find(id);
            if (o != null)
            {
                return o;
            }
            return null;//idk
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
