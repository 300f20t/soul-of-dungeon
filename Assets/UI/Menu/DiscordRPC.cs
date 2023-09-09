using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiscordRPC;

public class DiscordRCP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            var client = new DiscordRpcClient("1138637051349188710");

            // Настройте параметры активности
            var presence = new RichPresence()
            {
                Details = "Play in soul of dangeon",
                State = "In Menu",
                Assets = new Assets()
                {
                    LargeImageKey = "large_image_key",
                    LargeImageText = "111",
                    SmallImageKey = "small_image_key",
                    SmallImageText = "111"
                }
            };

            client.Initialize();

            // Установите активность
            client.SetPresence(presence);   
    }
}

