using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_paysan : MonoBehaviour
{
	float vitesse;
	float offsetZpos;
	float offsetYpos;
	bool isFighting = false;
	
	
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
			transform.position += new Vector3(-vitesse,0,0);
		}
    }
	
	private void OnTriggerExit2D(Collider2D other){
		isFighting = false;
	}
	
	public void die(){
		Destroy(this.gameObject);
	}
	
	public void enterCombat(){
		isFighting=true;
	}
}
