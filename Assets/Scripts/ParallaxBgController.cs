using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Material bg1;
    [SerializeField] private Material bg2;
    [SerializeField] private Material bg3;
    [SerializeField] private Material bg4;
    [SerializeField] private Player player;

    private float _offSet1;
    private float _offSet2;
    private float _offSet3;
    private float _offSet4;


    private void Update()
    {
        _offSet1 += Time.deltaTime * player.speedMove * 0.001f;
        _offSet2 += Time.deltaTime * player.speedMove * 0.002f;
        _offSet3 += Time.deltaTime * player.speedMove * 0.003f;
        _offSet4 += Time.deltaTime * player.speedMove * 0.004f;

        bg1.mainTextureOffset = new Vector2(-_offSet1, 0);
        bg2.mainTextureOffset = new Vector2(-_offSet2, 0);
        bg3.mainTextureOffset = new Vector2(-_offSet3, 0);
        bg4.mainTextureOffset = new Vector2(-_offSet4, 0);
    }
}