using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class shadowMasKAnim : MonoBehaviour
{
    public Transform spriteTransform; // Sprite'�n Transform component'ini bu alana s�r�kleyin
    private SpriteRenderer shadowMaskSpriteRenderer;

    private void Start()
    {
        shadowMaskSpriteRenderer = GetComponent<SpriteRenderer>();

        // Shadow Mask'� her frame'de Sprite ile ayn� konumda ve �l�ekte g�ncellemek i�in bir DOTween animasyonu kullan�n
        DOTween.To(() => shadowMaskSpriteRenderer.transform.position, pos => shadowMaskSpriteRenderer.transform.position = pos, spriteTransform.position, 1f)
            .SetUpdate(true) // Her frame'de g�ncelleme yap
            .SetEase(Ease.Linear)
            .OnComplete(OnAnimationComplete);
    }
    private void OnAnimationComplete()
    {
        Debug.Log("Animasyon tamamland�!");
        // Animasyon tamamland���nda yapmak istedi�iniz ek i�lemleri ekleyebilirsiniz.
    }
}
