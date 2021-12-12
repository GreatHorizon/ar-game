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


        [SerializeField]
        private float _speed = 0.015f;

        private Vector3 _tower;

        public void SetTower(Vector3 tower)
        {
            _tower = tower;
        }


        public void Move(Vector3 dest)
        {
            this.dest = dest;
            transform.LookAt(dest);
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
                transform.position += new Vector3(transform.forward.x, _tower.y, transform.forward.z) * Time.deltaTime * _speed;
                Debug.Log("position: " + transform.position.ToString());        
                Debug.Log("forward: " + transform.forward.ToString());
            }
        }

    }
}