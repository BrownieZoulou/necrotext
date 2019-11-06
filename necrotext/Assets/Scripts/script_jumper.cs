using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_jumper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void jump(Vector3 posJump){
		transform.position = posJump;
	}
}
