using System.Collections.Generic;
using LiveClinic.Ordering.Core.Application.Dtos;
using LiveClinic.Ordering.Core.Domain;

namespace LiveClinic.Ordering.Core.Tests.TestArtifacts
{
    public class TestData
    {
        public static List<DrugOrder> CreateTestDrugOrders()
        {
            var dto = new DrugOrderDto() {Patient = "Test Patient", Provider = "Dr Wu Long"};
            dto.Drugs.Add(new PrescriptionDto(){DrugCode = "P",Quantity = 10,Days = 5});
            var dto2 = new DrugOrderDto() {Patient = "Test2 Patient2", Provider = "Dr Wu Long"};
            dto2.Drugs.Add(new PrescriptionDto(){DrugCode = "B",Quantity = 10,Days = 5});

            var testDrugOrders = new List<DrugOrder>()
            {
             DrugOrder.Generate(dto),DrugOrder.Generate(dto2)
            };
            return testDrugOrders;
        }

        public static DrugOrderDto CreateTestDrugOrderDto(string code="PN")
        {
            var dto = new DrugOrderDto() {Patient = "Test Patient", Provider = "Dr Wu Long"};
            dto.Drugs.Add(new PrescriptionDto(){DrugCode = code,Quantity = 10,Days = 5});
            return dto;
        }
    }
}
