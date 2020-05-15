using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RazorAppForArduino
{
    public class Program
    {
        /// <summary>
        /// The SerialPort which communicates with the Arduino. 
        /// It is made public so that otehr pages can write to it
        /// </summary>
        public static SerialPort portFromProgram;


        /// <summary>
        /// The SerialPort is opened as soon as the application starts and remains open until it is closed.
        /// Rather than opening an closing the port before and after writing/reading respectively,
        /// we decided to keep it open. 
        /// This is because port.close() of the SerialPort class has known bugs which dont close the port
        /// for a while after the method is called so opening it back up throws an exception. 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            portFromProgram = new SerialPort
            {
                BaudRate = 9600,
                PortName = "COM5"
            };
            portFromProgram.Open();
            System.Threading.Thread.Sleep(1000);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
