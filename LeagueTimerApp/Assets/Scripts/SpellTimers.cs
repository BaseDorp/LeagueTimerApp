using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellTimers : MonoBehaviour
{
    Image spellImage;
    Button button;
    [SerializeField]
    TextMeshProUGUI Text;

    int flashTime = 300;
    int igniteTime = 180;
    int teleportTime = 360;
    int healTime = 240;
    int barrierTime = 180;
    int cleanseTime = 210;
    int exhaustTime = 210;
    int ghostTime = 180;
    int smiteTime = 15;
    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        spellImage = GetComponent<Image>();
        button = GetComponent<Button>();
        //Text = GetComponent<TextMeshProUGUI>();

        Text.text = " ";
    }

    
    void Update()
    {
        button.onClick.AddListener(TaskOnClick);

        // Converts the current number for the timer to Text
        this.Text.text = Mathf.RoundToInt(this.currentTime).ToString();

        // Decreases time if a timer has started
        if (this.currentTime > 0)
        {
            this.currentTime -= Time.deltaTime;
        }

        // Clears the number once the timer reaches 0
        if (this.currentTime <= 0)
        {
            this.Text.text = " ";
        }
    }

    
    void TaskOnClick()
    {
        // Changes color of button to show it's been pressed
        this.spellImage.color = new Color(25,25,25);

        // Starts Timer when button is pressed
        switch (this.spellImage.sprite.name)
        {
            case "Flash":
                this.currentTime = flashTime;
                break;
            case "Teleport":
                this.currentTime = teleportTime;
                break;
            case "Smite":
                this.currentTime = smiteTime;
                break;
            case "Heal":
                this.currentTime = healTime;
                break;
            case "Ignite":
                this.currentTime = igniteTime;
                break;
            case "Ghost":
                this.currentTime = ghostTime;
                break;
            case "Barrier":
                this.currentTime = barrierTime;
                break;
            case "Exhaust":
                this.currentTime = exhaustTime;
                break;
            case "Cleanse":
                this.currentTime = cleanseTime;
                break;
        }
    }
}
