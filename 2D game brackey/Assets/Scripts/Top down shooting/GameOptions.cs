using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptions : MonoBehaviour
{
        GameObject hero;
        GameObject survivor;

    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.Find("Hero");
        survivor = GameObject.Find("Survivor");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            hero.SetActive(true);
            survivor.SetActive(false);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            hero.SetActive(false);
            survivor.SetActive(true);
        }
    }
}
