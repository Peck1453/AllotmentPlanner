﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllotmentPlanner.Data;
using AllotmentPlanner.Data.IDAO;
using AllotmentPlanner.Data.DAO;
using AllotmentPlanner.Data.ViewModel;

namespace AllotmentPlanner.Services.Service
{
    public class CropService : AllotmentPlanner.Services.IService.ICropService
    {
        private ICropDAO _cropDAO;

        public CropService()
        {
            _cropDAO = new CropDAO();
        }

        public IList<AllotmentPlanner.Data.Crop> GetCrops()
        {
            return _cropDAO.GetCrops();
        }

        public Crop GetCrop(int id)
        {
            return _cropDAO.GetCrop(id);

       
        }

        public CropHarvest GetCropHarvest(int id)
        {
            return _cropDAO.GetCropHarvest(id);

        }
        public CropRequirements GetCropRequirement(int id)
        {
            return _cropDAO.GetCropRequirement(id);

        }



        public void addCrop(Crop crop)
        {
            _cropDAO.addCrop(crop);
        }

        public void addCropHarvest(CropHarvest crop)
        {
            _cropDAO.addCropHarvest(crop);


        }
        public void addCropRequirements(CropRequirements crop)
        {

            _cropDAO.addCropRequirements(crop);

        }


        public void editCrop(Crop crop)
        {
            _cropDAO.editCrop(crop);
        }

        public void editCropHarvest(CropHarvest crop)
        {

            _cropDAO.editCropHarvest(crop);

        }
        public void editCropRequirements(CropRequirements crop)
        {

            _cropDAO.editCropRequirements(crop);

        }


        public CropDataViewModel GetCropViewModel(int id)
        {
            return _cropDAO.GetCropViewModel(id);
        }

    }
}
