using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3(0.1f, 7.0f, -10);
    public float dampTime = 0.3f;
    public Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pointToMove = GetComponent<Camera>().WorldToViewportPoint(target.position);
        Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(offset.x, offset.y, pointToMove.z));

        Vector3 destination = pointToMove + delta;
        
        destination = new Vector3(target.position.x, offset.y, offset.z);

        this.transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref velocity, dampTime);
    
    }
}
