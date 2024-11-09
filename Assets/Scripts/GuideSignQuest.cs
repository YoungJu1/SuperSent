using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideSignQuest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Customer"))
        {
            other.GetComponent<CustomerMove>().moveBasket = true;
            //other.GetComponent<CustomerMove>().Ani.SetBool("walk", false);


            //other.GetComponent<CustomerQuest>().quest_txt.text = Random.Range(1, 7).ToString();
            //other.GetComponent<CustomerQuest>().bubble_img.gameObject.SetActive(true);
            //other.GetComponent<CustomerQuest>().bread_img.gameObject.SetActive(true);
            //other.GetComponent<CustomerQuest>().quest_txt.gameObject.SetActive(true);
        }
    }
}
