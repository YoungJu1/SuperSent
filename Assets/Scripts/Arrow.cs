using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float time;
    private float peekTime = 0.50f;
    private bool isUp;
    private Vector3 startPosition;

    private void Awake()
    {
        isUp = true;
        startPosition = transform.position;
    }

    public void SetArrowAnimation(Vector3 position)
    {
        startPosition = position;
        isUp = true;
        StopAllCoroutines();
        StartCoroutine(UpdatePosition());
    }

    private IEnumerator UpdatePosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            var delta = (0.01f / peekTime);

            if (isUp)
            {
                time += delta;
            }
            else
            {
                time -= delta;
            }

            transform.position = startPosition + new Vector3(0, time, 0);

            if (time >= peekTime)
            {
                isUp = false;
            }
            else if (time == 0)
            {
                isUp = true;
            }
        }
    }
}