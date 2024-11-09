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
    private static GameControl instance;
    public static GameControl Instance
    {
        get { return instance; }
    }

    public List<GameControlBase> Managers = new List<GameControlBase>();
    public List<CustomerPositionCheck> BasketPosition = new List<CustomerPositionCheck>();

    private MapManager mapManager;
    private CustomerManager customerManager;
    private PlayerManager playerManager;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Init();

        mapManager.Open();
        customerManager.Open();
        playerManager.Open();

        BasketPosition.AddRange(GameObject.Find("basketpoint").gameObject.GetComponentsInChildren<CustomerPositionCheck>());
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
        playerManager = Managers.Find(x => x.myType == TypeClass.ManagerType.Player) as PlayerManager;
    }
}
