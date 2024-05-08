using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedText : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    private void Update()
    {
        string velocityNumber = Mathf.Abs(Mathf.Ceil(PlayerMovement.Instance.Velocity.y)).ToString();
        text.text = velocityNumber;
    }
}
