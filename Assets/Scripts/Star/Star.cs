using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    private Grid _myGrid;

    private void Start()
    {
        _myGrid = FindObjectOfType<Grid>();
    }

    private void Update()
    {
        transform.Rotate(0f, 1f, 0f, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var currentPlayer = collision.GetComponent<PlayerStar>();
        if (currentPlayer != null)
        {
            currentPlayer.GetStar();
            _myGrid.allPositionOnMap.Add(transform.position);

            int randomStarPos = Random.Range(0, _myGrid.allPositionOnMap.Count);
            transform.position = _myGrid.allPositionOnMap[randomStarPos];
            _myGrid.allPositionOnMap.Remove(transform.position);
        }
    }
}
