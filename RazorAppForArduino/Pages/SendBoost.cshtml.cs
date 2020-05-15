using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace RazorAppForArduino.Pages
{
    public class SendBoostModel : PageModel
    {
        /// <summary>
        /// The Boost value entered in the textbox on the page is bound to this property
        /// </summary>
        [BindProperty]
        public string Boost { get; set; }
        
        public void OnGet()
        {
            
        }

        /// <summary>
        /// Event handler for the Send button.
        /// Sends 'S,' so the Arduino sketch can identify that the value is coming from the Send Boost page
        /// 'e' is added at the end so the sketch can know when to stop reading
        /// </summary>
        public void OnPostSendBoost()
        {
            StringBuilder sb = new StringBuilder("S," + Boost+"e");
            string sending = sb.ToString();
            Program.portFromProgram.WriteLine(sending);
            
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