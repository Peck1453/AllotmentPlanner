﻿using AllotmentPlanner.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllotmentPlanner.Data.IDAO
{
    public interface IGardenDAO
    {
        IList<AllotmentPlanner.Data.GardenLocation> GetGardenLocations();

        GardenLocation GetGardenLocation(string pcode);
        void editGarden(GardenLocation gardenLocation);

        void addGarden(GardenLocation gardenLocation);
        void DeleteGarden(GardenLocation gardenLocation);



    }
}
