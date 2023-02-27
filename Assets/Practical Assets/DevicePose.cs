/*
 * Script based on code from:
 * https://forum.unity3d.com/threads/sharing-gyroscope-camera-script-ios-tested.241825/
 * https://gist.github.com/BichengLUO/32091aecf9f189a24953840e32c060cf
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DevicePose : MonoBehaviour
{
	public float accelSensitivity = 0.1f;
	private Vector3 lpAccel;
	private Quaternion initialRotation;

	void Start()
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		if (SystemInfo.supportsGyroscope)
		{
			Input.gyro.enabled = true;
		}
		else
		{
			lpAccel = Vector3.zero;
			initialRotation = transform.rotation;
		}
	}

	void Update()
	{
		if (SystemInfo.supportsGyroscope)
		{
			transform.rotation = Input.gyro.attitude;
			transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
			transform.Rotate(90.0f, 180.0f, 0.0f, Space.World);
		}
		else
		{
			Vector3 acc = Input.acceleration;
			lpAccel = ((1.0f - accelSensitivity) * lpAccel) + (accelSensitivity * acc);

			transform.rotation = initialRotation;
			transform.RotateAround(transform.position, Vector3.forward, -lpAccel.x * 90.0f);
			transform.RotateAround(transform.position, Vector3.right, -lpAccel.z * 90.0f);
		}
	}
}
