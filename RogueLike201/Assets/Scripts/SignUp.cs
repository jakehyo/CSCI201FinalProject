﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Final_Project_Client;
using TMPro;

public class SignUp : MonoBehaviour
{
    public TMP_InputField userInput;

    public void Register()
    {
        string username = userInput.text;

        if (username != null)
        {
            Client client = new Client(9999);

            client.registerUser(username);
        }
    }
}
