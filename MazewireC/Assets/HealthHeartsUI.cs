using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeartsUI : MonoBehaviour
{

    [SerializeField] private GameObject heart;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    
    [SerializeField] private float distanceBetweenHearts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawHearts(int life, int totalLife)
    {
        Image heartImgInstance;
        for(int i = 0; i < totalLife; i ++)
        {
            heartImgInstance = Instantiate(heart, transform).GetComponent<Image>();
            heartImgInstance.rectTransform.anchoredPosition = new Vector3(heartImgInstance.rectTransform.anchoredPosition.x + i * distanceBetweenHearts,
                                                           heartImgInstance.rectTransform.anchoredPosition.y,
                                                           0);
            if(i < life)
            {
                heartImgInstance.sprite = fullHeart;
            }
            else
            {
                heartImgInstance.sprite = emptyHeart;
            }
            
        }
    }
}
