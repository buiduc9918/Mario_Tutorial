
public static class Extensions
{
    //LayerMask.GetMask("Default"); chuyển từ tên Đefaul sang dạng int.
    // khai báo khái niệm layermask với tĩnh - static để sử dụng rộng rãi như 1 thuộc tính, 
    private static LayerMask layerMask = LayerMask.GetMask("Default");


    // xác định 1 hàm chức năng theo phương thức tĩnh với static thì gọi bất cứ đâu cũng được 
    // kiểm tra va chạm , tạo ra 1 hit với 
    // hit la 1 bài kiểm tra xác định trạng thái tồn tài và không tồn tại của conlider và rigidbody
    // nếu cả hai đều tồn tại và không kinematic thì trả về true
    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction)
    {
        if (rigidbody.isKinematic) {
            return false;
        }

        float radius = 0.25f;
        float distance = 0.375f;

        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction.normalized, distance, layerMask);
        return hit.collider != null && hit.rigidbody != rigidbody;
    }


 // kiểm tra tác dụng các vector nêu vector nào lớn hơn sẽ trả về sức áp đảo lớn hơn từ đó xac dịnh vector quán tính của 2 vât thể so sánh với vector lực mong muốn
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
    }

}
