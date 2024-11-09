using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeClass : MonoBehaviour
{
    public enum ManagerType
    {
        None = 0,
        Map = 1,
        Player = 2,
        Quest = 3,
        Customer = 4,
    }

    public ManagerType myType = ManagerType.None;
}

public class GameControl : MonoBehaviour
{
    public List<GameControlBase> Managers = new List<GameControlBase>();

    private MapManager mapManager;
    private CustomerManager customerManager;
    private PlayerManager PlayerManager;

    private void Awake()
    {
        if (Camera.main != null) Camera.main.gameObject.SetActive(false);
    }

    private void Start()
    {
        Init();

        mapManager.Open();
        customerManager.Open();
        PlayerManager.Open();
    }

    private void Init()
    {
        Managers.AddRange(gameObject.GetComponentsInChildren<GameControlBase>(true));

        for (int i = 0; i < Managers.Count; i++)
        {
            Managers[i].Init(TypeClass.ManagerType.Map + i);
        }

        mapManager = Managers.Find(x => x.myType == TypeClass.ManagerType.Map) as MapManager;
        customerManager = Managers.Find(x => x.myType == TypeClass.ManagerType.Customer) as CustomerManager;
        PlayerManager = Managers.Find(x => x.myType == TypeClass.ManagerType.Player) as PlayerManager;
    }
}