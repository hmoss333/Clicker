using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int clickCount;
    public static int clickBonus;
    public static float clickRate;

    public static bool paused;
    public static bool isAutomated;
    bool startAuto;

    public Text scoreUI;
    private static Text refUI; //dumb; needed to be used in static function
    
    // Use this for initialization
	void Start () {
        clickCount = 0;
        clickBonus = 0;
        clickRate = 1f;
        paused = false;
        isAutomated = false;
        startAuto = false;
        //PlayerPrefs.SetInt("isAutomated", 0); //for testing

        refUI = scoreUI;

        LoadConfigs();
	}
	
	// Update is called once per frame
	void Update () {
        if (!paused)
        {
            PlayerPrefs.SetInt("clickCount", clickCount);
            PlayerPrefs.SetInt("clickBonus", clickBonus);
            PlayerPrefs.SetFloat("clickRate", clickRate);

            if (isAutomated && !startAuto)
            {
                StartCoroutine(AutoClick(clickRate));
                startAuto = true;
            }
        }
	}

    void LoadConfigs ()
    {
        //set all saved data here
        clickCount = PlayerPrefs.GetInt("clickCount", 0);
        clickBonus = PlayerPrefs.GetInt("clickBonus", 0);
        clickRate = PlayerPrefs.GetFloat("clickRate", 1f);

        if (PlayerPrefs.GetInt("isAutomated") == 1)
            isAutomated = true;
        else
            isAutomated = false;

        scoreUI.text = "Score: " + clickCount.ToString() + "\nBonus: " + clickBonus + "\nRate: " + clickRate;
    }

    public void Click ()
    {
        clickCount++;
        clickCount += clickBonus;

        UpdateUI();
        //scoreUI.text = "Score: " + clickCount.ToString() + "\nBonus: " + clickBonus + "\nRate: " + clickRate;
    }

    IEnumerator AutoClick (float interval)
    {
        while (paused)
            yield return null;

        Click();
        yield return new WaitForSeconds(1 / interval);
        Coroutine co = StartCoroutine(AutoClick(clickRate));
    }

    public static void UpdateUI()
    {
         refUI.text = "Score: " + clickCount.ToString() + "\nBonus: " + clickBonus + "\nRate: " + clickRate;
    }
}
