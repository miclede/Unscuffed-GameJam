using UnityEngine;

public class TossTrigger : MonoBehaviour
{
    public AIProcessor aiProcessor;

    private void Start()
    {
        aiProcessor.Toss = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        aiProcessor.Toss = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        aiProcessor.Toss = false;
    }
}
