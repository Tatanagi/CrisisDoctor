using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private Transform _gunOffset;
    [SerializeField]
    private float _timeBetweenShots;
    [SerializeField]
    private int _maxAmmo = 10; // Maximum ammo count
    private int _currentAmmo;
    
    [SerializeField]
    private TMP_Text _ammoText; // Reference to a UI TextMeshPro element to display ammo
    
    private bool _fireSingle;
    private bool _fireContinuously;
    private float _lastFireTime;

    void Start()
    {
        _currentAmmo = _maxAmmo;
        UpdateAmmoUI();
    }

    void Update()
    {
        if ((_fireContinuously || _fireSingle) && _currentAmmo > 0)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if (timeSinceLastFire >= _timeBetweenShots)
            {
                FireBullet();
                _lastFireTime = Time.time;
                _fireSingle = false;
            }
        }
    }

    private void FireBullet()
    {
        if (_currentAmmo > 0)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, _gunOffset.rotation);
            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

            if (rigidbody != null)
            {
                rigidbody.velocity = _gunOffset.up * _bulletSpeed;
            }

            _currentAmmo--;
            UpdateAmmoUI();
        }
    }

    private void OnFire(InputValue inputValue)
    {
        _fireContinuously = inputValue.isPressed;

        if (inputValue.isPressed)
        {
            _fireSingle = true;
        }
    }

    public void Reload(int ammoAmount)
    {
        _currentAmmo = Mathf.Min(_currentAmmo + ammoAmount, _maxAmmo);
        UpdateAmmoUI();
    }

    private void UpdateAmmoUI()
    {
        if (_ammoText != null)
        {
            _ammoText.text = _currentAmmo + "/" + _maxAmmo;
        }
    }
}
