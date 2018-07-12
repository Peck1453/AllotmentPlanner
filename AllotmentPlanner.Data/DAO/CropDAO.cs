using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllotmentPlanner.Data.IDAO;
using AllotmentPlanner.Data.ViewModel;


namespace AllotmentPlanner.Data.DAO
{
    public class CropDAO : ICropDAO
    {
        private AllotmentEntities _context;
        public CropDAO()
        {

            _context = new AllotmentEntities();
        }


        public IList<Crop> GetCrops()
        {
            IQueryable<Crop> _crops;
            _crops = from Crop
                     in _context.Crop
                     select Crop;
            return _crops.ToList();
        }

        public Crop GetCrop(int id)
        {
            IQueryable<Crop> _crop;

            _crop = from crop
                    in _context.Crop
                    where crop.cropID == id
                    select crop;

            return _crop.ToList().FirstOrDefault();

        }

        public CropHarvest GetCropHarvest(int id)
        {
            IQueryable<CropHarvest> _cropharv;

            _cropharv = from cropharv
                    in _context.CropHarvest
                        where cropharv.cropID == id
                        select cropharv;

            return _cropharv.ToList().FirstOrDefault();
        }

        public CropRequirements GetCropRequirements(int id)
        {
            IQueryable<CropRequirements> _cropreq;

            _cropreq = from cropreq
                       in _context.CropRequirements
                       where cropreq.cropID == id
                       select cropreq;

            return _cropreq.ToList().FirstOrDefault();
        }


        public CropDataViewModel GetCropViewModel(int id)
        {
            IQueryable<CropDataViewModel> _cropDataViewModel = from crop in _context.Crop
                                                               from cropharv in _context.CropHarvest
                                                               from cropreq in _context.CropRequirements
                                                               where crop.cropID == id
                                                               && crop.cropID == cropharv.cropID
                                                               && crop.cropID == cropreq.cropID
                                                               select new CropDataViewModel
                                                               {
                                                                   CropId = crop.cropID,
                                                                   CropName = crop.cropName,
                                                                   SpaceRequired = crop.cropSize,
                                                                   EarlyPlanting = cropharv.earliestPlant,
                                                                   LatePlanting = cropharv.latestPlant,
                                                                   EarlyHarvest = cropharv.earliestHarvest,
                                                                   LateHarvest = cropharv.latestHarvest,
                                                                   growthTime = cropharv.growthTime,
                                                                   birdNetting = cropreq.birdNetting,
                                                                   slugPellets = cropreq.slugPellets,
                                                                   Feed = cropreq.Feed,
                                                                   Water = cropreq.Water
                                                               };
            return _cropDataViewModel.ToList().First();



        }





        public void addCrop(Crop crop)
        {
            Crop myCrop = new Crop();
            myCrop.cropName = crop.cropName;
            myCrop.cropSize = crop.cropSize;

            _context.Crop.Add(myCrop);
            _context.SaveChanges();

        }

        public void addCropHarvest(CropHarvest croph)
        {



            _context.CropHarvest.Add(croph);
            _context.SaveChanges();
        }

        public void addCropRequirements(CropRequirements cropr)
        {

            _context.CropRequirements.Add(cropr);
            _context.SaveChanges();
        }

        public void editCrop(Crop crop, CropHarvest cropHarvest, CropRequirements cropRequirements)
        {
            Crop myCrop = GetCrop(crop.cropID);
            CropHarvest myCroph = GetCropHarvest(cropHarvest.cropID);
            CropRequirements myCropr = GetCropRequirements(cropRequirements.cropID);
            myCrop.cropName = crop.cropName;
            myCrop.cropSize = crop.cropSize;

            myCroph.earliestHarvest = cropHarvest.earliestHarvest;
            myCroph.latestHarvest = cropHarvest.latestHarvest;
            myCroph.earliestPlant = cropHarvest.earliestPlant;
            myCroph.latestPlant = cropHarvest.latestPlant;
            myCroph.growthTime = cropHarvest.growthTime;

            myCropr.birdNetting = cropRequirements.birdNetting;
            myCropr.slugPellets = cropRequirements.slugPellets;
            myCropr.Feed = cropRequirements.Feed;
            myCropr.Water = cropRequirements.Water;

            _context.SaveChanges();


        }
        //public void editCropHarvest(CropDataViewModel cropDataViewModel)
        //{

        //    myCrop.earliestHarvest = cropDataViewModel.EarlyHarvest;
        //    myCrop.latestHarvest = cropDataViewModel.LateHarvest;
        //    myCrop.earliestPlant = cropDataViewModel.EarlyPlanting;
        //    myCrop.latestPlant = cropDataViewModel.LatePlanting;
        //    myCrop.growthTime = cropDataViewModel.growthTime;

        //    _context.SaveChanges();


        //}
        //public void editCropRequirements(CropDataViewModel cropDataViewModel)
        //{
        //    CropRequirements myCrop = GetCropRequirements(cropDataViewModel.CropId);

        //    myCrop.birdNetting = cropDataViewModel.birdNetting;
        //    myCrop.slugPellets = cropDataViewModel.slugPellets;
        //    myCrop.Feed = cropDataViewModel.Feed;
        //    myCrop.Water = cropDataViewModel.Water;

        //    _context.SaveChanges();


        //}


        public void DeleteCrop(Crop crop)
        {
            Crop myCrop = GetCrop(crop.cropID);

            _context.Crop.Remove(crop);
            _context.SaveChanges();
        }
        public void DeleteCropHarvest(CropHarvest cropHarvest)
        {
            CropHarvest myCrop = GetCropHarvest(cropHarvest.cropID);

            _context.CropHarvest.Remove(cropHarvest);
            _context.SaveChanges();
        }
        public void DeleteCropRequirements(CropRequirements cropRequirements)
        {
            
                CropRequirements myCropRequirements = GetCropRequirements(cropRequirements.cropID);

                _context.CropRequirements.Remove(cropRequirements);
                _context.SaveChanges();
        }
    }
}

