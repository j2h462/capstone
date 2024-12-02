using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneTrans : MonoBehaviour
{
    public Image fadeImage; // 화면을 어둡게 만들 이미지
    public float fadeDuration = 1.0f; // 페이드 아웃 시간
    public string nextSceneName; // 전환할 씬 이름
   
   


    // 버튼 클릭 시 호출되는 함수
    public void OnButtonClick()
    {
        StartCoroutine("FadeOutAndLoadScene");
    }

    // 페이드 아웃 후 씬을 로드하는 코루틴
    private IEnumerator FadeOutAndLoadScene()
    {
        float elapsedTime = 0f;

        // 페이드 아웃 (화면을 점점 어둡게)
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration); // 알파 값 증가
            fadeImage.color = new Color(0, 0, 0, alpha); // 이미지 색상에 알파 적용
            yield return null; // 다음 프레임까지 대기
        }

        // 페이드 아웃 완료 후 씬 전환
        SceneManager.LoadScene(nextSceneName);
    }


}