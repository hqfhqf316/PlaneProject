using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class BackGround : MonoBehaviour {

    public float movespeed=0.2f;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Material m_material;
    // Update is called once per frame

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        m_material = spriteRenderer.material;
    }
    void Update () {
      
       // m_material.SetTextureOffset("_MainTex", Vector2.down * Time.time);
        m_material.mainTextureOffset = Vector2.up * Time.time*movespeed;
    }
}
