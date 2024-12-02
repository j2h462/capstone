using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swip_menu : MonoBehaviour
{
    public GameObject scrollBar; // Scrollbar 오브젝트
    private Scrollbar scrollbarComponent; // Scrollbar 컴포넌트 캐싱
    private float scroll_pos = 0f; // 현재 스크롤 위치
    private float[] pos; // 스냅 포인트 배열

    private const float scaleFocused = 1.5f; // 선택된 항목의 확대 비율
    private const float scaleUnfocused = 1f; // 선택되지 않은 항목의 축소 비율

    void Start()
    {
        
        scrollbarComponent = scrollBar.GetComponent<Scrollbar>();

        // 자식 개수 기반으로 스냅 포인트 배열 초기화
        int childCount = transform.childCount;
        pos = new float[childCount];
        float distance = 1f / (childCount - 1f);

        for (int i = 0; i < childCount; i++)
        {
            pos[i] = distance * i; // 각 스냅 포인트 계산
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // 마우스 왼쪽 버튼 확인
        {
            scroll_pos = scrollbarComponent.value; // 현재 스크롤 위치 저장
        }
        else
        {
            SnapToNearestPosition();
        }

        UpdateChildScales();
    }

    private void SnapToNearestPosition()
    {
        // 스크롤 위치를 가장 가까운 포인트로 스냅
        for (int i = 0; i < pos.Length; i++)
        {
            float halfDistance = 0.5f / pos.Length;
            if (scroll_pos < pos[i] + halfDistance && scroll_pos > pos[i] - halfDistance)
            {
                scrollbarComponent.value = Mathf.Lerp(scrollbarComponent.value, pos[i], 0.05f);
               
            }
        }
    }

    private void UpdateChildScales()
    {
        // 자식 오브젝트의 크기 업데이트
        for (int i = 0; i < pos.Length; i++)
        {
            float halfDistance = 0.5f / pos.Length;
            if (scroll_pos < pos[i] + halfDistance && scroll_pos > pos[i] - halfDistance)
            {
                // 선택된 항목 확대
                UpdateButtonScale(transform.GetChild(i), scaleFocused);
                SetButtonInteractable(transform.GetChild(i), true);

                // 다른 항목 축소
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        UpdateButtonScale(transform.GetChild(j), scaleUnfocused);
                        SetButtonInteractable(transform.GetChild(j), false);
                    }
                }
            }
        }
    }

    private void UpdateButtonScale(Transform button, float targetScale)
    {
        // 버튼 크기만 조정, 자식 텍스트 크기에는 영향을 주지 않음
        Vector3 newScale = Vector3.Lerp(button.localScale, new Vector3(targetScale, targetScale, 1f), 0.05f);
        button.localScale = newScale;

        // 텍스트 오브젝트의 스케일 초기화
        Text textComponent = button.GetComponentInChildren<Text>();
        if (textComponent != null)
        {
            textComponent.transform.localScale = Vector3.one; // 텍스트 크기 고정
        }
    }

        private void SetButtonInteractable(Transform button, bool interactable)
    {
        // Button 컴포넌트 확인
        Button buttonComponent = button.GetComponent<Button>();
        if (buttonComponent != null)
        {
            buttonComponent.interactable = interactable;
        }

        // Raycast를 막아 클릭 방지 (Text 등 다른 요소 클릭 방지)
        CanvasGroup canvasGroup = button.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = button.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.blocksRaycasts = interactable;
    }
}
