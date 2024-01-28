using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class shadowMasKAnim : MonoBehaviour
{
    public Transform spriteTransform; // Sprite'ýn Transform component'ini bu alana sürükleyin
    private SpriteRenderer shadowMaskSpriteRenderer;

    private void Start()
    {
        shadowMaskSpriteRenderer = GetComponent<SpriteRenderer>();

        // Shadow Mask'ý her frame'de Sprite ile ayný konumda ve ölçekte güncellemek için bir DOTween animasyonu kullanýn
        DOTween.To(() => shadowMaskSpriteRenderer.transform.position, pos => shadowMaskSpriteRenderer.transform.position = pos, spriteTransform.position, 1f)
            .SetUpdate(true) // Her frame'de güncelleme yap
            .SetEase(Ease.Linear)
            .OnComplete(OnAnimationComplete);
    }
    private void OnAnimationComplete()
    {
        Debug.Log("Animasyon tamamlandý!");
        // Animasyon tamamlandýðýnda yapmak istediðiniz ek iþlemleri ekleyebilirsiniz.
    }
}
