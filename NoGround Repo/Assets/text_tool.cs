using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;
using TMPro;

public class text_tool : MonoBehaviour
{
    [SerializeField] TMP_FontAsset Fa_Font;
    [SerializeField] RTLTextMeshPro rt;
    [SerializeField] DialogueColector D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rt.font=Fa_Font;
        rt.text = D.Get_Fa_Dialogue()[0];
    }
}
