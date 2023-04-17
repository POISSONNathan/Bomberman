using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float _maxLife;

    [SerializeField]
    public float _life;

    [SerializeField]
    private Image progressBarLife;

    private Vector2 _startPos;

    void Start()
    {
        _startPos = transform.position;
        ResetLife();
    }

    void Update()
    {
        
    }

    public void ResetLife()
    {
        _life = _maxLife;
        progressBarLife.fillAmount = 1f;
    }

    public void AddLife(float ammountOfLifeChange)
    {
        _life += ammountOfLifeChange;
        progressBarLife.fillAmount = _life / _maxLife;

        if (_life <= 0)
        {
            ResetLife();
            transform.position = _startPos;
        }
    }

    public void DeacreaseLife(float ammountOfLifeChange)
    {
        AddLife(-ammountOfLifeChange);
    }
}
