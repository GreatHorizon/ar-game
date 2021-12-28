using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scenes.scripts;
using UnityEngine.SceneManagement;
using System;

public class StartButtonScript : MonoBehaviour
{
    [SerializeField]
    private Button button;


    [SerializeField]
    private GameObject endGame;

    [SerializeField]
    private Text _aliensAmount;

    [SerializeField]
    private GameObject _loseSound;

    [SerializeField]
    private GameObject _winSound;

    [SerializeField]
    private GameObject _alienShipAudio;

    [SerializeField]
    private Text winText;
    [SerializeField]
    private GameObject _loseAmount;
    [SerializeField]
    private Text closeText;

    [SerializeField]
    private Button reloadButton;

    [SerializeField]
    private GameObject ship;
    [SerializeField]
    private GameObject towerTarget;
    [SerializeField]
    private GameObject cannon;
    [SerializeField]
    private GameObject cannonEarth;
    [SerializeField] 
    private GameObject towerPrefab;
    private SmoothMovement movement = new SmoothMovement();

    // Start is called before the first frame update
    void Start()
    {
        reloadButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });

        button.GetComponent<Button>().onClick.AddListener(() => {
            button.GetComponent<Button>().gameObject.SetActive(false);                                                                              
            button.enabled = false;
            var towerObj = towerTarget.transform.GetChild(0).gameObject;
            Vector3 towerPositon = towerObj.transform.position;
            var towerRotation = towerObj.transform.rotation;
            Vector3 shipPosition1 = towerPositon;
            Vector3 shipPosition2 = towerPositon;
            var tower = Instantiate(towerPrefab);
            tower.transform.position = towerPositon;
            tower.transform.rotation = towerRotation;
            var childTower = tower.transform.GetChild(0);
            //childTower.GetComponent<Destoyer>().SetText(text);
            childTower.GetComponent<Destoyer>().SetTower(childTower.gameObject);

            childTower.GetComponent<Destoyer>().SetAliensAmountForTower(_loseAmount.GetComponent<AliensAmount>());
            _loseAmount.GetComponent<AliensAmount>().SetColor(new Color(0.4f, 1, 0));
            childTower.GetComponent<Destoyer>().SetEndGameObject(endGame);
            childTower.GetComponent<Destoyer>().SetLoseSound(Instantiate(_loseSound).GetComponent<AudioSource>());
            childTower.GetComponent<Destoyer>().SetWinSound(Instantiate(_winSound).GetComponent<AudioSource>());





            //towerTop.GetComponent<SmoothRotation>().Move(cannon.transform);


            Destroy(towerTarget);

            shipPosition1.x = towerPositon.x + 0.25f;
            shipPosition1.y = towerPositon.y + 0.35f;

            shipPosition2.x = towerPositon.x - 0.25f;
            shipPosition2.y = towerPositon.y + 0.35f;


            GameObject shipObject1 = Instantiate(ship);
            GameObject shipObject2 = Instantiate(ship);
            SmoothMovementShip movementShip1 = shipObject1.GetComponent<SmoothMovementShip>();
            SmoothMovementShip movementShip2 = shipObject2.GetComponent<SmoothMovementShip>();

            movementShip1.PassTower(tower);
            movementShip2.PassTower(tower);
            shipObject1.transform.position = shipPosition1;
            shipObject2.transform.position = shipPosition2;

            movementShip1.Move(shipObject1.transform, new Vector3(shipPosition1.x, tower.transform.position.y + 0.05f, shipPosition1.z));
            movementShip1.SetAndPlayAudio(Instantiate(_alienShipAudio).GetComponent<AudioSource>());
            cannon.transform.Find("Turret Platform").GetComponent<GatlingGun>().SetShip(shipObject1);

            int rem = Convert.ToInt32(_aliensAmount.text) % 2;
            movementShip1.SetAliensAmount(Convert.ToInt32(_aliensAmount.text) / 2 + rem);
            movementShip2.SetAliensAmount(Convert.ToInt32(_aliensAmount.text) / 2);
            movementShip2.Move(shipObject2.transform, new Vector3(shipPosition2.x, tower.transform.position.y + 0.05f, shipPosition2.z));



            cannon.transform.GetChild(1).GetComponent<GatlingGun>().SetTower(tower.transform.position);               
            cannon.transform.GetChild(1).GetComponent<GatlingGun>().enabled = true;
            childTower.GetComponent<Destoyer>().SetCannon(cannon.transform.GetChild(1).gameObject);
        });
    }

    void UntargetObject()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }


}
