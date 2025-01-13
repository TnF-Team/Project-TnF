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
        Debug.DrawRay(cameraArm.position, cameraArm.forward, Color.red );
    }
}
