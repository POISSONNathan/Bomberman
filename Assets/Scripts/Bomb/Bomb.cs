using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bomb : MonoBehaviour
{
    private float _timer;

    public float lifeSpan;

    public GameObject bombExplode;

    public float forceAmount;

    private Grid _myGrid;

    private void Start()
    {
        _myGrid = FindObjectOfType<Grid>();
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > lifeSpan)
        {
            for (int i = 0; i < 4; i++)
            {
                var newBomb = Instantiate(bombExplode, transform.position, Quaternion.identity);

                switch (i)
                {
                    case 0:
                        newBomb.GetComponent<Rigidbody2D>().AddForce(Vector3.right * forceAmount);
                        break;
                    case 1:
                        newBomb.GetComponent<Rigidbody2D>().AddForce(-Vector3.right * forceAmount);
                        break;
                    case 2:
                        newBomb.GetComponent<Rigidbody2D>().AddForce(Vector3.up * forceAmount);
                        break;
                    case 3:
                        newBomb.GetComponent<Rigidbody2D>().AddForce(-Vector3.up * forceAmount);
                        break;
                    default:
                        break;
                }

            }
            DestroyGameObject();
        }
    }

    private void DestroyGameObject()
    {
        _myGrid.allPositionOnMap.Add(transform.position);

        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
