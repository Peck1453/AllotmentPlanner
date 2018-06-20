using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllotmentPlanner.Data.IDAO;

namespace AllotmentPlanner.Data.DAO
{

    public class TendDAO: ITendDAO
    {

        private AllotmentEntities _context;
        public TendDAO()
        {

            _context = new AllotmentEntities();
        }




        public IList<AllotmentPlanner.Data.TendType> getTends()
        {
            IQueryable<TendType> _tends;
            _tends = from TendType
                    in _context.TendType
                     select TendType;
            return _tends.ToList();



        }
        public TendType getTend(int id)
        {
            IQueryable<TendType> _tend;

            _tend = from tend
                    in _context.TendType
                    where tend.tendId == id
                    select tend;

            return _tend.ToList().First();


        }

        public void addTend(TendType tend)
        {
            _context.TendType.Add(tend);
            _context.SaveChanges();


        }

        public void editTend(TendType tend)
        {
            TendType mytend = getTend(tend.tendId);

            mytend.tendName = tend.tendName;

            _context.SaveChanges();


        }
        public void deleteTend(TendType tend)
        {
            TendType myTend = getTend(tend.tendId);

            _context.TendType.Remove(myTend);
            _context.SaveChanges();


        }


    }
}
