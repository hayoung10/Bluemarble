using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class Wheel : MonoBehaviour
{
    public static bool mouseBtnCheck;
    Quaternion defaultAngle;
    float angle;
    float rotateSpeed;
    float rotateAcceleration;
    bool isRotate;
    bool finish;
    bool change;

    public GameObject wheelScore;
    public GameObject mainCamera;
    public GameObject miniGameCamera;
    public GameObject diceNumber;
    public GameObject playerManager;
    public GameObject wheelname;
    public float result;
    GameObject asset1, asset2;


    // Start is called before the first frame update
    void Start()
    {
        mouseBtnCheck = false;
        isRotate = false;
        defaultAngle = this.transform.rotation;
        wheelScore.SetActive(false);
        wheelname = GameObject.Find("PlusMinus");
        wheelname.SetActive(false);
        playerManager = GameObject.Find("PlayerManager");
        asset1 = GameObject.Find("1P_asset");
        asset2 = GameObject.Find("2P_asset");
        finish = false;
        change = false;
        result = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerManager.GetComponent<PlayerManager>().turn == 0)
        {
            if (playerManager.GetComponent<PlayerManager>().player[0].position == 7)
            {
                wheelname.GetComponent<Text>().text = "알거지 돌림판";
            }
            else if (playerManager.GetComponent<PlayerManager>().player[0].position == 21)
            {
                wheelname.GetComponent<Text>().text = "벼락부자 돌림판";
            }
        }
        else
        {
            if (playerManager.GetComponent<PlayerManager>().player[1].position == 7)
            {
                wheelname.GetComponent<Text>().text = "알거지 돌림판";
            }
            else if (playerManager.GetComponent<PlayerManager>().player[1].position == 21)
            {
                wheelname.GetComponent<Text>().text = "벼락부자 돌림판";
            }
        }
        if (mouseBtnCheck) // 마우스 클릭시 원판회전 
        {
            wheelname.SetActive(true);
            wheelScore.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                GetAngle(); //회전할 각도 random함수로 생성
            }
        }
        if (angle > 0) // 회전각이 0보다 크면 회전시킴
        {
            if (angle < 540) // 회전각이 540 이하가 되면 가속도를 주어서 천천히 멈추게함
            {
                if (rotateSpeed > 2)
                {
                    rotateSpeed -= rotateAcceleration;
                }
                transform.Rotate(new Vector3(0, 0, rotateSpeed));
                angle -= rotateSpeed;
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, rotateSpeed));
                angle -= rotateSpeed;
            }
        }
        else
        {
            if (isRotate) //회전각을 얻으면 isRotate 값을 true로 바꿔서 결과를 한번만 출력하게함
                          //결과 출력후 원판 각도를 초기값으로 맞추었을 때 결과값이 다시 바뀌지 않기위함
            {
                //각도에 따른 결과값 일단 텍스트에 표시
                result = transform.eulerAngles.z;
                if (result > 16 && result < 103)
                {
                    wheelScore.GetComponent<Text>().text = "700";
                }
                else if (result > 103 && result < 255)
                {
                    wheelScore.GetComponent<Text>().text = "500";
                }
                else if (result > 255 && result < 316)
                {
                    wheelScore.GetComponent<Text>().text = "1000";
                }
                else if (result > 316 && result < 346)
                {
                    wheelScore.GetComponent<Text>().text = "2000";
                }
                else
                {
                    wheelScore.GetComponent<Text>().text = "5000";
                }
                isRotate = false;
                finish = true;

            }
            
        }
        // 메인카메라로 다시 전환 
        // 일단은 마우스 오른쪽 버튼으로 해놓음
        if (finish)
        {
            finish = false;
            StartCoroutine(Example());
            

            // 자산 관리
            int score = int.Parse(wheelScore.GetComponent<Text>().text);
            if (playerManager.GetComponent<PlayerManager>().turn == 0)
            {
                int assets = int.Parse(asset1.GetComponent<Text>().text);
                if (playerManager.GetComponent<PlayerManager>().player[0].position == 7)
                {
                    //추가된부분
                    if (assets - score <0)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                    }
                    //
                    asset1.GetComponent<Text>().text = (assets - score).ToString();
                }
                else if (playerManager.GetComponent<PlayerManager>().player[0].position == 21)
                {
                    asset1.GetComponent<Text>().text = (assets + score).ToString();
                }
            }
            else
            {
                int assets = int.Parse(asset2.GetComponent<Text>().text);
                if (playerManager.GetComponent<PlayerManager>().player[1].position == 7)
                {
                    //추가된부분
                    if (assets - score <0)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                    //
                    asset2.GetComponent<Text>().text = (assets - score).ToString();
                }
                else if (playerManager.GetComponent<PlayerManager>().player[1].position == 21)
                {
                    asset2.GetComponent<Text>().text = (assets + score).ToString();
                }
            }           
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(2); // 대기 2초
        
        mainCamera.GetComponent<Camera>().enabled = true;
        miniGameCamera.GetComponent<Camera>().enabled = false;

        diceNumber.SetActive(true);
        mouseBtnCheck = false;
        GameObject.Find("Dice").GetComponent<DiceScript>().MouseBtn = false;
        GameObject.Find("Dice2").GetComponent<DiceScript>().MouseBtn = false;
        BuildingMenuControl.b = true;
        BuildingMenuControl.BuildingIsOpend = true;
        transform.rotation = defaultAngle; // 원판 각도를 처음 값으로 초기화
        wheelScore.SetActive(false);
        wheelScore.GetComponent<Text>().text = "start";
        wheelname.SetActive(false);
    }

    void GetAngle()
    {
        wheelScore.SetActive(true);
        angle = Random.Range(720, 1440);
        rotateSpeed = 10;
        rotateAcceleration = 0.1f;
        mouseBtnCheck = false;
        isRotate = true;
    }
}
