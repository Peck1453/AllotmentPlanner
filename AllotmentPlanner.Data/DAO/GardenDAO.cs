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

        public Allotment GetAllotment(int gardenId)
        {
            IQueryable<Allotment> _allotment;

            _allotment = from allotment
                    in _context.Allotment
                      where allotment.gardenID == gardenId
                         select allotment;

            return _allotment.ToList().First();
        }

        public IList<GardenViewModel> ViewGardensinLocation(string pcode)
        {
            var listWithEmpty = (from allot in _context.Allotment
                                 from allocation in _context.AllotmentAllocation
                                 from location in _context.GardenLocation
                                 from user in _context.AspNetUsers
                                 where allot.postCode == pcode
                                 && location.postCode == allot.postCode
                                 && allot.gardenID == allocation.gardenID
                                 && allocation.userID == user.Id
                                 && allocation.dateTo == null
                                 select new
                                 {
                                     postCode = allot.postCode,
                                     Name = location.Name,
                                     gardenId = allot.gardenID,
                                     Size = allot.size,
                                     AssignedGardener = user.UserName
                                 }).ToList().Select(GardensList => new GardenViewModel()
                                 {
                                     postCode = GardensList.postCode,
                                     Name = GardensList.Name,
                                     gardenID = GardensList.gardenId,
                                     size = GardensList.Size,
                                     AssignedGardener = GardensList.AssignedGardener
                                 }
                                 );
            return listWithEmpty.ToList();
        }
        public IList<GardenViewModel> ViewEmptyGardensinLocation(string pcode)
        {
            var listWithEmpty = (from allot in _context.Allotment
                                 from allocation in _context.AllotmentAllocation
                                 from location in _context.GardenLocation
                                 //from user in _context.AspNetUsers
                                 where allot.postCode == pcode
                                 && location.postCode == allot.postCode
                                 && allot.gardenID == allocation.gardenID
                                 && allocation.userID == null
                                 && allocation.allocationID == allocation.allocationID
                                 //&& allocation.dateTo == null
                                 select new
                                 {
                                     postCode = allot.postCode,
                                     Name = location.Name,
                                     gardenId = allot.gardenID,
                                     Size = allot.size,
                                     //AssignedGardener = user.UserName

                                 }).ToList().Select(GardensList => new GardenViewModel()
                                 {
                                     postCode = GardensList.postCode,
                                     Name = GardensList.Name,
                                     gardenID = GardensList.gardenId,
                                     size = GardensList.Size,
                                     //AssignedGardener = GardensList.AssignedGardener

                                 }
                                 );
            return listWithEmpty.ToList();
        }






        public GardenViewModel GetGardenViewModel(string pcode)
        {
            IQueryable<GardenViewModel> _gardenViewModel = from garden in _context.GardenLocation
                                                           from allot in _context.Allotment
                                                           from allocation in _context.AllotmentAllocation
                                                           from user in _context.AspNetUsers
                                                           where garden.postCode == pcode
                                                           && garden.postCode == allot.postCode
                                                           && allocation.gardenID == allot.gardenID
                                                           && user.Id == allocation.userID
                                                           select new GardenViewModel
                                                           {
                                                               postCode = garden.postCode,
                                                               Name = garden.Name,
                                                               AssignedGardener = user.UserName,
                                                               Owner = garden.Owner,
                                                               gardenID = allot.gardenID,
                                                               size = allot.size
                                                           };

            return _gardenViewModel.ToList().First();
        }

        public void addGardenLocation(GardenLocation gardenLocation)
        {
            _context.GardenLocation.Add(gardenLocation);
            _context.SaveChanges();
        }

        public void addGardentoAllotment(Allotment allotment)
        {
            _context.Allotment.Add(allotment);
            _context.SaveChanges();
        }

        public void addGardenerToGarden(AllotmentAllocation allotmentAllocation)
        {
            _context.AllotmentAllocation.Add(allotmentAllocation);
            _context.SaveChanges();


        }

        public void removeGardenerFromGarden(AllotmentAllocation allotmentAllocation)
        {
            _context.AllotmentAllocation.Add(allotmentAllocation);
            _context.SaveChanges();


        }


        public void editGardenLocation(GardenLocation gardenLocation)
        {

            GardenLocation mygarden = GetGardenLocation(gardenLocation.postCode);


            mygarden.Name = gardenLocation.Name;
            mygarden.Owner = gardenLocation.Owner;

            _context.SaveChanges();

        }

        public void editGarden(Allotment allotment)
        {

            Allotment myallotment = GetAllotment(allotment.gardenID);

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
            Allotment myallotment = GetAllotment(allotment.gardenID);

            _context.Allotment.Add(allotment);
            _context.SaveChanges();

        }

        public EditGardenViewModel ViewSelectedCrops(string userID)
        {
                IQueryable<EditGardenViewModel> _selectedcrops;
                _selectedcrops = from allot in _context.Allotment
                                 from crop in _context.Crop
                                 from planted in _context.Planted
                                 from allocation in _context.AllotmentAllocation
                                 from user in _context.AspNetUsers

                                 where allocation.userID == userID
                                 && allocation.gardenID == planted.gardenID
                                 && crop.cropID == planted.cropID
                                 && allocation.dateTo == null
                                 select new EditGardenViewModel
                                 {
                                     GardenId = allot.gardenID,
                                     CropId = crop.cropID,
                                     GardenSize = allot.size,
                                     CropSize = crop.cropSize,
                                     CropName = crop.cropName
                                 };

                return _selectedcrops.ToList().FirstOrDefault();
            

        }

        public IList<EditGardenViewModel> ListSelectedCrops(string userID)
        {
            var listWithEmpty = (from allocation in _context.AllotmentAllocation
                                 from crop in _context.Crop
                                 from allot in _context.Allotment
                                 from croph in _context.CropHarvest
                                 from planted in _context.Planted
                                 where allocation.userID == userID
                                 && allocation.gardenID == planted.gardenID
                                 && allot.gardenID ==planted.gardenID
                                 && crop.cropID == planted.cropID
                                 && croph.cropID == planted.cropID
                                 && crop.cropID == planted.cropID
                                 && allocation.dateTo == null

                                 //join plantedjoin in _context.Planted on allocation.gardenID equals plantedjoin.gardenID
                                 //from plantedjoin in ThisList.DefaultIfEmpty()
                                 select new
                                 {
                                     GardenId = allocation.gardenID,
                                     CropId = crop.cropID,
                                     GardenSize = allot.size,
                                     CropName = crop.cropName,
                                     CropSize = crop.cropSize,
                                     EarliestPlant = croph.earliestPlant,
                                     LatestPlant = croph.latestPlant,
                                     EarliestHarvest = croph.earliestHarvest,
                                     LastestHarvest = croph.latestHarvest
                                 }).ToList().Select(CropList => new EditGardenViewModel()
                                 {
                                     GardenId = CropList.GardenId,
                                     CropId = CropList.CropId,
                                     GardenSize = CropList.GardenSize,
                                     CropName = CropList.CropName,
                                     CropSize = CropList.CropSize,
                                     EarliestPlant = CropList.EarliestPlant,
                                     LatestPlant = CropList.LatestPlant,
                                     EarliestHarvest = CropList.EarliestHarvest,
                                     LastestHarvest = CropList.LastestHarvest
                                 }
                                     );
            return listWithEmpty.ToList();
        }

        public EditGardenViewModel GetGardenFromUser(string userId)
        {

            IQueryable<EditGardenViewModel> _usergarden;
            _usergarden = from allot in _context.Allotment
                             from allocation in _context.AllotmentAllocation
                             from planted in _context.Planted

                             where allocation.userID == userId
                             select new EditGardenViewModel
                             {
                                 GardenId = allot.gardenID,
                             };

            return _usergarden.ToList().First();
        }
            public void addcropstogarden(string userId, Planted crop, Planted garden)
        {
            EditGardenViewModel addgarden = GetGardenFromUser(userId);

            _context.Planted.Add(crop);
            _context.Planted.Add(garden);
            _context.SaveChanges();


        }

        public EditGardenViewModel GetUserGarden(int id)
        {


            IQueryable<EditGardenViewModel> _editgarden = from allot in _context.Allotment
                                                          from crop in _context.Crop
                                                          from planted in _context.Planted
                                                          from allocation in _context.AllotmentAllocation
                                                          where allot.gardenID  == id
                                                          where planted.cropID == crop.cropID
                                                          && allocation.dateTo == null

                                                          select new EditGardenViewModel
                                                          {
                                                              GardenId = allot.gardenID,
                                                              CropId = crop.cropID,
                                                              GardenSize = allot.size,
                                                              CropSize = crop.cropSize,
                                                              CropName = crop.cropName
                                                          };
            return _editgarden.ToList().First();
                                                         
    }




}


    }

