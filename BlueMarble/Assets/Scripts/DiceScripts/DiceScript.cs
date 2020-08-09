using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DiceScript : MonoBehaviour
{
    enum MouseEvent
    {
        LEFTBUTTON = 0,
        RIGHTBUTTON,
        WHEELBUTTON

    }
    static Rigidbody rbOne; //Dice의 rigidbody
    static Rigidbody rbTwo; //Dice2의 rigidbody
    private bool mouseBtnCheck; //마우스가 눌렸는지 체크 
    public bool diceBtnPress;//주사위버튼이 눌렸는지 체크 


    public static Vector3 diceOneVelocity;
    public static Vector3 diceTwoVelocity;

    public bool MouseBtn {
        get { return mouseBtnCheck; }
        set { mouseBtnCheck = value; }
    }



    // Start is called before the first frame update
    void Start()
    {
        rbOne = GameObject.Find("Dice").GetComponent<Rigidbody>(); //initialization;
        rbTwo = GameObject.Find("Dice2").GetComponent<Rigidbody>(); //initialization;
        diceOneVelocity = new Vector3(0, 0, 0);
        diceTwoVelocity = new Vector3(0, 0, 0);

        mouseBtnCheck = false;
        diceBtnPress = false;

    }

    // Update is called once per frame
    void Update()
    {

        diceOneVelocity = rbOne.velocity;
        diceTwoVelocity = rbTwo.velocity;

        ////디버그 로그 
        //Debug.Log(rb.velocity);
        //Debug.Log(diceVelocity);
        //if (GameObject.Find("DiceBoard").GetComponent<DiceCheckScript>().DiceCal == 2)  //주사위 값계산이 다끝나면 
        //    mouseBtnCheck = false; //마우스를 클릭가능하도록 셋팅


        
        if (Input.GetMouseButtonDown((int)MouseEvent.LEFTBUTTON) && !mouseBtnCheck )   //주사위를 마우스왼쪽버튼 클릭한순간과 마우스는 한번만 눌린다.
        {
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 500.0f);
            if (didHit && rhInfo.collider.name.Equals("PressBtn")){ //주사위버튼을 눌렀을때에만 작동
                diceBtnPress = true; //주사위 버튼 눌림 .
                GameObject.Find("DiceBoard").GetComponent<DiceCheckScript>().DiceCal = 0;
                DiceNumberScript.diceOneNum = 0;
                DiceNumberScript.diceTwoNum = 0;
                mouseBtnCheck = true;

                float dirX = Random.Range(0, 500);
                float dirY = Random.Range(0, 500);
                float dirZ = Random.Range(0, 500);

                ////디버그 로그 
                //Debug.Log(dirX);
                //Debug.Log(dirY);
                //Debug.Log(dirZ);
                switch (this.gameObject.name) //gameObject이름으로 Dice와 Dice2를 구별하자.
                {
                    case "Dice":
                        this.transform.position = new Vector3(-16, 6, 9);  //마우스가 처음 던져지는 위치 셋팅 
                        this.transform.rotation = Quaternion.identity; //회전값 초기화 
                        rbOne.AddForce(transform.up * 200); //위로 힘작용 
                        rbOne.AddTorque(dirX, dirY, dirZ); //회전힘 적용     
                        break;
                    case "Dice2":
                        this.transform.position = new Vector3(-11, 5, 9);  //마우스가 처음 던져지는 위치 셋팅 
                        this.transform.rotation = Quaternion.identity; //회전값 초기화 
                        rbTwo.AddForce(transform.up * 200); //위로 힘작용 
                        rbTwo.AddTorque(dirX, dirY, dirZ); //회전힘 적용 

                        break;
                }
            }

        }

    }
    
}
