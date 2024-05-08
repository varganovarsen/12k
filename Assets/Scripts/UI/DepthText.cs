using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DepthText : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    private void Update()
    {
        text.text = Mathf.Abs(Mathf.Ceil(DepthController.Depth)).ToString();
    }
}
