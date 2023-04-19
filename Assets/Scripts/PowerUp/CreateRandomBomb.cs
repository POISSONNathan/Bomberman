using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomBomb : PowerUp
{
    public float _numberBombToCreate;

    private gameManager _myGameManager;

    private void Start()
    {
        _myGameManager = FindObjectOfType<gameManager>();

        _numberBombToCreate = _myGameManager.numberCaseInMap / 15;
    }
    void Update()
    {
        MyUpdate();   
    }

     public override void AddEffect(PlayerBombGenerator playerUseBomb)
     {
        for (int i = 0; i < _numberBombToCreate; i++)
        {
            var randomPos = Random.Range(0, myGrid.allPositionOnMap.Count);

            playerUseBomb.CreateBomb(myGrid.allPositionOnMap[randomPos]);

        }
    }
}
