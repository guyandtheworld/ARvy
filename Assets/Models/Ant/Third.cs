using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		var time = anim.GetFloat ("Time");
		if(time>12 && time<12.1){
			transform.Rotate (0, -7.9f, 0);
		}
	}
}
