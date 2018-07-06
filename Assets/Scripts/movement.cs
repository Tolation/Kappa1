using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class movement : NetworkBehaviour {

	public float moveSpeed;
	private Rigidbody rigidb;
	// Use this for initialization
	RaycastHit hit;

	void Start () {
		rigidb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer){
			return;
		}
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		rigidb.velocity = new Vector3(horizontal,0,vertical)*moveSpeed*Time.deltaTime;

        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation =  Quaternion.Euler (new Vector3(0f,angle,0f));

     }
 
	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.x - b.x, a.y - b.y) * Mathf.Rad2Deg;
     }

}
