using UnityEngine;

public class TransitionAnimationEvents : MonoBehaviour
{
	private Animator animator;
	private void Start()
	{
		animator = transform.GetComponent<Animator>();
	}
	public void UnsetActive() => gameObject.SetActive(false);

	private void Update()
	{
		animator.SetBool("HasLoaded", TransitionManager.Instance.HasLoaded);
	}

}
