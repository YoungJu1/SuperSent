using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMove : CustomerManager
{
    public CustomerState myState = CustomerState.None;
    public int positioncheck = 0;

    private Animator Ani;

    private Vector3[] basketPosition_Case1 =
        { new Vector3(4.7f, 0, 9), new Vector3(5.36f, 0, 3.5f), new Vector3(4.17f, 0, 3.44f) };

    private Vector3[] basketPosition_Case2 = { new Vector3(2.53f, 0, 9), new Vector3(2.53f, 0, 4.73f) };
    private List<Vector3> sittingPosition = new List<Vector3>();
    private float speed = 1f;
    public int walkpoint_case1 = 0;
    public int walkpoint_case2 = 0;

    public override void Init(ManagerType _type)
    {
        base.Init(_type);
    }

    private void Start()
    {
        Ani = GetComponent<Animator>();

        Ani.SetBool("walk", true);
    }

    private void Update()
    {
        if (myState == CustomerState.BasketCase1)
        {
            if (walkpoint_case1 == 3) return;
            //if (positioncheck==1)
            //{
            //    positioncheck = 0;
            //    walkpoint_case1++;
            //}

            transform.position = Vector3.MoveTowards(transform.position, basketPosition_Case1[walkpoint_case1],
                speed * Time.deltaTime);
            //transform.localRotation = Quaternion.Euler(0, transform.rotation.y + 90, 0);
        }
        else if (myState == CustomerState.BasketCase2)
        {
            //if (positioncheck == 2)
            //{
            //    positioncheck = 0;
            //    walkpoint_case2++;
            //}

            if (walkpoint_case2 == 2) return;
            transform.position = Vector3.MoveTowards(transform.position, basketPosition_Case2[walkpoint_case2],
                speed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(0, transform.rotation.y + 90, 0);
        }
    }
}