using System.Collections.Generic;
using LiveClinic.Inventory.Core.Domain;

namespace LiveClinic.Inventory.Infrastructure.Seed
{
    public static class DrugSeed
    {
        public static List<Drug> GetDrugs()
        {
            return new List<Drug>()
            {
                new Drug("PN","Panadol 500mg"),
                new Drug("BF","Brufen 500mg")
            };
        }
    }
}
