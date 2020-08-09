using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//public class Buildings
//{
//    public static int villa = 0;
//    public static int hotel = 1;
//    public static int building = 2;
//}

public class BuildingMenuClick : MonoBehaviour
{

    public GameObject villaBtn;
    public GameObject buildingBtn;
    public GameObject hotelBtn;
    public GameObject buyingBtn;
    public GameObject cancelBtn;


    public Sprite villaBeforeClick;
    public Sprite villaAfterClick;
    public static bool villaBtnIsClicked;


    public Sprite buildingBeforeClick;
    public Sprite buildingAfterClick;
    public static bool buildingBtnIsClicked;

    public Sprite hotelBeforeClick;
    public Sprite hotelAfterClick;
    public static bool hotelBtnIsClicked;

    public Sprite buyingBeforeClick;
    public Sprite buyingAfterClick;
    public static bool buyingBtnIsClicked;

    public Sprite cancelBeforeClick;
    public Sprite cancelAfterClick;
    public static bool cancelBtnIsClicked;

    GameObject dice1, dice2;
    BuildingManager buildingManager;
    PlayerManager playerManager;

    void Start()
    {
        villaBtnIsClicked = false;
        buildingBtnIsClicked = false;
        hotelBtnIsClicked = false;
        buyingBtnIsClicked = false;
        cancelBtnIsClicked = false;
        dice1 = GameObject.Find("Dice");
        dice2 = GameObject.Find("Dice2");
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    public void VillaBtnClick()
    {
        villaBtn.GetComponent<Image>().sprite = villaAfterClick;
        villaBtnIsClicked = true;
        Debug.Log("클릭 " + villaBtnIsClicked);
        //if (!villaBtnIsClicked)
        //{
        //    villaBtn.GetComponent<Image>().sprite = villaAfterClick;
        //    villaBtnIsClicked = true;
        //    Debug.Log("클릭");
        //}
        //else
        //{
        //    villaBtn.GetComponent<Image>().sprite = villaBeforeClick;
        //    villaBtnIsClicked = false;
        //}

    }
    public void BuildingBtnClick()
    {
        buildingBtn.GetComponent<Image>().sprite = buildingAfterClick;
        buildingBtnIsClicked = true;
        //if (!buildingBtnIsClicked)
        //{ //안눌려져있을때 클릭하면 
        //    buildingBtn.GetComponent<Image>().sprite = buildingAfterClick;
        //    buildingBtnIsClicked = true;
        //}
        //else
        //{
        //    buildingBtn.GetComponent<Image>().sprite = buildingBeforeClick;
        //    buildingBtnIsClicked = false;
        //}


    }
    public void HotelBtnClick()
    {
        hotelBtn.GetComponent<Image>().sprite = hotelAfterClick;
        hotelBtnIsClicked = true;
        //if (!hotelBtnIsClicked)
        //{ //안눌려져있을때 클릭하면 
        //    hotelBtn.GetComponent<Image>().sprite = hotelAfterClick;
        //    hotelBtnIsClicked = true;
        //}
        //else
        //{
        //    hotelBtn.GetComponent<Image>().sprite = hotelBeforeClick;
        //    hotelBtnIsClicked = false;
        //}
    }

    public void BuyingBtnClick()
    {
        if (!buyingBtnIsClicked)
        { //안눌려져있을때 클릭하면 
            //buyingBtn.GetComponent<Image>().sprite = buyingAfterClick;
            //buyingBtnIsClicked = true;
            BuildingMenuControl.BuildingIsOpend = true;
            //GameObject.Find("Canvas").GetComponent<BuildingMenuControl>().b = true;
            
            if (villaBtnIsClicked)
            {
                buildingManager.Build(Buildings.villa);
            }
            if(hotelBtnIsClicked)
            {
                buildingManager.Build(Buildings.hotel);
            }
            if (buildingBtnIsClicked)
            {
                buildingManager.Build(Buildings.building);
            }

            villaBtnIsClicked = false;
            hotelBtnIsClicked = false;
            buildingBtnIsClicked = false;
            dice1.GetComponent<DiceScript>().MouseBtn = false;
            dice2.GetComponent<DiceScript>().MouseBtn = false;
        }
        else
        {
            buyingBtn.GetComponent<Image>().sprite = buyingBeforeClick;
            buyingBtnIsClicked = false;
        }

    }

    public void CancelBtnClick()
    {
        if (!cancelBtnIsClicked)
        { //안눌려져있을때 클릭하면 
            //cancelBtn.GetComponent<Image>().sprite = cancelAfterClick;
            //cancelBtnIsClicked = true;
            dice1.GetComponent<DiceScript>().MouseBtn = false;
            dice2.GetComponent<DiceScript>().MouseBtn = false;
            BuildingMenuControl.BuildingIsOpend = true;
            //GameObject.Find("Canvas").GetComponent<BuildingMenuControl>().b = true;
        }
        else
        {
            cancelBtn.GetComponent<Image>().sprite = cancelBeforeClick;
            cancelBtnIsClicked = false;
        }

    }

}
