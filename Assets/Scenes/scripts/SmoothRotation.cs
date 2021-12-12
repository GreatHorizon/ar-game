using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotation : MonoBehaviour
{
    // Start is called before the first frame update
    Quaternion _rotation;

    Transform dest;
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {
        if (dest != null)
        {
            Debug.Log("look at");
            transform.LookAt(new Vector3(dest.position.x, transform.position.y, dest.position.z));
            //var lookPos = dest.position - transform.position;
/*            _rotation = Quaternion.LookRotation(lookPos);

            transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(transform.rotation.x, _rotation.y, transform.rotation.z, transform.rotation.w)
                , 2 * Time.deltaTime);*/
        }
    }

    public void Move(Transform trans)
    {
        dest = trans;
    }
}
