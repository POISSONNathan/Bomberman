using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Grid : MonoBehaviour
{
    public int _minWallDestructible;
    public int _maxWallDestructible;

    public GameObject destructibleWall;
    public GameObject ubdestructibleWall;
    public GameObject wallAroudMap;

    public List<Vector2> allPositionOnMap;

    private int numberWallX;
    private int numberWallY;

    public int numberPlayer;

    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private Camera myCamera;

    public List<GameObject> listPowerUp;

    private int _numberOfEachPowerUp;

    [SerializeField]
    private int _timeToReCreateWallOnMap;

    private int _numberToReCreateWallOnMap;

    [SerializeField]
    private GameObject _star;

    private gameManager _myGameManager;

    private int _numberWallMaxOnMap;
    private int _numberWallOnMap;

    void Start()
    {
        _myGameManager = FindObjectOfType<gameManager>();

        numberWallX = _myGameManager.sizeWallX;
        numberWallY = _myGameManager.sizeWallY;

        _numberToReCreateWallOnMap = (_myGameManager.numberCaseInMap / 50) + 1;
        _numberOfEachPowerUp = (_myGameManager.numberCaseInMap / 50) + 1;

        _minWallDestructible = _myGameManager.numberCaseInMap / 5;
        _maxWallDestructible = _myGameManager.numberCaseInMap / 4;

        _numberWallMaxOnMap = _myGameManager.numberCaseInMap / 3;

        if (_myGameManager.gameMode == "Solo")
        {
            numberWallX = 13;
            numberWallY = 9;
        }

        // all vector in grid
        for (int i = 0; i < numberWallX; i++)
        {
            for (int j = 0; j < numberWallY; j++)
            {
                allPositionOnMap.Add(new Vector2(i, j));
            }
        }

        // set camera position
        myCamera.transform.position = new Vector3(allPositionOnMap[allPositionOnMap.Count / 2].x, allPositionOnMap[allPositionOnMap.Count / 2].y, -Mathf.Max(numberWallX - 2, numberWallY));

        GenerateUndestructibleWall();

        // number player
        switch (numberPlayer)
        {
            case 1:
                player1.transform.position = allPositionOnMap[0];

                allPositionOnMap.Remove(new Vector2(0,1));
                allPositionOnMap.Remove(new Vector2(1,0));

                allPositionOnMap.Remove(allPositionOnMap[0]);

                break;
            case 2:
                player1.transform.position = allPositionOnMap[0];

                allPositionOnMap.Remove(new Vector2(0, 1));
                allPositionOnMap.Remove(new Vector2(1, 0));

                allPositionOnMap.Remove(allPositionOnMap[0]);

                player2.transform.position = allPositionOnMap[allPositionOnMap.Count - 1];

                allPositionOnMap.Remove(new Vector2(allPositionOnMap[allPositionOnMap.Count - 1].x -1, allPositionOnMap[allPositionOnMap.Count - 1].y));
                allPositionOnMap.Remove(new Vector2(allPositionOnMap[allPositionOnMap.Count - 1].x, allPositionOnMap[allPositionOnMap.Count - 1].y - 1));

                allPositionOnMap.Remove(allPositionOnMap[allPositionOnMap.Count - 1]);
                break;
            default:
                break;
        }

        StartCoroutine(CreateWall());

        GenerateDestructibleWall();
    }

    private void GenerateUndestructibleWall()
    {
        // undestructible wall generator
        for (int i = 0; i < allPositionOnMap.Count; i++)
        {
            if (allPositionOnMap[i].x % 2 == 1 && allPositionOnMap[i].y % 2 == 1)
            {
                Instantiate(ubdestructibleWall, allPositionOnMap[i], Quaternion.identity, transform);
                allPositionOnMap.Remove(allPositionOnMap[i]);
            }

            if (allPositionOnMap[i].x == 0)
            {
                Instantiate(wallAroudMap, new Vector2(allPositionOnMap[i].x - 1, allPositionOnMap[i].y), Quaternion.identity, transform);
                if (allPositionOnMap[i].y == 0)
                {
                    Instantiate(wallAroudMap, new Vector2(allPositionOnMap[i].x - 1, allPositionOnMap[i].y-1), Quaternion.identity, transform);
                }
                if (allPositionOnMap[i].y == numberWallY - 1)
                {
                    Instantiate(wallAroudMap, new Vector2(allPositionOnMap[i].x - 1, allPositionOnMap[i].y + 1), Quaternion.identity, transform);
                }
            }
            if (allPositionOnMap[i].x == numberWallX - 1)
            {
                Instantiate(wallAroudMap, new Vector2(allPositionOnMap[i].x + 1, allPositionOnMap[i].y), Quaternion.identity, transform);
                if (allPositionOnMap[i].y == 0)
                {
                    Instantiate(wallAroudMap, new Vector2(allPositionOnMap[i].x + 1, allPositionOnMap[i].y - 1), Quaternion.identity, transform);
                }
                if (allPositionOnMap[i].y == numberWallY - 1)
                {
                    Instantiate(wallAroudMap, new Vector2(allPositionOnMap[i].x + 1, allPositionOnMap[i].y + 1), Quaternion.identity, transform);
                }
            }
            if (allPositionOnMap[i].y == 0)
            {
                Instantiate(wallAroudMap, new Vector2(allPositionOnMap[i].x, allPositionOnMap[i].y - 1), Quaternion.identity, transform);
            }
            if (allPositionOnMap[i].y == numberWallY - 1)
            {
                Instantiate(wallAroudMap, new Vector2(allPositionOnMap[i].x, allPositionOnMap[i].y + 1), Quaternion.identity, transform);
            }
        }

        if (_myGameManager.gameMode == "Solo")
        {
            CreateStar();
        }
    }

    private void GenerateDestructibleWall()
    {
        // destructible wall generator
        int numberWall = Random.Range(_minWallDestructible, _maxWallDestructible);

        for (int i = 0; i < numberWall; i++)
        {
            int randomPosInList = Random.Range(0, allPositionOnMap.Count);
            Instantiate(destructibleWall, allPositionOnMap[randomPosInList], Quaternion.identity, transform);
            _numberWallOnMap++;
            allPositionOnMap.Remove(allPositionOnMap[randomPosInList]);
        }

        // set position power up
        for (int i = 0; i < _numberOfEachPowerUp; i++)
        {
            for (int j = 0; j < listPowerUp.Count; j++)
            {
                int randomPowerUpPos = Random.Range(0, allPositionOnMap.Count);
                Instantiate(listPowerUp[j], allPositionOnMap[randomPowerUpPos], Quaternion.identity);
                allPositionOnMap.Remove(allPositionOnMap[randomPowerUpPos]);
            }
        }
    }

    private void CreateStar()
    {
        int randomStarPos = Random.Range(0, allPositionOnMap.Count);
        Instantiate(_star, allPositionOnMap[randomStarPos], Quaternion.identity);
        allPositionOnMap.Remove(allPositionOnMap[randomStarPos]);
    }

    IEnumerator CreateWall()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToReCreateWallOnMap);
            if (_numberWallOnMap <= _numberWallMaxOnMap)
            {
                for (int i = 0; i < _numberToReCreateWallOnMap; i++)
                {
                    int randomPosInList = Random.Range(0, allPositionOnMap.Count);
                    Instantiate(destructibleWall, allPositionOnMap[randomPosInList], Quaternion.identity, transform);
                    allPositionOnMap.Remove(allPositionOnMap[randomPosInList]);
                    _numberWallOnMap++;
                }
            }
        }
    }
}
