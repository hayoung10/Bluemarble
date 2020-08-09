using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    PlayerManager playerManager; //playerManager
    public float moveDistance;
    public float moveDistanceUnit;
    public int moveCount, position;
    public float currentX /*= 0*/, currentZ /*= -3.96f*/;

    //rotation을 도는 지점들의 최대,최소 postion
    public float minXpos;
    public float maxXpos;
    public float minZpos;
    public float maxZpos;

    int dir;
    public bool isMove;
    public bool isAnotherPlayerZone = false;


    private Animator anim;
    BuildingMenuControl buildingMenuControl;
    public int time = 0;
    public GameObject asset1, asset2;

    // Start is called before the first frame update
    void Start()
    {
        //1북서(왼쪽위), 2북동(오른쪽위), 3남동(오른쪽아래), 4남서(왼쪽아래)
        dir = 2;
        position = 0;
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        buildingMenuControl = GameObject.Find("Canvas").GetComponent<BuildingMenuControl>();
        anim = GetComponent<Animator>();
        asset1 = GameObject.Find("1P_asset");
        asset2 = GameObject.Find("2P_asset");
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time > 70)
        {
            buildingMenuControl.reward.SetActive(false);
            time = 0;
        }
        if (dir == 1)
        {
            if (this.transform.position.x > currentX - moveDistance)
            {
                isMove = true;
                BuildingMenuControl.BuildingIsOpend = false;
                isAnotherPlayerZone = true;
                this.transform.Translate(Vector3.left * 10 * Time.deltaTime);
                anim.SetBool("isRun", true); //달리기 이벤트 활성화 

            }
            else
            {
                isMove = false;
                anim.SetBool("isRun", false); //대기상태 이벤트 
            }
            if (this.transform.position.x <= maxXpos/*-27.72*/)
            {
                this.transform.eulerAngles = new Vector3(0, -90, 0);
                moveCount -= round((currentX - this.transform.position.x) / 3.96f);
                moveDistance = moveCount * moveDistanceUnit;
                dir = 4;
                currentX = transform.position.x;
            }

        }
        else if (dir == 2)
        {
            if (this.transform.position.z < currentZ + moveDistance)
            {
                isMove = true;
                BuildingMenuControl.BuildingIsOpend = false;
                isAnotherPlayerZone = true;
                this.transform.Translate(Vector3.left * 10 * Time.deltaTime);
                anim.SetBool("isRun", true);//달리기 이벤트 활성화

            }
            else
            {
                isMove = false;
                anim.SetBool("isRun", false);//대기상태 이벤트 
            }
            if (this.transform.position.z >= minZpos/*23.76*/)
            {
                this.transform.eulerAngles = new Vector3(0, 0, 0);
                moveCount -= round((this.transform.position.z - currentZ) / 3.96f);
                moveDistance = moveCount * moveDistanceUnit;
                dir = 1;
                currentZ = transform.position.z;
            }

        }

        else if (dir == 3)
        {
            if (this.transform.position.x < currentX + moveDistance)
            {
                isMove = true;
                BuildingMenuControl.BuildingIsOpend = false;
                isAnotherPlayerZone = true;
                this.transform.Translate(Vector3.left * 10 * Time.deltaTime);
                anim.SetBool("isRun", true);//달리기 이벤트 활성화 
            }
            else
            {
                isMove = false;
                anim.SetBool("isRun", false);//대기상태 이벤트 
            }
            if (this.transform.position.x >= minXpos/*0*/)
            {
                this.transform.eulerAngles = new Vector3(0, 90, 0);
                moveCount -= round((this.transform.position.x - currentX) / 3.96f);
                moveDistance = moveCount * moveDistanceUnit;
                dir = 2;
                currentX = transform.position.x;
                buildingMenuControl.reward.GetComponent<Text>().text = "완주 보상 1000";
                buildingMenuControl.reward.SetActive(true);
                if (playerManager.GetComponent<PlayerManager>().turn == 0)
                {
                    asset1.GetComponent<Text>().text = (int.Parse(asset1.GetComponent<Text>().text) + 1000).ToString();
                }
                else
                {
                    asset2.GetComponent<Text>().text = (int.Parse(asset2.GetComponent<Text>().text) + 1000).ToString();
                }
                time = 0;
            }

        }
        else if (dir == 4)
        {
            if (this.transform.position.z > currentZ - moveDistance)
            {
                isMove = true;
                BuildingMenuControl.BuildingIsOpend = false;
                isAnotherPlayerZone = true;
                this.transform.Translate(Vector3.left * 10 * Time.deltaTime);
                anim.SetBool("isRun", true);//달리기 이벤트 활성화 
            }
            else
            {
                isMove = false;
                anim.SetBool("isRun", false);//대기상태 이벤트 
            }
            if (this.transform.position.z <= maxZpos/*-3.96*/)
            {
                this.transform.eulerAngles = new Vector3(0, -180, 0);
                moveCount -= round((currentZ - this.transform.position.z) / 3.96f);
                moveDistance = moveCount * moveDistanceUnit;
                dir = 3;
                currentZ = transform.position.z;
            }

        }

    }


    private int round(float f)
    {
        int result = 0;

        if (f - (int)f <= 0.5f)
        {
            result = (int)f;
        }
        else
        {
            result = (int)f + 1;
        }

        return result;
    }

}
