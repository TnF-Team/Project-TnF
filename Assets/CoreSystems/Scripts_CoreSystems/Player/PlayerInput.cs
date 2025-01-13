using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // �Է� ���¸� ������ ������Ƽ��
    // public bool IsMovingLeft { get; private set; }:**get**�� public�̱� ������, �ܺ� ��ũ��Ʈ���� IsMovingLeft ���� ���� �� �ֽ��ϴ�.
    // private bool IsMovingLeft { get; private set; }: **get**�� private�̹Ƿ�, �ܺο��� IsMovingLeft ���� ���� �� �����ϴ�.
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
        // ���� �Է�: ���� �̵� �Է� ó�� (WASD �� ����Ű), �޸���� Shift
        /*IsMovingLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        IsMovingRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        IsMovingFront = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        IsMovingBack = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);*/

        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;


        IsLeftShift = Input.GetKey(KeyCode.LeftShift);

        // ��ȸ�� �Է�: ESC, Space, Ű �Է� ó��
        IsEsc = Input.GetKeyDown(KeyCode.Escape);
        IsSpace = Input.GetKeyDown(KeyCode.Space);

        IsIKey = Input.GetKeyDown(KeyCode.I);
        IsRKey = Input.GetKeyDown(KeyCode.R);
        IsCKey = Input.GetKeyDown(KeyCode.C);


    }

    // �Է� ���¸� �ʱ�ȭ�ϴ� �޼���
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