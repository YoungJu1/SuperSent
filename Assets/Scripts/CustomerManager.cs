using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : GameControlBase
{
    public enum CustomerState
    {
        None=0,
        BasketCase1=1,
        BasketCase2=2,
        TakeOut=3,
        Sitting=4,
    }

    public int customerCount = 10;

    private List<GameObject> Customers = new List<GameObject>();
    private float currentTime = 0f;
    private int activeCount = 0;
    private bool setPooling = false;

    public override void Init(ManagerType _type)
    {
        base.Init(_type);
    }
    public override void Open()
    {
        base.Open();

        CreateObject();
    }

    private void CreateObject()
    {
        for (int i = 0; i < customerCount; i++)
        {
            var customerobj = Instantiate(Resources.Load("Prefabs/Customer") as GameObject, new Vector3(-4.7f, 0, 9), Quaternion.Euler(0, 90, 0));
            customerobj.transform.SetParent(GameObject.Find("Customers").transform);
            if (i % 2 == 0) customerobj.GetComponent<CustomerMove>().myState = CustomerState.BasketCase1;
            else customerobj.GetComponent<CustomerMove>().myState = CustomerState.BasketCase2;
            customerobj.SetActive(false);

            Customers.Add(customerobj);
        }

        setPooling = true;
    }

    private void Update()
    {
        if (!setPooling) return;

        currentTime += Time.deltaTime;

        if (currentTime > 1f)
        {
            for (int i = 0; i < Customers.Count; i++)
            {
                if (activeCount == 3) break;

                if (Customers[i].activeSelf == false)
                {
                    Customers[i].SetActive(true);
                    activeCount++;
                }
            }
            currentTime = 0f;
        }
    }
}
