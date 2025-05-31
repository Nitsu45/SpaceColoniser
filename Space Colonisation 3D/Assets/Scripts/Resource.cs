using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Resource
    {
        //Array with the names of all Resources in the game
        //This is used to get the field number in which a Resource is stored 
        public string[] resourceNamePosition = new string[] {"ore","rareEarths","coal", "uranium", "water", "energy", "researchPoints","manpower", "food", "maschine parts", "special tools" };
        public string[] staticResources = new string[] {"energy", "manpower"};




        public bool IsResourceStatic(string resourceName)
        {
            for (int i = 0; i < staticResources.Length; i++)
            {
                if (resourceName == staticResources[i]) return true;
            }
            return false;
        }

        public int ArrayPositionofResource(string resourceName)
        {
            for (int i = 0; i < resourceNamePosition.Length; i++)
            {
                if (resourceName == resourceNamePosition[i]) return i;
            }
            return -1;
        }

    }
}