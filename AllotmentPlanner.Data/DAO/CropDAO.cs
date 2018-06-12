using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllotmentPlanner.Data.IDAO;


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
            

    }
}
