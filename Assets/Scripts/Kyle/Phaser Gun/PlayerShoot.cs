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

    [SerializeField]
    private AudioClip _fireSound;
    [SerializeField]
    private AudioClip _noAmmoSound;
    private AudioSource _audioSource;

    private float _lastFireTime;

    void Start()
    {
        _currentAmmo = _maxAmmo;
        UpdateAmmoUI();
        _audioSource = GetComponent<AudioSource>(); // Get AudioSource component
    }

    void Update()
    {
        bool fireSingle = Input.GetMouseButtonDown(0);  // Detects single click
        bool fireContinuously = Input.GetMouseButton(0); // Detects holding down

        if ((fireSingle || fireContinuously))
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if (timeSinceLastFire >= _timeBetweenShots)
            {
                if (_currentAmmo > 0)
                {
                    FireBullet();
                }
                else
                {
                    PlayNoAmmoSound(); // Play empty sound if no ammo
                }

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
            PlayFireSound(); // Play firing sound
        }
    }

    public void Reload(int ammoAmount)
    {
        _currentAmmo = Mathf.Clamp(_currentAmmo + ammoAmount, 0, _maxAmmo);
        UpdateAmmoUI();
    }

    private void UpdateAmmoUI()
    {
        if (_ammoText != null)
        {
            _ammoText.text = _currentAmmo + "/" + _maxAmmo;
        }
    }

    private void PlayFireSound()
    {
        if (_audioSource != null && _fireSound != null)
        {
            _audioSource.PlayOneShot(_fireSound);
        }
    }

    private void PlayNoAmmoSound()
    {
        if (_audioSource != null && _noAmmoSound != null)
        {
            _audioSource.PlayOneShot(_noAmmoSound);
        }
    }
}
