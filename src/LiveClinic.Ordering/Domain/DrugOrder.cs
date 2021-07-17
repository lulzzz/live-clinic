using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using LiveClinic.Ordering.Application.Dtos;
using LiveClinic.SharedKernel;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Ordering.Domain
{
    public class DrugOrder : AggregateRoot<Guid>
    {
        public DateTime OrderDate { get; }
        public string OrderNo { get; }
        public string Patient { get; }
        public string Provider { get; }
        public OrderStatus Status { get; private set; }
        public List<Prescription> Prescriptions { get; } = new List<Prescription>();

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
    }
}
