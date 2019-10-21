using UnityEngine;

public class SpecialTrigger : MonoBehaviour
{
    public AIProcessor aiProcessor;

    private void Start()
    {
        aiProcessor.SpecialAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        aiProcessor.SpecialAttack = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        aiProcessor.SpecialAttack = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        aiProcessor.SpecialAttack = false;
    }
}
