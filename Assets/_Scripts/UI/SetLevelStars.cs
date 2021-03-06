﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetLevelStars : MonoBehaviour {

    public Sprite star0, star1, star2, star3, levelLocked;
    public Image levelImage;
    public int level;
    public bool gameMode;


    void Awake()
    {
        GameHUDManager.SetAllImages += SetStar;
    }


    public void SetStar()
    {
        //Debug.Log("STAR");
        levelImage.transform.GetComponent<Button>().interactable = true;
        if(gameMode)
        {
            switch (Player.completedLevelsHardMode[level])
            {
                case 0:
                    levelImage.sprite = star0;
                    break;
                case 1:
                    levelImage.sprite = star1;
                    break;
                case 2:
                    levelImage.sprite = star2;
                    break;
                case 3:
                    levelImage.sprite = star3;
                    break;
                case -1:
                    if (Player.completedLevelsHardMode[level - 1] != 0 && Player.completedLevelsHardMode[level - 1] != -1)
                    {
                        levelImage.sprite = star0;
                    }
                    else
                    {
                        levelImage.sprite = levelLocked;
                        levelImage.transform.GetComponent<Button>().interactable = false;
                    }

                    break;
            }
        }
        else
        {
            switch (Player.completedLevels[level])
            {
                case 0:
                    levelImage.sprite = star0;
                    break;
                case 1:
                    levelImage.sprite = star1;
                    break;
                case 2:
                    levelImage.sprite = star2;
                    break;
                case 3:
                    levelImage.sprite = star3;
                    break;
                case -1:
                    if (Player.completedLevels[level - 1] != 0 && Player.completedLevels[level - 1] != -1)
                    {
                        levelImage.sprite = star0;
                    }
                    else
                    {
                        levelImage.sprite = levelLocked;
                        levelImage.transform.GetComponent<Button>().interactable = false;
                    }

                    break;
            }
        }
        
    }

}
