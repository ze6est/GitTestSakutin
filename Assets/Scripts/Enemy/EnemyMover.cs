using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private LevelManager _levelManager;

    [SerializeField] private float _speedEnemy;      

    private void Update()
    {        
        _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        if (_levelManager.LevelM == 1)
        {
            _speedEnemy = 2.0f;
        } 
        else if (_levelManager.LevelM == 2)
        {
            _speedEnemy = 2.75f;
        } 
        else if (_levelManager.LevelM == 3)
        {
            _speedEnemy = 3.5f;
        }
        else if (_levelManager.LevelM == 4)
        {
            _speedEnemy = 4.25f;
        }
        else
        {
            _speedEnemy = _levelManager.LevelM;
        }

        transform.Translate(Vector3.left * _speedEnemy * Time.deltaTime);        
    }

    
}
