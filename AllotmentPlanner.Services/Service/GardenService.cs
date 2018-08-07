using System;
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
    public class GardenService : AllotmentPlanner.Services.IService.IGardenService
    {
        private IGardenDAO _gardenDAO;

        public GardenService()
        {
            _gardenDAO = new GardenDAO();
        }


        public IList<AllotmentPlanner.Data.GardenLocation> GetGardenLocations()
        {
            return _gardenDAO.GetGardenLocations();


        }
        public IList<GardenViewModel> ViewGardensinLocation(string pcode)
        {
            return _gardenDAO.ViewGardensinLocation(pcode);
        }

        public IList<GardenViewModel> ViewEmptyGardensinLocation(string pcode)
        {
            return _gardenDAO.ViewEmptyGardensinLocation(pcode);
        }

        public IList<Planted> getPlantedCrops()
        {

            return _gardenDAO.getPlantedCrops();
        }



        public IList<AllotmentAllocation> CountUserActiveGardens(string userId)
        {

            return _gardenDAO.CountUserActiveGardens(userId);
        }


        public Planted getPlantedCrop(int plantedId)
        {
            return _gardenDAO.getPlantedCrop(plantedId);
        }

        public int GetLastGardenId()
        {
            return _gardenDAO.GetLastGardenId();
        }

        public Planted GetLastPlanted()
        {
            return _gardenDAO.GetLastPlanted();
        }

        public GardenLocation GetGardenLocation(string pcode)
        {
            return _gardenDAO.GetGardenLocation(pcode);
        }
        public Allotment GetAllotment(int gardenId)
        {
            return _gardenDAO.GetAllotment(gardenId);
        }
        public GardenViewModel GetGardenViewModel(string pcode)
        {
            return _gardenDAO.GetGardenViewModel(pcode);
        }

        public AllotmentAllocation GetAllocatedAllotment(int gardenId)
        {
            return _gardenDAO.GetAllocatedAllotment(gardenId);
        }


        public void addGardenLocation(GardenLocation gardenLocation, Allotment allotment)
        {
            _gardenDAO.addGardenLocation(gardenLocation, allotment);

        }

        public void addGardentoAllotment(Allotment allotment)
        {
            _gardenDAO.addGardentoAllotment(allotment);
        }
        
        public void AllocateGarden()
        {
            _gardenDAO.AllocateGarden();
        }

        public void editGardenLocation(GardenLocation gardenLocation)
        {
            _gardenDAO.editGardenLocation(gardenLocation);
        }
        public void editGarden(Allotment allotment)
        {
            _gardenDAO.editGarden(allotment);
        }
            public void DeleteGarden(GardenLocation gardenLocation)
        {
            _gardenDAO.DeleteGarden(gardenLocation);
        }

        public void assignGardenerToGarden(AllotmentAllocation allotmentAllocation)
        {
            _gardenDAO.assignGardenerToGarden(allotmentAllocation);
        }
        public void removeGardenerFromGarden(AllotmentAllocation allotmentAllocation)
        {
            _gardenDAO.removeGardenerFromGarden(allotmentAllocation);
        }





        public IList<EditGardenViewModel> ListSelectedCrops(string userID)

        {

            return _gardenDAO.ListSelectedCrops(userID);
        }

        public void addcropstogarden(Planted planted)
        {

            _gardenDAO.addcropstogarden(planted);
        }


        public UserGardenViewModel GetGardenFromUser(string userId)
        {
            return _gardenDAO.GetGardenFromUser(userId);
        }

        public IList<UserGardenViewModel>GetUserGarden(string userId)
        {
            return _gardenDAO.GetUserGarden(userId);
        }

        public void logCropAsPlanted(Planted planted)
        {

            _gardenDAO.logCropAsPlanted(planted);

        }

        public void logCropAsHarvested(Planted planted)
        {
            _gardenDAO.logCropAsHarvested(planted);
        }
        public void deletePlantedCrop(Planted planted)
        {
            _gardenDAO.deletePlantedCrop(planted);
        }


    }
}
