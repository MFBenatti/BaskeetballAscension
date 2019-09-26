using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    float larguraTela;
    float alturaTela;

    void Start()
    {
        SpriteRenderer grafico = GetComponent<SpriteRenderer>();

        float larguraImagem = grafico.sprite.bounds.size.x;
        float alturaImagem = grafico.sprite.bounds.size.y;

        alturaTela = Camera.main.orthographicSize * 2.0f;
        larguraTela = alturaTela / Screen.height * Screen.width;

        Vector2 novaEscala = transform.localScale;
        novaEscala.x = larguraTela / larguraImagem + 0.25f;
        novaEscala.y = alturaTela / alturaImagem;
        transform.localScale = novaEscala;

        transform.position = new Vector2(larguraImagem-larguraImagem, 0.0f);
    }
}
