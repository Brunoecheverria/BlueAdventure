using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLimit : MonoBehaviour
{

	[SerializeField] GameObject Cam;


	[SerializeField] float SensX;
	[SerializeField] float SensY;
	[SerializeField] float MinX;
	[SerializeField] float MaxX;
	[SerializeField] float MinY;
	[SerializeField] float MaxY;
	private float mouseX;
	private float mouseY;
	private Vector3 Limitex;
	private Vector3 Limitey;

    private void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
	{

		mouseX = SensX * Input.GetAxis("Mouse X");
		mouseY = SensY * Input.GetAxis("Mouse Y");

		Cam.transform.localEulerAngles = Limitex;
		Limitex.x -= mouseY;

		if (Limitex.x >= MaxY)
		{

			Limitex.x = MaxY;

		}
		else if (Limitex.x <= MinY)
		{

			Limitex.x = MinY;

		}

		transform.localEulerAngles = Limitey;
		Limitey.y += mouseX;

		if (Limitey.y >= MaxX)
		{

			Limitey.y = MaxX;

		}
		else if (Limitey.y <= MinX)
		{

			Limitey.y = MinX;

		}

	}
}
