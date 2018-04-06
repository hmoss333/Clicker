using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour {

    public GameObject gameUI;
    public GameObject storeUI;
    
    // Use this for initialization
	void Start () {
        gameUI.SetActive(true);
        storeUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenStore ()
    {
        GameManager.paused = true;

        gameUI.SetActive(false);
        storeUI.SetActive(true);
    }

    public void CloseStore()
    {
        GameManager.paused = false;

        gameUI.SetActive(true);
        storeUI.SetActive(false);
    }

    public void BuyAutoClick(int cost)
    {
        if (GameManager.clickCount - cost >= 0)
        {
            if (!GameManager.isAutomated)
            {
                GameManager.isAutomated = true;
                PlayerPrefs.SetInt("isAutomated", 1);
                GameManager.clickCount -= cost;
                GameManager.UpdateUI();
            }
        }
    }

    public void BuyBonus (int cost)
    {
        if (GameManager.clickCount - cost >= 0)
        {
            GameManager.clickBonus++;
            GameManager.clickCount -= cost;
            GameManager.UpdateUI();
        }
    }

    public void BuyRate (int cost)
    {
        if (GameManager.clickCount - cost >= 0)
        {
            if (GameManager.isAutomated)
            {
                GameManager.clickRate += 0.1f;
                GameManager.clickCount -= cost;
                GameManager.UpdateUI();
            }
        }
    }
}
