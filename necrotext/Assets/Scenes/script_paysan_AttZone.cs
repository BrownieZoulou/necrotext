using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_paysan_AttZone : MonoBehaviour
{
	int cooldown;
	
    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown!=0){
			cooldown--;
		}	
    }
	
	private void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.tag =="Zombies"){
			gameObject.GetComponentInParent<script_paysan>().enterCombat();
			if(cooldown==0){
				Destroy(other.gameObject);
				cooldown=100;
			}
		}
	}
}
