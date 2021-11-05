using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicLevel : MonoBehaviour
{
    InGameUI gameUI;
    [SerializeField] GameObject level1;
    [SerializeField] GameObject level2;
    [SerializeField] GameObject level3;
    [SerializeField] GameObject level4;

    void Start()
    {
        gameUI = FindObjectOfType<InGameUI>();

        if (SaveLoadManager.getFakeLevel() == 1)
        {
            Level1();
        }

        if (SaveLoadManager.getFakeLevel() == 2)
        {
            Level2();
        }

        if (SaveLoadManager.getFakeLevel() == 3)
        {
            Level3();
        }

        if (SaveLoadManager.getFakeLevel() == 4)
        {
            Level4();
        }

        if (SaveLoadManager.getFakeLevel() == 5)
        {
            Level1();
        }

        if (SaveLoadManager.getFakeLevel() == 6)
        {
            Level2();
        }

        if (SaveLoadManager.getFakeLevel() == 7)
        {
            Level3();
        }

        if (SaveLoadManager.getFakeLevel() == 8)
        {
            Level4();
        }

        if (SaveLoadManager.getFakeLevel() == 9)
        {
            Level1();
        }

        if (SaveLoadManager.getFakeLevel() == 10)
        {
            Level2();
        }

        if (SaveLoadManager.getFakeLevel() == 11)
        {
            Level3();
        }

        if (SaveLoadManager.getFakeLevel() == 12)
        {
            Level4();
        }

        if (SaveLoadManager.getFakeLevel() == 13)
        {
            Level1();
        }

        if (SaveLoadManager.getFakeLevel() == 14)
        {
            Level2();
        }

        if (SaveLoadManager.getFakeLevel() == 15)
        {
            Level3();
        }

        if (SaveLoadManager.getFakeLevel() == 16)
        {
            Level4();
        }

        if (SaveLoadManager.getFakeLevel() == 17)
        {
            Level1();
        }
    }

    void Update()
    {
        
    }

    void Level1()
    {
        //Instantiate(level1);
        //Destroy(level4);
        level1.SetActive(true);
        level4.SetActive(false);
    }

    void Level2()
    {
        //Instantiate(level2);
        //Destroy(level1);
        level1.SetActive(false);
        level2.SetActive(true);
    }

    void Level3()
    {
        //Instantiate(level3);
        //Destroy(level2);
        level2.SetActive(false);
        level3.SetActive(true);
    }

    void Level4()
    {
        //Instantiate(level4);
        //Destroy(level3);
        level3.SetActive(false);
        level4.SetActive(true);
    }
}
