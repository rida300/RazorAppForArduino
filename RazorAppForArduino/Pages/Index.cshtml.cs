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

        private readonly IHubContext<MyHub> HubContext;

        public SerialPort potty;

        public string SerialData;

        public static Action<String> UpdateAction { get; set; }

        public string Message { get; set; }

        public IndexModel(IHubContext<MyHub> hubContext)
        {
            HubContext = hubContext;
            potty = new SerialPort
            {
                BaudRate = 9600,
                PortName = "COM11"
            };

            potty.Open();
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

        //public void OnGetRefresh()
        //{
        //    if (!myport.IsOpen)
        //    {
        //        myport.Open();
        //    }
        //    string existing = myport.ReadExisting();
        //    SerialData = myport.ReadLine();
        //}

        public void OnGet()
        {
            Message = "Rida's Razor Page!";
            getMyData();
        }

        public void getMyData()
        {
            byte[] buffer = new byte[4096];
            Action kickoffRead = null;
            kickoffRead = delegate
            {
                potty.BaseStream.BeginRead(buffer, 0, buffer.Length, delegate (IAsyncResult ar)
                {
                    try
                    {
                        int actualLength = potty.BaseStream.EndRead(ar);
                        byte[] received = new byte[actualLength];
                        Buffer.BlockCopy(buffer, 0, received, 0, actualLength);
                        SerialData += System.Text.Encoding.Default.GetString(received);
                        Update(SerialData);
                        //raiseAppSerialDataEvent(received);
                    }
                    catch (IOException exc)
                    {
                        SerialData = "Fucked";
                    }
                    kickoffRead();
                }, null);
            };
            kickoffRead();
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
