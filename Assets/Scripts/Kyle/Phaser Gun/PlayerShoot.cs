using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private int _maxAmmo = 10;
    private int _currentAmmo;

    [SerializeField]
    private TMP_Text _ammoText;

    private float _lastFireTime;

    void Start()
    {
        _currentAmmo = _maxAmmo;
        UpdateAmmoUI();
    }

    void Update()
    {
        bool fireSingle = Input.GetMouseButtonDown(0);  // Detects single click
        bool fireContinuously = Input.GetMouseButton(0); // Detects holding down

        if ((fireSingle || fireContinuously) && _currentAmmo > 0)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if (timeSinceLastFire >= _timeBetweenShots)
            {
                FireBullet();
                _lastFireTime = Time.time;
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

    public void Reload(int ammoAmount)
    {
        _currentAmmo = Mathf.Clamp(_currentAmmo + ammoAmount, 0, _maxAmmo);
        UpdateAmmoUI();  // Ensures the ammo count is updated on screen
    }


    private void UpdateAmmoUI()
    {
        if (_ammoText != null)
        {
            _ammoText.text = _currentAmmo + "/" + _maxAmmo;
        }
    }
}
