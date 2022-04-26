using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Hearth _hearthTemplate;

    private List<Hearth> _hearts = new List<Hearth>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if(_hearts.Count < value)
        {
            int creareHealth = value - _hearts.Count;
            for (int i = 0; i < creareHealth; i++)
            {
                CreateHearth();
            }
        }
        else if(_hearts.Count > value && _hearts.Count != 0)
        {
            int deleteHealth = _hearts.Count - value;
            for (int i = 0; i < deleteHealth; i++)
            {
                DestroyHearth(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void CreateHearth()
    {
        Hearth newHearth = Instantiate(_hearthTemplate, transform);
        _hearts.Add(newHearth.GetComponent<Hearth>());
        newHearth.ToFill();
    }

    private void DestroyHearth(Hearth hearth)
    {
        _hearts.Remove(hearth);
        hearth.ToEmpty();
    }
}
