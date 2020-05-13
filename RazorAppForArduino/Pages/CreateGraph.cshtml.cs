using System;
using System.Collections.Generic;
using System.Linq;
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

        [ViewData]
        [BindProperty]
        public string Element { get; set; }

        [ViewData]
        [BindProperty]
        public string Title { get; set; }

        public CreateGraph(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public void OnGet()
        {
            InvoiceList = _invoiceService.GetInvoices();
        }

        public JsonResult OnGetInvoiceChartData()
        {
           
            InvoiceList = _invoiceService.GetInvoices();
            var invoiceChart = new CategoryChartModel();
            invoiceChart.AmountList = new List<double>();
            invoiceChart.CategoryList = new List<string>();

            foreach (var inv in InvoiceList)
            {
                invoiceChart.AmountList.Add(inv.Amount);
                invoiceChart.CategoryList.Add(inv.CostCategory);
            }

            return new JsonResult(invoiceChart);
        }

        public void OnPostShowReading()
        {
         
            var so = Element;
        }

        public void OnPost(Object o)
        {
            var some = o;
        }

        public void OnPostProcessData(Object person)
        {
            var p = person;
        }

    }
}