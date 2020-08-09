using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


class Tile
{
    public string[] tileName = { "시작", "Argentina", "Austrailia", "China", "Canada", "Denmark", "Egypt",
                                "bonus1", "England", "France", "Germany", "Greece", "Hungary", "India",
                                "bonus2", "Italy", "Japan", "Mexico","NorthKorea", "Norway", "Russia",
                                "bonus3", "SaudiArabia", "Senegal", "SouthKorea", "Spain", "USA", "Vietnam"
    };

    public string[] villaPrices = {"None","550","530","510","570","590","540",
                                    "None","650","630","610","670","690","640",
                                    "None","750","730","710","770","790","740",
                                    "None","850","830","810","870","890","840"
    };
    public string[] buildingPrices = {"None","1550","1530","1510","1570","1590","1540",
                                    "None","1650","1630","1610","1670","1690","1640",
                                    "None","1750","1730","1710","1770","1790","1740",
                                    "None","1850","1830","1810","1870","1890","1840"

    };
    public string[] hotelPrices = {"None","2550","2530","2510","2570","2590","2540",
                                  "None","2650","2630","2610","2670","2690","2640",
                                  "None","2750","2730","2710","2770","2790","2740",
                                  "None","2850","2830","2810","2870","2890","2840",
    };
}

public class Buildings
{
    public static int villa = 0;
    public static int building = 1;
    public static int hotel = 2;
}



public class BuildingMenuControl : MonoBehaviour
{
    public static bool BuildingIsOpend = true;
    public GameObject BuildingMenuUI;
    BuildingManager buildingManager;
    PlayerManager playerManager;
    public Button TileName, VillaPrice, BuildingPrice, HotelPrice, TotalPrice;

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

    public Sprite cancelBeforeClick;
    public Sprite cancelAfterClick;

    GameObject dice1, dice2;
    public GameObject diceNumber;
    Tile tileInfo;
    public static bool b = true;
    GameObject mainCamera, miniGameCamera;
    public GameObject asset1, asset2;

