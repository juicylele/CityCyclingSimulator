using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public List<Transform> prefebFloor;
    public List<Transform> floors;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreatDestroyFloor();
    }

    void CreatDestroyFloor()
    {
        Transform lastFloor = floors[floors.Count - 1];
        if (lastFloor.position.z < transform.position.z + 20)
        {
            Transform prefeb = prefebFloor[Random.Range(0, prefebFloor.Count)];
            Transform newFloor = Instantiate(prefeb, null);
            newFloor.position = lastFloor.position + new Vector3(0, 0, 20);
            floors.Add(newFloor);
        }
        Transform firstFloor = floors[0];
        if (firstFloor.position.z < transform.position.z - 20)
        {
            floors.RemoveAt(0);
            Destroy(firstFloor.gameObject);
        }
    }
}
