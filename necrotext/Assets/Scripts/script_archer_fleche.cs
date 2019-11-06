using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_archer_fleche : MonoBehaviour
{
	public Vector3 positionCible;
	private float vitesse;
	
	
    // Start is called before the first frame update
    void Start()
    {
		vitesse = 0.06f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position+vitesse*(positionCible-transform.position);
		if(positionCible==transform.position){
			Destroy(this.gameObject);
		}
    }
	
	private void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Zombies" || other.gameObject.tag == "sol"){
			other.gameObject.GetComponent<script_zombies>().Die();
			Destroy(this.gameObject);
		}
	}
}
