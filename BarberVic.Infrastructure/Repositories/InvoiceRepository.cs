using BarberVic.Application.Common.Interfaces;
using BarberVic.Domain.Entities;
using BarberVic.Infrastructure.Contexts.BarberVic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public static List<Invoice> invoices = new List<Invoice>()
        {

        };
        private readonly BarberVicDbContext _invoiceDbContext;

        public InvoiceRepository(BarberVicDbContext invoiceDbContext)
        {
            _invoiceDbContext = invoiceDbContext;
        }

        public Invoice CreateInvoice(Invoice invoice)
        {
            _invoiceDbContext.Invoices.Add(invoice);
            _invoiceDbContext.SaveChanges();
            return invoice;
        }

        public Invoice DeleteInvoice(Invoice invoice)
        {
            _invoiceDbContext.Invoices.Remove(invoice);
            _invoiceDbContext.SaveChanges();

            return null;
        }

        public List<Invoice> GetAllInvoices()
        {
            return _invoiceDbContext.Invoices.ToList();
        }

    }
}
