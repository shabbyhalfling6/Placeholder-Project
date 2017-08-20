using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    public GameObject startPos;
    public GameObject endPos;

    public GameObject segment;

    public List<GameObject> segments = new List<GameObject>();

    public float offset = 0.2f;

    public float comp = 0.5f;

	// Use this for initialization
	void Start ()
    {
        foreach (Transform child in this.transform)
        {
            segments.Add(child.gameObject);
        }
	}

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i < segments.Count; i++)
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
                Debug.Log(pos1 + ", " + pos2);
                segments[i].transform.position=pos1;
                segments[i-1].transform.position=pos2;
            }
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
