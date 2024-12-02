using UnityEngine;
using UnityEngine.UI;

public class ButtonImageChanger : MonoBehaviour
{
    // 버튼에 연결된 Image 컴포넌트
    public Button targetButton;
    public Image buttonImage;

    // 변경할 스프라이트
    public Sprite newSprite;

    void Start()
    {
        // 버튼 클릭 이벤트에 메서드 추가
        if (targetButton != null)
        {
            targetButton.onClick.AddListener(ChangeButtonImage);
        }
    }

    void ChangeButtonImage()
    {
        if (buttonImage != null && newSprite != null)
        {
            // 버튼의 이미지를 새로운 스프라이트로 변경
            buttonImage.sprite = newSprite;
        }
    }
}