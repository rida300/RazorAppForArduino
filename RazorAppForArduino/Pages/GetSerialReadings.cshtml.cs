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
        private readonly IHubContext<MyHub> HubContext;

        public string SerialData;

        public static Action<byte> UpdateAction { get; set; }

        public GetSerialReadingsModel(IHubContext<MyHub> hubContext)
        {
            HubContext = hubContext;

            UpdateAction = ReceiveMessage;

        }

        public static void Update(byte msg)
        {
            UpdateAction.Invoke(msg);
        }
        public async void ReceiveMessage(byte message1)
        {
            await HubContext.Clients.All.SendAsync("ReceiveMessage", message1);
        }

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
                        SerialData = "Error";
                    }
                    kickoffRead();
                }, null); ;
            };
            kickoffRead();
        }

        public void OnGet()
        {
            getMyData();
        }
        public void OnPostScramble()
        {
            Program.portFromProgram.WriteLine("!e");
        }

    }
}