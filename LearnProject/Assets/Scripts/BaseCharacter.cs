using LearnProject.Movement;
using LearnProject.Shooting;
using UnityEngine;

namespace LearnProject
{
    [RequireComponent(typeof(CharacterMovementController), typeof(ShootingController))]
    public class BaseCharacter : MonoBehaviour
    {
        [SerializeField]
        private Weapon _baseWeaponPrefab;

        [SerializeField]
        private Transform _hand;


        [SerializeField]
        private float _health = 2f;

        private CharacterMovementController _characterMovementController;

        private IMovementDirectionSource _movementDirectionSource;
        private ShootingController _shootingController;

        private void Awake()
        {
            _characterMovementController = GetComponent<CharacterMovementController>();
            _movementDirectionSource = GetComponent<IMovementDirectionSource>();
            _shootingController = GetComponent<ShootingController>();
        }

        protected private void Start()
        {
            _shootingController.SetWeapon(_baseWeaponPrefab, _hand);
        }

        void Update()
        {
            var direction = _movementDirectionSource.MovementDirection;
            var visionDirection = direction;
            if (_shootingController.HasTarget)
                visionDirection = (_shootingController.TargetPosition - transform.position).normalized; 


            _characterMovementController.MovementDirection = direction;
            _characterMovementController.VisionDirection = visionDirection;

            if (_health<= 0f)
                Destroy(gameObject);
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (LayerUtils.IsBullet(other.gameObject))
            {
                var bullet = other.gameObject.GetComponent<Bullet>();

                _health -= bullet.Damage;

                Destroy(other.gameObject);
            }
        }
    }
}