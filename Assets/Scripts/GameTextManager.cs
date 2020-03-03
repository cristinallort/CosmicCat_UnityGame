using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTextManager : MonoBehaviour
{

    public GameObject textPrefab;
    public GameObject deathMenuPrefab;
    public RectTransform canvasTransform;

    private static GameTextManager instance;
    public static GameTextManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameTextManager>();
            }
            return instance;
        }
    }
    public void CreateText()
    {
        GameObject text = (GameObject)Instantiate(textPrefab);
        text.transform.SetParent(canvasTransform);
        text.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        text.GetComponent<RectTransform>().localPosition = new Vector3(0, 60, 0);
        GameObject buttons = (GameObject)Instantiate(deathMenuPrefab);
        buttons.transform.SetParent(canvasTransform);
        buttons.GetComponent<RectTransform>().localScale = new Vector3(110.58f, 110.58f, 1);
        buttons.GetComponent<RectTransform>().localPosition = new Vector3(127.9f, -12.8f, 1);
    }
}
