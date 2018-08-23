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
        public IList<GardenLocation> GetActiveGardenLocations()
        {
            IQueryable<GardenLocation> _gardens;

            _gardens = from GardenLocation in _context.GardenLocation
                       where GardenLocation.Active == true
                       select GardenLocation;

            return _gardens.ToList();
        }

        public IList<GardenLocation> GetInactiveGardenLocations()
        {
            IQueryable<GardenLocation> _gardens;

            _gardens = from GardenLocation in _context.GardenLocation
                       where GardenLocation.Active == false
                       select GardenLocation;

            return _gardens.ToList();
        }


        public int GetLastGardenId()
        {
            IQueryable<Allotment> _gardens;

            _gardens = from Allotment in _context.Allotment
                       orderby Allotment.gardenId descending
                       select Allotment;

            return _gardens.ToList().First().gardenId;
        }

        public Planted GetLastPlanted()
        {
            IQueryable<Planted> _planted;

            _planted = from planted in _context.Planted
                       orderby planted.plantedId descending
                       select planted;

            return _planted.ToList().First();
        }


        public GardenLocation GetGardenLocation(string pcode)
        {
            IQueryable<GardenLocation> _garden;

            _garden = from garden in _context.GardenLocation
                      where garden.postCode == pcode
                      select garden;

            return _garden.ToList().First();
        }

        public IList<Planted> getPlantedCrops()
        {
            IQueryable<Planted> _planted;

            _planted = from Planted in _context.Planted
                       select Planted;

            return _planted.ToList();

        }

        public IList<Allotment> ListGardensbyPostCode(string pcode)
        {
            IQueryable<Allotment> _gardens;

            _gardens = from allotment in _context.Allotment
                       where allotment.postCode == pcode
                       select allotment;

            return _gardens.ToList();

        }

        public IList<AllotmentAllocation> CountUserActiveGardens(string userId)
        {
            IQueryable<AllotmentAllocation> _countUserGardens;
            _countUserGardens = from allocation in _context.AllotmentAllocation
                                where allocation.userId == userId
                                && allocation.dateTo == null
                                select allocation;


            return _countUserGardens.ToList();
        }

        public Allotment GetAllotment(int gardenId)
        {
            IQueryable<Allotment> _allotment;

            _allotment = from allotment in _context.Allotment
                         where allotment.gardenId == gardenId
                         select allotment;

            return _allotment.ToList().First();
        }

        public AllotmentAllocation GetAllocatedAllotment(int gardenId)
        {
            IQueryable<AllotmentAllocation> _allotment;

            _allotment = from allocated in _context.AllotmentAllocation
                         where allocated.gardenId == gardenId
                         select allocated;

            return _allotment.ToList().First();
        }

        public Planted getPlantedCrop(int plantedId)
        {
            IQueryable<Planted> _planted;

            _planted = from planted in _context.Planted
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
                                 select new GardenViewModel
                                 {
                                     postCode = allot.postCode,
                                     Name = location.Name,
                                     gardenId = allot.gardenId,
                                     size = allot.size,
                                     AssignedGardener = user.UserName
                                 });

            return listWithEmpty.ToList();
        }

        public IList<GardenViewModel> ViewEmptyGardensinLocation(string pcode)
        {
            var listWithEmpty = (from allot in _context.Allotment
                                 from allocation in _context.AllotmentAllocation
                                 from location in _context.GardenLocation
                                 where allot.postCode == pcode
                                 && location.postCode == allot.postCode
                                 && allot.gardenId == allocation.gardenId
                                 && allocation.userId == null
                                 && allocation.allocationId == allocation.allocationId
                                 select new GardenViewModel
                                 {
                                     postCode = allot.postCode,
                                     Name = location.Name,
                                     gardenId = allot.gardenId,
                                     size = allot.size
                                 });

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
                                                               size = allot.size,
                                                               Active = garden.Active
                                                           };

            return _gardenViewModel.ToList().First();
        }

        public void addGardenLocation(GardenLocation gardenLocation, Allotment allotment)
        {
            _context.GardenLocation.Add(gardenLocation);
            _context.Allotment.Add(allotment);
            _context.SaveChanges();
        }

        public void addGardentoAllotment(Allotment allotment)
        {
            _context.Allotment.Add(allotment);
            _context.SaveChanges();
        }

        public void AllocateGarden()
        {
            int gardenId = GetLastGardenId();

            AllotmentAllocation myallotmentAllocation = new AllotmentAllocation
            {
                gardenId = gardenId
            };

            _context.AllotmentAllocation.Add(myallotmentAllocation);
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

        public void DeactivateGardenLocation(GardenLocation gardenLocation)
        {
            GardenLocation myGarden = GetGardenLocation(gardenLocation.postCode);

            _context.GardenLocation.Remove(myGarden);

            _context.SaveChanges();
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
                                 select new EditGardenViewModel
                                 {
                                     gardenId = allocation.gardenId,
                                     cropId = crop.cropId,
                                     plantedId = planted.plantedId,
                                     gardenSize = allot.size,
                                     cropName = crop.cropName,
                                     cropSize = crop.cropSize,
                                     earliestPlant = croph.earliestPlant,
                                     latestPlant = croph.latestPlant,
                                     earliestHarvest = croph.earliestHarvest,
                                     lastestHarvest = croph.latestHarvest
                                 });

            return listWithEmpty.ToList();
        }

        public UserGardenViewModel GetGardenFromUser(string userId)
        {
            IQueryable<UserGardenViewModel> _usergarden;

            _usergarden = from allot in _context.Allotment
                          from allocation in _context.AllotmentAllocation
                          where allocation.userId == userId
                          select new UserGardenViewModel
                          {
                              gardenId = allocation.gardenId,
                          };

            return _usergarden.ToList().First();
        }

        // Adds a crop to a garden
        public void addcropstogarden(Planted planted)
        {
            _context.Planted.Add(planted);
            _context.SaveChanges();
        }

        public void removecropsfromgarden(Planted planted)
        {
            _context.Planted.Remove(planted);
            _context.SaveChanges();

        }

        public IList<UserGardenViewModel> GetUserGarden(string userId)
        {
            var cropsPlanted = (from allocation in _context.AllotmentAllocation
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
                                 select new UserGardenViewModel
                                 {
                                     gardenId = allocation.gardenId,
                                     cropId = crop.cropId,
                                     plantedId = planted.plantedId,
                                     cropName = crop.cropName,
                                     cropSize = crop.cropSize,
                                     growthTime = croph.growthTime,
                                     dateIn = planted.dateIn,
                                     dateOut = planted.dateOut,
                                     earliestPlant = croph.earliestPlant,
                                     latestPlant = croph.latestPlant,
                                     earliestHarvest = croph.earliestHarvest,
                                     estimatedHarvestDate = planted.dateIn,
                                     lastestHarvest = croph.latestHarvest
                                 });

            List<UserGardenViewModel> newCropsPlantedList = new List<UserGardenViewModel>();

            //This is a temporary solution to the problem. get rid of nullables and create some new methods, could be done right.
            foreach (var planted in cropsPlanted.ToList())
            {
                if (planted.dateIn != null && planted.growthTime != null)
                {
                    DateTime plantedDate = planted.dateIn ?? DateTime.Now; // It should never hit datetime now since the if does a check
                    int growthTime = planted.growthTime ?? 10; // It should never hit 10 since the if does a check
                    DateTime estmatedHarvest = plantedDate.AddDays(growthTime); // It should only ever set the est harvest as what you need it to be if the values aren't null

                    planted.estimatedHarvestDate = estmatedHarvest; //  Sets the est harvest date for the record
                }
                else
                {
                    planted.estimatedHarvestDate = null;
                }

                newCropsPlantedList.Add(planted); // Adding the updated values to a new list
            }

            return newCropsPlantedList; // Pass the new list instead of the cropsPlanted.ToList()
        }

        public void setAsTended(Tended tended)
        {
            _context.Tended.Add(tended);
            _context.SaveChanges();
        }

        public IList<CropMaintenanceViewModel> getTendActions(string userId)
        {
            var listWithEmpty = (from crop in _context.Crop
                                 from cropr in _context.CropRequirements
                                 from tends in _context.TendType
                                 from tended in _context.Tended
                                 from planted in _context.Planted
                                 from allocation in _context.AllotmentAllocation
                                 where planted.plantedId == tended.plantedId
                                 && crop.cropId == cropr.cropId
                                 && planted.cropId == crop.cropId
                                 && allocation.gardenId == planted.gardenId
                                 && allocation.userId == userId
                                 select new CropMaintenanceViewModel
                                 {
                                     cropId = crop.cropId,
                                     tendId = tends.tendId,
                                     plantedId = planted.plantedId,
                                     cropName = crop.cropName,
                                     tendName = tends.tendName,
                                     waterFrequency = cropr.wateringInterval,
                                     Date = tended.Date,
                                     gardenId = planted.gardenId
                                 });

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
 }