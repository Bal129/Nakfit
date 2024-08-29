using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxBG : MonoBehaviour
{
    [SerializeField] private GameObject[] _componentImages;
    [SerializeField] private float[] _componentSpeeds;
    public GameObject p_camera;

    private Vector3[] _componentStartPoses;
    private float[] _componentLengths;

    void Start()
    {
        _componentStartPoses = new Vector3[_componentImages.Length];
        _componentLengths = new float[_componentImages.Length];

        for (int i = 0; i < _componentImages.Length; i++)
        {
            _componentStartPoses[i] = _componentImages[i].transform.position;
            _componentLengths[i] = _componentImages[i].GetComponent<SpriteRenderer>().bounds.size.x;
        }        
    }

    void Update()
    {
        for (int i = 0; i < _componentImages.Length; i++)
        {
            float temp = p_camera.transform.position.x * (1 - _componentSpeeds[i]);
            // float dist = p_camera.transform.position.x * _componentSpeeds[i];

            // _componentImages[i].transform.position += Vector3(
            //     _componentStartPoses[i] + _componentSpeeds[i] * Time.deltaTime,
            //     _componentImages[i].transform.position.y, 
            //     _componentImages[i].transform.position.z
            // );

            // _componentImages[i].transform.position += Vector3.left * _componentSpeeds[i] * Time.deltaTime;

            // _componentImages[i].GetComponent<SpriteRenderer>().material.mainTextureOffset = new Vector2(Time.deltaTime * _componentSpeeds[i], 0f);

            // if (temp > _componentStartPoses[i] + (_componentLengths[i] / 2))
            // {
            //     _componentStartPoses[i] += _componentLengths[i];
            // }
            // else if (temp < _componentStartPoses[i] - (_componentLengths[i] / 2))
            // {
            //     _componentStartPoses[i] -= _componentLengths[i];
            // }

            float newPosition = Mathf.Repeat(Time.time * _componentSpeeds[i], _componentLengths[i]);
            _componentImages[i].transform.position = _componentStartPoses[i] + Vector3.left * newPosition;
        }
    }
}