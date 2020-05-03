using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IO.Ports;
using System.Web;

namespace RazorAppForArduino.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string Message { get; set; }

        private SerialPort myport;

        public IndexModel(ILogger<IndexModel> logger)
        {
           
            _logger = logger;
        }

        public void OnGet()
        {
            Message = "Rida's Razor Page!";
        }

        public void OnPostLedOn()
        {
            myport = new SerialPort
            {
                BaudRate = 9600,
                PortName = "COM11"
            };
            myport.Open();

            myport.Write("1");
            myport.Close();
            
        }

        public void OnPostLedOff()
        {
            myport = new SerialPort
            {
                BaudRate = 9600,
                PortName = "COM11"
            };
            myport.Open();

            myport.Write("2");
            myport.Close();
        }

    }
}
