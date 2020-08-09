using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckScript : MonoBehaviour
{
    Vector3 diceOneVelocity;
    Vector3 diceTwoVelocity;
    private DiceScript diceScript;
    private byte diceCal;//diceCalculation

    public byte DiceCal
    {
        get { return diceCal; }
        set { diceCal = value; }
    }



    void Start()
    {
        diceScript = GameObject.Find("Dice").GetComponent<DiceScript>(); //for mouseBtnCheck 
        diceCal = 0;
        
    }

    void FixedUpdate()
    {
        diceOneVelocity = DiceScript.diceOneVelocity; //velocity of Dice
        diceTwoVelocity = DiceScript.diceTwoVelocity; //velocity of Dice2


    }


    void OnTriggerStay(Collider collider)  //충돌이 되고 있을때마다 호출 
    {
        if (2 == diceCal) { } //값계산이 끝났으면 
                              //diceCal = 0;

        //dice,dice2의 속도가 모두 0일때= 주사위가 굴려지고  모두 멈춰있을때 and  마우스 버튼이 한번누른상태일때만  
        else if ((diceScript.MouseBtn) && diceOneVelocity.x == 0f && diceOneVelocity.y == 0f && diceOneVelocity.z == 0f &&
            diceTwoVelocity.x == 0f && diceTwoVelocity.y == 0f && diceTwoVelocity.z == 0f)
        {
            diceCal++;
            switch (collider.gameObject.name) //오브젝트 이름을 확인해서 
            {
                //Dice
                case "Side11": //Side1이면 
                    DiceNumberScript.diceOneNum = 6;  //주사위수는 반대수로 셋팅 
                                                      //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
                    break;
                case "Side12":
                    DiceNumberScript.diceOneNum = 5;
                    //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
                    break;
                case "Side13":
                    DiceNumberScript.diceOneNum = 4;
                    //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
                    break;
                case "Side14":
                    DiceNumberScript.diceOneNum = 3;
                    //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
                    break;
                case "Side15":
                    DiceNumberScript.diceOneNum = 2;
                    //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
                    break;
                case "Side16":
                    DiceNumberScript.diceOneNum = 1;
                    //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
                    break;
                //Dice2 
                case "Side21": //Side1이면 
                    DiceNumberScript.diceTwoNum = 6;  //주사위수는 반대수로 셋팅 
                                                      //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
                    break;
                case "Side22":
                    DiceNumberScript.diceTwoNum = 5;
                    //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
                    break;
                case "Side23":
                    DiceNumberScript.diceTwoNum = 4;
                    //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
                    break;
                case "Side24":
                    DiceNumberScript.diceTwoNum = 3;
                    //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
                    break;
                case "Side25":
                    DiceNumberScript.diceTwoNum = 2;
                    //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
                    break;
                case "Side26":
                    DiceNumberScript.diceTwoNum = 1;
                    //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
                    break;

            }

            ////무인도 테스트용
            //if (GameObject.Find("PlayerManager").GetComponent<PlayerManager>().turn == 0)
            //{
            //    switch (collider.gameObject.name) //오브젝트 이름을 확인해서 
            //    {
            //        //Dice
            //        case "Side11": //Side1이면 
            //            DiceNumberScript.diceOneNum = 3;  //주사위수는 반대수로 셋팅 
            //                                              //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
            //            break;
            //        case "Side12":
            //            DiceNumberScript.diceOneNum = 3;
            //            //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
            //            break;
            //        case "Side13":
            //            DiceNumberScript.diceOneNum = 3;
            //            //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
            //            break;
            //        case "Side14":
            //            DiceNumberScript.diceOneNum = 3;
            //            //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
            //            break;
            //        case "Side15":
            //            DiceNumberScript.diceOneNum = 3;
            //            //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
            //            break;
            //        case "Side16":
            //            DiceNumberScript.diceOneNum = 3;
            //            //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
            //            break;
            //        //Dice2 
            //        case "Side21": //Side1이면 
            //            DiceNumberScript.diceTwoNum = 4;  //주사위수는 반대수로 셋팅 
            //                                              //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
            //            break;
            //        case "Side22":
            //            DiceNumberScript.diceTwoNum = 4;
            //            //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
            //            break;
            //        case "Side23":
            //            DiceNumberScript.diceTwoNum = 4;
            //            //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
            //            break;
            //        case "Side24":
            //            DiceNumberScript.diceTwoNum = 4;
            //            //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
            //            break;
            //        case "Side25":
            //            DiceNumberScript.diceTwoNum = 4;
            //            //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
            //            break;
            //        case "Side26":
            //            DiceNumberScript.diceTwoNum = 4;
            //            //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
            //            break;

            //    }
            //}
            //else
            //{
            //    switch (collider.gameObject.name)
            //    {

            //        ////주사위 7만 나오게 하는 코드
            //        case "Side11": //Side1이면 
            //            DiceNumberScript.diceOneNum = 2;  //주사위수는 반대수로 셋팅 
            //            //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
            //            break;
            //        case "Side12":
            //            DiceNumberScript.diceOneNum = 2;
            //            //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
            //            break;
            //        case "Side13":
            //            DiceNumberScript.diceOneNum = 2;
            //            //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
            //            break;
            //        case "Side14":
            //            DiceNumberScript.diceOneNum = 2;
            //            //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
            //            break;
            //        case "Side15":
            //            DiceNumberScript.diceOneNum = 2;
            //            //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
            //            break;
            //        case "Side16":
            //            DiceNumberScript.diceOneNum = 2;
            //            //Debug.Log("Dice의 주사위눈:" + DiceNumberScript.diceOneNum);
            //            break;
            //        //Dice2 
            //        case "Side21": //Side1이면 
            //            DiceNumberScript.diceTwoNum = 2;  //주사위수는 반대수로 셋팅 
            //            //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
            //            break;
            //        case "Side22":
            //            DiceNumberScript.diceTwoNum = 2;
            //            //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
            //            break;
            //        case "Side23":
            //            DiceNumberScript.diceTwoNum = 2;
            //            //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
            //            break;
            //        case "Side24":
            //            DiceNumberScript.diceTwoNum = 2;
            //            //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
            //            break;
            //        case "Side25":
            //            DiceNumberScript.diceTwoNum = 2;
            //            //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
            //            break;
            //        case "Side26":
            //            DiceNumberScript.diceTwoNum = 2;
            //            //Debug.Log("Dice2의 주사위눈:" + DiceNumberScript.diceTwoNum);
            //            break;
            //    }
            //}

        }

    }
}
