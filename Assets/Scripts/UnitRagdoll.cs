using UnityEngine;

public class UnitRagdoll : MonoBehaviour
{
  [SerializeField] private Transform ragdollRootBone;

  public void Setup(Transform originalRootBone)
  {
    MatchAllChildTransform(originalRootBone, ragdollRootBone);
    ApplyExplosionToRagdoll(ragdollRootBone, 300f, transform.position ,10f);
  }

  private void MatchAllChildTransform(Transform root, Transform clone)
  {
    foreach (Transform child in root)
    {
        Transform cloneChild = clone.Find(child.name);

        if (cloneChild != null)
        {
            cloneChild.SetPositionAndRotation(child.position, child.rotation);

            MatchAllChildTransform(child, cloneChild);
        }
    }
  }

  private void ApplyExplosionToRagdoll(Transform root, float explosionForce, Vector3 explosionPosition, float explosionRange)
  {
    foreach(Transform child in root)
    {
        if (child.TryGetComponent(out Rigidbody childRigidbody))
        {
            childRigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRange);
        }
        
        ApplyExplosionToRagdoll(child, explosionForce, explosionPosition, explosionRange);
    }
  }

}
