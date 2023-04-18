using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombToTake : MonoBehaviour
{
    private CreateBombOnMap _myCreateBombOnMap;
    private Grid _myGrid;

    private void Start()
    {
        _myCreateBombOnMap = FindObjectOfType<CreateBombOnMap>();
        _myGrid = FindObjectOfType<Grid>();
    }
    private void Update()
    {
        transform.Rotate(1f, -1f, 0f, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var currentPlayer = collision.gameObject.GetComponent<PlayerBombGenerator>();

        if (currentPlayer != null)
        {
            _myCreateBombOnMap.numberBombOnMap--;
            _myGrid.allPositionOnMap.Add(transform.position);
            currentPlayer.SetBomb(1);
            Destroy(gameObject);
        }
    }
}
