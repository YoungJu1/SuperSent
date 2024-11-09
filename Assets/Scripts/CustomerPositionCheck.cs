using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerPositionCheck : MonoBehaviour
{
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.name);
    //    if (collision.gameObject.CompareTag("Customer"))
    //    {
    //        Debug.Log(collision.gameObject.name);
    //        switch (collision.gameObject.GetComponent<CustomerMove>().myState)
    //        {
    //            case CustomerManager.CustomerState.BasketCase1:
    //                Debug.Log(collision.gameObject.name);
    //                collision.gameObject.GetComponent<CustomerMove>().positioncheck = 1;
    //                break;
    //            case CustomerManager.CustomerState.BasketCase2:
    //                collision.gameObject.GetComponent<CustomerMove>().positioncheck = 2;
    //                break;
    //            default:
    //                collision.gameObject.GetComponent<CustomerMove>().positioncheck = 0;
    //                break;
    //        }

    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Customer"))
        {
            switch (other.gameObject.GetComponent<CustomerMove>().myState)
            {
                case CustomerManager.CustomerState.BasketCase1:
                    float rot = other.gameObject.transform.localRotation.y;
                    other.gameObject.GetComponent<CustomerMove>().walkpoint_case1++;
                    other.gameObject.transform.localRotation = Quaternion.Euler(0, rot+90f, 0);
                    break;
                case CustomerManager.CustomerState.BasketCase2:
                    other.gameObject.GetComponent<CustomerMove>().walkpoint_case2++;
                    break;
                default:
                    other.gameObject.GetComponent<CustomerMove>().positioncheck = 0;
                    break;
            }

        }
    }
}
