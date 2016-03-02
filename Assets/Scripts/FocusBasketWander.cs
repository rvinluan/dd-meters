using UnityEngine;
using System.Collections;

public class FocusBasketWander : MonoBehaviour {
  public float speed = .1f;
  public float directionChangeInterval = 3;
  public float maxHeadingChange = 30;
  
  Vector3 destination;

  void Awake ()
  {  
    // Set random initial destination
    NewDestinationRoutine();
  
    StartCoroutine(NewHeading());
  }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    // Debug.DrawLine(transform.position, destination, Color.red);
    float step = speed * Time.deltaTime;
    transform.position = Vector3.MoveTowards(transform.position, destination, step);
	}

  IEnumerator NewHeading () {
    while (true) {
      NewDestinationRoutine();
      yield return new WaitForSeconds(directionChangeInterval);
    }
  }

  void NewDestinationRoutine () {
    //given the angle between this and its current destination
    float a = Vector3.Angle(transform.position, destination);
    //get a new angle within 30deg
    float newAngMin = Mathf.Clamp(a - maxHeadingChange, 0, 360);
    float newAngMax = Mathf.Clamp(a + maxHeadingChange, 0, 360);
    float newAng = Random.Range(newAngMin, newAngMax);
    //find a point on that circle to be the new Destination
    float circleRadius = 1;
    float newX = Mathf.Cos(newAng)*circleRadius;
    float newY = Mathf.Sin(newAng)*circleRadius;
    destination = new Vector3(transform.position.x + newX, transform.position.y + newY, 0);
    float clip = 2.36f;
    if (Vector3.Distance(destination, Vector3.zero) > clip) {
      float correctedX = Random.Range(-clip, clip);
      float correctedY = Random.Range(-clip, clip);
      destination = new Vector3(correctedX, correctedY, 0);
    }
  }

}
