using System;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField] private int _maxFuel = 25;
    [SerializeField] private float _timeBetweenSpend;

    [SerializeField] private GameObject _gameOverUI;

    private int _fuel;
    private float _spendTime;

    public event Action<float> FuelChanged;
    void Start()
    {
        _fuel = _maxFuel;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > _spendTime)
        {
            ChangeFuel(-1);
            _spendTime = Time.time + _timeBetweenSpend;
        }
    }
    public void ChangeFuel(int value)
    {
        _fuel += value;

        switch (_fuel)
        {
            case <= 0:
                Death();
                break;
            default:
                float _fuelAsPercentage = (float)_fuel / _maxFuel;
                FuelChanged?.Invoke(_fuelAsPercentage);
                break;
        }
        if (_fuel > _maxFuel)
            _fuel = _maxFuel;
    }
    private void Death()
    {
        FuelChanged?.Invoke(0);
        Time.timeScale = 0;
        _gameOverUI.SetActive(true);
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Canister")
        {
            ChangeFuel(25);
            Debug.Log(collision.gameObject.tag);
            Destroy(collision.gameObject);
        }

    }
}
