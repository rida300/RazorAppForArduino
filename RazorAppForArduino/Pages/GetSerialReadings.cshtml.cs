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

        public static Action<String> UpdateAction { get; set; }

        public GetSerialReadingsModel(IHubContext<MyHub> hubContext)
        {
            HubContext = hubContext;

            UpdateAction = ReceiveMessage;

        }

        public static void Update(string msg)
        {
            UpdateAction.Invoke(msg);
        }
        public async void ReceiveMessage(string message1)
        {
            string whole = SerialData;
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

                        string justReceived = System.Text.Encoding.Default.GetString(received);
                       // string justReceived = Program.portFromProgram.ReadLine();
                        string[] words = justReceived.Split("\r\n");

                        foreach (var word in words)
                        {
                            if (word != "\r\n" && word!="")
                            {
                                 SerialData += word;
                                 Console.WriteLine(word);
                                 Update(word);                                    
                            }                            
                        }
                        //SerialData += justReceived;
                        //Update(SerialData);
                    }
                    catch (IOException exc)
                    {
                        SerialData = "Fucked";
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
    }
}