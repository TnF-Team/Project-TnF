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
    /// ���콺�� �̵��� ���� ���� ī�޶�(��)�� ȸ��
    /// </summary>
    void LookAround()
    {
        //���콺�� ������ġ��� �󸶳� �̵��ߴ��� ���� �޾Ƽ� Vector2�� ����
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        
        // camArm�� rotaition���� ���Ϸ������� ��ȯ�ص�
        Vector3 camAngle = cameraArm.rotation.eulerAngles;

        float x = camAngle.x - mouseDelta.y;

        if (x < 180f)//ī�޶� ĳ���͸Ӹ����ΰ��� ������ �Ʒ��� ��±���
        {
            x = Mathf.Clamp(x, -1f, 70f);// min���� -1�̾ƴ� 0�����ָ� ī�޶� ����Ʒ��� �������� ĳ���͸� �÷����±���� ���������ʱ⶧��.
        }
        else
        {
            x = Mathf.Clamp(x, 300f, 361f);
        }

        // camAngle�� mouseDelta���� ���ļ� ���ο� ȸ������ �������� cameraArm.rotation�� ����
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);//�������� �������� �Ʒ������� �Ʒ��κ��� ����

        Move();
    }

    /// <summary>
    /// ���콺�� �ٶ󺸰��ִ� ������ �������� �÷��̾�(Body)�� �̵�
    /// </summary>
    void Move()
    {
        //ī�޶� ������ ���ϴ¹������� ���̰� �������µ� �̷��� ���� �Ʒ��� ������, �÷��̾��� �̵������� Y�ప�� ���� X�� rotation���� �����Ұ�.
        //Debug.DrawRay(cameraArm.position, cameraArm.forward, Color.red );

        //y���� �����ؼ� ���̰����� x rotate�������θ� ������� ray, normalized == ���̸� 1�� �����ִ±��
        // Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x, 0, cameraArm.forward.z).normalized, Color.red);

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // moveInput�Ǳ��̰� 0�̸� �Է��� �߻������ʰ�(0, false)�ִ°��̰�, �׷����ʴٸ� �Է��� �߻����̹Ƿ� 1(true) 
        bool ismove = moveInput.magnitude != 0;
        animator.SetBool("IsMove", ismove);

        if (ismove)
        {
            Vector3 lookForward = new Vector3 (cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x,0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            //ĳ���Ͱ� �ٶ󺸴� ���� �����ϴ¹��1. ĳ���͸� �̵���ų�� �ü��� �������� ������Ų��.
            //body.Forward = lookForward ���ָ��
            //�̷����ϸ� ĳ���ʹ��׻� ���������⶧���� �ް���, �¿���� �ִϸ��̼��� �߰�������Ѵ�.
            body.forward = lookForward;
            
            //2������ĳ���ʹ� �Է��� Ű�� �������� �����δ�
            //ĳ���Ͱ� �׻� �̵��ؾ��ϴ¹��⸸ �ٶ󺸱⶧���� �� ���������������� ������ ��Ʈ���� ����������.
            //body.forward = moveDir;

            transform.position += moveDir * Time.deltaTime * 5f;
        }

    }

    void DrwaPlayerRay()
    {

    }
}
