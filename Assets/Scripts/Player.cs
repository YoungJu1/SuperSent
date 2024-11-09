using System;
using UnityEngine;

public class Player : MonoBehaviour
{
  private void OnCollisionEnter(Collision collision)
  {
    Debug.Log(collision.gameObject.name);
  }
}
