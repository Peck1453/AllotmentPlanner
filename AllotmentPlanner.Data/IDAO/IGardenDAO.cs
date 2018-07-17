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
        IList<GardenViewModel> ViewGardensinLocation(string pcode);
        IList<GardenViewModel> ViewEmptyGardensinLocation(string pcode);
        Allotment GetLastGardenId();




        GardenLocation GetGardenLocation(string pcode);
        Allotment GetAllotment(int gardenId);
        GardenViewModel GetGardenViewModel(string pcode);
        AllotmentAllocation GetAllocatedAllotment(int gardenId);




        void addGardenLocation(GardenLocation gardenLocation, Allotment allotment);
        void addGardentoAllotment(Allotment allotment, AllotmentAllocation allotmentAllocation);

        void editGardenLocation(GardenLocation gardenLocation);
        void editGarden(Allotment allotment);
        
        void DeleteGarden(GardenLocation gardenLocation);


        void assignGardenerToGarden(AllotmentAllocation allotmentAllocation);
        void removeGardenerFromGarden(AllotmentAllocation allotmentAllocation);






        IList<UserGardenViewModel> GetUserGarden(string userId);
        IList<EditGardenViewModel> ListSelectedCrops(string userID);
        void addcropstogarden(Planted crop, Planted garden);


        EditGardenViewModel GetGardenFromUser(string userId);




    }
}
