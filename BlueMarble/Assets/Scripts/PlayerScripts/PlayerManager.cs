using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public enum TURN
    {
        PLAYER1 = 0,
        PLAYER2
    }
    public PlayerMove[] player;  //player 2명 
    DiceNumberScript diceNumScript;
    DiceCheckScript diceCheckScript;
    public bool isDone;

    public TURN turn;
    int[] muindoTurn = new int[2];

    public GameObject mTxt1, mTxt2, turnTxt;

    //Initialization
    void Start()
    {
        player = new PlayerMove[2];
        player[0] = GameObject.Find("Player1").GetComponent<PlayerMove>();
        player[1] = GameObject.Find("Player2").GetComponent<PlayerMove>();
        isDone = false;
        turn = TURN.PLAYER1; //첫번쩨는 player1차례

        for (int i = 0; i < player.Length; i++)
        {
            player[i].moveDistance = 0;
            player[i].moveCount = 0;
            player[i].position = 0;
            muindoTurn[i] = 0;
        }


        //player1(파란색)
        player[0].currentX = 1.38f;
        player[0].currentZ = -3.96f;
        player[0].minXpos = 1.38f;
        player[0].maxXpos = -28.0f;
        player[0].minZpos = 24.0f;
        player[0].maxZpos = -4.2f;
        player[0].moveDistanceUnit = 4.2f;


        //player2(빨간색)
        player[1].currentX = 0;
        player[1].currentZ = -3.96f;
        player[1].minXpos = 0;
        player[1].maxXpos = -27.72f;
        player[1].minZpos = 23.76f;
        player[1].maxZpos = -3.96f;
        player[1].moveDistanceUnit = 3.96f;



        diceNumScript = GameObject.Find("DiceNumber").GetComponent<DiceNumberScript>();
        diceCheckScript = GameObject.Find("DiceBoard").GetComponent<DiceCheckScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //turnTxt.GetComponent<Text>().text = turn.ToString();
        //mTxt1.GetComponent<Text>().text = muindoTurn[0].ToString();
        //mTxt2.GetComponent<Text>().text = muindoTurn[1].ToString();
        if (!isDone && diceNumScript.totalDiceNum != 0 &&
            GameObject.Find("DiceBoard").GetComponent<DiceCheckScript>().DiceCal == 2) //주사위를 돌린후 움직일 이동값 계산
        {
            player[(int)turn].moveCount = diceNumScript.totalDiceNum;
            player[(int)turn].moveDistance = diceNumScript.totalDiceNum * 3.96f;
            player[(int)turn].position += diceNumScript.totalDiceNum;
            //player[(int)turn].moveCount = 7;
            //player[(int)turn].moveDistance = 7 * 3.96f;
            //player[(int)turn].position += 7;
            if (player[(int)turn].position > 27)
                player[(int)turn].position %= 28;

            player[(int)turn].currentX = player[(int)turn].transform.position.x;
            player[(int)turn].currentZ = player[(int)turn].transform.position.z;
            isDone = true;
        }
        if (muindoTurn[1] != 0 && muindoTurn[0] != 0)
        {
            if (muindoTurn[0] > muindoTurn[1])
            {
                muindoTurn[0] -= muindoTurn[1];
                muindoTurn[1] = 0;
            }
            else
            {
                muindoTurn[1] -= muindoTurn[0];
                muindoTurn[0] = 0;
            }
        }
        if (isDone && diceNumScript.totalDiceNum == 0) //다시 주사위를 돌릴경우
        {
            isDone = false;
            if (turn == TURN.PLAYER2 && muindoTurn[0] != 0)
            {
                muindoTurn[0]--;
                BuildingMenuControl.b = true;
            }
            else if (turn == TURN.PLAYER1 && muindoTurn[1] != 0)
            {
                muindoTurn[1]--;
                BuildingMenuControl.b = true;
            }
            else
            {
                UpdateTurn(); //턴 교체
            }
        }


    }

    public void UpdateTurn()
    {
        if (TURN.PLAYER1 == turn)
            turn = TURN.PLAYER2;
        else if (TURN.PLAYER2 == turn)
            turn = TURN.PLAYER1;
    }

    public void setMuindo()
    {
        muindoTurn[(int)turn] = 3;
    }



}
