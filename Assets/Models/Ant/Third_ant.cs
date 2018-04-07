using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_ant : MonoBehaviour {

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
		if((time>2&&time<=6)&&state==0){
			anim.SetInteger ("state", 1);
			state = 1;
		}
		if((time>7&&time<12)&&state==1){
			anim.SetInteger ("state", 0);
			state = 0;
		}
		if((time>12&&time<15)&&state==0){
			anim.SetInteger ("state", 2);
			transform.Rotate (0, -45.0f, 0);
			state = 2;
		}
		if(time>15&&state==2){
			anim.SetInteger ("state", 2);
			state = 0;
		}
	}
}
