using UnityEngine;
using System.Collections;

using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;

public class WindmillRotate : MonoBehaviour {
	
	float airDensity;
	float bladeLength;
	float windSpeed;
	
	float power;
	
	HingeJoint hJoint;
    JointMotor Hmotor;
	
	string logFileName,logFileStr;
	
	Rect windowRect = new Rect(0, 0, Screen.width, Screen.height);
	
	bool tigLogWin=false;
	
	
	void Awake()
     {
         hJoint = hingeJoint;
         Hmotor = hJoint.motor;
         Hmotor.targetVelocity = 10.0f;
     }

	// Use this for initialization
	void Start () {
		
		
		airDensity=1.0f;
	 	bladeLength=0.05f;
	 	windSpeed=0.0f;
	
	 	power=0;
		
		logFileName=logFileStr="";
		
		logFileStr = "Air Density(kg/m^3)\t\t\tBlade Length(m)\t\t\tWind Speed(m/s)\t\t\tPower (watts)";
		
//		try
//		{
//			logFileName = "/sdcard/transferred/LogFiles/DataFile_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt";
//
//			if(!File.Exists(logFileName))
//			{
//				using (FileStream fs = new FileStream(logFileName, FileMode.Append, FileAccess.Write))
//				using (StreamWriter sw = new StreamWriter(fs))
//	            {
//
//					logFileStr = "Air Density(kg/m^3)\t\t\tBlade Length(m)\t\t\tWind Speed(m/s)\t\t\tPower (watts)";
//					
//					logFileStr=(String.Format("{0,-30}  {1,-30}  {2,-30} {3,-30}", "Air Density(kg/m^3)", "Blade Length(m)", "Wind Speed(m/s)" , "Power(watts)"));
//					
//	                sw.WriteLine(logFileStr);
//	                print(logFileStr);
//	        	}
//
//			}
//		}
//		catch(Exception e)
//		{
//		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.localScale=new Vector3((105.2632f*bladeLength)+94.73684f,(105.2632f*bladeLength)+94.73684f,(105.2632f*bladeLength)+94.73684f);
		
		Hmotor.targetVelocity = 40*windSpeed;
		
		
		hingeJoint.motor=Hmotor;
		
		//print(windSpeed+"   "+Hmotor.targetVelocity);
        
	
	}
	
	void OnGUI()
	{
//		GUI.Label(new Rect(500.0f,50.0f,200.0f,40.0f),"Air Density (kg/m^3)\t= "+ airDensity.ToString());
//		airDensity=GUI.HorizontalSlider(new Rect(750.0f,55.0f,100.0f,40.0f),airDensity,1.0f,1.50f);
//		
//		GUI.Label(new Rect(500.0f,100.0f,200.0f,40.0f),"Blade Length (m)\t\t=  "+ bladeLength.ToString("0.0000"));
//		bladeLength=GUI.HorizontalSlider(new Rect(750.0f,105.0f,100.0f,40.0f),bladeLength,0.05f,1.0f);
//		
//		GUI.Label(new Rect(500.0f,150.0f,200.0f,40.0f),"Wind Speed (m/s)\t\t= "+ windSpeed.ToString());
//		windSpeed=GUI.HorizontalSlider(new Rect(750.0f,155.0f,100.0f,40.0f),windSpeed,0.0f,10.0f);
//		
//		GUI.Label(new Rect(500.0f,200.0f,200.0f,30.0f),"Power (Watts) ");
//		GUI.TextField(new Rect(750.0f,195.0f,100.0f,30.0f),power.ToString());
//		
//		power=0.5f*(airDensity)*Mathf.PI*(Mathf.Pow(bladeLength,2))*(Mathf.Pow(windSpeed,3));
//		
//		if(GUI.Button(new Rect(580.0f,250.0f,100.0f,30.0f),"Submit"))
//		{
//			
//			logFileStr+="\n"+(String.Format("{0,-34}  {1,-26}  {2,-28} {3,-30}", airDensity.ToString("00.00000"), bladeLength.ToString("00.00000"), windSpeed.ToString("00.00000"), power.ToString("00.00000")));
//		}
//		
//		if(GUI.Button(new Rect(700.0f,250.0f,100.0f,30.0f),"Show log"))
//		{
//			tigLogWin=true;
//		}
		
		
		GUI.Label(new Rect(Screen.width-500,50.0f,200.0f,40.0f),"Air Density (kg/m^3)\t= "+ airDensity.ToString());
		airDensity=GUI.HorizontalSlider(new Rect(Screen.width-300,55.0f,100.0f,40.0f),airDensity,1.0f,1.50f);
		
		GUI.Label(new Rect(Screen.width-500,100.0f,200.0f,40.0f),"Blade Length (m)\t\t=  "+ bladeLength.ToString("0.0000"));
		bladeLength=GUI.HorizontalSlider(new Rect(Screen.width-300,105.0f,100.0f,40.0f),bladeLength,0.05f,1.0f);
		
		GUI.Label(new Rect(Screen.width-500,150.0f,200.0f,40.0f),"Wind Speed (m/s)\t\t= "+ windSpeed.ToString());
		windSpeed=GUI.HorizontalSlider(new Rect(Screen.width-300,155.0f,100.0f,40.0f),windSpeed,0.0f,10.0f);
		
		GUI.Label(new Rect(Screen.width-500,200.0f,200.0f,30.0f),"Power (Watts) ");
		GUI.TextField(new Rect(Screen.width-300,195.0f,100.0f,30.0f),power.ToString());
		
		power=0.5f*(airDensity)*Mathf.PI*(Mathf.Pow(bladeLength,2))*(Mathf.Pow(windSpeed,3));
		
		if(GUI.Button(new Rect(Screen.width-480,250.0f,100.0f,30.0f),"Submit"))
		{
			
			logFileStr+="\n"+(String.Format("{0,-34}  {1,-26}  {2,-28} {3,-30}", airDensity.ToString("00.00000"), bladeLength.ToString("00.00000"), windSpeed.ToString("00.00000"), power.ToString("00.00000")));
		}
		
		if(GUI.Button(new Rect(Screen.width-360,250.0f,100.0f,30.0f),"Show log"))
		{
			tigLogWin=true;
		}
		
		if(tigLogWin)
		{
			windowRect = GUI.Window(0, windowRect, DoMyWindow, "Log.txt");
			
		}
			
						
		
	}
	
	void DoMyWindow(int windowID) {
        if (GUI.Button(new Rect(Screen.width-30, 2, 30, 20), "X"))
		{
			tigLogWin=false;
		}
		
		GUI.TextArea(new Rect(10,30,Screen.width-20,Screen.height-40),logFileStr);
        
    }
}
