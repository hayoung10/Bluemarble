using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OwnInfo
{
    public int owner = 0;
    public bool hasVilla = false;
    public bool hasHotel = false;
    public bool hasBuilding = false;
}

class Tile2
{
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

public class BuildingManager : MonoBehaviour
{
    public GameObject VillaObject1, HotelObject1, BuildingObject1, VillaObject2, HotelObject2, BuildingObject2, playerManager;
    GameObject asset1, asset2;
    PlayerMove Player1, Player2;
    Vector3[] villaPositions = { new Vector3(0,0,0), new Vector3(-1, 4, -0.89f), new Vector3(-1,4,3.07f), new Vector3(-1, 4, 7.03f),
                           new Vector3(-1, 4, 10.99f), new Vector3(-1, 4, 14.96f), new Vector3(-1, 4, 18.91f), new Vector3(0, 0, 0),
                            new Vector3(-2.8f, 4, 22.5f), new Vector3(-6.76f, 4, 22.5f), new Vector3(-10.72f, 4, 22.5f), new Vector3(-14.68f, 4, 22.5f),
                            new Vector3(-18.64f, 4, 22.5f), new Vector3(-22.6f, 4, 22.5f), new Vector3(0, 0, 0), new Vector3(-26.8f, 4, 20.7f),
                            new Vector3(-26.8f, 4, 16.74f), new Vector3(-26.8f, 4, 12.78f), new Vector3(-26.8f, 4, 8.82f), new Vector3(-26.8f, 4, 4.86f),
                            new Vector3(-26.8f, 4, 0.9f), new Vector3(0, 0, 0), new Vector3(-24.5f, 4, -3), new Vector3(-20.54f, 4, -3), new Vector3(-16.58f, 4, -3),
                            new Vector3(-12.62f, 4, -3), new Vector3(-8.66f, 4, -3), new Vector3(-4.7f, 4, -3)};

    Vector3[] hotelPositions = { new Vector3(0,0,0), new Vector3(-1, 4, 0f), new Vector3(-1,4,3.96f), new Vector3(-1, 4, 7.92f),
                           new Vector3(-1, 4, 11.88f), new Vector3(-1, 4, 15.84f), new Vector3(-1, 4, 19.8f), new Vector3(0, 0, 0),
                            new Vector3(-3.69f, 4, 22.5f), new Vector3(-7.65f, 4, 22.5f), new Vector3(-11.61f, 4, 22.5f), new Vector3(-15.57f, 4, 22.5f),
                            new Vector3(-19.53f, 4, 22.5f), new Vector3(-23.49f, 4, 22.5f), new Vector3(0, 0, 0), new Vector3(-26.8f, 4, 19.81f),
                            new Vector3(-26.8f, 4, 15.85f), new Vector3(-26.8f, 4, 11.89f), new Vector3(-26.8f, 4, 7.93f), new Vector3(-26.8f, 4, 3.97f),
                            new Vector3(-26.8f, 4, 0.01f), new Vector3(0, 0, 0), new Vector3(-23.61f, 4, -3), new Vector3(-19.65f, 4, -3), new Vector3(-15.69f, 4, -3),
                            new Vector3(-11.72f, 4, -3), new Vector3(-7.77f, 4, -3), new Vector3(-3.81f, 4, -3)};

    Vector3[] buildingPositions = { new Vector3(0,0,0), new Vector3(-1, 4, 1f), new Vector3(-1,4, 4.96f), new Vector3(-1, 4, 8.92f),
                           new Vector3(-1, 4, 12.88f), new Vector3(-1, 4, 16.84f), new Vector3(-1, 4, 20.8f), new Vector3(0, 0, 0),
                            new Vector3(-4.69f, 4, 22.5f), new Vector3(-8.65f, 4, 22.5f), new Vector3(-12.61f, 4, 22.5f), new Vector3(-16.57f, 4, 22.5f),
                            new Vector3(-20.53f, 4, 22.5f), new Vector3(-24.49f, 4, 22.5f), new Vector3(0, 0, 0), new Vector3(-26.8f, 4, 18.81f),
                            new Vector3(-26.8f, 4, 14.85f), new Vector3(-26.8f, 4, 10.89f), new Vector3(-26.8f, 4, 6.93f), new Vector3(-26.8f, 4, 2.97f),
                            new Vector3(-26.8f, 4, -1.01f), new Vector3(0, 0, 0), new Vector3(-22.71f, 4, -3), new Vector3(-18.75f, 4, -3), new Vector3(-14.79f, 4, -3),
                            new Vector3(-10.83f, 4, -3), new Vector3(-6.87f, 4, -3), new Vector3(-2.91f, 4, -3)};

