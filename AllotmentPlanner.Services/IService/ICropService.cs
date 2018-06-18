using AllotmentPlanner.Data;
using AllotmentPlanner.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllotmentPlanner.Services.IService
{
    public interface ICropService
    {
        IList<AllotmentPlanner.Data.Crop> GetCrops();

        Crop GetCrop(int id);
        void addCrop(Crop crop);
        void addCropHarvest(CropHarvest crop);
        void addCropRequirements(CropRequirements crop);

        void editCrop(Crop crop);

        CropDataViewModel GetCropViewModel(int id);

    }
}
