using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingMenu : MonoBehaviour
{
    public RectTransform menu; // 움직일 메뉴의 RectTransform
    public float slideDuration = 0.5f; // 메뉴가 슬라이드하는 데 걸리는 시간
    public Vector2 hiddenPosition; // 메뉴의 숨겨진 위치
    public Vector2 visiblePosition; // 메뉴의 보이는 위치
    private bool isMenuVisible = false; // 메뉴가 보이는 상태인지 확인

    // 버튼 클릭 시 호출될 메서드
    public void ToggleMenu()
    {
        if (isMenuVisible)
        {
            StartCoroutine(SlideMenu(hiddenPosition));
        }
        else
        {
            StartCoroutine(SlideMenu(visiblePosition));
        }
        isMenuVisible = !isMenuVisible;
    }

    // 메뉴 슬라이드 효과를 구현하는 Coroutine
    private IEnumerator SlideMenu(Vector2 targetPosition)
    {
        Vector2 startPosition = menu.anchoredPosition; // 현재 위치
        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            menu.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / slideDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        menu.anchoredPosition = targetPosition; // 최종 위치로 설정
    }
}