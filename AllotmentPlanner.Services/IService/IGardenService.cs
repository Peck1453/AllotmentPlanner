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
        IList<AllotmentPlanner.Data.GardenLocation> GetGardenLocations();
        IList<GardenViewModel> ViewGardensinLocation(string pcode);
        IList<GardenViewModel> ViewEmptyGardensinLocation(string pcode);
        AllotmentAllocation GetAllocatedAllotment(int gardenId);
        Allotment GetLastGardenId();




        GardenLocation GetGardenLocation(string pcode);
        Allotment GetAllotment(int gardenId);
        GardenViewModel GetGardenViewModel(string pcode);
        void addGardenLocation(GardenLocation gardenLocation, Allotment allotment);
        void addGardentoAllotment(Allotment allotment, AllotmentAllocation allotmentAllocation);
        void editGarden(Allotment allotment);
        void DeleteGarden(GardenLocation gardenLocation);
        void assignGardenerToGarden(AllotmentAllocation allotmentAllocation);
        void removeGardenerFromGarden(AllotmentAllocation allotmentAllocation);

        EditGardenViewModel ViewSelectedCrops(string userID);
        IList<EditGardenViewModel> ListSelectedCrops(string userID);
        void addcropstogarden(string userId, Planted crop, Planted garden);

        EditGardenViewModel GetUserGarden(int id);

        EditGardenViewModel GetGardenFromUser(string userId);

    }
}
