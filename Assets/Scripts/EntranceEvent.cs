using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceEvent : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Customer")) other.gameObject.SetActive(false);
    }
}
