using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button shootButton;
    public Button resetButton;

    public GameObject aim;
    public GameObject scan;
    public GameObject msgDied;

    public TMPro.TextMeshProUGUI txtScore;
    public TMPro.TextMeshProUGUI txtTime;

    public TMPro.TextMeshProUGUI stageDetail;
    public TMPro.TextMeshProUGUI txtRequiredLevel;

    public TMPro.TextMeshProUGUI txtWin;
    public Button startButton;

    public TMPro.TextMeshProUGUI txtWeaponDetail;
    public TMPro.TextMeshProUGUI txtRequiredLevelWeapon;
    public Button weaponButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetInitScene();
        SetSelectStageScene();
        SetSelectWeaponScene();
        SetPlayingScene();
        SetWinningScene();
        SetGameOverScene();
    }

    void SetInitScene() {
        bool isActive = GameManager.Instance.gameState == GameConstant.initState;
        scan.gameObject.SetActive(isActive);
    }

    void SetSelectStageScene() {
        bool isActive = GameManager.Instance.gameState == GameConstant.selectStageState;
        stageDetail.gameObject.SetActive(isActive);
        if (isActive && GameManager.Instance.selectStage != null) {
            string level = "Stage: " + GameManager.Instance.selectStage.level.ToString();
            string time = "Time: " + GameManager.Instance.selectStage.time.ToString();
            string description = GameManager.Instance.selectStage.description;
            stageDetail.text = level + "\n" + time + "\n" + description;
            if (GameManager.Instance.level >= GameManager.Instance.selectStage.level) {
                startButton.gameObject.SetActive(isActive);
            }
            else {
                txtRequiredLevel.gameObject.SetActive(isActive);
                txtRequiredLevel.text = "Required level: " + GameManager.Instance.selectStage.level.ToString();
            }
        }
        else {
            startButton.gameObject.SetActive(isActive);
            txtRequiredLevel.gameObject.SetActive(isActive);
        }
    }

    void SetPlayingScene() {
        bool isActive = GameManager.Instance.gameState == GameConstant.playingState;
        shootButton.gameObject.SetActive(isActive);
        txtTime.gameObject.SetActive(isActive);
        txtScore.gameObject.SetActive(isActive);
        aim.gameObject.SetActive(isActive);
        if (isActive) {
            txtScore.text = "Score: " + GameManager.Instance.score.ToString();
            txtTime.text = GameManager.Instance.timeRemaining.ToString("0.00");
        }
        else {
            txtTime.text = "Not start";
        }
    }

    void SetWinningScene() {
        bool isActive = GameManager.Instance.gameState == GameConstant.winState;
        txtWin.gameObject.SetActive(isActive);
    }

    void SetGameOverScene() {
        bool isActive = GameManager.Instance.gameState == GameConstant.gameOverState;
        msgDied.gameObject.SetActive(isActive);
        resetButton.gameObject.SetActive(isActive);
    }

    void SetSelectWeaponScene() {
        bool isActive = GameManager.Instance.gameState == GameConstant.selectWeaponState;
        txtWeaponDetail.gameObject.SetActive(isActive);
        if (isActive && GameManager.Instance.selectWeapon != null) {
            string damage = "Damage: " + GameManager.Instance.weapon.damage.ToString() + " -> " + GameManager.Instance.selectWeapon.damage.ToString();
            string fireRate = "Rate: " + GameManager.Instance.weapon.firingRate.ToString() + " -> " + GameManager.Instance.selectWeapon.firingRate.ToString();
            txtWeaponDetail.text = damage + "\n" + fireRate;
            if (GameManager.Instance.weapon.name == GameManager.Instance.selectWeapon.name) {
                txtRequiredLevelWeapon.gameObject.SetActive(isActive);
                txtRequiredLevelWeapon.text = "Equipped";
            }
            else if (GameManager.Instance.level >= GameManager.Instance.selectWeapon.minimumLevel) {
                weaponButton.gameObject.SetActive(isActive);
            }
            else {
                txtRequiredLevelWeapon.gameObject.SetActive(isActive);
                txtRequiredLevelWeapon.text = "Required level: " + GameManager.Instance.selectWeapon.minimumLevel.ToString();
            }
        }
        else {
            weaponButton.gameObject.SetActive(isActive);
            txtWeaponDetail.gameObject.SetActive(isActive);
            txtRequiredLevelWeapon.gameObject.SetActive(isActive);
        }
    }
}
