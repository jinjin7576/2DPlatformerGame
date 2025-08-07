using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsChest : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemPrefabs;
    [SerializeField]
    private int itemCount;
    [SerializeField]
    private Sprite openChestImage;

    private SpriteRenderer spriteRenderer;
    private bool isChestOpen = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isChestOpen == false && collision.gameObject.CompareTag("Player"))
        {
            isChestOpen = true;
            spriteRenderer.sprite = openChestImage;

            StartCoroutine(nameof(SpawnAllItems));
        }
    }

    private IEnumerator SpawnAllItems()
    {
        int count = 0;
        while ( count < itemCount)
        {
            int index = Random.Range(0, itemPrefabs.Length);
            GameObject item = Instantiate(itemPrefabs[index], transform.position, Quaternion.identity);
            item.GetComponent<ItemBase>().Setup();

            yield return new WaitForSeconds(Random.Range(0.01f, 0.1f));

            count++;
        }
        float destroyTime = 2f;
        StartCoroutine(FadeEffect.Fade(spriteRenderer, 1, 0, destroyTime));
        Destroy(gameObject, destroyTime);
    }
}
