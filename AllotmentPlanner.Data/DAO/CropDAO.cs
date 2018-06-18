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

            return _crop.ToList().First();

        }

        public CropHarvest GetCropHarvest(int id)
        {
            IQueryable<CropHarvest> _cropharv;

            _cropharv = from cropharv
                    in _context.CropHarvest
                    where cropharv.cropID == id
                    select cropharv;

            return _cropharv.ToList().First();
        }

        public CropRequirements GetCropRequirement(int id)
        {
            IQueryable<CropRequirements> _cropreq;

            _cropreq = from cropreq
                       in _context.CropRequirements
                       where cropreq.cropID == id
                       select cropreq;

            return _cropreq.ToList().First();
        }






        //public IList<ProductBEAN> GetBEANProducts() //Gets list of products within a customised view with modified labels and text validation
        //{
        //    IQueryable<ProductBEAN> _productBEANs = from prod in _context.Product
        //                                            from mt in _context.Meat
        //                                            where prod.MeatId == mt.MeatId
        //                                            select new ProductBEAN
        //                                            {
        //                                                ProductId = prod.ProductId,
        //                                                Meat = mt.Name,
        //                                                MeatId = mt.MeatId,
        //                                                Name = prod.Name
        //                                            };

        //    return _productBEANs.ToList();
        //}








        //public ProductItemBEAN GetBEANProductItem(int id) //Gets specific ProductItem based on Id and displays it in customised view 
        //{
        //    IQueryable<ProductItemBEAN> _productItemBEAN = from proditems in _context.ProductItem
        //                                                   from prod in _context.Product
        //                                                   from measure in _context.Measurement
        //                                                   where proditems.ProductItemId == id
        //                                                   && proditems.ProductId == prod.ProductId
        //                                                    && proditems.MeasurementId == measure.MeasurementId
        //                                                   select new ProductItemBEAN
        //                                                   {
        //                                                       ProductItemId = proditems.ProductItemId,
        //                                                       Product = prod.Name,
        //                                                       Cost = proditems.Cost,
        //                                                       MeasurementId = proditems.MeasurementId,
        //                                                       MeasurementName = measure.MeasurementName,
        //                                                       Discontinued = proditems.Discontinued,
        //                                                       ProductId = prod.ProductId,
        //                                                       StockQty = proditems.StockQty
        //                                                   };

        //    return _productItemBEAN.ToList().First();
        //}


        public CropDataViewModel GetCropViewModel(int id)
        {
            IQueryable<CropDataViewModel> _cropDataViewModel = from crop in _context.Crop
                                                               from cropharv in _context.CropHarvest
                                                               from cropreq in _context.CropRequirements
                                                               where crop.cropID == cropharv.cropID
                                                               where crop.cropID == cropreq.cropID
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
            _context.Crop.Add(crop);
            _context.SaveChanges();

        }

        public void addCropHarvest (CropHarvest crop)
        {

            _context.CropHarvest.Add(crop);
            _context.SaveChanges();
        }

        public void addCropRequirements(CropRequirements crop)
        {

            _context.CropRequirements.Add(crop);
            _context.SaveChanges();
        }

        public void editCrop(Crop crop)
        {
            Crop myCrop = GetCrop(crop.cropID);

            myCrop.cropName = crop.cropName;

            _context.SaveChanges();


        }
        public void editCropHarvest(CropHarvest crop)
        {
            CropHarvest myCrop = GetCropHarvest(crop.cropID);

            myCrop.earliestHarvest = crop.earliestHarvest;
            myCrop.latestHarvest = crop.latestHarvest;
            myCrop.earliestPlant = crop.earliestPlant;
            myCrop.latestPlant = crop.latestPlant;
            myCrop.growthTime = crop.growthTime;

            _context.SaveChanges();


        }
        public void editCropRequirements(CropRequirements crop)
        {
            CropRequirements myCrop = GetCropRequirement(crop.cropID);

            myCrop.birdNetting = crop.birdNetting;
            myCrop.slugPellets = crop.slugPellets;
            myCrop.Feed = crop.Feed;
            myCrop.Water = crop.Water;

            _context.SaveChanges();


        }




    }
}
