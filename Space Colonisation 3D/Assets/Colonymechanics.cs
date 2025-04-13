using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colonymechanics : MonoBehaviour
{
    public int oreProduction = 0;
    public int energyProduction = 0;
    public int manpower = 0;


    int[] planetStorage = new int[2] {0,0};
    List<string> colonyBuildingsList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //Check buildings list and adjust resource production
        foreach (var item in colonyBuildingsList)
        {
            switch(item)
            {
                
                case "mine":
                    oreProduction =+ 50;
                    break;
                case "energyProduction":
                    energyProduction =+ 50;
                    break;
                case "house":
                    manpower =+ 50;
                    break;
                default:
                    Debug.Log("No resource Building");
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        planetStorage[0] =+ oreProduction; 
        planetStorage[1] =+ energyProduction;
        planetStorage[2] = manpower;
    }
}
