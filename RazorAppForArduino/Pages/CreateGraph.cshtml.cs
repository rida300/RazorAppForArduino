using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAppForArduino;
using static RazorAppForArduino.InvoiceModel;

namespace RazorAppForArduino.Pages
{
    public class CreateGraph : PageModel
    { 

        /// <summary>
        /// The y-axis value of the first coordinate (x,y) set
        /// </summary>
        [BindProperty]
        public int Point { get; set; }

        /// <summary>
        /// The y-axis value of the second coordinate (x,y) set
        /// </summary>
        [BindProperty]
        public int Point2 { get; set; }

        /// <summary>
        /// The y-axis value of the third coordinate (x,y) set
        /// </summary>
        [BindProperty]
        public int Point3 { get; set; }

        /// <summary>
        /// The y-axis value of the fourth coordinate (x,y) set
        /// </summary>
        [BindProperty]
        public int Point4 { get; set; }

        public void OnGet()
        {
           
        }        

        /// <summary>
        /// Event handler for the 'Send values from graph' button
        /// Appends the y vaues of all 4 datapoints.
        /// Prefixes the string with "G," so the ARduino can identify that the value is from the Graph.
        /// Ends with ",e" so the end of this value can be recognized by the Arduino.
        /// </summary>
        public void OnPostShowReading()
        {
            StringBuilder sb = new StringBuilder("G,"+Point+","+Point2+","+Point3+","+Point4+",e");
            string sendMe = sb.ToString();
            Program.portFromProgram.WriteLine(sendMe.ToString());
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