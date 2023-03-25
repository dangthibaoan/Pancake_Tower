using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CakeController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private bool CanDrag = true;
    private bool Spawn = true;
    public Rigidbody2D rigid;
    private Vector3 offset;
    public GameObject spawnPoint;
    public GameObject spawnDrop;
    public GameObject Land;
    public Level1 lv1;

    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (CanDrag == true)
        {
            Vector3 pointerPosition = GetPointerPosition();
            transform.position = pointerPosition - offset;
        }
    }

    private Vector3 GetPointerPosition()
    {
        Vector3 pointerPosition = Vector3.zero;
        pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pointerPosition.z = 0;
        return pointerPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (CanDrag == true)
        {
            SoundController.Instance.PlayOnce(SoundType.ButtonClick);
            transform.DOScale(1.5f, .01f);
            Vector3 pointerPosition = GetPointerPosition();
            offset = pointerPosition - transform.position;
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (CanDrag == true)
        {
            if (Spawn == true)
            {
                if (transform.position.y > spawnDrop.transform.position.y)
                {
                    transform.position = new Vector3(transform.position.x, spawnDrop.transform.position.y, 0);
                    lv1.SetScale();
                }
                lv1.spawnCake(transform.position);
            }
            transform.position = spawnPoint.transform.position;
            transform.DOScale(1f, .01f);
        }
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     Spawn = false;
    //     Debug.Log("banh da va cham voi " + other.gameObject.name);
    // }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == Land.name)
        {
            Debug.Log("banh da va cham voi " + other.gameObject.name);
            lv1.endLevel();
        }
    }

    public void setCanDrag(bool canDrag)
    {
        CanDrag = canDrag;
    }
}
