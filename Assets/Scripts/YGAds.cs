using UnityEngine;
using YG;

public class YGAds : MonoBehaviour
{
    private float advertisementInterval = 120f; // Интервал между рекламными воспроизведениями в секундах
    private float timer;

    void Start()
    {
        YandexGame.FullscreenShow();
        timer = advertisementInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {

            PlayAdvertisement();
            timer = advertisementInterval;
        }
    }

    void PlayAdvertisement()
    {
        YandexGame.FullscreenShow();
    }
}
