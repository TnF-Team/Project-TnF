using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // 입력 상태를 저장할 프로퍼티들
    // public bool IsMovingLeft { get; private set; }:**get**이 public이기 때문에, 외부 스크립트에서 IsMovingLeft 값을 읽을 수 있습니다.
    // private bool IsMovingLeft { get; private set; }: **get**도 private이므로, 외부에서 IsMovingLeft 값을 읽을 수 없습니다.
    public bool IsMovingLeft { get; private set; }
    public bool IsMovingRight { get; private set; }
    public bool IsMovingUp { get; private set; }
    public bool IsMovingDown { get; private set; }

    public bool IsSpace { get; private set; }
    public bool IsEsc { get; private set; }
    public bool IsIKey { get; private set; }
    public bool IsRKey { get; private set; }

    private void Update()
    {
        // 방향 이동 입력 처리 (WASD 및 방향키)
        IsMovingLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        IsMovingRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        IsMovingUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        IsMovingDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

        // 상호작용 키 입력 처리 (Space 및 Enter)
        IsSpace = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return);

        // ESC, I, R 키 입력 처리
        IsEsc = Input.GetKeyDown(KeyCode.Escape);
        IsIKey = Input.GetKeyDown(KeyCode.I);
        IsRKey = Input.GetKeyDown(KeyCode.R);
    }

    // 입력 상태를 초기화하는 메서드
    public void RefreshInputStates()
    {
        IsMovingLeft = false;
        IsMovingRight = false;
        IsMovingUp = false;
        IsMovingDown = false;
        IsSpace = false;
        IsEsc = false;
        IsIKey = false;
        IsRKey = false;
    }
}