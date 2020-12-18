using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform spriteTransform;
    [SerializeField] private Sprite stationarySprite;
    [SerializeField] private Sprite movingUpSprite;
    [SerializeField] private Sprite movingDownSprite;

    [SerializeField] int speed;
    private HingeJoint2D hingeJoint2D;
    private JointMotor2D jointMotor;

    private Vector3 normalRotation;
    private Vector3 flippedRotation;

    private void Start () {
        hingeJoint2D = GetComponent<HingeJoint2D>();
        jointMotor = hingeJoint2D.motor;

        normalRotation = spriteTransform.rotation.eulerAngles;
        flippedRotation = new Vector3(normalRotation.x, normalRotation.y, normalRotation.z + 90);
    }

    private void FixedUpdate () {
        if (Input.GetKey(KeyCode.Space)) {
            jointMotor.motorSpeed = speed;
            hingeJoint2D.motor = jointMotor;
        } else {
            jointMotor.motorSpeed = -speed;
            hingeJoint2D.motor = jointMotor;
        }

        if (hingeJoint2D.jointSpeed > 100) {
            spriteRenderer.sprite = movingUpSprite;
        } else if (hingeJoint2D.jointSpeed < - 100) {
            spriteRenderer.sprite = movingDownSprite;
        } else {
            spriteRenderer.sprite = stationarySprite;
        }
    }
}
