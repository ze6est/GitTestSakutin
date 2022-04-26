using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player _player;    
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private TextMeshProUGUI _levelText;    

    private int _level = 0;
    private int _points = 0;
    private float _waitSeconds = 20.0f;

    public int LevelM => _level;
    public int PointsM => _points;

    void Start()
    {        
        StartCoroutine(Level());
        StartCoroutine(Points());
    }

    
    void Update()
    {
        
    }

    private IEnumerator Level()
    {
        while (!_player.StopGame())
        {
            ++_level;
            _levelText.text = "LEVEL " + _level;
            yield return new WaitForSeconds(_waitSeconds);
        }          
    }

    private IEnumerator Points()
    {
        while (!_player.StopGame())
        {
            ++_points;
            _pointsText.text = "POINTS " + _points;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
