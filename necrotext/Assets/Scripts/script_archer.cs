using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_archer : MonoBehaviour
{
	
	public GameObject fleche;
	
	public Vector3 posCible;
	public Vector3 positionArcher;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	
	public void tirer(GameObject cible){
		posCible = cible.transform.position;
		positionArcher = transform.position;
		Instantiate(fleche,positionArcher, Quaternion.identity);
		fleche.GetComponent<script_archer_fleche>().positionCible = posCible;
	}
}
