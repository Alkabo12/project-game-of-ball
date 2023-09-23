using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    private Vector3 temp;
     void Start()
    {
        temp = this.transform.position;  
    }
    void LateUpdate()
    {
        this.transform.position = player.transform.position+temp;  
    }
}
