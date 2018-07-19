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
        public Allotment GetLastGardenId()
        {
            IQueryable<Allotment> _gardens;
            _gardens = from Allotment
                       in _context.Allotment
                       orderby Allotment.gardenId ascending
                       select Allotment;
            return _gardens.ToList().First();
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
                         where allotment.gardenId == gardenId
                         select allotment;

            return _allotment.ToList().First();
        }

        public AllotmentAllocation GetAllocatedAllotment(int gardenId)
        {
            IQueryable<AllotmentAllocation> _allotment;

            _allotment = from allocated
                    in _context.AllotmentAllocation
                         where allocated.gardenId == gardenId
                         select allocated;

            return _allotment.ToList().First();
        }

        public Planted getPlantedCrop(int plantedId)
        {
            IQueryable<Planted> _planted;

            _planted = from planted
                      in _context.Planted
                         where planted.plantedId == plantedId
                         select planted;

            return _planted.ToList().First();
        }


        public IList<GardenViewModel> ViewGardensinLocation(string pcode)
        {
            var listWithEmpty = (from allot in _context.Allotment
                                 from allocation in _context.AllotmentAllocation
                                 from location in _context.GardenLocation
                                 from user in _context.AspNetUsers
                                 where allot.postCode == pcode
                                 && location.postCode == allot.postCode
                                 && allot.gardenId == allocation.gardenId
                                 && allocation.userId == user.Id
                                 && allocation.dateTo == null
                                 select new
                                 {
                                     postCode = allot.postCode,
                                     Name = location.Name,
                                     gardenId = allot.gardenId,
                                     Size = allot.size,
                                     AssignedGardener = user.UserName
                                 }).ToList().Select(GardensList => new GardenViewModel()
                                 {
                                     postCode = GardensList.postCode,
                                     Name = GardensList.Name,
                                     gardenId = GardensList.gardenId,
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
                                 && allot.gardenId == allocation.gardenId
                                 && allocation.userId == null
                                 && allocation.allocationId == allocation.allocationId
                                 //&& allocation.dateTo == null
                                 select new
                                 {
                                     postCode = allot.postCode,
                                     Name = location.Name,
                                     gardenId = allot.gardenId,
                                     Size = allot.size,
                                     //AssignedGardener = user.UserName

                                 }).ToList().Select(GardensList => new GardenViewModel()
                                 {
                                     postCode = GardensList.postCode,
                                     Name = GardensList.Name,
                                     gardenId = GardensList.gardenId,
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
                                                           && allocation.gardenId == allot.gardenId
                                                           && user.Id == allocation.userId
                                                           select new GardenViewModel
                                                           {
                                                               postCode = garden.postCode,
                                                               Name = garden.Name,
                                                               AssignedGardener = user.UserName,
                                                               Owner = garden.Owner,
                                                               gardenId = allot.gardenId,
                                                               size = allot.size
                                                           };

            return _gardenViewModel.ToList().First();
        }

        public void addGardenLocation(GardenLocation gardenLocation, Allotment allotment)
        {
            _context.GardenLocation.Add(gardenLocation);
            _context.Allotment.Add(allotment);
            _context.SaveChanges();
        }

        public void addGardentoAllotment(Allotment allotment, AllotmentAllocation allotmentAllocation)
        {
            _context.Allotment.Add(allotment);
            _context.AllotmentAllocation.Add(allotmentAllocation);
            _context.SaveChanges();
        }


        //Methods for adding and removing Gardeners from garden

        public void assignGardenerToGarden(AllotmentAllocation allotmentAllocation)
        {
            AllotmentAllocation myAlloction = GetAllocatedAllotment(allotmentAllocation.gardenId);
            myAlloction.userId = allotmentAllocation.userId;
            myAlloction.dateFrom = allotmentAllocation.dateFrom;
            _context.SaveChanges();
        }

        public void removeGardenerFromGarden(AllotmentAllocation allotmentAllocation)
        {
            AllotmentAllocation myAlloction = GetAllocatedAllotment(allotmentAllocation.gardenId);
            myAlloction.dateTo = allotmentAllocation.dateTo;
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

            Allotment myallotment = GetAllotment(allotment.gardenId);

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
            Allotment myallotment = GetAllotment(allotment.gardenId);

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

                             where allocation.userId == userID
                             && allocation.gardenId == planted.gardenId
                             && crop.cropId == planted.cropId
                             && allocation.dateTo == null
                             select new EditGardenViewModel
                             {
                                 gardenId = allot.gardenId,
                                 cropId = crop.cropId,
                                 gardenSize = allot.size,
                                 cropSize = crop.cropSize,
                                 cropName = crop.cropName
                             };

            return _selectedcrops.ToList().FirstOrDefault();


        }

        public IList<EditGardenViewModel> ListSelectedCrops(string userId)
        {
            var listWithEmpty = (from allocation in _context.AllotmentAllocation
                                 from crop in _context.Crop
                                 from allot in _context.Allotment
                                 from croph in _context.CropHarvest
                                 from planted in _context.Planted
                                 where allocation.userId == userId
                                 && allocation.gardenId == planted.gardenId
                                 && allot.gardenId == planted.gardenId
                                 && crop.cropId == planted.cropId
                                 && croph.cropId == planted.cropId
                                 && crop.cropId == planted.cropId
                                 && allocation.dateTo == null
                                 && planted.dateOut == null

                                 //join plantedjoin in _context.Planted on allocation.gardenID equals plantedjoin.gardenID
                                 //from plantedjoin in ThisList.DefaultIfEmpty()
                                 select new
                                 {
                                     GardenId = allocation.gardenId,
                                     CropId = crop.cropId,
                                     plantedId = planted.plantedId,
                                     GardenSize = allot.size,
                                     CropName = crop.cropName,
                                     CropSize = crop.cropSize,
                                     EarliestPlant = croph.earliestPlant,
                                     LatestPlant = croph.latestPlant,
                                     EarliestHarvest = croph.earliestHarvest,
                                     LastestHarvest = croph.latestHarvest
                                 }).ToList().Select(CropList => new EditGardenViewModel()
                                 {
                                     gardenId = CropList.GardenId,
                                     cropId = CropList.CropId,
                                     plantedId = CropList.plantedId,
                                     gardenSize = CropList.GardenSize,
                                     cropName = CropList.CropName,
                                     cropSize = CropList.CropSize,
                                     earliestPlant = CropList.EarliestPlant,
                                     latestPlant = CropList.LatestPlant,
                                     earliestHarvest = CropList.EarliestHarvest,
                                     lastestHarvest = CropList.LastestHarvest
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

                          where allocation.userId == userId
                          select new EditGardenViewModel
                          {
                              gardenId = allot.gardenId,
                          };

            return _usergarden.ToList().First();
        }
        public void addcropstogarden(Planted crop, Planted garden)
        {
            Planted setPlanted = new Planted
            {
                gardenId = garden.gardenId,
                cropId = crop.cropId
            };

            _context.Planted.Add(setPlanted);
            _context.SaveChanges();


        }


        public IList<UserGardenViewModel> GetUserGarden(string userId)
        {
            var listWithEmpty = (from allocation in _context.AllotmentAllocation
                                 from crop in _context.Crop
                                 from allot in _context.Allotment
                                 from croph in _context.CropHarvest
                                 from cropr in _context.CropRequirements
                                 from planted in _context.Planted
                                 where allocation.userId == userId
                                 && allocation.gardenId == planted.gardenId
                                 && allot.gardenId == planted.gardenId
                                 && crop.cropId == planted.cropId
                                 && croph.cropId == planted.cropId
                                 && cropr.cropId == crop.cropId
                                 && crop.cropId == planted.cropId
                                 && allocation.dateTo == null
                                 && planted.dateOut == null

                                 //join plantedjoin in _context.Planted on allocation.gardenID equals plantedjoin.gardenID
                                 //from plantedjoin in ThisList.DefaultIfEmpty()
                                 select new
                                 {
                                     GardenId = allocation.gardenId,
                                     CropId = crop.cropId,
                                     plantedId = planted.plantedId,
                                     CropName = crop.cropName,
                                     CropSize = crop.cropSize,
                                     growthTime = croph.growthTime,
                                     dateIn = planted.dateIn,
                                     dateOut = planted.dateOut,
                                     EarliestPlant = croph.earliestPlant,
                                     LatestPlant = croph.latestPlant,
                                     EarliestHarvest = croph.earliestHarvest,
                                     EstimatedHarvest = planted.dateIn,
                                     LastestHarvest = croph.latestHarvest
                                 }).ToList().Select(gardenList => new UserGardenViewModel()
                                 {
                                     gardenId = gardenList.GardenId,
                                     cropId = gardenList.CropId,
                                     plantedId = gardenList.plantedId,
                                     cropName = gardenList.CropName,
                                     cropSize = gardenList.CropSize,
                                     growthTime = gardenList.growthTime,
                                     dateIn = gardenList.dateIn,
                                     dateOut = gardenList.dateOut,
                                     earliestPlant = gardenList.EarliestPlant,
                                     latestPlant = gardenList.LatestPlant,
                                     earliestHarvest = gardenList.EarliestHarvest,
                                     estimatedHarvestDate = gardenList.EstimatedHarvest,
                                     lastestHarvest = gardenList.LastestHarvest
                                 }
                                     );
            return listWithEmpty.ToList();
        }

        public void logCropAsPlanted(Planted planted)
        {
            Planted myPlanted = getPlantedCrop(planted.plantedId);
            myPlanted.dateIn = planted.dateIn;
            _context.SaveChanges();

        }


        public void logCropAsHarvested(Planted planted)
        {
            Planted myPlanted = getPlantedCrop(planted.plantedId);
            myPlanted.dateOut = planted.dateOut;
            _context.SaveChanges();

        }
        public void deletePlantedCrop(Planted planted)
        {
            _context.Planted.Remove(planted);
            _context.SaveChanges();
        }

    }





//    public calculateSeedsNeeded()
//{



//}



 }