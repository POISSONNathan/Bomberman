using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    private float timer;

    [SerializeField]
    private float _lifeSpan;

    [SerializeField]
    private Renderer mRenderer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > _lifeSpan)
        {
            Destroy(gameObject);
        }

        Color color = mRenderer.material.color;
        color.a = 1-(timer / _lifeSpan);
        mRenderer.material.color = color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                collision.GetComponent<Life>().DeacreaseLife(_lifeSpan + 1 - timer);
                Destroy(gameObject);
                break;

            case "Wall":
                Destroy(gameObject);
                break;

            case "DestructibleWall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            default:
                break;
        };
    }
}
