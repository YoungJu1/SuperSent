using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float time;
    private float peekTime = 0.50f;
    private bool isUp;

    private void Awake()
    {
        isUp = true;
    }
    public void SetArrowAnimation(Vector3 position)
    {
        isUp = true;
        transform.position = position + new Vector3(2f,2f,0f);
    }
}