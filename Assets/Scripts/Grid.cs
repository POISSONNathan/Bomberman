using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private int _minWall;
    [SerializeField]
    private int _maxWall;

    public List<GameObject> listDestructibleWall;

    void Start()
    {
        int numberWall = Random.Range(_minWall, _maxWall);

        for (int i = 0; i < numberWall; i++)
        {
            int randomInList = Random.Range(0, listDestructibleWall.Count);

            while (listDestructibleWall[randomInList].activeSelf)
            {
                randomInList = Random.Range(0, listDestructibleWall.Count);
            }

            listDestructibleWall[randomInList].SetActive(true);
        }
    }

}
