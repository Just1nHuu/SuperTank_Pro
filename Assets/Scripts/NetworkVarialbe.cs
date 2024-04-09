using System;
using Unity.Netcode;

internal class NetworkVarialbe<T>
{
    public static implicit operator NetworkVarialbe<T>(NetworkVariable<bool> v)
    {
        throw new NotImplementedException();
    }
}