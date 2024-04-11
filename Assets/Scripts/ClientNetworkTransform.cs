using System.Collections;
using System.Collections.Generic;
using Unity.Netcode.Components;
using UnityEngine;

public class ClientNetworkTransform : NetworkTransform
{
    // Start is called before the first frame update
    protected virtual bool OnIsServerAuthoritative()
    {
        return false;
    }
}
