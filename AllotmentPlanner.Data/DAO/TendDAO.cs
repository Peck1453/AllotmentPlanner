using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllotmentPlanner.Data.IDAO;
using AllotmentPlanner.Data.ViewModel;


namespace AllotmentPlanner.Data.DAO
{

    public class TendDAO: ITendDAO
    {
        private AllotmentEntities _context;

        public TendDAO()
        {
            _context = new AllotmentEntities();
        }

        public IList<TendType> getTends()
        {
            IQueryable<TendType> _tends;

            _tends = from TendType in _context.TendType
                     select TendType;

            return _tends.ToList();
        }

        public TendType getTend(int id)
        {
            IQueryable<TendType> _tend;

            _tend = from tend in _context.TendType
                    where tend.tendId == id
                    select tend;

            return _tend.ToList().First();
        }

        public TendType GetLastTendCreated()
        {
            IQueryable<TendType> _lasttend;

            _lasttend = from tend in _context.TendType
                       orderby tend.tendId descending
                       select tend;

            return _lasttend.ToList().First();


        }

        public void addTend(TendType tend)
        {
            _context.TendType.Add(tend);
            _context.SaveChanges();
        }

        public void editTend(TendType tend)
        {
            TendType mytend = getTend(tend.tendId);

            mytend.tendName = tend.tendName;

            _context.SaveChanges();
        }

        public void deleteTend(TendType tend)
        {
            TendType myTend = getTend(tend.tendId);

            _context.TendType.Remove(myTend);

            _context.SaveChanges();
        }

        public void setAsTended(Tended tended)
        {
            Tended myTended = new Tended
            {
                cropId = tended.cropId,
                tendId = tended.tendId,
                Date = tended.Date,
                plantedId = tended.plantedId
            };

            _context.Tended.Add(myTended);
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
                                 from allot in _context.Allotment
                                 where allocation.userId == userId
                                 && allocation.gardenId == planted.gardenId
                                 && allot.gardenId == planted.gardenId
                                 && crop.cropId == planted.cropId
                                 && cropr.cropId == crop.cropId
                                 && crop.cropId == planted.cropId
                                 && allocation.dateTo == null
                                 && planted.dateOut == null
                                 select new CropMaintenanceViewModel
                                 {
                                     cropId = crop.cropId,
                                     tendId = tends.tendId,
                                     tendName = tends.tendName,
                                     cropName = crop.cropName,
                                     plantedId = planted.plantedId,
                                     waterFrequency = cropr.wateringInterval,
                                     Date = tended.Date,
                                     gardenId = planted.gardenId
                                 });

            return listWithEmpty.ToList();
        }

        public IList<CropMaintenanceViewModel> loopTends(string userId, int plantedId)
        {
            var listWithEmpty = (from crop in _context.Crop
                                 from tends in _context.TendType
                                 from tendactions in _context.Tended
                                 from planted in _context.Planted
                                 from croph in _context.CropHarvest
                                 from allocation in _context.AllotmentAllocation
                                 where planted.plantedId == plantedId
                                 && allocation.userId == userId
                                 && allocation.gardenId == planted.gardenId
                                 && crop.cropId == planted.cropId
                                 && croph.cropId == planted.cropId
                                 select new CropMaintenanceViewModel
                                 {
                                     plantedId = planted.plantedId,
                                     tendId = tends.tendId,
                                     tendedId = tendactions.tendedId,
                                     tendName = tends.tendName,
                                     cropId = crop.cropId,
                                     tendFrequency = tends.tendFrequency
                                 });

            return listWithEmpty.ToList();
        }

        public CropMaintenanceViewModel GetRecentTend(int tendId, int plantedId)
        {
            IQueryable<CropMaintenanceViewModel> _tended;

            _tended = from tended in _context.Tended
                      from tends in _context.TendType
                      where tended.tendId == tendId
                      && tended.plantedId == plantedId
                      && tended.tendId == tends.tendId
                       orderby tended.tendedId descending
                       select new CropMaintenanceViewModel
                       {
                           tendedId = tended.tendedId,
                           cropId = tended.cropId,
                           tendId = tended.tendId,
                           tendName = tends.tendName,
                           tendFrequency = tends.tendFrequency,
                           Date = tended.Date,
                           plantedId = tended.plantedId
                       };

            return _tended.ToList().First();
        }

        public IList<Tended> GetTendActionsperPlanted(int plantedId, int tendedId)
        {
            {
                IQueryable<Tended> _tend;

                _tend = from tended in _context.Tended
                        where tended.plantedId == plantedId && tended.tendedId == tendedId
                        orderby tended.Date descending
                        select tended;

                return _tend.ToList();
            }
        }
    }
}
