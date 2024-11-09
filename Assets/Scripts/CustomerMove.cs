using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMove : CustomerManager
{
    public GameObject targetobj;
    public Transform trs;
    public Animator Ani;
    public bool moveBasket = false;

    private float speed = 1f;
    private bool aniCheck = false;

    public override void Init(ManagerType _type)
    {
        base.Init(_type);
    }
    private void Start()
    {
        Ani = GetComponent<Animator>();

        Ani.SetBool("walk", true);
        trs = GameControl.Instance.BasketPosition[2].gameObject.transform;
        targetobj = GameControl.Instance.BasketPosition[2].gameObject;
    }

    public void ChangeMoveBasketPoint(Transform _pos, GameObject _obj)
    {
        if (moveBasket) return;

        trs = _pos;
        targetobj = _obj;
        aniCheck = true;
    }
    public void ChangeMovePoint(Transform _pos, GameObject _obj)
    {
        trs = _pos;
        targetobj = _obj;
        aniCheck = true;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, trs.position, speed * Time.deltaTime);
        transform.LookAt(targetobj.transform);

        if (transform.position == trs.position && aniCheck)
        {
            aniCheck = false;
            Ani.SetBool("walk", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MoveCheck"))
        {
            other.GetComponent<CustomerPositionCheck>().isCutromer = false;

        }
    }
}
