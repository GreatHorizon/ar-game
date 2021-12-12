using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes.scripts
{
    public class SmoothMovementBall : MonoBehaviour
    {
        public bool isMooving { get; set; } = false;

        Transform target;
        Vector3 dest;
        private Quaternion initialRotation;

        [SerializeField]
        private float _speed = 0.015f;


        public void Move(Vector3 dest)
        {
            this.dest = dest;
            //transform.LookAt(dest);
            //transform.position;
        }

        public void Start()
        {
        }

        public void Update()
        {
            if (transform.position != dest)
            {
                //keep existing "y" rotation and set "x" and "z" rotation from intitalRotation
 //               transform.position += new Vector3(dest.x, dest.y, dest.z) * Time.deltaTime * _speed;

                float step = _speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, dest, step);
            }
        }

        /*        public float forceMul = 200;
                private Rigidbody rb;


                public void Move(Vector3 dest)
                {
                    this.dest = dest;
                    //transform.LookAt(dest);
                    //transform.position;
                }

                private void Awake()
                {
                    rb = GetComponent<Rigidbody>();
                }

                private void Update()
                {
                    if (dest != null)
                    {
                        rb.AddForce(dest * forceMul * Time.deltaTime);
                    }

                }*/

    }
}