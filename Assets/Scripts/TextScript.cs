using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var mText = gameObject.GetComponent<TextMeshProUGUI>();
        mText.text = "GAME OVER! \n Enemies killed; " + KillCount.killCount;

    }

    // Update is called once per frame
    void Update()
    {
        var mText = gameObject.GetComponent<TextMeshProUGUI>();
        mText.text = "GAME OVER! \n Enemies killed; " + KillCount.killCount;
    }
}
