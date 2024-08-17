using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float mouseSpeed = 2f;
    private float gravity;
    private CharacterController controller;
    private Vector3 mov;


    private float mouseX;

    private float jumpHeight = 1.0f;
    private float gravityValue = -20.0f;
    private float velocityY;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        mov = Vector3.zero;
        gravity = 10f;
        velocityY = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded && velocityY < 0)
        {
            velocityY = 0f;
        }

        // 좌우 시점 변경
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        transform.localEulerAngles = new Vector3(0, mouseX, 0);

        // 플레이어 수평 움직임
        mov = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        mov = controller.transform.TransformDirection(mov);

        // 제곱근을 사용하여 점프의 높이를 조절합니다.
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        // 시간을 사용하여 중력 가속도를 구현합니다.
        velocityY += gravityValue * Time.deltaTime;

        // 수평 이동
        controller.Move(mov * Time.deltaTime * speed);

        // 수직 이동(점프 및 낙하)
        controller.Move(new Vector3(0, velocityY, 0) * Time.deltaTime);
    }
}
