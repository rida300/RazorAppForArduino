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

        public IndexModel()
        {
        }

        
        public void OnGet()
        {
            
        }

        /// <summary>
        /// The event handler for the scramble button.
        /// Writes "!e" to the SerialPort, the '!' lets the Arduino sketch to
        /// identify that the value is coming from the Scramble button.
        /// The 'e' lets the Arduino know that the end of the input value is reached
        /// </summary>
        public void OnPostScramble()
        {
            Program.portFromProgram.WriteLine("!e");
        }
    }
}
