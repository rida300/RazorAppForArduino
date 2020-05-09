using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IO.Ports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.SignalR;
using System.IO;
using SerailPortRazor.Hubs;

namespace RazorAppForArduino.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public SerialPort potty { get; set; }

        public IndexModel()
        {
            //potty = new SerialPort
            //{
            //    BaudRate = 9600,
            //    PortName = "COM11"
            //};
            //potty.Open();
            //ViewData["Port"] = potty;
        }

        
        public void OnGet()
        {
            
        }   


        //public void OnPostLedOn()
        //{
        //    myport = new SerialPort
        //    {
        //        BaudRate = 9600,
        //        PortName = "COM11"
        //    };
        //    myport.Open();

        //    myport.Write("1");
        //    myport.Close();

        //}

        //public void OnPostLedOff()
        //{
        //    myport = new SerialPort
        //    {
        //        BaudRate = 9600,
        //        PortName = "COM11"
        //    };
        //    myport.Open();

        //    myport.Write("2");
        //    myport.Close();
        //}

    }
}
