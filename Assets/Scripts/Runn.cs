using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runn : MonoBehaviour
{
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, V) * Time.deltaTime * moveSpeed, Space.World);

    }
}
