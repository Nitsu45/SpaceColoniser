using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TechNode 
{
    public int costs = 0;
    public string Name;
    public List<TechNode> Prerequisites;
    public List<TechNode> Unlocks;

    public bool IsResearched;

        public TechNode(string name)
        {
            Name = name;
            Prerequisites = new List<TechNode>();
            Unlocks = new List<TechNode>();
            IsResearched = false;
        }

        public bool CanResearch()
        {
            return Prerequisites.All(p => p.IsResearched);
        }

        public bool Research()
        {
            if (!CanResearch()) return false;
                

            IsResearched = true;
            return true;
        }

}
