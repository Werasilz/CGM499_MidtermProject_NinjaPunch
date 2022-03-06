using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;

    public void Handle(PlayerController playerController)
    {
        if (!_playerController)
        {
            _playerController = playerController;
        }

        Debug.Log("Player Hurt");
        ScreenShake.Instance.Shake(1);
        StartCoroutine(RedScreen());
        _playerController.animator.SetTrigger("Hurt");
        GameManager.Instance.PlayerTakeDamage(1);
        _playerController.StartPlayer();
    }

    private void Update()
    {
        if (GameManager.Instance.playerHealth <= 0)
        {
            _playerController.animator.Play("Dead");
        }
    }

    IEnumerator RedScreen()
    {
        GameManager.Instance.redScreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.redScreen.SetActive(false);
    }
}
