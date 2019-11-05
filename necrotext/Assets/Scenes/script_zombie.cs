using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_zombie : MonoBehaviour
{
	float vitesse;
	float vitesseAtt;
	float offsetZpos;
	float offsetYpos;
	bool isFighting = false;
	int cooldown = 0;

	
	
    // Start is called before the first frame update
    void Start()
    {
		
        offsetZpos = Random.Range(1f,3f);
		offsetYpos = offsetZpos*-1;
		vitesse = Random.Range(0.015f,0.020f);
		transform.position += new Vector3(0,offsetYpos,-offsetZpos);
    }

    // Update is called once per frame
    void Update()
    {
		if(!isFighting){
			transform.position += new Vector3(vitesse,0,0);
		}
		if(cooldown != 0){
			cooldown--;
		}
    }
	
	private void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Humains"){
			isFighting = true;
			if(cooldown == 0){
				Destroy(other.gameObject);
				cooldown = 10;
			}
		}
	}
	
	private void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.tag == "Humains"){
			isFighting = true;
			if(cooldown == 0){
				other.gameObject.GetComponent<script_paysan>()	.die();
				cooldown = 10;
			}
		}
	}
	
	private void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Humains"){
			isFighting = false;
		}
	}
}
