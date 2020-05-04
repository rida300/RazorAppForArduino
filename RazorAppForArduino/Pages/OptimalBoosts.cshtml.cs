using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAppForArduino.Model;

namespace RazorAppForArduino.Pages
{
    public class OptimalBoostsModel : PageModel
    {

        private readonly IOptimalBoostRepository boostRepository;

        public IEnumerable<OptimalBoost> OptimalBoosts { get; set; }



        public OptimalBoostsModel(IOptimalBoostRepository boostRepository)
        {

            this.boostRepository = boostRepository;
        }


        public void OnGet()
        {
            //OptimalBoost oo = boostRepository.GetOptimalVoltage(22);
            //OptimalBoosts = new List<OptimalBoost> { oo };
            OptimalBoosts = boostRepository.GetAll();
        }
    }
}