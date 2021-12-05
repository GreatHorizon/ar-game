using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes.scripts
{
    public class SmoothMovement : MonoBehaviour
    {
        public bool isMooving { get; set; } = false;

        Transform target;
        Vector3 dest;
        private Quaternion initialRotation;

        public void Move(Vector3 dest)
        {
            this.dest = dest;
        }

        public void Start()
        {
        }

        public void Update()
        {
            if (transform.position != dest)
            {
                //keep existing "y" rotation and set "x" and "z" rotation from intitalRotation
                transform.LookAt(dest);
                transform.position += transform.forward * Time.deltaTime * 0.015f;
            }
            else
            {
                Destroy(gameObject);
                Debug.Log("destroy");
            }
        }

    }
}
