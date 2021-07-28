using System;
using System.Collections.Generic;

namespace LiveClinic.Billing.Core.Application.Dtos
{
    public class InvoiceDto
    {
        public string Patient { get; set; }
        public Guid OrderId { get; set; }
        public string OrderNo { get; set; }
        public List<InvoiceItemDto> Items { get; set; }=new List<InvoiceItemDto>();
    }
}
