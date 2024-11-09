using System.Collections.Generic;
using UnityEngine;

public class GuideSignQuest : MonoBehaviour 
{
    public List<GameObject> Bread = new List<GameObject>();

    private const int breadMaxCount = 30;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Customer"))
        {
            other.GetComponent<CustomerMove>().moveBasket = true;
            other.GetComponent<CustomerQuest>().isBreadQuest = true;
            //other.GetComponent<CustomerQuest>().quest_txt.text = Random.Range(1, 7).ToString();
            //other.GetComponent<CustomerQuest>().bubble_img.gameObject.SetActive(true);
        }
    }
}
