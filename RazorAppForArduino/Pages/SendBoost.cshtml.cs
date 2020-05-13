using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IO.Ports;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace RazorAppForArduino.Pages
{
    public class SendBoostModel : PageModel
    {
        [BindProperty]
        public int Boost { get; set; }
        
        public void OnGet()
        {
            
        }
        public void OnPostSendBoost()
        {
            //Program.portFromProgram.Write("set:"+Boost);
            //byte[] intBytes = BitConverter.GetBytes(Boost);
            //Array.Reverse(intBytes);
            //byte[] result = intBytes;
            Program.portFromProgram.WriteLine(Boost.ToString());
            
        }
    }
}