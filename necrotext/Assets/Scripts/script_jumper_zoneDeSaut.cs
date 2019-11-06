using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_jumper_zoneDeSaut : MonoBehaviour
{
	public Vector3 positionJump;
	bool jumped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Fleche" || other.gameObject.tag == "Humains" && !jumped){
			positionJump = positionJump + (positionJump-this.gameObject.GetComponentInParent<script_zombies>().transform.position);
			print("Je saute de "+this.gameObject.GetComponentInParent<script_zombies>().transform.position+" à "+positionJump);
			jumped = true;
		}
	}
}
