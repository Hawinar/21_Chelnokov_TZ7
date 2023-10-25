using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _heathBarFilling;
    [SerializeField] private Health _health;


    private void Awake()
    {
        _health.HealthChanged += OnHealthChanged;
    }
    private void OnDestroy()
    {
        _health.HealthChanged -= OnHealthChanged;
    }
    private void OnHealthChanged(float valueAsPercentage)
    {
        Debug.Log(valueAsPercentage);
        _heathBarFilling.fillAmount = valueAsPercentage;
    }
}
