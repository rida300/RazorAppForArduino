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
    public class BoostModel : PageModel
    {
        [BindProperty]
        public float Boost { get; set; }
        SerialPort port = new SerialPort
        {
            BaudRate = 9600,
            PortName = "COM11" 
            
        };
        public void OnGet()
        {
            port.Close();
            //port.Open();

        }
        public void OnPostSendBoost()
        {
            port.Write("set:"+Boost);
        }
    }
}