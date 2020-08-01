using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ChangerHelthBar : MonoBehaviour
{
    [SerializeField] private float _health, _takeDamage, _takeTreatment;
    [SerializeField] private float _durationDamage, _durationTreatment;

    private Slider _slider;
    private bool _damage, _treatment;
    private float _healthAfterDamage, _healthAfterTreatment;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _health;
        _slider.value = _health;
    }

    public void Damage()
    {
        _damage = true;
        _healthAfterDamage = _slider.value - _takeDamage;
    }

    public void Treatment()
    {
        _treatment = true;
        _healthAfterTreatment = _slider.value + _takeTreatment;
    }


    public void Update()
    {
        if (_damage)
        {
            if (_healthAfterDamage >= _slider.value)
                _damage = false;
            else
                _slider.value = Mathf.Lerp(_slider.value, _slider.value - _takeDamage, _durationDamage * Time.deltaTime);

        }

        if (_treatment)
        {
            if (_healthAfterTreatment <= _slider.value)
                _treatment = false;
            else
                _slider.value = Mathf.Lerp(_slider.value, _slider.value + _takeTreatment, _durationTreatment * Time.deltaTime);
        }
    }
}