    public static int time = 0;
    public GameObject tollText;
    public int total = 0;
    public GameObject reward;
    void Start()
    {
        villaBtnIsClicked = false;
        buildingBtnIsClicked = false;
        hotelBtnIsClicked = false;
        dice1 = GameObject.Find("Dice");
        dice2 = GameObject.Find("Dice2");
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        mainCamera = GameObject.Find("MainCamera");
        miniGameCamera = GameObject.Find("MiniGameCamera");
        tileInfo = new Tile();
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        asset1 = GameObject.Find("1P_asset");
        asset2 = GameObject.Find("2P_asset");

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerManager.GetComponent<PlayerManager>().turn == 0 && buildingManager.ownInfos[playerManager.GetComponent<PlayerManager>().player[0].position].owner != 2)
        {
            if (!BuildingIsOpend && !playerManager.GetComponent<PlayerManager>().player[0].isMove) //player가 다 돌았을때
            {
                if (b)
                {
                    Purchase(playerManager.GetComponent<PlayerManager>().player[0].position);
                }
            }
        }
        else if (playerManager.GetComponent<PlayerManager>().turn != 0 && buildingManager.ownInfos[playerManager.GetComponent<PlayerManager>().player[1].position].owner != 1)
        {
            if (!BuildingIsOpend && !playerManager.GetComponent<PlayerManager>().player[1].isMove) //player가 다 돌았을때,
            {
                if (b)
                {
                    Purchase(playerManager.GetComponent<PlayerManager>().player[1].position);
                }
            }
        }
        else
        {
            if (playerManager.GetComponent<PlayerManager>().turn == 0)
            {
                if (playerManager.player[0].isAnotherPlayerZone && !playerManager.GetComponent<PlayerManager>().player[0].isMove)
                {
                    time++;
                    int v = 0, bd = 0, h = 0;
                    int position = playerManager.GetComponent<PlayerManager>().player[0].position;
                    //다른 플레이어 땅위에 올라갔다는 ui 띄우기
                    if (time < 70)
                    {
                        if (buildingManager.ownInfos[position].hasVilla)
                        {
                            v = int.Parse(tileInfo.villaPrices[position]);
                        }
                        if (buildingManager.ownInfos[position].hasHotel)
                        {
                            h = int.Parse(tileInfo.buildingPrices[position]);
                        }

                        if (buildingManager.ownInfos[position].hasBuilding)
                        {
                            bd = int.Parse(tileInfo.hotelPrices[position]);
                        }
                        total = v + h + bd;
                        
                        tollText.GetComponent<Text>().text = "통행료 " + total.ToString() + " 지불";
                        tollText.SetActive(true);

                    }
                    else
                    {
                        //------------추가된 부분
                        if (int.Parse(asset1.GetComponent<Text>().text) - total < 0)
                        {
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

                        }
                        //-----------
                        asset1.GetComponent<Text>().text = (int.Parse(asset1.GetComponent<Text>().text) - total).ToString();
                        tollText.SetActive(false);
                        playerManager.player[0].isAnotherPlayerZone = false;
                        dice1.GetComponent<DiceScript>().MouseBtn = false;
                        dice2.GetComponent<DiceScript>().MouseBtn = false;
                        time = 0;
                        BuildingIsOpend = true;
                    }

                }
            }
            else
            {
                if (playerManager.player[1].isAnotherPlayerZone && !playerManager.GetComponent<PlayerManager>().player[1].isMove)
                {
                    //다른 플레이어 땅위에 올라갔다는 ui 띄우기
                    time++;
                    int v = 0, bd = 0, h = 0;
                    int position = playerManager.GetComponent<PlayerManager>().player[1].position;

                    if (time < 70)
                    {
                        if (buildingManager.ownInfos[position].hasVilla)
                        {
                            v = int.Parse(tileInfo.villaPrices[position]);
                        }

                        if (buildingManager.ownInfos[position].hasHotel)
                        {
                            h = int.Parse(tileInfo.buildingPrices[position]);
                        }

                        if (buildingManager.ownInfos[position].hasBuilding)
                        {
                            bd = int.Parse(tileInfo.hotelPrices[position]);
                        }
                        total = v + h + bd;
                        tollText.GetComponent<Text>().text = "통행료 " + total.ToString() + " 지불";
                        tollText.SetActive(true);
                    }
                    else
                    {
                        //------------추가된 부분
                        if(int.Parse(asset2.GetComponent<Text>().text)-total <0)
                        {
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                        }
                        //-----------
                        asset2.GetComponent<Text>().text = (int.Parse(asset2.GetComponent<Text>().text) - total).ToString();
                        tollText.SetActive(false);
                        playerManager.player[1].isAnotherPlayerZone = false;
                        dice1.GetComponent<DiceScript>().MouseBtn = false;
                        dice2.GetComponent<DiceScript>().MouseBtn = false;
                        time = 0;
                        BuildingIsOpend = true;
                    }
                }
            }

        }

    }

    void Purchase(int position)
    {
        if (position == 0)
        {
            dice1.GetComponent<DiceScript>().MouseBtn = false;
            dice2.GetComponent<DiceScript>().MouseBtn = false;
            BuildingIsOpend = true;
        }
        else if (position == 7)
        {
            diceNumber.SetActive(false);
            mainCamera.GetComponent<Camera>().enabled = false;
            miniGameCamera.GetComponent<Camera>().enabled = true;
            BuildingIsOpend = true;
            Wheel.mouseBtnCheck = true;
        }
        else if (position == 14)
        {
            playerManager.GetComponent<PlayerManager>().setMuindo();
            playerManager.GetComponent<PlayerManager>().UpdateTurn();
            b = false;
            MuindoUI.UIOpend = true;
        }
        else if (position == 21)
        {
            diceNumber.SetActive(false);
            mainCamera.GetComponent<Camera>().enabled = false;
            miniGameCamera.GetComponent<Camera>().enabled = true;
            BuildingIsOpend = true;
            Wheel.mouseBtnCheck = true;
        }
        else
        {
            TileName.GetComponentInChildren<TextMeshProUGUI>().text = tileInfo.tileName[position];
            VillaPrice.GetComponentInChildren<TextMeshProUGUI>().text = tileInfo.villaPrices[position];
            BuildingPrice.GetComponentInChildren<TextMeshProUGUI>().text = tileInfo.buildingPrices[position];
            HotelPrice.GetComponentInChildren<TextMeshProUGUI>().text = tileInfo.hotelPrices[position];
            TotalPrice.GetComponentInChildren<TextMeshProUGUI>().text = "0";

            if (buildingManager.ownInfos[position].hasVilla)
            {
                villaBtn.GetComponent<Image>().sprite = villaAfterClick;
                villaBtn.GetComponent<Button>().interactable = false;
            }
            else
            {
                villaBtn.GetComponent<Image>().sprite = villaBeforeClick;
                villaBtn.GetComponent<Button>().interactable = true;
            }
            if (buildingManager.ownInfos[position].hasHotel)
            {
                buildingBtn.GetComponent<Image>().sprite = buildingAfterClick;
                buildingBtn.GetComponent<Button>().interactable = false;
            }
            else
            {
                buildingBtn.GetComponent<Image>().sprite = buildingBeforeClick;
                buildingBtn.GetComponent<Button>().interactable = true;
            }
            if (buildingManager.ownInfos[position].hasBuilding)
            {
                hotelBtn.GetComponent<Image>().sprite = hotelAfterClick;
                hotelBtn.GetComponent<Button>().interactable = false;
            }
            else
            {
                hotelBtn.GetComponent<Image>().sprite = hotelBeforeClick;
                hotelBtn.GetComponent<Button>().interactable = true;
            }

            BuildingMenuUI.SetActive(true);
            b = false;
        }

    }

    public void VillaBtnClick()
    {

        if (!villaBtnIsClicked)
        {
            villaBtn.GetComponent<Image>().sprite = villaAfterClick;
            TotalPrice.GetComponentInChildren<TextMeshProUGUI>().text =
                (int.Parse(TotalPrice.GetComponentInChildren<TextMeshProUGUI>().text) +
                    int.Parse(VillaPrice.GetComponentInChildren<TextMeshProUGUI>().text)).ToString();
            villaBtnIsClicked = true;
        }
        else
        {
            villaBtn.GetComponent<Image>().sprite = villaBeforeClick;
            TotalPrice.GetComponentInChildren<TextMeshProUGUI>().text =
                (int.Parse(TotalPrice.GetComponentInChildren<TextMeshProUGUI>().text) -
                    int.Parse(VillaPrice.GetComponentInChildren<TextMeshProUGUI>().text)).ToString();
            villaBtnIsClicked = false;
        }
    }
    public void BuildingBtnClick()
    {
        if (!buildingBtnIsClicked)
        {
            buildingBtn.GetComponent<Image>().sprite = buildingAfterClick;
            TotalPrice.GetComponentInChildren<TextMeshProUGUI>().text =
                (int.Parse(TotalPrice.GetComponentInChildren<TextMeshProUGUI>().text) +
                    int.Parse(BuildingPrice.GetComponentInChildren<TextMeshProUGUI>().text)).ToString();
            buildingBtnIsClicked = true;
        }
        else
        {
            buildingBtn.GetComponent<Image>().sprite = buildingBeforeClick;
            TotalPrice.GetComponentInChildren<TextMeshProUGUI>().text =
                (int.Parse(TotalPrice.GetComponentInChildren<TextMeshProUGUI>().text) -
                    int.Parse(BuildingPrice.GetComponentInChildren<TextMeshProUGUI>().text)).ToString();
            buildingBtnIsClicked = false;
        }

    }
    public void HotelBtnClick()
    {
        if (!hotelBtnIsClicked)
        {
            hotelBtn.GetComponent<Image>().sprite = hotelAfterClick;
            TotalPrice.GetComponentInChildren<TextMeshProUGUI>().text =
                (int.Parse(TotalPrice.GetComponentInChildren<TextMeshProUGUI>().text) +
                    int.Parse(HotelPrice.GetComponentInChildren<TextMeshProUGUI>().text)).ToString();
            hotelBtnIsClicked = true;
        }
        else
        {
            hotelBtn.GetComponent<Image>().sprite = hotelBeforeClick;
            TotalPrice.GetComponentInChildren<TextMeshProUGUI>().text =
              (int.Parse(TotalPrice.GetComponentInChildren<TextMeshProUGUI>().text) -
                  int.Parse(HotelPrice.GetComponentInChildren<TextMeshProUGUI>().text)).ToString();
            hotelBtnIsClicked = false;
        }

    }

    public void BuyingBtnClick()
    {
        BuildingIsOpend = true;
        BuildingMenuUI.SetActive(false);
        b = true;

        int position = 100, assets = 0;

        if (playerManager.GetComponent<PlayerManager>().turn == 0)
        {

            position = playerManager.GetComponent<PlayerManager>().player[0].position;
            assets = int.Parse(asset1.GetComponent<Text>().text);
        }
        else if (playerManager.GetComponent<PlayerManager>().turn != 0)
        {
            position = playerManager.GetComponent<PlayerManager>().player[1].position;
            assets = int.Parse(asset2.GetComponent<Text>().text);
        }

        int buy = 0;
        if (villaBtnIsClicked)
        {
            buy += int.Parse(tileInfo.villaPrices[position]);
        }
        if (hotelBtnIsClicked)
        {
            buy += int.Parse(tileInfo.hotelPrices[position]);
        }
        if (buildingBtnIsClicked)
        {
            buy += int.Parse(tileInfo.buildingPrices[position]);
        }

        if (assets - buy > 0)
        {
            if (villaBtnIsClicked)
            {
                buildingManager.Build(Buildings.villa);
            }
            if (hotelBtnIsClicked)
            {
                buildingManager.Build(Buildings.hotel);
            }
            if (buildingBtnIsClicked)
            {
                buildingManager.Build(Buildings.building);
            }
        }
        villaBtnIsClicked = false;
        hotelBtnIsClicked = false;
        buildingBtnIsClicked = false;
        dice1.GetComponent<DiceScript>().MouseBtn = false;
        dice2.GetComponent<DiceScript>().MouseBtn = false;

    }

    public void CancelBtnClick()
    {
        dice1.GetComponent<DiceScript>().MouseBtn = false;
        dice2.GetComponent<DiceScript>().MouseBtn = false;
        BuildingIsOpend = true;
        b = true;
        BuildingMenuUI.SetActive(false);
    }
}


