using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EngineerExam.Utilities
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GenericDraggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public static GenericDraggable activeDraggable;
        public int draggableMatchID;
        public RectTransform spawnArea; // this should be assigned by GameManager during spawn
        public bool returnToOriginOnFalse;
        // public TextMeshProUGUI label;
        private Image myImage;
        private Vector2 offset;
        private Vector3 originalPos;
        private bool isIdle = false;
        private CanvasGroup _canvasGroup;
        private RectTransform _rectTransform;
        private Rigidbody2D _rigidbody2D;
        private CapsuleCollider2D _collider2D;
        private CanvasGroup MyCanvasGroup
        {
            get
            {
                if (!_canvasGroup) _canvasGroup = GetComponent<CanvasGroup>();
                return _canvasGroup;
            }
        }
        public RectTransform MyRectTransform
        {
            get
            {
                if (!_rectTransform) _rectTransform = GetComponent<RectTransform>();
                return _rectTransform;
            }
        }
        private new Rigidbody2D MyRigidbody2D
        {
            get
            {
                if (!_rigidbody2D) _rigidbody2D = GetComponent<Rigidbody2D>();
                return _rigidbody2D;
            }
        }
        private new CapsuleCollider2D MyCollider2D
        {
            get
            {
                if (!_collider2D) _collider2D = GetComponent<CapsuleCollider2D>();
                return _collider2D;
            }
        }

        // public GenericDraggable(string text, float width = 200f)
        // {
        //     SetValues(text, width);
        // }

        void Awake()
        {
            myImage = this.GetComponent<Image>();
            originalPos = MyRectTransform.localPosition;
            transform.localScale = Vector3.zero;
        }

        public void ShowUp()
        {
            originalPos = MyRectTransform.localPosition;
            transform.localScale = Vector3.zero;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            offset = (Vector2)transform.position - eventData.position;
            originalPos = transform.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.localScale = Vector3.one * 1.2f;
            activeDraggable = this;
            MyCanvasGroup.blocksRaycasts = false;
            MyCanvasGroup.alpha = 0.5f;
        }

        public void OnDrag(PointerEventData eventData)
        {
            // if (!isIdle || activeDraggable == null || !canvasGroup.interactable)
            // {
            //     return;
            // }
            MyRigidbody2D.MovePosition(eventData.position + offset);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            activeDraggable = null;
            MyCanvasGroup.blocksRaycasts = true;
            MyCanvasGroup.alpha = 1f;
            isIdle = false;
            
            // Sequence sequence = DOTween.Sequence();

            // if (returnToOriginOnFalse)
            // {
            //     sequence
            //     .Append(rigidbody2D.DOMove(originalPos, 1f)
            //         .SetEase(Ease.OutQuad))
            //     .Join(transform.DOScale(Vector3.one, 0.5f)
            //         .SetEase(Ease.OutCubic))
            //     .AppendCallback(Idle);
            // }
            // else
            // {
            //     sequence
            //     .Append(rigidbody2D.DOMove(spawnArea.GetReturnPosition(eventData.position), 1f)
            //         .SetEase(Ease.OutQuad))
            //     .Join(transform.DOScale(Vector3.one, 0.5f)
            //         .SetEase(Ease.OutCubic))
            //     .AppendCallback(Idle);
            // }
        }

        public void OnDestroy()
        {
            // some particles and sound
        }

        private void Idle()
        {
            float tempYPos = transform.position.y + 5f;
            isIdle = true;
            
            // transform.DOMoveY(tempYPos, Random.Range(0.95f, 1.05f)).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        }

        public void SetImageSprite(Sprite _sprite)
        {
            myImage.sprite = _sprite;
        }
    }

    public static class DraggableExtensions
    {
        public static Vector2 GetReturnPosition(this RectTransform rect, Vector2 position)
        {
            Vector3[] corners = new Vector3[4];
            rect.GetWorldCorners(corners);
            Vector2 returnPosition = position;
            position.y = Random.Range(corners[0].y, corners[2].y);
            return returnPosition;
        }
    }
}
