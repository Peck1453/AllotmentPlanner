using AllotmentPlanner.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllotmentPlanner.Data.IDAO
{
    public interface ICropDAO
    {
        IList<AllotmentPlanner.Data.Crop> GetCrops();
    
        Crop GetCrop(int id);
        CropHarvest GetCropHarvest(int id);
        CropRequirements GetCropRequirements(int id);


        void editCrop(CropDataViewModel cropDataViewModel);
        void editCropHarvest(CropDataViewModel cropDataViewModel);
        void editCropRequirements(CropDataViewModel cropDataViewModel);


        CropDataViewModel GetCropViewModel(int id);

        void addCrop(Crop crop);
        void addCropHarvest(CropHarvest crop);
        void addCropRequirements(CropRequirements crop);


        void DeleteCrop(Crop crop);
        void DeleteCropHarvest(CropHarvest cropHarvest);
        void DeleteCropRequirements(CropRequirements cropRequirements);

    }
}
