namespace LiveClinic.Ordering.Application.Dtos
{
    public class PrescriptionDto
    {
        public string DrugCode { get;  }
        public double Days { get;  }
        public double Quantity { get; }
    }
}