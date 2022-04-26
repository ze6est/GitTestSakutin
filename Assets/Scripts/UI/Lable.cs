using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lable : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private TextMeshProUGUI _labelText;

    void Update()
    {
        StartCoroutine(Label());
    }    

    private IEnumerator Label()
    {
        if (_player.StopGame())
        {            
            _labelText.text = "�� ������� " + _levelManager.PointsM + " points! ������� ������?";
            yield return null;
        }
    }
}
