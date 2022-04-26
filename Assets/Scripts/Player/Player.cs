using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bam;
    [SerializeField] private ParticleSystem _lifeVideo;
    [SerializeField] private AudioClip _crash;
    [SerializeField] private AudioClip _lifeSound;
    [SerializeField] private CameraShake _cameraShake;
    [SerializeField] private int _health;

    private AudioSource _audio;
    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        HealthChanged?.Invoke(_health);
    }

    // принимаемый урон
    public void ApplyDamage(int damage)
    {
        _bam.Play();
        _audio.PlayOneShot(_crash, 1f);
        _cameraShake.Shake();
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (StopGame())
            Die();
    }

    public void ApplyLife(int life)
    {
        _lifeVideo.Play();
        _audio.PlayOneShot(_lifeSound, 1f);        
        _health += life;
        HealthChanged?.Invoke(_health);        
    }

    // смерть
    public void Die()
    {
        Died?.Invoke();        
    }    

    public bool StopGame()
    {
        if (_health <= 0)
            return true;
        else
            return false;
    }    
}
