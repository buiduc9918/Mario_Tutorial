using System.Collections;
using UnityEngine;

public class FlagPole : MonoBehaviour
{
    public Transform flag;
    public Transform poleBottom;
    public Transform castle;
    public float speed = 6f;
    public int nextWorld = 1;
    public int nextStage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // khi cờ chạm player di  chuyển từ đáy đến đỉnh cờ và di chuyển từ đỉnh cờ đến điểm castle hay điểm lưu.
        if (other.CompareTag("Player"))
        {
            // di chuyển lá cờ ở đáy đến đinh cờ 
            StartCoroutine(MoveTo(flag, poleBottom.position));
            // di chuyển player đến điêm lưu hay điểm lưu game 
            StartCoroutine(LevelCompleteSequence(other.transform));
        }
    }

    private IEnumerator LevelCompleteSequence(Transform player)
    {
        // tắt chưc năng di chuyển 
        player.GetComponent<PlayerMovement>().enabled = false;
        // di chuyen player đến đỉnh cờ 
        yield return MoveTo(player, poleBottom.position);
        // di chuyển player theo chiều sang phải và xuống
        yield return MoveTo(player, player.position + Vector3.right);
        yield return MoveTo(player, player.position + Vector3.right + Vector3.down);
        //di chuyên player dên diem lưu
        yield return MoveTo(player, castle.position);
        // tắt hiện player
        player.gameObject.SetActive(false);
        // đợi 2s
        yield return new WaitForSeconds(2f);
        // chuyển sang level khác
        GameManager.Instance.LoadLevel(1, 2);
    }


     // ham di chuyen tu diẻm đau tơi diẻm ket thuc vơi subject là điểm hiện tại và pósition la điểm cần tới.
    private IEnumerator MoveTo(Transform subject, Vector3 position)
    {
        while (Vector3.Distance(subject.position, position) > 0.125f)// Distance tính khoảng cách
        {
            subject.position = Vector3.MoveTowards(subject.position, position, speed * Time.deltaTime);//MoveToward di chuyển theo hướng từ điểm from đến điểm to trong khoảng thời gian tính toán

            yield return null;
        }

        subject.position = position;
    }

}
