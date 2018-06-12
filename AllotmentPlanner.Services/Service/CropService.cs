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
    public class CropService : AllotmentPlanner.Services.IService.ICropService
    {
        private ICropDAO _cropDAO;

        public CropService()
        {
            _cropDAO = new CropDAO();
        }

        public IList<AllotmentPlanner.Data.Crop> GetCrops()
        {
            return _cropDAO.GetCrops();
        }


    }
}
