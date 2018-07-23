using AllotmentPlanner.Data;
using AllotmentPlanner.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllotmentPlanner.Services.IService
{
    public interface ITendService
    {
        IList<AllotmentPlanner.Data.TendType> getTends();
        IList<CropMaintenanceViewModel> getTendActions(string userId);
        IList<CropMaintenanceViewModel> loopTends(string userId);


        TendType getTend(int id);
        void addTend(TendType tend);
        void editTend(TendType tend);
        void deleteTend(TendType tend);


        void setAsTended(Tended tended);
    }
}

