using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // 입력 상태를 저장할 프로퍼티들
    // public bool IsMovingLeft { get; private set; }:**get**이 public이기 때문에, 외부 스크립트에서 IsMovingLeft 값을 읽을 수 있습니다.
    // private bool IsMovingLeft { get; private set; }: **get**도 private이므로, 외부에서 IsMovingLeft 값을 읽을 수 없습니다.
    /*public bool IsMovingLeft { get; private set; }
    public bool IsMovingRight { get; private set; }
    public bool IsMovingFront { get; private set; }
    public bool IsMovingBack { get; private set; }*/

    public float hAxis { get; private set; }
    public float vAxis { get; private set; }
    public Vector3 moveVec { get; private set; }

    public bool IsLeftShift { get; private set; }


    public bool IsEsc { get; private set; }
    public bool IsSpace { get; private set; }
    public bool IsIKey { get; private set; }
    public bool IsRKey { get; private set; }
    public bool IsCKey { get; private set; }

    private void Update()
    {
        // 지속 입력: 방향 이동 입력 처리 (WASD 및 방향키), 달리기용 Shift
        /*IsMovingLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        IsMovingRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        IsMovingFront = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        IsMovingBack = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);*/

        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;


        IsLeftShift = Input.GetKey(KeyCode.LeftShift);

        // 일회성 입력: ESC, Space, 키 입력 처리
        IsEsc = Input.GetKeyDown(KeyCode.Escape);
        IsSpace = Input.GetKeyDown(KeyCode.Space);

        IsIKey = Input.GetKeyDown(KeyCode.I);
        IsRKey = Input.GetKeyDown(KeyCode.R);
        IsCKey = Input.GetKeyDown(KeyCode.C);


    }

    // 입력 상태를 초기화하는 메서드
    public void RefreshInputStates()
    {
        /*IsMovingLeft = false;
        IsMovingRight = false;
        IsMovingFront = false;
        IsMovingBack = false;*/
        IsLeftShift = false;

        IsEsc = false;
        IsSpace = false;

        IsIKey = false;
        IsRKey = false;
        IsCKey= false;
    }
}