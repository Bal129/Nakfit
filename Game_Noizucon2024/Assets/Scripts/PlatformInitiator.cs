using System;
using UnityEngine;

public class PlatformInitiator : MonoBehaviour
{
    [Header("PlatformGroup")]
    [SerializeField] private GameObject[] _platforms;
    private int _selectedPlatform;

    [Header("Developer Options")] 
    [SerializeField] private float _initCd = 3;
    [SerializeField] private int _spawnRange = 7;
    private float _currentCd;
    private float _basePositionY;
    private float _newPositionY;

    void Start() 
    {
        _currentCd = 0;
        _basePositionY = transform.position.y;
    }

    void Update() 
    {
        Init();
    }

    void Init() 
    {
        _currentCd -= Time.deltaTime;
        if (_currentCd <= 0)
        {
            _selectedPlatform = UnityEngine.Random.Range(0,_platforms.Length);
            _newPositionY = _basePositionY + (1.2f * UnityEngine.Random.Range(-_spawnRange,_spawnRange));
            _newPositionY = Math.Clamp(_newPositionY, 0f, 4.8f); // Hardcoded for now, edit later
            Instantiate(
                _platforms[_selectedPlatform], 
                new Vector3(transform.position.x, _newPositionY),
                Quaternion.identity
            );
            // Debug.Log("Platform created at " + _newPositionY);
            // _currentCd = UnityEngine.Random.Range(0f,_initCd);
            _currentCd = _initCd;
            transform.position = new Vector2(transform.position.x, _newPositionY);
            _basePositionY = transform.position.y;
        }
    }
}
