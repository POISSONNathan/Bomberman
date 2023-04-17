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
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            respawn = true;
            PlayerBombGenerator playerUseBomb = collision.GetComponent<PlayerBombGenerator>();
            AddEffect(playerUseBomb);
        }
    }

    public virtual void AddEffect(PlayerBombGenerator playerUseBomb)
    {

    }
}
