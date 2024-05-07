using UnityEngine;
using UnityEngine.UI;

public class DynamicFaceDisplay : MonoBehaviour
{
    [SerializeField] private Sprite[] faceSprites; 
    [SerializeField] private Image imageComponent; 
    private float changeInterval = 1f; 

    void Start()
    {
        InvokeRepeating("ChangeFace", 0f, changeInterval);
    }

    void ChangeFace()
    {
        int randomIndex = Random.Range(0, faceSprites.Length);
        imageComponent.sprite = faceSprites[randomIndex];
    }
}
