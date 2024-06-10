using System.Collections;
using UnityEngine;

public class BlockCoin : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.AddCoin();

        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 2f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        Destroy(gameObject);
    }

    private IEnumerator Move(Vector3 from, Vector3 to)//xác điểm đầu và cuối 
    {
        float elapsed = 0f;// giá trị mốc đơn vị ban đầu
        float duration = 0.25f;// mốc giá trị đơn vị

        while (elapsed < duration)
        {
            float t = elapsed / duration;// tính khoảng thời gian cho khung hình hay vận tốc.

            transform.localPosition = Vector3.Lerp(from, to, t);// dịch chuyển mềm theo hướng từ from đến to trong các khung hình t
            elapsed += Time.deltaTime;//cap nhat thoi gian

            // quang duong cang ngăn thi khung hình càng ít

            yield return null;
        }

        transform.localPosition = to;// sau khi đến gần thì dịch chuyển đến to với khoảng cach ngắn
    }

}
