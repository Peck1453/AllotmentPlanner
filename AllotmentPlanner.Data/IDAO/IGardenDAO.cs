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

        Crop GetGardenLocation(int id);
        void editCrop(GardenLocation gardenLocation);

        void addCrop(GardenLocation gardenLocation);
        void DeleteCrop(GardenLocation gardenLocation);

    }
}
