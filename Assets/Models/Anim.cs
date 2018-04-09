using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		var time = anim.GetFloat("Time");
		time += Time.deltaTime;
		anim.SetFloat ("Time", time);
	}
}
