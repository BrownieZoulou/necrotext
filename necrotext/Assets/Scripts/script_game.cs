using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_game : MonoBehaviour
{
	
	public GameObject zombie;
	public GameObject paysan;
	public GameObject archer;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("AddZombie")==true){	
			Instantiate(zombie,new Vector3(-12,-1,10), Quaternion.identity);
		}
		if(Input.GetButtonDown("AddHuman")==true){
			Instantiate(paysan,new Vector3(12,-1,10),  Quaternion.identity);
		}
		if(Input.GetButtonDown("AddArcher")==true){
			Instantiate(archer,new Vector3(12,-1,10),  Quaternion.identity);
		}
    }
}
