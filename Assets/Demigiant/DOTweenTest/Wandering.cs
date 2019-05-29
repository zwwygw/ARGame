using UnityEngine;
using System ;
 
public class Wandering : MonoBehaviour {
	public float speed=1;
	public int channge=1;
	//public float time=1f;
	//public int ok;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (UnityEngine.Random.Range (-20f, 20f), 0.5f, UnityEngine.Random.Range (-20f, 20f));
	}
	
	// Update is called once per frame
	void Update () {
		//time += 0.01f;
		/*if(time %2f<=0.1f){
			ok = UnityEngine.Random.Range (1, 10);
			if(ok==1)
			channge = UnityEngine.Random.Range (1, 4);
		}*/
		if (channge == 1) {
			transform.position += new Vector3 (speed * Time.deltaTime,0,0);
			Quaternion lookRot = Quaternion.LookRotation (new Vector3 (1f, 0, 0));
			transform.rotation = Quaternion.Slerp (transform.rotation, lookRot, speed  * Time.deltaTime);
		}
		if (channge == 2) {
			transform.position -= new Vector3 (speed * Time.deltaTime,0,0);
			Quaternion lookRot = Quaternion.LookRotation (new Vector3 (-1f,0,0));
			transform.rotation = Quaternion.Slerp (transform.rotation, lookRot, speed  * Time.deltaTime);
		}
		if (channge == 3) {
			transform.position+= new Vector3 (0,0,speed * Time.deltaTime);
			Quaternion lookRot = Quaternion.LookRotation (new Vector3 (0,0,1f));
			transform.rotation = Quaternion.Slerp (transform.rotation, lookRot, speed  * Time.deltaTime);
		}
		if (channge == 4) {
			transform.position -= new Vector3 (0,0,speed * Time.deltaTime);
			Quaternion lookRot = Quaternion.LookRotation (new Vector3 (0,0,-1f));
			transform.rotation = Quaternion.Slerp (transform.rotation, lookRot, speed  * Time.deltaTime);
		}
		if (transform.position.x > 20f) {
			transform.position = new Vector3 (20f, transform.position.y, transform .position .z);
			if (channge == 1 || channge == 3) {
				channge++;
			} else
				channge--;
		}
		if (transform.position.x < -20f) {
			transform.position = new Vector3 (-20f, transform.position.y, transform .position .z);
			if (channge == 1 || channge == 3) {
				channge++;
			} else
				channge--;
		}
		if (transform.position.z> 20f) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, 20f);
			if (channge == 1 || channge == 3) {
				channge++;
			} else
				channge--;
		}
		if (transform.position.z< -20f) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, 20f);
			if (channge == 1 || channge == 3) {
				channge++;
			} else
				channge--;
		}
 
	}
	void OnCollisionEnter(Collision  collision){
		channge = UnityEngine.Random.Range (1, 4);
	}
}
