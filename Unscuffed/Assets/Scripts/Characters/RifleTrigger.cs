using UnityEngine;

public class RifleTrigger : MonoBehaviour
{
    public AIProcessor aiProcessor;

    private void Start()
    {
        aiProcessor.FireRifle = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        aiProcessor.FireRifle = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        aiProcessor.FireRifle = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        aiProcessor.FireRifle = false;
    }
}
