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



        GardenLocation GetGardenLocation(string pcode);
        Allotment GetAllotment(int gardenId);
        GardenViewModel GetGardenViewModel(string pcode);
        void addGardenLocation(GardenLocation gardenLocation);
        void addGardentoAllotment(Allotment allotment);

        void editGardenLocation(GardenLocation gardenLocation);

        void editGarden(Allotment allotment);
        
        void DeleteGarden(GardenLocation gardenLocation);

        void addGardenerToGarden(AllotmentAllocation allotmentAllocation);
        void removeGardenerFromGarden(AllotmentAllocation allotmentAllocation);





        EditGardenViewModel ViewSelectedCrops(string userID);
        IList<EditGardenViewModel> ListSelectedCrops(string userID);
        void addcropstogarden(string userId, Planted crop, Planted garden);


        EditGardenViewModel GetUserGarden(int id);


        EditGardenViewModel GetGardenFromUser(string userId);




    }
}
