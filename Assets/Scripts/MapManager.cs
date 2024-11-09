using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : GameControlBase
{
    private List<GameObject> Floors = new List<GameObject>();
    private List<GameObject> Walls = new List<GameObject>();
    private float posX_floor = 0;
    private float posZ_floor = 0;
    private float posX_wall = -2.5f;
    private float posZ_wall = -3;

    public override void Init(ManagerType _type)
    {
        base.Init(_type);
    }

    public override void Open()
    {
        base.Open();

        FloorSetting();
        WallSetting();
        ObjectSetting();
    }

    private void FloorSetting()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i == 0 && j == 3)
                {
                    var questobj = Instantiate(Resources.Load("Prefabs/Floor_04") as GameObject, new Vector3(posX_floor, 0, posZ_floor), Quaternion.identity);
                    questobj.transform.SetParent(GameObject.Find("Floors").transform);
                    Floors.Add(questobj);

                    continue;
                }

                var obj = Instantiate(Resources.Load("Prefabs/Floor_02") as GameObject, new Vector3(posX_floor, 0, posZ_floor), Quaternion.identity);
                obj.transform.SetParent(GameObject.Find("Floors").transform);
                Floors.Add(obj);

                posZ_floor += 6;
            }

            posX_floor += 7.5f;
            posZ_floor = 0;
        }
    }
    private void WallSetting()
    {
        for (int i = 0; i < 15; i++)
        {
            var obj = Instantiate(Resources.Load("Prefabs/Wall") as GameObject, new Vector3(posX_wall, 0, -3), Quaternion.identity);
            obj.transform.SetParent(GameObject.Find("Walls").transform);
            Walls.Add(obj);

            posX_wall += 1.4f;
        }
        for (int j = 0; j < 17; j++)
        {
            var obj = Instantiate(Resources.Load("Prefabs/Wall") as GameObject, new Vector3(-3.5f, 0, posZ_wall), Quaternion.Euler(0, 90, 0));
            obj.transform.SetParent(GameObject.Find("Walls").transform);
            Walls.Add(obj);

            posZ_wall += 1.4f;
        }
    }
    private void ObjectSetting()
    {
        var wallscount = Walls.Count - 1;

        for (int i = 0; i < 3; i++)
        {
            Walls[wallscount - 7].SetActive(false);
            wallscount--;
        }

        var entrance = Instantiate(Resources.Load("Prefabs/Entrance") as GameObject, new Vector3(-3.8f, 0, 8.9f), Quaternion.Euler(0, 90, 0));
        var breadoven = Instantiate(Resources.Load("Prefabs/BreadOven") as GameObject, new Vector3(10, 0, 3), Quaternion.Euler(0, 90, 0));
        var basket = Instantiate(Resources.Load("Prefabs/Basket") as GameObject, new Vector3(12.5f, 0, 3), Quaternion.identity);
        var tablepos = Instantiate(Resources.Load("Prefabs/TableShort") as GameObject, new Vector3(9, 0, 11), Quaternion.Euler(0, 90, 0));
        var gaidesign = Instantiate(Resources.Load("Prefabs/GuideSign") as GameObject, new Vector3(1.5f, 1, 3), Quaternion.identity);
        var collidercheck1 = Instantiate(Resources.Load("Prefabs/collidercheck") as GameObject, new Vector3(2.53f, 0, 4.73f), Quaternion.identity);
        var collidercheck2 = Instantiate(Resources.Load("Prefabs/collidercheck") as GameObject, new Vector3(4.17f, 0, 3.44f), Quaternion.Euler(0, 270, 0));
        var collidercheck3 = Instantiate(Resources.Load("Prefabs/collidercheck") as GameObject, new Vector3(4.17f, 0, 9), Quaternion.identity);
        entrance.transform.SetParent(GameObject.Find("Objects").transform);
        breadoven.transform.SetParent(GameObject.Find("Objects").transform);
        basket.transform.SetParent(GameObject.Find("Objects").transform);
        tablepos.transform.SetParent(GameObject.Find("Objects").transform);
        gaidesign.transform.SetParent(GameObject.Find("Objects").transform);
        collidercheck1.transform.SetParent(GameObject.Find("basketpoint").transform);
        collidercheck2.transform.SetParent(GameObject.Find("basketpoint").transform);
        collidercheck3.transform.SetParent(GameObject.Find("basketpoint").transform);
    }
    private void QuestClear_FloorWallChange()
    {
        var posZ_window = 19.1f;
        var wallscount = Walls.Count - 1;
        for (int i = 0; i < 3; i++)
        {
            var obj = Instantiate(Resources.Load("Prefabs/Wall_Window_01") as GameObject, new Vector3(-3.5f, 0, posZ_window), Quaternion.Euler(0, 90, 0));
            obj.transform.SetParent(GameObject.Find("Objects").transform);

            posZ_window -= 1.9f;
        }
        for (int i = 0; i < 4; i++)
        {
            //Walls[wallscount].SetActive(false);
            Destroy(Walls[wallscount]);
            wallscount--;
        }
    }
}
