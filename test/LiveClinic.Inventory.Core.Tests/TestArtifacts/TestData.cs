using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using LiveClinic.Inventory.Core.Domain;

namespace LiveClinic.Inventory.Persistence.Tests.TestArtifacts
{
    public class TestData
    {
        public static List<Drug> CreateTestDrugs(string code="T")
        {
            var testDrugs = new List<Drug>()
            {
                new Drug($"{code}1",$"Test1{code}"),
                new Drug($"{code}T2",$"Test2{code}")
            };

            foreach (var drug in testDrugs)
            {
                drug.ReceiveStock($"{drug.Code}B1", 10);
                drug.ReceiveStock($"{drug.Code}B2", 10);
                drug.Dispense($"{drug.Code}B2", 5);
            }

            return testDrugs;
        }

        public static Drug CreateTestDrugWithStock(string code="T",int initial=20)
        {
            var testDrug = new Drug($"{code}1", $"Test1{code}");
            testDrug.ReceiveStock($"LEO", initial);
            return testDrug;
        }
    }
}
