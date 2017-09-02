using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    public GameObject startPos;
    public GameObject endPos;

    public GameObject segment;

    public GameObject[] segments;

    private LineRenderer ropeLine;

    public float offset = 0.2f;

    public float comp = 0.5f;

	void Start ()
    {
        ropeLine = this.GetComponent<LineRenderer>();

        for (int i = 1; i < segments.Length; i++)
        {
            ropeLine.SetPosition(i, segments[i].transform.position);
        }
	}

    void Update()
    {
        for (int i = 1; i < segments.Length; i++)
        {
            Vector3 delta = segments[i].transform.position - segments[i-1].transform.position;
            float deltaLength = delta.magnitude;
            if (deltaLength > 0)
            {
                float diff = (deltaLength - offset) / deltaLength;
                Vector3 pos1 = segments[i].transform.position;
                Vector3 pos2 = segments[i-1].transform.position;
                
                pos1 -= delta * comp * diff;
                pos2 += delta * comp * diff;
                segments[i].transform.position=pos1;
                segments[i-1].transform.position=pos2;
            }
            ropeLine.SetPosition(i-1, segments[i].transform.position);
        }
	}

    /*
    void SpawnSegments()
    {
        //distance between start and end pos
        Vector3 dis = endPos.transform.position - startPos.transform.position;
        int count = (int)(dis.magnitude / offset);
        segments.Add(startPos);
        for (float i = 1; i < count; i++)
        {
            GameObject currentSegment;
            //Instantiate segment(cube) at an offset of spawnOffset towards the end point
            currentSegment = Instantiate(segment, Vector3.Lerp(startPos.transform.position, endPos.transform.position, i / count), Quaternion.identity);
            segments.Add(currentSegment);
        }
        segments.Add(endPos);
    }
    */
}
