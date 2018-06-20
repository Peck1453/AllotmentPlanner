using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllotmentPlanner.Data;
using AllotmentPlanner.Data.IDAO;
using AllotmentPlanner.Data.DAO;
using AllotmentPlanner.Data.ViewModel;

namespace AllotmentPlanner.Services.Service
{
    public class TendService : AllotmentPlanner.Services.IService.ITendService
    {
        private ITendDAO _tendDAO;

        public TendService()
        {
            _tendDAO = new TendDAO();
        }



        public IList<AllotmentPlanner.Data.TendType> getTends()
        {

            return _tendDAO.getTends();

        }

        public TendType getTend(int id)
        {

            return _tendDAO.getTend(id);

        }

        public void addTend(TendType tend)
        {

            _tendDAO.addTend(tend);
        }

        public void editTend(TendType tend)
        {

            _tendDAO.editTend(tend);

        }
        public void deleteTend(TendType tend)
        {

            _tendDAO.deleteTend(tend);

        }

    }
}
