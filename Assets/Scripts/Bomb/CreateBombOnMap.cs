using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateBombOnMap : MonoBehaviour
{
    [SerializeField]
    private Grid _myGrid;

    [SerializeField]
    private GameObject _bombToTake;

    [SerializeField]
    private int _delayBetweenCreate;

    private gameManager _myGameManager;

    private int _numberBombToCreateEachTime;
    private int _maxBombOnMap;

    public int numberBombOnMap;
    
    void Start()
    {
        _myGameManager = FindObjectOfType<gameManager>();

        _numberBombToCreateEachTime = (_myGameManager.numberCaseInMap / 50) + 1;
        _maxBombOnMap = _numberBombToCreateEachTime * 2;

        StartCoroutine(GenerateBomb());
    }

    IEnumerator GenerateBomb()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delayBetweenCreate);

            for (int i = 0; i < _numberBombToCreateEachTime; i++)
            {
                if (numberBombOnMap < _maxBombOnMap)
                {
                    var randomPos = Random.Range(0, _myGrid.allPositionOnMap.Count);
                    Instantiate(_bombToTake, _myGrid.allPositionOnMap[randomPos], Quaternion.identity);

                    _myGrid.allPositionOnMap.Remove(_myGrid.allPositionOnMap[randomPos]);
                    numberBombOnMap++;
                }
            }
        }
    }
}
