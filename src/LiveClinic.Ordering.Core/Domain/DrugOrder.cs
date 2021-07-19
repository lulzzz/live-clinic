using System;
using System.Collections.Generic;
using System.Linq;
using LiveClinic.Ordering.Core.Application.Dtos;
using LiveClinic.SharedKernel;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Ordering.Core.Domain
{
    public class DrugOrder : AggregateRoot<Guid>
    {
        public DateTime OrderDate { get; private set; }
        public string OrderNo { get; private set;}
        public string Patient { get;private set; }
        public string Provider { get;private set; }
        public OrderStatus Status { get; private set; }
        public List<Prescription> Prescriptions { get; private set;} = new List<Prescription>();

        private DrugOrder()
        {
        }

        private DrugOrder(string patient, string provider)
        {
            Patient = patient;
            Provider = provider;
            OrderDate = DateTime.Now;
            OrderNo = Utils.GenerateNo("P");
            Status = OrderStatus.Pending;
        }

        public static DrugOrder Generate(DrugOrderDto orderDto)
        {
            var order =new DrugOrder(orderDto.Patient,orderDto.Provider);
            order.AddDrugsToOrder(orderDto.Drugs);

            if (!order.Prescriptions.Any())
                throw new Exception($"Invalid order ! No drugs prescribed");

            return order;
        }

        public void FulfillOrder()
        {
            Status = OrderStatus.Completed;
        }

        private void AddDrug(string drug, double days, double quantity)
        {
            if (Prescriptions.Any(x => x.DrugCode == drug))
                throw new Exception($"Drug {drug} already Exists");

            Prescriptions.Add(new Prescription(drug, days, quantity, Id));
        }

        private void AddDrugsToOrder(List<PrescriptionDto> prescriptionDtos)
        {
            foreach (var prescriptionDto in prescriptionDtos)
                AddDrug(prescriptionDto.DrugCode,prescriptionDto.Days,prescriptionDto.Quantity);
        }

        public override string ToString()
        {
            return $"{OrderNo}|{Patient}|{Provider}";
        }
    }
}
