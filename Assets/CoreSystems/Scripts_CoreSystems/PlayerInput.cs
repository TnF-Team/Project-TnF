using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // �Է� ���¸� ������ ������Ƽ��
    // public bool IsMovingLeft { get; private set; }:**get**�� public�̱� ������, �ܺ� ��ũ��Ʈ���� IsMovingLeft ���� ���� �� �ֽ��ϴ�.
    // private bool IsMovingLeft { get; private set; }: **get**�� private�̹Ƿ�, �ܺο��� IsMovingLeft ���� ���� �� �����ϴ�.
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
        // ���� �̵� �Է� ó�� (WASD �� ����Ű)
        IsMovingLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        IsMovingRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        IsMovingUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        IsMovingDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

        // ��ȣ�ۿ� Ű �Է� ó�� (Space �� Enter)
        IsSpace = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return);

        // ESC, I, R Ű �Է� ó��
        IsEsc = Input.GetKeyDown(KeyCode.Escape);
        IsIKey = Input.GetKeyDown(KeyCode.I);
        IsRKey = Input.GetKeyDown(KeyCode.R);
    }

    // �Է� ���¸� �ʱ�ȭ�ϴ� �޼���
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