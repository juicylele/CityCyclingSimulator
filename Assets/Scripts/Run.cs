using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runn : MonoBehaviour
{
    public float moveSpeed = 10f;

    private int State;//��ɫ״̬

    private int oldState = 0;//ǰһ�ν�ɫ��״̬

    private int UP = 0;//��ɫ״̬��ǰ

    private int DOWN = 1;//��ɫ״̬���

    public List<Transform> prefebFloor;
    public List<Transform> floors;


    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)

        {
            setState(UP);

            CreatDestroyFloor(UP);

        }

        else if (Input.GetAxis("Vertical") < 0)

        {
            setState(DOWN);

            CreatDestroyFloor(DOWN);
        }

        // float H = Input.GetAxis("Horizontal");
        //float V = Input.GetAxis("Vertical");


        //if (V < 0)
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
        //    transform.Translate(new Vector3(0, 0, -V) * Time.deltaTime * moveSpeed, Space.World);
        //}
        //else
        //{
        //    transform.Translate(new Vector3(0, 0, V) * Time.deltaTime * moveSpeed, Space.World);
        //}

    }
    void setState(int currState)

    {
        Vector3 transformValue = new Vector3();//����ƽ������

        int rotateValue = (currState - State) * 180;

        switch (currState)

        {
            case 0://��ǰ�ƶ�

                transformValue = Vector3.forward * Time.deltaTime * moveSpeed;

                break;

            case 1://����ƶ�

                transformValue = Vector3.back * Time.deltaTime * moveSpeed;

                

                break;

        }

        transform.Rotate(Vector3.up, rotateValue);//��ת

        transform.Translate(transformValue, Space.World);//ƽ��

        oldState = State;//��ֵ��������һ�μ���

        State = currState;//��ֵ��������һ�μ���

    }
    void CreatDestroyFloor(int currState)
    {
        Transform lastFloor;
        Transform firstFloor;

        switch (currState)
        {
            case 0://��ǰ���ɵ���
                lastFloor = floors[floors.Count - 1];
                firstFloor = floors[0];
                if (lastFloor.position.z < transform.position.z + 20)
                {
                    Transform prefeb = prefebFloor[Random.Range(0, prefebFloor.Count)];
                    Transform newFloor = Instantiate(prefeb, null);
                    newFloor.position = (lastFloor.position + new Vector3(0, 0, 20));
                    floors.Add(newFloor);
                }
                
                if (firstFloor.position.z < transform.position.z - 20)
                {
                    floors.RemoveAt(0);
                    Destroy(firstFloor.gameObject);
                }
                break;

            case 1://������ɵ���
                lastFloor = floors[0];
                firstFloor = floors[floors.Count - 1];
                if (firstFloor.position.z > transform.position.z - 20)
                {
                    Transform prefeb = prefebFloor[Random.Range(0, prefebFloor.Count)];
                    Transform newFloor = Instantiate(prefeb, null);
                    newFloor.position = (firstFloor.position + new Vector3(0, 0, -20));
                    floors.Add(newFloor);
                }
                if (lastFloor.position.z > transform.position.z + 20)
                {
                    floors.RemoveAt(0);
                    Destroy(lastFloor.gameObject);
                }
                break;
        }
        
    }

}


