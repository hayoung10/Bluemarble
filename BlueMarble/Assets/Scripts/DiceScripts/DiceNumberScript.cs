using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberScript : MonoBehaviour
{
    public Text text;
    public static int diceOneNum;
    public static int diceTwoNum;
    //public bool isDone = false; //다 끝났는지 체크 
    public int totalDiceNum;
    bool s = true;

    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "0";
        totalDiceNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        totalDiceNum = diceOneNum + diceTwoNum;
        text.text = totalDiceNum.ToString();

        //if (totalDiceNum != 0 && s)
        //{

        //    text.text = totalDiceNum.ToString();

        //    Debug.Log("이동 : " + totalDiceNum);

        //    s = false;

        //    GameObject.Find("PlayerManager").GetComponent<PlayerManager>().isDone = true;
        //}

        //if (totalDiceNum == 0 && !s)
        //{
        //    text.text = totalDiceNum.ToString();
        //    s = true;


        //}
    }

}
