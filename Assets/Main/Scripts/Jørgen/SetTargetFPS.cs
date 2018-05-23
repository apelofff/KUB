using UnityEngine;
using System.Collections;

public class SetTargetFPS : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
