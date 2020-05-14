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
            //Program.portFromProgram.WriteLine(Boost.ToString());
            var so = Point;
        }

        public void OnPostAddValues()
        {
            showBoxes = true;
            Console.WriteLine();
        }

        public void OnPostGotValues()
        {
            var vss = V1;
            StringBuilder sb = new StringBuilder(V1+","+V2+","+V3+","+V4);
            string passToArduino = sb.ToString();      
                
            Console.WriteLine();
        }


    }
}