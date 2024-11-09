using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : GameControlBase
{
    public TMP_Text playerMoney_txt;
    public int playerMoney = 0;

    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private JoyStick joyStick;

    public override void Init(ManagerType _type)
    {
        base.Init(_type);
    }

    public override void Open()
    {
        base.Open();
        PlayerSetting();
    }

    private void PlayerSetting()
    {
        var player = Instantiate(PlayerPrefab, transform);
        player.GetComponent<PlayerMovement>().SetJoyStick(joyStick);
        player.transform.position = new Vector3(7f, 0, 3f);
        player.transform.rotation = Quaternion.Euler(0f, 90f, 0f);

        playerMoney_txt.text = playerMoney.ToString();
    }
}