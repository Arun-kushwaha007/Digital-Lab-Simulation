using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Target;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,Target.transform.position,5* Time.deltaTime);
    }
}
