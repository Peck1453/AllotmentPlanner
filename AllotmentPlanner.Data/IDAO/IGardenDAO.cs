using AllotmentPlanner.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllotmentPlanner.Data.IDAO
{
    public interface IGardenDAO
    {
        IList<AllotmentPlanner.Data.GardenLocation> GetGardenLocations();

        GardenLocation GetGardenLocation(string pcode);
        Allotment GetAllotment(string pcode);
        GardenViewModel GetGardenViewModel(string pcode);
        void addGarden(GardenLocation gardenLocation);
        void addGardenAllotment(Allotment allotment);
        void editGarden(GardenLocation gardenLocation, Allotment allotment);
        void DeleteGarden(GardenLocation gardenLocation);



    }
}
