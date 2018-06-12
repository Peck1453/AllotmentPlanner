using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllotmentPlanner.Services.IService
{
    public interface ICropService
    {
        IList<AllotmentPlanner.Data.Crop> GetCrops();

    }
}
