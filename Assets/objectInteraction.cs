using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class InteractableObject : MonoBehaviour
{
    void OnMouseDown()
    {
        // 오브젝트가 클릭될 때 상호작용을 처리하는 코드
        Interact();
    }

    void Interact()
    {
        // 상호작용 시 발생할 행동을 정의
        Debug.Log("오브젝트와 상호작용 했습니다!");
    }
}
