using UnityEngine;
using UnityEngine.UI; // UI 관련 스크립트에 활용

public class DiceChange : MonoBehaviour
{
    [SerializeField]
    private Sprite[] Image;
    Image img; // 현재 이미지

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void ChangeImage(int value)
    {
        img.sprite = Image[value];
    }

}
