namespace LiveClinic.Ordering.Core.Application.Dtos
{
    public class PrescriptionDto
    {
        public string DrugCode { get; set; }
        public double Days { get; set; }
        public double Quantity { get; set; }
    }
}
