using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<IQuestBase>().IsUnityNull()) return;
        collision.transform.GetComponent<IQuestBase>().Quest();
    }
}