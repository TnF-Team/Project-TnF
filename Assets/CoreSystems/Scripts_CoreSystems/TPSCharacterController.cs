using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCharacterController : MonoBehaviour
{
    [SerializeField] private Transform cameraArm;

    [Tooltip("Character control with animation attached")]
    [SerializeField] private Transform body;


    Animator animator;

    private void Start()
    {
        animator = body.GetComponent<Animator>();
    }
    private void Update()
    {
        LookAround();
    }

    /// <summary>
    /// 마우스가 이동한 값에 따라 카메라(암)을 회전
    /// </summary>
    void LookAround()
    {
        //마우스가 기존위치대비 얼마나 이동했는지 값을 받아서 Vector2에 저장
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        
        // camArm의 rotaition값을 오일러각으로 변환해둠
        Vector3 camAngle = cameraArm.rotation.eulerAngles;

        float x = camAngle.x - mouseDelta.y;

        if (x < 180f)//카메라가 캐릭터머리위로가서 위에서 아래를 찍는구도
        {
            x = Mathf.Clamp(x, -1f, 70f);// min값을 -1이아닌 0으로주면 카메라가 수평아래로 내려가서 캐릭터를 올려보는기능이 구현되지않기때문.
        }
        else
        {
            x = Mathf.Clamp(x, 300f, 361f);
        }

        // camAngle과 mouseDelta값을 합쳐서 새로운 회전값을 만들어낸다음 cameraArm.rotation에 대입
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);//위를보면 위를보고 아래를보면 아래로보는 로직

        Move();
    }

    /// <summary>
    /// 마우스가 바라보고있는 방향을 기준으로 플레이어(Body)를 이동
    /// </summary>
    void Move()
    {
        Debug.DrawRay(cameraArm.position, cameraArm.forward, Color.red );
    }
}
