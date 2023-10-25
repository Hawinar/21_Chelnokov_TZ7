using UnityEngine;
using UnityEngine.UI;

public class OilBar : MonoBehaviour
{
    [SerializeField] private Image _fuelBarFilling;
    [SerializeField] private Fuel _fuel;


    private void Awake()
    {
        _fuel.FuelChanged += OnFuelChanged;
    }
    private void OnDestroy()
    {
        _fuel.FuelChanged -= OnFuelChanged;
    }
    private void OnFuelChanged(float valueAsPercentage)
    {
        _fuelBarFilling.fillAmount = valueAsPercentage;
    }
}
