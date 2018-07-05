using AllotmentPlanner.Data;
using AllotmentPlanner.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllotmentPlanner.Services.IService
{
    public interface IGardenService
    {

        GardenLocation GetGardenLocation(string pcode);
        Allotment GetAllotment(string pcode);
        GardenViewModel GetGardenViewModel(string pcode);
        void addGarden(GardenLocation gardenLocation);
        void addGardenAllotment(Allotment allotment);
        void editGarden(GardenLocation gardenLocation, Allotment allotment);
        void DeleteGarden(GardenLocation gardenLocation);


        IList<EditGardenViewModel> ViewSelectedCrops(int id);
        EditGardenViewModel GetUserGarden(int id);

    }
}
