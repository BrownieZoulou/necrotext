using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_game : MonoBehaviour
{
	
	public GameObject zombie;
	public GameObject paysan;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("AddZombie")==true){	
			print("1");
			Instantiate(zombie,new Vector3(-12,-1,10), Quaternion.identity);
		}
		if(Input.GetButtonDown("AddHuman")==true){
			print("2");
			Instantiate(paysan,new Vector3(12,-1,10),  Quaternion.identity);
		}
    }
}
