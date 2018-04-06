using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;

public class HoboController : MonoBehaviour {

    public int lifeSpan;
    public int incomeValue;
    int maxIncome = 5;

    public enum Addictions { weed, heroin, cocain, bathsalts }
    public List<Addictions> addictions;

    public enum Skills { perform , rant, harass }
    public List<Skills> skills;

    void Initialize()
    {
        lifeSpan = Random.Range(3, 11);
        incomeValue = Random.Range(1, maxIncome);

        addictions = RandomizeAddictions(addictions);
        skills = RandomizeSkills(skills);
    }

    // Use this for initialization
    void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
            Initialize();
	}

    List<Addictions> RandomizeAddictions(List<Addictions> addictionList)
    {
        addictionList.Clear();
        int randAmount = Random.Range(1, 3);

        for (int i = 0; i < randAmount; i++)
        {
            int randRange = Random.Range(0, 4);

            if (!addictionList.Contains((Addictions)randRange))
                addictionList.Add((Addictions)randRange);
            else
                i--;
        }

        return addictionList;
    }

    List<Skills> RandomizeSkills(List<Skills> skillList)
    {
        skillList.Clear();
        int randAmount = Random.Range(1, 3);

        for (int i = 0; i < randAmount; i++)
        {
            int randRange = Random.Range(0, 3);

            if (!skillList.Contains((Skills)randRange))
                skillList.Add((Skills)randRange);
            else
                i--;
        }

        return skillList;
    }
}
