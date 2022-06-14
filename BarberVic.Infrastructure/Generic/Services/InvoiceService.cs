using AutoMapper;
using BarberVic.Application.Common.Interfaces;
using BarberVic.Application.Dtos;
using BarberVic.Domain.Entities;
using BarberVic.Infrastructure.Contexts.BarberVic;
using BarberVic.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Infrastructure.Generic.Services
{

    public class InvoiceService : EntityCRUDService<Invoice, InvoiceDto>, IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceService(IMapper mapper, IUnitOfWork<IBarberVicDbContext> uow, IInvoiceRepository invoiceRepository)
            : base(mapper, uow)
        {
            _invoiceRepository = invoiceRepository;
        }
        public Invoice CreateInvoice(Invoice invoice)
        {
            _invoiceRepository.CreateInvoice(invoice);
            return invoice;
        }

        public Invoice DeleteInvoice(Invoice invoice)
        {
            _invoiceRepository.DeleteInvoice(invoice);
            return invoice;
        }
        public List<Invoice> GetAllInvoices()
        {
            var invoices = _invoiceRepository.GetAllInvoices();

            return invoices;
        }
    }
}
