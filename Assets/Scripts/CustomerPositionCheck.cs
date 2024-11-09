using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerPositionCheck : MonoBehaviour
{
    public bool isCutromer = false;

    public int collideridx = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Customer"))
        {
            for (int i = 0; i < 2; i++)
            {
                if (!GameControl.Instance.BasketPosition[i].isCutromer)
                {
                    GameControl.Instance.BasketPosition[i].isCutromer = true;
                    other.GetComponent<CustomerMove>().ChangeMoveBasketPoint(GameControl.Instance.BasketPosition[i].gameObject.transform, GameObject.FindGameObjectWithTag("GuideSign"));
                    return;
                }
            }
        }
    }
}
