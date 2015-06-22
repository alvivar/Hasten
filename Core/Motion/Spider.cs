using UnityEngine;
using System.Collections;


public class Spider : MonoBehaviour
{
    [Header("Rotation Puppet")]
    public Transform puppet;
    public float rotationDecay = 10;
    public int lastDirection;

    [Header("Up")]
    public Vector2 upGravity;
    public Vector2 upJump;
    public Vector2 upGround;

    [Header("Right")]
    public Vector2 rightGravity;
    public Vector2 rightJump;
    public Vector2 rightGround;

    [Header("Down")]
    public Vector2 downGravity;
    public Vector2 downJump;
    public Vector2 downGround;

    [Header("Left")]
    public Vector2 leftGravity;
    public Vector2 leftJump;
    public Vector2 leftGround;

    private Motion motion;
    private Vector3 rotation;


    void Start()
    {
        motion = GetComponent<Motion>();
    }


    void Update()
    {
        // gravity change
        if (lastDirection != motion.lastWallCollision)
        {
            // sfx
            if (lastDirection != 3)
                Sound.Get.PlayClaw();

            // Resets the jump force
            motion.ResetJump();
            lastDirection = motion.lastWallCollision;
            ChangeGravity(lastDirection);
        }

        // rotation change
        ChangeRotation(lastDirection);

        // default platform
        if (motion.isFlying)
            motion.lastWallCollision = 3;

        if (puppet)
            puppet.eulerAngles = Vector3.Lerp(puppet.eulerAngles, rotation, Time.deltaTime * rotationDecay);
    }


    void ChangeGravity(int direction)
    {
        switch (direction)
        {
            case 1:
                motion.allowVertical = false;
                motion.allowHorizontal = true;
                motion.gravityScale = upGravity;
                motion.jumpForce = upJump;
                motion.groundDirection = upGround;
                break;

            case 2:
                motion.allowVertical = true;
                motion.allowHorizontal = false;
                motion.gravityScale = rightGravity;
                motion.jumpForce = rightJump;
                motion.groundDirection = rightGround;
                break;

            case 3:
                motion.allowVertical = false;
                motion.allowHorizontal = true;
                motion.gravityScale = downGravity;
                motion.jumpForce = downJump;
                motion.groundDirection = downGround;
                break;

            case 4:
                motion.allowVertical = true;
                motion.allowHorizontal = false;
                motion.gravityScale = leftGravity;
                motion.jumpForce = leftJump;
                motion.groundDirection = leftGround;
                break;
        }
    }


    void ChangeRotation(int direction)
    {
        switch (motion.lastWallCollision)
        {
            case 1:
                if (motion.lastInputDirection.x > 0)
                    rotation = new Vector3(0, 180, 180);
                else
                    rotation = new Vector3(0, 0, 180);

                break;

            case 2:
                if (motion.lastInputDirection.y > 0)
                    rotation = new Vector3(0, 0, 90);
                else
                    rotation = new Vector3(0, 180, 270);

                break;

            case 3:
                if (motion.lastInputDirection.x > 0)
                    rotation = new Vector3(0, 0, 0);
                else
                    rotation = new Vector3(0, 180, 0);

                break;

            case 4:
                if (motion.lastInputDirection.y > 0)
                    rotation = new Vector3(0, 180, 90);
                else
                    rotation = new Vector3(0, 0, 270);

                break;
        }
    }
}
