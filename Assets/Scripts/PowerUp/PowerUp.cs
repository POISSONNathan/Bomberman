using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private float timer;
    [SerializeField]
    private float _timeToReapear;

    private bool respawn;

    public float timePowerUp;

    public Grid myGrid;

    public void MyUpdate()
    {
        if (respawn)
        {
            timer += Time.deltaTime;
            if (timer >= _timeToReapear)
            {
                timer = 0;
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                respawn = false;
            }
        }
        transform.Rotate(1f, -1f, 0f, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.GetComponent<MeshRenderer>().enabled == true)
        {
            myGrid.allPositionOnMap.Remove(transform.position);

            gameObject.GetComponent<MeshRenderer>().enabled = false;
            respawn = true;
            PlayerBombGenerator playerUseBomb = collision.GetComponent<PlayerBombGenerator>();

            int randomPowerUpPos = Random.Range(0, myGrid.allPositionOnMap.Count);
            transform.position = myGrid.allPositionOnMap[randomPowerUpPos];

            myGrid.allPositionOnMap.Add(transform.position);

            AddEffect(playerUseBomb);
        }
    }

    public virtual void AddEffect(PlayerBombGenerator playerUseBomb)
    {

    }
}
