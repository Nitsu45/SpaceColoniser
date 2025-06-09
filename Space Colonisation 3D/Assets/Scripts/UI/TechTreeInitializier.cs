using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TechTreeInitializier
    {
        List<TechNode> InitializisedNodes = new List<TechNode>();
        string[] technologylevel1Names = new string[] {"Scientific Research","Hydrolisis","Advanced Hull", "Orbitial spaceflight", "Spacetravel", "Housing development", "more efficient water production", "more efficient food production"};

        //Laden aller Bedingungen der einzelenen Nodes und Initialisieren dieser, in der richtigen Rangfolge, mit ihren jeweiligen Eigenschaften

        public TechTreeInitializier()
        { 
            //Initializing all Nodes with their names first


            //Then getting all the Nodes of the prerequisites by their name and save them in a list that is passed to FillingPrerequisites()

            //Then doing the same for the unlocks

            //Rinse and repeat until the whole list has been parsed through. Then pass the list back to The handler that Initialized this object.
        
        
        }


        void InitializingNode(string nodeName)
        {
            InitializisedNodes.Add(new TechNode(nodeName));
        }


        void FillingPrerequisites(TechNode Node, List<TechNode> Prerequisite)
        {
            Node.Prerequisites = Prerequisite;   
        }

        void FillingUnlocks(TechNode Node, List<TechNode> Unlocks) 
        {
            Node.Unlocks = Unlocks;
        }
        //Initialisieren der einzelnen Node und zufügen zur Liste

        //Anschließendes Übergeben der Nodes an den Tech tree handler


    }
}