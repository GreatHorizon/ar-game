using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotation : MonoBehaviour
{
    // Start is called before the first frame update

    Transform dest;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (dest != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, dest.rotation, 0.5f * Time.deltaTime);
            //keep existing "y" rotation and set "x" and "z" rotation from intitalRotation

        }
    }

    public void Move(Transform trans)
    {
        dest = trans;
    }
}
