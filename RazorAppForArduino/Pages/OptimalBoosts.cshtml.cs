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
        /// <summary>
        /// OptimalBoost respository contains methods such as create, update, etc
        /// </summary>
        private readonly IOptimalBoostRepository boostRepository;

        /// <summary>
        /// List of all entries
        /// </summary>
        public IEnumerable<OptimalBoost> OptimalBoosts { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="boostRepository"></param>
        public OptimalBoostsModel(IOptimalBoostRepository boostRepository)
        {

            this.boostRepository = boostRepository;
        }

        /// <summary>
        /// shows all entries when page is rendered
        /// </summary>
        public void OnGet()
        {           
            OptimalBoosts = boostRepository.GetAll();
        }
    }
}