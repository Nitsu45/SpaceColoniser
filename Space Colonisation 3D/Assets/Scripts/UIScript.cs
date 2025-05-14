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
    public Button LaunchRocketButton;
    public Button PlanetSwitchButton;

    public GameObject nextPlanet;
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

            mainCamera.transform.RotateAround(SelectedPlanet.transform.position, new Vector3(0, mouseX, 0), 200f * Time.deltaTime);
        }
    }

    //Updates the displayed text with the current values of the selected Colony
    void UpdateDisplay()
    {
        //PlanetNameDisplay.text = SelectedColony.planetName;
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
        if (ConstructionScript.ConstructingBuilding(buildingToAdd, SelectedColony))
        {
            
        }
        else Debug.Log("Building could not be constructed");
    }
    //Button that allows you to buy a powerplant (temporary feature)
    public void BuyPPButton()
    {
        string buildingToAdd = "powerplant";
        if (ConstructionScript.ConstructingBuilding(buildingToAdd, SelectedColony))
        {
           
        }
        else Debug.Log("Building could not be constructed");
    }
    //Button that allows you to buy a house (temporary feature)
    public void BuyHouseButton()
    {
        string buildingToAdd = "house";
        if (ConstructionScript.ConstructingBuilding(buildingToAdd, SelectedColony))
        {
            
        }
    }
    //Button that allows you to buy a Rocket Station (temporary feature)
    public void BuyRocketStationButton()
    {
        string buildingToAdd = "rocketstation";
        if (ConstructionScript.ConstructingBuilding(buildingToAdd, SelectedColony))
        {
            
        }
    }
    //Button that allows you to buy a Space Station (temporary feature)
    public void BuySpaceStationButton()
    {
        //Check if a rocket Station exists on the planet
        //THen allow the player to build a Space Sation on the next planet
    }
    //Here should be a button opening the rocket station menu when the building is selected
    public void LaunchRocketButtonFunction()
    {
        // The player should be able to select a planet to shoot the rocket to, but for development purposes it's just one other planet that get's choosen automatically
        // Add Space Station building to Testplanet1 when the player has enough resources
        // Add possibility to switch to the other Planet
        

        if (!SelectedColony.hasRocketStation) return;
        nextPlanet.GetComponent<Colonymechanics>().AddingBuildingToColony(ConstructionScript.spacestation);
        ChangePlanets();    
        

    }
    //Method to change the planet the Player is currently playing on
    //Developersnote: the Camera switches to a constant position
    public void ChangePlanets()
    {
        GameObject Planetbuffer = SelectedPlanet;
        //reseting camer to standard position
        mainCamera.transform.rotation = Quaternion.identity;
        Vector3 standartPosition = new Vector3(0f - mainCamera.transform.position.x, 0, 0);
        
        mainCamera.transform.Translate(standartPosition);
        

        SelectedPlanet = nextPlanet;
        nextPlanet = Planetbuffer; 
        SelectedColony = SelectedPlanet.GetComponent<Colonymechanics>();
        ConstructionScript = GetComponent<ConstructionMechanics>();
        PlanetNameDisplay.text = SelectedPlanet.name;

        //Moving Camera to the next planet
        
        Vector3 difference = new Vector3(SelectedPlanet.transform.position.x - mainCamera.transform.position.x, SelectedPlanet.transform.position.y - mainCamera.transform.position.y, SelectedPlanet.transform.position.z - 3.5f - mainCamera.transform.position.z);
        mainCamera.transform.Translate(difference);
        //mainCamera.transform.LookAt(SelectedPlanet.transform);


    }


}
