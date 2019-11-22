using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // Required when Using UI elements.

public class Example : MonoBehaviour
{
    public Slider mainSlider;
    public Transform mainCamera;
    int time_ = 0;
    bool a = true;
    bool b = true;
    //玩家最大血量
    public int maxHealth = 100;
    //玩家当前血量
    public int curHealth = 100;
    //血条的长度
    public float healthBarLength;
    private Rect healthBar;
	public void Start()
	{
        mainSlider.value = 0;
        mainSlider.GetComponent<RectTransform>().LookAt(mainCamera);
        healthBarLength = Screen.width / 3;
	}
	public void Update()
	{
        if (time_<=10){
            time_++;
        }
        else{
            time_ = 0;
            SubmitSliderSetting();
            AdjustCurHealth(5);
        }

	}

  

    void OnGUI()
    {
        //使用GUI.Box绘制血条
        GUI.Box(new Rect(10, 10, healthBarLength, 20), curHealth + "/" + maxHealth);
        GUI.Box(new Rect(12, 12, (healthBarLength-4) * curHealth / 100, 16),"");
       
    }
    //自定义调节当前血量的方法
    public void AdjustCurHealth(int adj)
    {
        if ((int)mainSlider.value == (int)100 && b == true)
            b = false;
        else if ((int)mainSlider.value == (int)0 && b == false)
            b = true;
        if (b)
            curHealth -= adj;
        else
        {
            if (curHealth == 100)
                curHealth = curHealth+0;
            else
            curHealth += adj;
        }
    }
	//Invoked when a submit button is clicked.
	public void SubmitSliderSetting()
    {
        //Displays the value of the slider in the console.
       
        if ((int)mainSlider.value == (int)100 && a == true)
            a = false;
        else if ((int)mainSlider.value == (int)0 && a == false)
            a = true;
        if (a)
            mainSlider.value = mainSlider.value + 5;
        else
            mainSlider.value = mainSlider.value - 5;
        Debug.Log(mainSlider.value);
    }
}