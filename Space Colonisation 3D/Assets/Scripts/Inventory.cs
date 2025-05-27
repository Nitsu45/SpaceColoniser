using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Inventory 
    {
        string[] resourceIDs;
        int[] resourceCounter; //The counter holds the amount of resource in the field with the same position as the respective Resources BuildingName in resource IDs (i.e. if ore is on position 0 in resources IDs the amount of ore is also saved in 0 in resourceCounter)
        //The Inventory gives the ability to create a custom Resource Inventory with either all or part of the Resources available in the game 
        public Inventory(string[]resourceNames)
        {
            resourceIDs = resourceNames;
            resourceCounter = new int[resourceNames.Length];
        }
        
        public bool AddToInventory(string resourceName, int amount)
        {
            for (int i = 0; i < resourceIDs.Length; i++)
            {
                if (resourceIDs[i] == resourceName)
                {
                    resourceCounter[i] = resourceCounter[i] + amount;
                    return true;
                }

            }
            return false;
        }

        public bool SubstracFromInventory(string resourceName, int amount)
        {
            for (int i = 0; i < resourceIDs.Length; i++)
            {
                if (resourceIDs[i] == resourceName)
                {
                    resourceCounter[i] = resourceCounter[i] - amount;
                    return true;
                }

            }
            return false;

        }

        //Gives back the position in the Inventory array of the resources in the parameter
        public int[] ArryPositionInInventory(string[] resourceNames)
        {
            bool resourceExist;
            int[] positionOfNames = new int[resourceNames.Length];
            for (int i = 0; i < resourceNames.Length; i++)
            {
                resourceExist = false;
                for (int i1 = 0; i1 < resourceIDs.Length; i1++)
                {
                    if (resourceIDs[i1] == resourceNames[i])
                    {
                        positionOfNames[i] = i1;
                        resourceExist = true;
                        break;
                    }
                    
                }
                if(!resourceExist) positionOfNames[i] = -1;
            }
            return positionOfNames;
        }



        public string[] ResourcesStoredInInventory()
        {
            return resourceIDs;
        }

        public int GetResourceAmount(string resourceName)
        {
            for (int i = 0; i < resourceIDs.Length; i++)
            { 
                if(resourceName == resourceIDs[i]) return resourceCounter[i];
            }
            return -1;   
        }

        public bool SetResourceAmount(string resourceName, int amount)
        {
            for (int i = 0; i < resourceIDs.Length; i++)
            {
                if (resourceName == resourceIDs[i])
                {
                    resourceCounter[i] = amount;
                    return true;
                }
            }
            return false;
        }
        public int GetLenghtOfInventory()
        { 
            return resourceIDs.Length; 
        }

    }
}