using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {
  private Vector3 screenPoint;
  private Vector3 offset;
  
  void OnMouseDown() {
      screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
      offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
  }
  
  void OnMouseDrag() {
    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
    if(Vector3.Distance(curPosition, Vector3.zero) < 2.2) {
      transform.position = curPosition;
    }
  }
}
