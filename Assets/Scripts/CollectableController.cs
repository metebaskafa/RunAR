using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CollectableController : MonoBehaviour
{

    public PlayerMovement playerMovement;
    public  GameObject coin;
    public static int coinCount;
    public TextMeshProUGUI coinCountDisplay;

    public TextMeshProUGUI damageDisplay;

    private void Update()
    {
        coinCountDisplay.text = "Coin: " + coinCount;
        damageDisplay.text = "Damage: "  +BreakableWalls._bulletDmg;
    }







}
