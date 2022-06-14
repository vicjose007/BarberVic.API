﻿using BarberVic.Application.Dtos;
using BarberVic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Application.Common.Interfaces
{
    public interface IInvoiceService : IEntityCRUDService<Invoice, InvoiceDto>
    {
        List<Invoice> GetAllInvoices();

        Invoice CreateInvoice(Invoice invoice);

        Invoice DeleteInvoice(Invoice invoice);


    }
}
