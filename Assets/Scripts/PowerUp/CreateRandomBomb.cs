using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomBomb : PowerUp
{
    public Grid myGrid;

    [SerializeField]
    private float minBomb;

    [SerializeField]

    private float maxBomb;
    void Update()
    {
        MyUpdate();   
    }

     public override void AddEffect(PlayerBombGenerator playerUseBomb)
     {
        var numberBomb = Random.Range(minBomb, maxBomb);

        for (int i = 0; i < numberBomb; i++)
        {
            var randomPos = Random.Range(0, myGrid.listDestructibleWall.Count);

            while (myGrid.listDestructibleWall[randomPos].gameObject.activeSelf )
            {
                randomPos = Random.Range(0, myGrid.listDestructibleWall.Count);
            }

            playerUseBomb.CreateBomb(myGrid.listDestructibleWall[randomPos].transform.position);

        }
    }
}
