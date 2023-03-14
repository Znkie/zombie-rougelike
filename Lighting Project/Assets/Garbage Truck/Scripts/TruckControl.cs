using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo
{
	public WheelCollider leftWheelCollider;
	public WheelCollider rightWheelCollider;
	public GameObject leftWheelMesh;
	public GameObject rightWheelMesh;
	public bool motor;
	public bool steering;
}

public class TruckControl : MonoBehaviour
{
	public List<AxleInfo> axleInfos;
	public float maxMotorTorque;
	public float maxSteeringAngle;
	public float brakeTorque;
	public float decelerationForce;

	public void ApplyLocalPositionToVisuals (AxleInfo axleInfo)
	{
		Vector3 position;
		Quaternion rotation;
		axleInfo.leftWheelCollider.GetWorldPose (out position, out rotation);
		axleInfo.leftWheelMesh.transform.position = position;
		axleInfo.leftWheelMesh.transform.rotation = rotation;
		axleInfo.rightWheelCollider.GetWorldPose (out position, out rotation);
		axleInfo.rightWheelMesh.transform.position = position;
		axleInfo.rightWheelMesh.transform.rotation = rotation;
	}

	void FixedUpdate ()
	{
		float motor = maxMotorTorque * Input.GetAxis ("Vertical");
		float steering = maxSteeringAngle * Input.GetAxis ("Horizontal");
		for (int i = 0; i < axleInfos.Count; i++)
		{
			if (axleInfos [i].steering)
			{
				Steering (axleInfos [i], steering);
			}
			if (axleInfos [i].motor)
			{
				Acceleration (axleInfos [i], motor);
			}
			if (Input.GetKey (KeyCode.Space))
			{
				Brake (axleInfos [i]);
			} 
			ApplyLocalPositionToVisuals (axleInfos [i]);
		}
	}

	private void Acceleration (AxleInfo axleInfo, float motor)
	{
		if (motor != 0f)
		{
			axleInfo.leftWheelCollider.brakeTorque = 0;
			axleInfo.rightWheelCollider.brakeTorque = 0;
			axleInfo.leftWheelCollider.motorTorque = motor;
			axleInfo.rightWheelCollider.motorTorque = motor;
		} else
		{
			Deceleration (axleInfo);
		}
	}

	private void Deceleration (AxleInfo axleInfo)
	{
		axleInfo.leftWheelCollider.brakeTorque = decelerationForce;
		axleInfo.rightWheelCollider.brakeTorque = decelerationForce;
	}

	private void Steering (AxleInfo axleInfo, float steering)
	{
		axleInfo.leftWheelCollider.steerAngle = steering;
		axleInfo.rightWheelCollider.steerAngle = steering;
	}

	private void Brake (AxleInfo axleInfo)
	{
		axleInfo.leftWheelCollider.brakeTorque = brakeTorque;
		axleInfo.rightWheelCollider.brakeTorque = brakeTorque;
	}
}
