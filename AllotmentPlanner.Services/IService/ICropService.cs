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
        CropHarvest GetCropHarvest(int id);
        CropRequirements GetCropRequirements(int id);


        void addCrop(Crop crop);
        void addCropHarvest(CropHarvest crop);
        void addCropRequirements(CropRequirements crop);


        void editCrop(CropDataViewModel cropDataViewModel);
        void editCropHarvest(CropDataViewModel cropDataViewModel);
        void editCropRequirements(CropDataViewModel cropDataViewModel);


        void DeleteCrop(Crop crop);
        void DeleteCropHarvest(CropHarvest cropHarvest);
        void DeleteCropRequirements(CropRequirements cropRequirements);


        CropDataViewModel GetCropViewModel(int id);

    }
}
