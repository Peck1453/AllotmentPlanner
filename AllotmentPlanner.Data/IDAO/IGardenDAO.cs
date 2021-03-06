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
        //List Functions
        IList<AllotmentPlanner.Data.GardenLocation> GetActiveGardenLocations();
        IList<GardenLocation> GetInactiveGardenLocations();

        IList<GardenViewModel> ViewGardensinLocation(string pcode);
        IList<GardenViewModel> ViewEmptyGardensinLocation(string pcode);
        IList<UserGardenViewModel> GetUserGarden(string userId);
        IList<EditGardenViewModel> ListSelectedCrops(string userID);
        IList<Planted> getPlantedCrops();

        IList<Allotment> ListGardensbyPostCode(string pcode);


        IList<AllotmentAllocation> CountUserActiveGardens(string userId);


        int GetLastGardenId();
        Planted GetLastPlanted();


        //Get Specific Functions

        GardenLocation GetGardenLocation(string pcode);
        Allotment GetAllotment(int gardenId);
        GardenViewModel GetGardenViewModel(string pcode);
        AllotmentAllocation GetAllocatedAllotment(int gardenId);
        UserGardenViewModel GetGardenFromUser(string userId);
        Planted getPlantedCrop(int plantedId);


        //Edit Garden Functions

        void addGardenLocation(GardenLocation gardenLocation, Allotment allotment);
        void addGardentoAllotment(Allotment allotment);
        void AllocateGarden();
        void editGardenLocation(GardenLocation gardenLocation);
        void editGarden(Allotment allotment);
        void DeactivateGardenLocation(GardenLocation gardenLocation);
        void assignGardenerToGarden(AllotmentAllocation allotmentAllocation);
        void removeGardenerFromGarden(AllotmentAllocation allotmentAllocation);

        //Edit User Crop Functions
        void logCropAsPlanted(Planted planted);
        void logCropAsHarvested(Planted planted);
        void deletePlantedCrop(Planted planted);
        void addcropstogarden(Planted planted);

        //Tend Functionalities

        void setAsTended(Tended tended);


    }
}
