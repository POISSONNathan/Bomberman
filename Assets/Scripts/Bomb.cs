using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _timer;

    public float lifeSpan;

    public GameObject bombExplode;

    public float forceAmount;

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
        Destroy(gameObject);
    }
}
