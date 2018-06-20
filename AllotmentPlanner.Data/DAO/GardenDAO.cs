using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllotmentPlanner.Data.IDAO;
using AllotmentPlanner.Data.ViewModel;

namespace AllotmentPlanner.Data.DAO
{
    public class GardenDAO : IGardenDAO
    {

        private AllotmentEntities _context;
        public GardenDAO()
        {

            _context = new AllotmentEntities();
        }

        public IList<AllotmentPlanner.Data.GardenLocation> GetGardenLocations()
        {
            IQueryable<GardenLocation> _gardens;
            _gardens = from GardenLocation
                    in _context.GardenLocation
                     select GardenLocation;
            return _gardens.ToList();


        }

        public GardenLocation GetGardenLocation(string pcode)
        {
            IQueryable<GardenLocation> _garden;

            _garden = from garden
                    in _context.GardenLocation
                      where garden.postCode == pcode
                    select garden;

            return _garden.ToList().First();


        }

        public void addGarden(GardenLocation gardenLocation)
        {
            _context.GardenLocation.Add(gardenLocation);
            _context.SaveChanges();



        }



       public void editGarden(GardenLocation gardenLocation)
        {

            GardenLocation mygarden = GetGardenLocation(gardenLocation.postCode);

            mygarden.Name = gardenLocation.Name;

            _context.SaveChanges();

        }

        public void DeleteGarden(GardenLocation gardenLocation)
        {
            GardenLocation myGarden = GetGardenLocation(gardenLocation.postCode);

            _context.GardenLocation.Remove(myGarden);
            _context.SaveChanges();


        }



    }
}
