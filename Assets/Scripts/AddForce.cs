using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    [Range(0, 5)] [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private CharacterAttributes charAttributes;
    [SerializeField] private Transform firstClickTransform;
    [SerializeField] private Transform mouseUpTransform;
    [SerializeField] private PhysicsMaterial2D bouncyMaterial;
    [SerializeField]private CameraZoom _cameraZoom;
    [SerializeField]private bool _grounded;

    private SoundPlayer _sound;
    private Rigidbody2D _rbd;
    private BoxCollider2D _boxCollider2D;
    private PlayerSounds _playerSounds;
    private bool _dragging;
    private bool _zoom = false;
    private bool _stopGrounded = false;

    private void Start()
    {
        _sound = GetComponent<SoundPlayer>();
        _rbd = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _playerSounds = GetComponent<PlayerSounds>();
    }

    private void Update()
    {
        Inputs();
        IsGrounded();
    }

    private void IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f,
            -Vector2.up, raycastDistance, groundLayer);
        // Color color = raycastHit2D.collider != null?  Color.green : Color.red;
        // Debug.Log(raycastHit2D.collider);
        // Debug.DrawRay(_boxCollider2D.bounds.center + new Vector3(_boxCollider2D.bounds.extents.x, 0),-Vector2.up * (_boxCollider2D.bounds.extents.y + raycastDistance), color);
        // Debug.DrawRay(_boxCollider2D.bounds.center - new Vector3(_boxCollider2D.bounds.extents.x, 0),-Vector2.up * (_boxCollider2D.bounds.extents.y + raycastDistance), color);
        // Debug.DrawRay(_boxCollider2D.bounds.center - new Vector3(_boxCollider2D.bounds.extents.x, _boxCollider2D.bounds.extents.y + raycastDistance),Vector2.right * (_boxCollider2D.bounds.extents.x), color);
        _grounded = raycastHit2D.collider != null;

        _boxCollider2D.sharedMaterial = _grounded ? null : bouncyMaterial;
        if (_grounded)
        {
            _rbd.drag = 5;
            if (_zoom && _stopGrounded)
            {
                _cameraZoom.zoomIn = true;
                _zoom = false;
            }
        }
        else
        {
            _rbd.drag = 0;
        }
    }

    private void Inputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstClickTransform.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseUpTransform.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (_grounded)
            {
                LaunchCharacter();
            }
        }
    }

    private void LaunchCharacter()
    {
        Vector2 direction =
            CalculateDirection(firstClickTransform.transform.position, mouseUpTransform.transform.position);
        _rbd.drag = 0;
        _rbd.AddForce(direction * charAttributes.PullForce);
        StartCoroutine(StopGrounded());
        _cameraZoom.zoomOut = true;
        _zoom = true;
        _sound.PlayJumpSound();
    }

    private Vector2 CalculateDirection(Vector2 pointA, Vector2 pointB)
    {
        Vector2 direction = pointA - pointB;

        if (Mathf.Abs(direction.y) > 5)
        {
            direction.y = Mathf.Sign(direction.y) * 5;
        }

        if (Mathf.Abs(direction.x) > 3)
        {
            direction.x = Mathf.Sign(direction.x) * 3;
        }

        return direction;
    }

    private IEnumerator StopGrounded()
    {
        _stopGrounded = false;
        yield return new WaitForSeconds(0.05f);
        _stopGrounded = true;
    }
}