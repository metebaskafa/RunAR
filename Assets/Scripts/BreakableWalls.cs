using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakableWalls : MonoBehaviour
{
    static public float _bulletDmg = 5;
    public float _wallHp = 30;
    public TextMeshProUGUI _wallHpDisplay;

    private void OnEnable()
    {
        PowerUpDoors.OnPowerUp += wallHpIncrease;
    }
    private void Update()
    {
        _wallHpDisplay.text = _wallHp.ToString();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (_wallHp > _bulletDmg)
            {
                _wallHp -= _bulletDmg;
                other.gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
                other.gameObject.SetActive(false);
            }
        }

        
    }
    private void wallHpIncrease() 
    {
        _wallHp += 10;
    }
    private void OnDisable()
    {
        PowerUpDoors.OnPowerUp -= wallHpIncrease;
    }
}