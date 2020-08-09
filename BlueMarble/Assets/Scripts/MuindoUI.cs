using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuindoUI : MonoBehaviour
{
    public GameObject muindoUI;
    public static bool UIOpend = false;
    public static int time = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (UIOpend)
        {
            muindoUI.SetActive(true);
            time++;
            if(time > 70)
            {
                BuildingMenuControl.b = true;
                BuildingMenuControl.BuildingIsOpend = true;
                UIOpend = false;
                muindoUI.SetActive(false);
                GameObject.Find("Dice").GetComponent<DiceScript>().MouseBtn = false;
                GameObject.Find("Dice2").GetComponent<DiceScript>().MouseBtn = false;
                time = 0;
            }
        }

    }
}
