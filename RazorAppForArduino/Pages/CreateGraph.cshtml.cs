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
        private readonly InvoiceService _invoiceService;

        public List<InvoiceModel> InvoiceList;

        [BindProperty]
        public int Point { get; set; }

        [BindProperty]
        public int Point2 { get; set; }

        [BindProperty]
        public int Point3 { get; set; }

        [BindProperty]
        public int Point4 { get; set; }

        public bool showBoxes { get; set; }

        [BindProperty]
        public string V1 { get; set; } = "";
        [BindProperty]
        public string V2 { get; set; } = "";
        [BindProperty]
        public string V3 { get; set; } = "";
        [BindProperty]
        public string V4 { get; set; } = "";



        public CreateGraph(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public void OnGet()
        {
            InvoiceList = _invoiceService.GetInvoices();
        }        

        public void OnPostShowReading()
        {
            StringBuilder sb = new StringBuilder(Point+","+Point2+","+Point3+","+Point4);
            string sendMe = sb.ToString();
            Program.portFromProgram.WriteLine(sendMe.ToString());
        }

        public void OnPostAddValues()
        {
            showBoxes = true;
        }

        public void OnPostGotValues()
        {
            StringBuilder sb = new StringBuilder("G,"+V1+","+V2+","+V3+","+V4+ "e");
            string passToArduino = sb.ToString();
            Program.portFromProgram.WriteLine(passToArduino);            
        }

        public void OnPostScramble()
        {
            Program.portFromProgram.WriteLine("!e");
        }


    }
}