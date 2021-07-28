using System.Collections.Generic;

namespace LiveClinic.Ordering.Core.Application.Dtos
{
    public class DrugOrderDto
    {
        public string Patient { get; set; }
        public string Provider { get; set; }
        public List<PrescriptionDto> Drugs { get; set; }=new List<PrescriptionDto>();
    }
}
