using UnityEngine;
using System.Collections;

public class GroundMove : MonoBehaviour {

	public Vector3 movement;
	public Transform [] waypoints;
	public float speed = 1f;

	public int waypointIndex = 0;
	bool isReverse = false;
	public enum WaypointType {
		loop,
		pingPong,
		once,
		random,
		off
	};

	public WaypointType type;

	void Start (){

	}

	void Update () {

		switch (type){
		case WaypointType.loop: // loops around the waypoints
			if (transform.position == waypoints[waypointIndex].position) {
				if (waypointIndex == waypoints.Length-1){
					waypointIndex = 0;
				}
				else{
					waypointIndex ++;
				}
			}

			break;
		case WaypointType.pingPong: // go though the wayponts and back in reverse order
			if (transform.position == waypoints[waypointIndex].position) {
				if (waypointIndex == waypoints.Length-1){
					isReverse = true;
				}
				if (waypointIndex == 0){
					isReverse = false;
				}

				if (isReverse) {
					waypointIndex--;
				}
				else {
					waypointIndex++;
				}
			}
			break;
		case WaypointType.once: // go through the waypoints and stop at the end
			if (transform.position == waypoints[waypointIndex].position) {
				if (waypointIndex == waypoints.Length - 1){
					type = WaypointType.off;
					break;
				}
				else {
					waypointIndex ++;
				}
			}
			break;
		case WaypointType.random: // go to a random waypoint
			if (transform.position == waypoints[waypointIndex].position) {
				waypointIndex = Random.Range(0, waypoints.Length);
			}
			break;
		case WaypointType.off: // go to the next waypoint on the list and stop
			break;
		}

		transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, Time.deltaTime * speed);

	
	}
	
}
