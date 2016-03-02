using UnityEngine;
using System.Collections;

public class CollisionWithGreen : MonoBehaviour {

  void Start () {
    //Debug.Log("start");
  }

	void OnTriggerEnter2D (Collider2D c) {
    Debug.Log("hi");
  }
}
