using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.SignalR;
using SerailPortRazor.Hubs;

namespace RazorAppForArduino.Pages
{
    public class GetSerialReadingsModel : PageModel
    {
        /// <summary>
        /// HubContext to get reference of the MyHub class in the Hubs folder which passes
        /// the message along to the Javascript handler and updates the values on the page
        /// </summary>
        private readonly IHubContext<MyHub> HubContext;

        /// <summary>
        /// Action to be invoked when the Update method is called. This is mapped to the ReceiveMessage
        /// handler in chat.js and MyHub.cs
        /// </summary>
        public static Action<byte> UpdateAction { get; set; }

        /// <summary>
        /// Constructor for model class
        /// </summary>
        /// <param name="hubContext">contains async method to Send the msg to all clients connected to server</param>
        public GetSerialReadingsModel(IHubContext<MyHub> hubContext)
        {
            HubContext = hubContext;

            UpdateAction = ReceiveMessage;

        }

        /// <summary>
        /// Calls the Invoke method and passes the new msg received from the Arduino
        /// </summary>
        /// <param name="msg"> msg received from getMyData method</param>
        public static void Update(byte msg)
        {
            UpdateAction.Invoke(msg);
        }

        /// <summary>
        /// Calls the MyHub class's SendAsync method to update the value on the page with message1
        /// </summary>
        /// <param name="message1">new value of message</param>
        public async void ReceiveMessage(byte message1)
        {
            await HubContext.Clients.All.SendAsync("ReceiveMessage", message1);
        }

        /// <summary>
        /// Method to read data from the Arduino. Uses Beginread to stream continuous Psi values.
        /// Uses the kickoffRead delegate as the async callback for the SerialPort class's BeginRead method.
        /// Reads in an array of bytes at a time,  then notifies the Javascript handler for each byte
        /// </summary>
        public void getMyData()
        {
            byte[] buffer = new byte[4096];
            Action kickoffRead = null;
            kickoffRead = delegate
            {
                Program.portFromProgram.BaseStream.BeginRead(buffer, 0, 4096, delegate (IAsyncResult ar)
                {
                    try
                    {
                        int actualLength = Program.portFromProgram.BaseStream.EndRead(ar);
                        byte[] received = new byte[actualLength];
                        Buffer.BlockCopy(buffer, 0, received, 0, actualLength);
                        
                        foreach (byte c in received)
                        {
                            byte[] temp = { c };
                            Update(c);
                        }
                    }
                    catch (IOException exc)
                    {
                        Console.WriteLine(exc);
                    }
                    kickoffRead();
                }, null); ;
            };
            kickoffRead();
        }

        /// <summary>
        /// OnGet is called whenever the 'Read Psi' page is rendered
        /// </summary>
        public void OnGet()
        {
            getMyData();
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