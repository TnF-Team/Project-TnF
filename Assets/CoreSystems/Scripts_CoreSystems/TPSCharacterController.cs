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
        //카메라 정면이 향하는방향으로 레이가 뻗어지는데 이러면 위나 아래로 기울어짐, 플레이어의 이동을위해 Y축값이 없는 X축 rotation값만 추출할것.
        //Debug.DrawRay(cameraArm.position, cameraArm.forward, Color.red );

        //y값을 제거해서 높이가없이 x rotate방향으로만 뻗어나가는 ray, normalized == 길이를 1로 맞춰주는기능
        // Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x, 0, cameraArm.forward.z).normalized, Color.red);

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // moveInput의길이가 0이면 입력이 발생하지않고(0, false)있는것이고, 그렇지않다면 입력이 발생중이므로 1(true) 
        bool ismove = moveInput.magnitude != 0;
        animator.SetBool("IsMove", ismove);

        if (ismove)
        {
            Vector3 lookForward = new Vector3 (cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x,0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            //캐릭터가 바라보는 방향 결정하는방법1. 캐릭터를 이동시킬때 시선을 정면으로 고정시킨다.
            //body.Forward = lookForward 해주면됨
            //이렇게하면 캐릭터는항상 정면을보기때문에 뒷걸음, 좌우걸음 애니메이션을 추가해줘야한다.
            body.forward = lookForward;
            
            //2번방향캐릭터는 입력한 키의 방향으로 움직인다
            //캐릭터가 항상 이동해야하는방향만 바라보기때문에 좀 직관적이지않지만 섬세한 컨트롤이 가능해진다.
            //body.forward = moveDir;

            transform.position += moveDir * Time.deltaTime * 5f;
        }

    }

    void DrwaPlayerRay()
    {

    }
}
