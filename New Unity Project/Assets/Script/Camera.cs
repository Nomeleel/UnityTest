using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform playTransform;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - playTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + playTransform.position;
    }
}
