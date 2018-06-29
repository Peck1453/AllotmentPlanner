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

        public Allotment GetAllotment(string pcode)
        {
            IQueryable<Allotment> _allotment;

            _allotment = from allotment
                    in _context.Allotment
                      where allotment.postCode == pcode
                      select allotment;

            return _allotment.ToList().First();
        }



        public GardenViewModel GetGardenViewModel(string pcode)
        {
            IQueryable<GardenViewModel> _gardenViewModel = from garden in _context.GardenLocation
                                                           from allot in _context.Allotment
                                                           where garden.postCode == pcode
                                                           && allot.postCode == allot.postCode
                                                           select new GardenViewModel
                                                           {
                                                               postCode = garden.postCode,
                                                               Name = garden.Name,
                                                               Owner = garden.Owner,
                                                               gardenID = allot.gardenID,
                                                               size = allot.size
                                                           };

            return _gardenViewModel.ToList().First();
        }


        public void addGarden(GardenLocation gardenLocation)
        {
            _context.GardenLocation.Add(gardenLocation);
            _context.SaveChanges();



        }

        public void addGardenAllotment(Allotment allotment)
        {
            _context.Allotment.Add(allotment);
            _context.SaveChanges();

        }



       public void editGarden(GardenLocation gardenLocation, Allotment allotment)
        {

            GardenLocation mygarden = GetGardenLocation(gardenLocation.postCode);
            Allotment myallotment = GetAllotment(allotment.postCode);


            mygarden.Name = gardenLocation.Name;
            mygarden.Owner = gardenLocation.Owner;

            myallotment.size = allotment.size;
            myallotment.postCode = allotment.postCode;

            _context.SaveChanges();

        }

        public void DeleteGarden(GardenLocation gardenLocation)
        {
            GardenLocation myGarden = GetGardenLocation(gardenLocation.postCode);

            _context.GardenLocation.Remove(myGarden);
            _context.SaveChanges();


        }

        public void deleteGardenAllotment(Allotment allotment)
        {
            Allotment myallotment = GetAllotment(allotment.postCode);

            _context.Allotment.Add(allotment);
            _context.SaveChanges();

        }




    }
}
