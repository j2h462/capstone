using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage;  // 페이드 인/아웃을 위한 이미지 (UI 이미지)
    public float fadeDuration = 1.0f;  // 페이드 인/아웃 시간
    public string nextScene;  // 전환할 씬 이름

    private void OnEnable()
    {
        // 씬이 로드될 때마다 페이드 인을 실행하기 위해 이벤트 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // 이벤트 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        // 시작 시 이미지 투명하게 설정
        fadeImage.color = new Color(0, 0, 0, 0);
    }

    // 씬 로드될 때마다 호출되는 함수
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬 로드 후 페이드 인 시작
        StartCoroutine(FadeIn());
    }

    // 버튼 클릭 시 호출될 함수
    public void OnButtonClick()
    {
        StartCoroutine(FadeOutAndLoadScene());
    }

    // 페이드 아웃 후 씬을 로드하는 코루틴
    private IEnumerator FadeOutAndLoadScene()
    {
        float elapsedTime = 0f;

        // 페이드 아웃 (이미지를 점점 불투명하게 만듦)
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);  // 알파 값 증가
            yield return null;
        }

        // 페이드 아웃 완료 후 씬 로드
        SceneManager.LoadScene(nextScene);
    }

    // 페이드 인 코루틴 (이미지를 점점 투명하게 만듦)
    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        // 시작할 때 이미지를 불투명하게 설정
        fadeImage.color = new Color(0, 0, 0, 1);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = 1 - Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);  // 알파 값 감소
            yield return null;
        }
        
        // 페이드 인 완료 후 이미지의 알파 값을 0으로 설정하여 완전히 투명하게 만듦
        fadeImage.color = new Color(0, 0, 0, 0);
    }
}
