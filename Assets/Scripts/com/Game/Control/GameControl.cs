﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    //盾牌道具时间
    public int sheildTime;
    public float countDownTime;

    /*子弹类型*/
    public string bulletStyle;


    /*增强子弹计数板*/
    public int bulletPowerNum;
    public Slider bulletPowerSlider;
    public Text bulletPowerText;


    /*减速子弹计数板*/
    public int bulletBounceNum;
    public Slider bulletBounceSlider;
    public Text bulletBounceText;


    /*盾牌计数板*/
    public Slider sheildSlider;
    public Text sheildText;


    /*生命值计数板*/
    public Slider healthSlider;
    public Text healthText;


    //获取玩家坦克挂载的脚本
    public PlayerTank playerTankS;



    //获取子弹上挂载的脚本
    public Bullet bulletS;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        bulletPowerNum=0;
        bulletBounceNum=0;
        sheildTime = 0;
        bulletStyle = "";
       
	}
	
	// Update is called once per frame
	void Update () {


	}

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void BulletPower ()
    {
        playerTankS.normalShoot = false;
        if (bulletPowerNum < 20)
        {
            bulletPowerNum += 10;
        }
        else
        {
            bulletPowerNum = 30;
        }
        bulletPowerSlider.value += bulletPowerNum;
        bulletPowerText.text = "" + bulletPowerNum;
    }

    public void BulletPowerShoot ()
    {
        bulletPowerNum--;
        bulletPowerSlider.value = bulletPowerNum;
        bulletPowerText.text = "" + bulletPowerNum;
    }

    public void BulletBounce ()
    {
        if (bulletBounceNum < 20)
        {
            bulletBounceNum += 10;
        }
        else
        {
            bulletBounceNum = 30;
        }
        playerTankS.normalShoot = false;
        bulletBounceSlider.value+= bulletBounceNum;
        bulletBounceText.text = "" + bulletBounceNum;
    }

    public void BulletBounceShoot ()
    {
        bulletBounceNum--;
        bulletBounceSlider.value= bulletBounceNum;
        bulletBounceText.text = "" + bulletBounceNum;
    }

    public void SheildPick ()
    {
        if(sheildTime<20)
        {
            sheildTime += 10;
        }
        else
        {
            sheildTime =30;
        }
        sheildSlider.value += sheildTime;
        sheildText.text = ""+sheildTime+"s";
        
        
    }

    public void SheildCountdown ()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator  CountDown()
    {

            while(sheildTime>0)
            {
                yield return new WaitForSeconds(1);
                sheildTime--;
                sheildSlider.value = sheildTime;
                sheildText.text = "" + sheildTime + "s";
            }
               
    }



}
