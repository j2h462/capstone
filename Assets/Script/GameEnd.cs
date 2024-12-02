using UnityEngine;

public class GameEnd : MonoBehaviour
{
    // 게임 종료 함수
    public void EndGame()
    {
        // 에디터에서 실행 중일 때는 플레이 모드를 종료
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 빌드된 게임에서는 애플리케이션 종료
        Application.Quit();
#endif
    }
}
