using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllotmentPlanner.Data.IDAO
{
    public interface ITendDAO
    {

        IList<AllotmentPlanner.Data.TendType> getTends();
        TendType getTend(int id);
        void addTend(TendType tend);
        void editTend(TendType tend);
        void deleteTend(TendType tend);


    }
}
