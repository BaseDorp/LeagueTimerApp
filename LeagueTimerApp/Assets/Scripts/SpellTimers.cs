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

    float cdrPercent = 0;
    bool hasLucidity = false;
    bool hasCosmicInsight = false;
    bool addedLucidity = false;
    bool addedCosmicInsight = false;

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

        // Check if player has CDR items // addedLucidity and addedCosmicInsight bools are so that % cdr isn't added every update
        if (/* this.player has Lucidity && */ addedLucidity == false)
        {
            cdrPercent += .10f;
            addedLucidity = true;
        }
        if (/* this.player has Cosmic Insight && */ addedCosmicInsight == true)
        {
            cdrPercent += .05f;
            addedCosmicInsight = true;
        }

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
                this.currentTime = flashTime - (flashTime * cdrPercent);
                break;
            case "Teleport":
                this.currentTime = teleportTime - (teleportTime * cdrPercent);
                break;
            case "Smite":
                this.currentTime = smiteTime - (smiteTime * cdrPercent);
                break;
            case "Heal":
                this.currentTime = healTime - (healTime * cdrPercent);
                break;
            case "Ignite":
                this.currentTime = igniteTime - (igniteTime * cdrPercent);
                break;
            case "Ghost":
                this.currentTime = ghostTime - (ghostTime * cdrPercent);
                break;
            case "Barrier":
                this.currentTime = barrierTime - (barrierTime * cdrPercent);
                break;
            case "Exhaust":
                this.currentTime = exhaustTime - (exhaustTime * cdrPercent);
                break;
            case "Cleanse":
                this.currentTime = cleanseTime - (cleanseTime * cdrPercent);
                break;
        }
    }
}
