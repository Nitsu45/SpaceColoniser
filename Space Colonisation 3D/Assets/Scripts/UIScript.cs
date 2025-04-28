using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    //References
    public Camera mainCamera;
    public Text OreProductionDisplay;
    public Text OreDisplay;
    public Text EnergyProductionDisplay;
    public Text ManPowerDisplay;
    public Text PlanetNameDisplay;

    public GameObject SelectedPlanet;

    Colonymechanics SelectedColony;
    ConstructionMechanics ConstructionScript;

    //Global variables


    // Start is called before the first frame update
    void Start()
    {
        SelectedColony = SelectedPlanet.GetComponent<Colonymechanics>();
        ConstructionScript = GetComponent<ConstructionMechanics>();
    }

    // Update is called once per frame
    void Update()
    {

        UpdateDisplay();
        lookAroundPlanet();
    }

    //Function to look around the Planet with the mouse
    void lookAroundPlanet()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * 20;

            mainCamera.transform.RotateAround(transform.position, new Vector3(0, mouseX, 0), 200f * Time.deltaTime);
        }
    }

    //Updates the displayed text with the current values of the selected Colony
    void UpdateDisplay()
    {
        PlanetNameDisplay.text = SelectedColony.planetName;
        OreProductionDisplay.text = $"Ore Production: {SelectedColony.oreProduction}/m";
        OreDisplay.text = $"Ore: {SelectedColony.planetStorage[0]}";
        EnergyProductionDisplay.text = $"Energy Production: {SelectedColony.planetStorage[1]}";
        ManPowerDisplay.text = $"Man Power:  {SelectedColony.planetStorage[2]}";
    }

    //Button functions
    //Button that allows you to buy a mine (temporary feature)
    public void BuyMineButton()
    {
        // Calling the ConstructBuilding function and pass the planet inventory and the building type
        //If there are enough resources the player can place the building and the cost ist subtracted from the inventory
        //if not it generates an error message
        string buildingToAdd = "mine";
        if (ConstructionScript.ConstructingBuilding(buildingToAdd, SelectedColony.planetStorage))
        {
            SelectedColony.AddingBuildingToColony(buildingToAdd);
            SelectedColony.planetStorage = ConstructionScript.SubstractingConstrctuionCosts(buildingToAdd, SelectedColony.planetStorage);
        }
        else Debug.Log("Building could not be constructed");
    }
    //Button that allows you to buy a powerplant (temporary feature)
    public void BuyPPButton()
    {
        string buildingToAdd = "powerplant";
        if (ConstructionScript.ConstructingBuilding(buildingToAdd, SelectedColony.planetStorage))
        {
            SelectedColony.AddingBuildingToColony(buildingToAdd);
            SelectedColony.planetStorage = ConstructionScript.SubstractingConstrctuionCosts(buildingToAdd, SelectedColony.planetStorage);
        }
        else Debug.Log("Building could not be constructed");
    }
    //Button that allows you to buy a house (temporary feature)
    public void BuyHouseButton()
    {
        string buildingToAdd = "house";
        if (ConstructionScript.ConstructingBuilding(buildingToAdd, SelectedColony.planetStorage))
        {
            SelectedColony.AddingBuildingToColony(buildingToAdd);
            SelectedColony.planetStorage = ConstructionScript.SubstractingConstrctuionCosts(buildingToAdd, SelectedColony.planetStorage);
        }
    }
    public void BuyRocketStationButton()
    {
        string buildingToAdd = "rocketstation";
        if (ConstructionScript.ConstructingBuilding(buildingToAdd, SelectedColony.planetStorage))
        {
            SelectedColony.AddingBuildingToColony(buildingToAdd);
            SelectedColony.planetStorage = ConstructionScript.SubstractingConstrctuionCosts(buildingToAdd, SelectedColony.planetStorage);
        }
    }

}
