using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    public GameObject tanitim;


    float time = 0f;

    bool isactivern = false;
    private void Awake()
    {
        if(!PlayerPrefs.HasKey("Count"))
        {
            PlayerPrefs.SetInt("Count", 3);
        }

        if(PlayerPrefs.GetInt("Count") > 0)
        {
            PlayerPrefs.SetInt("Count", PlayerPrefs.GetInt("Count") - 1);
            isactivern = true;
            tanitim.SetActive(true);
        }
    }

    private void Update()
    {
        if(PlayerInput.dead)
        {
            tanitim.SetActive(false);
        }
        else if (isactivern)
        {
            time += Time.deltaTime;
            if(time > 5)
            {
                tanitim.SetActive(false);
                isactivern = false;
            }
        }
    }
}
