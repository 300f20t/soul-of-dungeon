using System;
using UnityEditor.PackageManager;
using UnityEngine;
using DiscordRPC;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
        var client = new DiscordRpcClient("1138637051349188710");

        // Завершите соединение перед выходом
        client.Dispose();

        Application.Quit(); // Завершаем приложение при нажатии Esc
    }
}
