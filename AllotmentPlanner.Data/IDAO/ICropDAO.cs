using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllotmentPlanner.Data.IDAO
{
    public interface ICropDAO
    {
        IList<AllotmentPlanner.Data.Crop> GetCrops();

    }
}
