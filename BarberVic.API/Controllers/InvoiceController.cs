using BarberVic.Application.Common.Interfaces;
using BarberVic.Application.Dtos;
using BarberVic.Domain.Entities;
using BarberVic.Infrastructure.Contexts.BarberVic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BarberVic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        public static Invoice invoice = new Invoice();
        private readonly IConfiguration _configuration;
        private readonly IInvoiceService _service;
        private readonly IHttpContextAccessor _accesor;
        private readonly BarberVicDbContext Context;



        public InvoiceController(IConfiguration configuration, IInvoiceService service, IHttpContextAccessor accessor, BarberVicDbContext dataContext)
        {
            Context = dataContext;
            _configuration = configuration;
            _service = service;
            _accesor = accessor;

        }
        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Invoice>>> Get()
        {
            return Ok(await Context.Invoices.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> Get(int id)
        {
            var invoice = await Context.Invoices.FindAsync(id);
            if (invoice == null)
                return BadRequest("Invoice not found");
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<ActionResult<List<Invoice>>> AddInvoices(InvoiceDto request)
        {
            var appointment = await Context.Appointments.FindAsync(request.AppointmentId);
            if (appointment == null)
                return BadRequest("Appointment not found.");

            var newInvoice = new Invoice
            {
                Appointment = appointment,
                InvoiceDate = request.InvoiceDate,
                Total = request.Total,
                Details = request.Details


            };

            PostInvoice(newInvoice);

            return Ok(newInvoice);
        }

        private Invoice PostInvoice(Invoice invoice)
        {

            var invoiceFromService = _service.CreateInvoice(invoice);
            return invoiceFromService;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Invoice>>> UpdateInvoices(int id,InvoiceDto request)
        {
            var invoice = await Context.Invoices.FindAsync(id);
            if (invoice == null)
                return BadRequest("Invoice not found.");

            invoice.InvoiceDate = request.InvoiceDate;
            invoice.Total = request.Total;
            invoice.Details = request.Details;



            await Context.SaveChangesAsync();

            return Ok(await Context.Invoices.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Invoice>>> Delete(int id)
        {
            var invoice = await Context.Invoices.FindAsync(id);
            if (invoice == null)
                return BadRequest("Invoice not found");

            Context.Invoices.Remove(invoice);
            await Context.SaveChangesAsync();
            return Ok(await Context.Invoices.ToListAsync());
        }
    }
}
