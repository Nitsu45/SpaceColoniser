using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Resource
    {
        //Array with the names of all Resources in the game
        //This is used to get the field number in which a Resource is stored 
        public string[] ResourceNamePosition = new string[] {"ore","rareEarths","coal", "uranium", "water", "energy", "researchPoints","manpower", "food", "maschine parts", "special tools" }; 




        public int ArrayPositionofResource(string resourceName)
        {
            for (int i = 0; i < ResourceNamePosition.Length; i++)
            {
                if (resourceName == ResourceNamePosition[i]) return i;
            }
            return -1;
        }

    }
}