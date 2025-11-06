using UnityEngine;

public class FundoQuarto : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // arraste o SpriteRenderer do seu GameObject
    public Sprite imagem1;
    public Sprite imagem2;
    public Sprite imagemFinal;

    public void MudarImagem1()
    {
        spriteRenderer.sprite = imagem1;
    }

    public void MudarImagem2()
    {
        spriteRenderer.sprite = imagem2;
    }

    public void MudarImagem3()
    {
        spriteRenderer.sprite = imagemFinal;
;
    }
}
