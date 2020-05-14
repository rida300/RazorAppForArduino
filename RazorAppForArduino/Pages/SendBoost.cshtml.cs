using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IO.Ports;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace RazorAppForArduino.Pages
{
    public class SendBoostModel : PageModel
    {
        [BindProperty]
        public string Boost { get; set; }
        
        public void OnGet()
        {
            
        }
        public void OnPostSendBoost()
        {
            //Program.portFromProgram.Write("set:"+Boost);
            //byte[] intBytes = BitConverter.GetBytes(Boost);
            //Array.Reverse(intBytes);
            //byte[] result = intBytes;
            StringBuilder sb = new StringBuilder("S," + Boost+"e");
            string sending = sb.ToString();
            Program.portFromProgram.WriteLine(sending);
            
        }
        public void OnPostScramble()
        {
            Program.portFromProgram.WriteLine("!e");
        }

    }
}