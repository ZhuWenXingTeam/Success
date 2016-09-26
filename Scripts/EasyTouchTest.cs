using UnityEngine;
using System.Collections;

/*
 * worldUp的描述“在完成上面的旋转之后，继续旋转自身，
 * 使得当前对象的正y轴朝向与worldUp所指向的朝向一致”里的朝向一致，
 * 指的是新旋转后的y轴与worldUp在该对象初次旋转后的xy平面上的投影向量一致。
 * 也就是说，worldUp应取它在应用了旋转量q后的xy平面的投影量。
  */
public class EasyTouchTest : MonoBehaviour {
	public EasyJoystick stick;

	void OnEnable()
	{
		EasyJoystick.On_JoystickMove += OnJoystickMove;
		EasyJoystick.On_JoystickMoveEnd += OnJoystickMove;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//移动摇杆结束  
	void OnJoystickMoveEnd(MovingJoystick move)  
	{
		if (move.joystickName == "MyStick") {

		}
	}
	//移动摇杆中  
	void OnJoystickMove(MovingJoystick move)  
	{
		if (move.joystickName != "MyStick")  
		{  
			return;  
		}

		//获取摇杆中心偏移的坐标  
		float joyPositionX = move.joystickAxis.x;  
		float joyPositionY = move.joystickAxis.y;  
		//float x = move.joystick.JoystickTouch.x;
		print (joyPositionX);
		print (joyPositionY);
		if (joyPositionY != 0 || joyPositionX != 0)  
		{  
			//根据官方的文档描述，该函数的功能是，旋转自身，使得当前对象的正z轴指向目标对象target所在的位置。
			//而对于worldUp的描述是，在完成上面的旋转之后，继续旋转自身，使得当前对象的正y轴朝向与worldUp所指向的朝向一致。
			//设置角色的朝向（朝向当前坐标+摇杆偏移量）  
			transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));  
			//移动玩家的位置（按朝向位置移动）  
			transform.Translate(Vector3.forward * Time.deltaTime * 5);  
			//播放奔跑动画  
			//GetComponent<Animation>().CrossFade("run");  
		} 


	}
}