    public OwnInfo[] ownInfos = { new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(),
                                  new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(),
                                  new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(),
                                  new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo(), new OwnInfo() };
    Tile2 tileinfo;

    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.Find("Player1").GetComponent<PlayerMove>();
        Player2 = GameObject.Find("Player2").GetComponent<PlayerMove>();
        playerManager = GameObject.Find("PlayerManager");
        asset1 = GameObject.Find("1P_asset");
        asset2 = GameObject.Find("2P_asset");
        tileinfo = new Tile2();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Build(int building)
    {
        if (playerManager.GetComponent<PlayerManager>().turn == 0)
        {
            ownInfos[Player1.position].owner = 1;
            int assets = int.Parse(asset1.GetComponent<Text>().text);
            switch (building)
            {
                case 0:
                    int villaprice = int.Parse(tileinfo.villaPrices[playerManager.GetComponent<PlayerManager>().player[0].position]);
                    if (assets - villaprice > 0)
                    {
                        GameObject villaObject = Instantiate(VillaObject1) as GameObject;
                        villaObject.transform.position = villaPositions[Player1.position];
                        ownInfos[Player1.position].hasVilla = true;
                        asset1.GetComponent<Text>().text = (assets - villaprice).ToString();
                    }
                    break;
                case 1:
                    int hotelprice = int.Parse(tileinfo.buildingPrices[playerManager.GetComponent<PlayerManager>().player[0].position]);
                    if (assets - hotelprice > 0)
                    {
                        GameObject hotelObject = Instantiate(HotelObject1) as GameObject;
                        hotelObject.transform.position = hotelPositions[Player1.position];
                        ownInfos[Player1.position].hasHotel = true;
                        asset1.GetComponent<Text>().text = (assets - hotelprice).ToString();
                    }
                    break;
                case 2:
                    int buildingprice = int.Parse(tileinfo.hotelPrices[playerManager.GetComponent<PlayerManager>().player[0].position]);
                    if (assets - buildingprice > 0)
                    {
                        GameObject buildingObject = Instantiate(BuildingObject1) as GameObject;
                        buildingObject.transform.position = buildingPositions[Player1.position];
                        ownInfos[Player1.position].hasBuilding = true;
                        asset1.GetComponent<Text>().text = (assets - buildingprice).ToString();
                    }
                    break;
            }
        }
        else
        {
            ownInfos[Player2.position].owner = 2;
            int assets = int.Parse(asset2.GetComponent<Text>().text);
            switch (building)
            {
                case 0:
                    int villaprice = int.Parse(tileinfo.villaPrices[playerManager.GetComponent<PlayerManager>().player[1].position]);
                    if (assets - villaprice > 0)
                    {
                        GameObject villaObject = Instantiate(VillaObject2) as GameObject;
                        villaObject.transform.position = villaPositions[Player2.position];
                        ownInfos[Player2.position].hasVilla = true;
                        asset2.GetComponent<Text>().text = (assets - villaprice).ToString();
                    }
                    break;
                case 1:
                    int hotelprice = int.Parse(tileinfo.buildingPrices[playerManager.GetComponent<PlayerManager>().player[1].position]);
                    if (assets - hotelprice > 0)
                    {
                        GameObject hotelObject = Instantiate(HotelObject2) as GameObject;
                        hotelObject.transform.position = hotelPositions[Player2.position];
                        ownInfos[Player2.position].hasHotel = true;
                        asset2.GetComponent<Text>().text = (assets - hotelprice).ToString();
                    }
                    break;
                case 2:
                    int buildingprice = int.Parse(tileinfo.hotelPrices[playerManager.GetComponent<PlayerManager>().player[1].position]);
                    if (assets - buildingprice > 0)
                    {
                        GameObject buildingObject = Instantiate(BuildingObject2) as GameObject;
                        buildingObject.transform.position = buildingPositions[Player2.position];
                        ownInfos[Player2.position].hasBuilding = true;
                        asset2.GetComponent<Text>().text = (assets - buildingprice).ToString();
                    }
                    break;
            }
        }

    }

}

