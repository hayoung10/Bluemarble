using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressBtnEvent : MonoBehaviour
{
    private Animator anim;
    private AudioSource diceSound;
    DiceScript diceScript;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        diceSound = GetComponent<AudioSource>();
        diceScript = GameObject.Find("Dice").GetComponent<DiceScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (diceScript.diceBtnPress)
        {
            anim.Play("Press");
            diceSound.PlayDelayed(0.9f);
            diceScript.diceBtnPress = false;
        }
    }
}
