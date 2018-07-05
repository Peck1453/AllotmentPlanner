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
        public GardenLocation GetGardenLocation(string pcode)
        {
            return _gardenDAO.GetGardenLocation(pcode);
        }
        public Allotment GetAllotment(string pcode)
        {
            return _gardenDAO.GetAllotment(pcode);
        }
        public GardenViewModel GetGardenViewModel(string pcode)
        {
            return _gardenDAO.GetGardenViewModel(pcode);
        }

        public void addGarden(GardenLocation gardenLocation)
        {
            _gardenDAO.addGarden(gardenLocation);

        }

        public void addGardenAllotment(Allotment allotment)
        {
            _gardenDAO.addGardenAllotment(allotment);
        }


        public void editGarden(GardenLocation gardenLocation, Allotment allotment)
        {

            _gardenDAO.editGarden(gardenLocation, allotment);


        }
        public void DeleteGarden(GardenLocation gardenLocation)
        {
            _gardenDAO.DeleteGarden(gardenLocation);


        }

        public IList<EditGardenViewModel> ViewSelectedCrops(int gardenid)
        {

            return _gardenDAO.ViewSelectedCrops(gardenid);
        }


        public EditGardenViewModel GetUserGarden(int id)
        {

            return _gardenDAO.GetUserGarden(id);
        }

    }
}
