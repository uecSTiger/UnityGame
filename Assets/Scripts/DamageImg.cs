using UnityEngine;
using UnityEngine.UI;

public class DamageImg : MonoBehaviour
{
    private Image img;

    void Start()
    {
        img = GetComponent<Image>();
        img.color = Color.clear;
    }

    void Update()
    {
      img.color = Color.Lerp(img.color, Color.clear, Time.deltaTime);
    }
}
