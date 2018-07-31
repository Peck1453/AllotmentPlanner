using AllotmentPlanner.Data.ViewModel;
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
        IList<CropMaintenanceViewModel> getTendActions(string userId);
        IList<CropMaintenanceViewModel> loopTends(string userId, int plantedId);


        TendType getTend(int id);
        IList<Tended> GetTendActionsperPlanted(int plantedId, int tendedId);

        CropMaintenanceViewModel GetRecentTend(int tendId, int plantedId);

        void addTend(TendType tend);
        void editTend(TendType tend);
        void deleteTend(TendType tend);


        void setAsTended(Tended tended);


    }
}
