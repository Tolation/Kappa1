using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {
	public GameObject bullet;
	public GameObject bulletspawn;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			GameObject s = Instantiate(bullet,bulletspawn.transform.position,bulletspawn.transform.rotation);
			s.GetComponent<Rigidbody>().velocity=-s.transform.forward*speed;
			s.transform.LookAt(s.transform.forward);
			Destroy(s,2);
		}
		
	}
}
