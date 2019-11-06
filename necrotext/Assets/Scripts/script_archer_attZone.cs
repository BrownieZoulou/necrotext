using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_archer_attZone : MonoBehaviour
{
	[SerializeField] int cooldownArcher=150;
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
			gameObject.GetComponentInParent<script_humains>().enterCombat();
			if(cooldown==0){
				gameObject.GetComponentInParent<script_archer>().tirer(other.gameObject);
				cooldown=cooldownArcher;
			}
		}
	}
}
