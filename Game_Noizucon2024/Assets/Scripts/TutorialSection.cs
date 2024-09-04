using UnityEngine;

public class TutorialSection : MonoBehaviour
{
    [Header("Texts for tutorial")]
    [SerializeField] private RectTransform crouch;
    [SerializeField] private RectTransform stand;
    [SerializeField] private RectTransform meter_loop;
    [SerializeField] private RectTransform cancel_jump;

        
    void Start()
    {
        
    }

    void Update()
    {
    crouch.gameObject.SetActive(false);        
    }

    void ChangeText(bool crouch, bool stand, bool meter_loop, bool cancel_jump)
    {
        
    }
}
