using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllotmentPlanner.Data;
using AllotmentPlanner.Data.IDAO;
using AllotmentPlanner.Data.DAO;


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

        public void addGarden(GardenLocation gardenLocation)
        {
            _gardenDAO.addGarden(gardenLocation);

        }

        public void editGarden(GardenLocation gardenLocation)
        {

            _gardenDAO.editGarden(gardenLocation);


        }
        public void DeleteGarden(GardenLocation gardenLocation)
        {
            _gardenDAO.DeleteGarden(gardenLocation);


        }

    }
}
