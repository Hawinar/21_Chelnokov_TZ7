using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    private int _health;

    [SerializeField] private GameObject _gameOverUI;

    public event Action<float> HealthChanged;
    private void Start()
    {
        _health = _maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        ChangeHealth(0);
    }
    private void ChangeHealth(int value)
    {
        _health += value;
        if(_health <= 0)
        {
            Death();
        }
        else
        {
            float _healthAsPercentage = (float)_health / _maxHealth;
            HealthChanged?.Invoke(_healthAsPercentage);
        }

        if (_health > _maxHealth)
            _health -= _maxHealth;
    }
    private void Death()
    {
        HealthChanged?.Invoke(0);
        Time.timeScale = 0;
        _gameOverUI.SetActive(true);

    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "EnemyProjectile":
                ChangeHealth(-10);
                Destroy(collision.gameObject);
                break;

            case "Airplane":
                ChangeHealth(-100);
                Destroy(collision.gameObject);
                break;
        }
    }
}
