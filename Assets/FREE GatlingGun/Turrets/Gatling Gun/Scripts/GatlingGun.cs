using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scenes.scripts;
using UnityEngine.UI;

public class GatlingGun : MonoBehaviour
{
    // target the gun will aim at
    [SerializeField]
    Transform go_target;

    [SerializeField]
    GameObject amount;

    [SerializeField]
    GameObject _wonText;


    [SerializeField]
    GameObject bullet;

    // Gameobjects need to control rotation and aiming
    public Transform go_baseRotation;
    public Transform go_GunBody;
    public Transform go_barrel;
    private Vector3 _tower;

    // Gun barrel rotation
    public float barrelRotationSpeed;
    float currentRotationSpeed;
    private GameObject ship;

    // Distance the turret can aim and fire from
    public float firingRange;

    // Particle system for the muzzel flash
    public ParticleSystem muzzelFlash;

    // Used to start and stop the turret firing
    bool canFire = true;
    bool started = false;

    
    void Start()
    {
        amount.GetComponent<AliensAmount>().SetColor(new Color(0.4f, 1, 0));
        // Set the firing range distance
        //this.GetComponent<SphereCollider>().radius = firingRange;
    }

    void Update()
    {
        AimAndFire();
    }
     
    void OnDrawGizmosSelected()
    {
        // Draw a red sphere at the transform's position to show the firing range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, firingRange);
    }

    private Coroutine _spawn;

    // Detect an Enemy, aim and fire
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            go_target = other.transform;
            canFire = true;
        }

    }
    // Stop firing
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            canFire = false;
        }
    }
    public void SetShip(GameObject obj)
    {
        ship = obj;
    }



    public IEnumerator SpawnBulletWithDelay()
    {
        started = true;
        while (true)
        {
                GameObject bulletObj = Instantiate(bullet);
                bulletObj.transform.position = go_barrel.position;

                this.GetComponent<AudioSource>().Play();
                SmoothMovement movement = bulletObj.GetComponent<SmoothMovement>();
                BulletDestoyer bulletDestroyer = bulletObj.GetComponent<BulletDestoyer>();
                bulletDestroyer.SetWonText(_wonText);
                bulletDestroyer.SetAliensAmount(amount.GetComponent<AliensAmount>());
                bulletDestroyer.SetGunObj(this.gameObject);
                movement.SetTower(_tower);

                movement.Move(go_barrel.transform.forward);
                yield return new WaitForSeconds(0.6f);
        }

    }

    public void SetTower(Vector3 tower)
    {
        _tower = tower;
    }

    public void StopCoroutine()
    {
        StopCoroutine(_spawn);
    }

    void AimAndFire()
    {
        // Gun barrel rotation
        //go_barrel.transform.Rotate(0, 0, currentRotationSpeed * Time.deltaTime);
        
        
        if (!started && ship.GetComponent<SmoothMovementShip>().isAliensWalking) {
            _spawn = StartCoroutine(SpawnBulletWithDelay());
        }


        // if can fire turret activates
        /*if (canFire)
        {
            // start rotation
            currentRotationSpeed = barrelRotationSpeed;


            // aim at enemy
            if (go_target != null)
            {
                Vector3 baseTargetPostition = new Vector3(go_target.position.x, this.transform.position.y, go_target.position.z);
                Vector3 gunBodyTargetPostition = new Vector3(go_target.position.x, go_target.position.y, go_target.position.z);
                go_baseRotation.transform.LookAt(baseTargetPostition);
                go_GunBody.transform.LookAt(gunBodyTargetPostition);
            }


            // start particle system 
            if (!muzzelFlash.isPlaying)
            {
                muzzelFlash.Play();
            }
        }
        else
        {
            // slow down barrel rotation and stop
            currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, 0, 10 * Time.deltaTime);

            // stop the particle system
            if (muzzelFlash.isPlaying)
            {
                muzzelFlash.Stop();
            }
        }*/
    }
}