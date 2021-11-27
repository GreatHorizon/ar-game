using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes.scripts
{
    public class SmoothMovementShip : MonoBehaviour
    {
        public bool isMooving { get; set; } = false;

        Transform target;
        Vector3 b;

        [SerializeField]
        private GameObject alien;

        private GameObject tower;
        bool started = false;

        public void Move(Transform target, Vector3 b)
        {
            this.target = target;
            this.b = b;
        }
        public void PassTower(GameObject tower)
        {
            this.tower = tower;
        }

        public void Update()
        {
            if (target.position != b)
            {
                float newPositionX = (float)Mathf.Lerp(target.position.x, b.x, 5 * 0.001f);
                float newPositionY = (float)Mathf.Lerp(target.position.y, b.y, 5 * 0.01f);
                target.position = new Vector3(newPositionX, newPositionY, b.z);
            } else if (!started){
                StartCoroutine(HERE());
            }
        }
        public IEnumerator HERE()
        {
            started = true;
            while (true)
            {
                GameObject alienObj = Instantiate(alien);
                alienObj.transform.LookAt(tower.transform.position);

                Vector3 towerPos = tower.transform.position;
                SmoothMovement movement = alienObj.GetComponent<SmoothMovement>();
                alienObj.transform.position = transform.position;
                movement.Move(towerPos);
                yield return new WaitForSeconds(1.0f);
            }

        }

    }
}
