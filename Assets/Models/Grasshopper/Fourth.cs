using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fourth : MonoBehaviour {

	Animator anim;
	int state = 0;
	float time = 0.0f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time>7&&state==0){
			anim.SetInteger ("state", 1);
			state = 1;
		}
	}
}
