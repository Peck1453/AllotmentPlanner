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

        public void addGardenLocation(GardenLocation gardenLocation)
        {
            _gardenDAO.addGardenLocation(gardenLocation);

        }

        public void addGardentoAllotment(Allotment allotment)
        {
            _gardenDAO.addGardentoAllotment(allotment);
        }


        public void editGarden(GardenLocation gardenLocation)
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

        public void addGardenerToGarden(AllotmentAllocation allotmentAllocation)
        {
            _gardenDAO.addGardenerToGarden(allotmentAllocation);
        }
        public void removeGardenerFromGarden(AllotmentAllocation allotmentAllocation)
        {
            _gardenDAO.removeGardenerFromGarden(allotmentAllocation);
        }






        public EditGardenViewModel ViewSelectedCrops(string userID)

        {
            return _gardenDAO.ViewSelectedCrops(userID);
        }

        public IList<EditGardenViewModel> ListSelectedCrops(string userID)

        {

            return _gardenDAO.ListSelectedCrops(userID);
        }

        public void addcropstogarden(string userId, Planted crop, Planted garden)
        {

            _gardenDAO.addcropstogarden(userId, crop, garden);
        }


        public EditGardenViewModel GetGardenFromUser(string userId)
        {

            return _gardenDAO.GetGardenFromUser(userId);
        }



        public EditGardenViewModel GetUserGarden(int id)
        {

            return _gardenDAO.GetUserGarden(id);
        }

    }
}
