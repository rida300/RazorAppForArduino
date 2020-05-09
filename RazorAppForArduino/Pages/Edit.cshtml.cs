using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAppForArduino.Model;

namespace RazorAppForArduino.Pages
{
    public class EditModel : PageModel
    {
        private readonly IOptimalBoostRepository optimalBoostRepository;

       [BindProperty]
        public OptimalBoost OptimalBoost { get; set; }

        public EditModel(IOptimalBoostRepository optimalBoostRepository)
        {
            this.optimalBoostRepository = optimalBoostRepository;
        }
        public IActionResult OnGet(int id)
        {
           OptimalBoost= optimalBoostRepository.GetById(id);
            //if(OptimalBoost == null)
            //{
            //    return RedirectToPage("/NotFound");
            //}
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                OptimalBoost = optimalBoostRepository.Update(OptimalBoost);
                return Page();//redirect somewhere
            }
            
            return Page();
            
        }
    }
}