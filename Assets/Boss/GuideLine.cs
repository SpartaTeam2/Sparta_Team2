using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GuideLine : MonoBehaviour
{
    private static GuideLine instance;
    public static GuideLine Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        instance = this;
    }

    private const float maxDistance = 50f;

    private LayerMask wallLayer;
    private Queue<LineRenderer> lines;
    [SerializeField] private GameObject linePrefab;


    private void Start()
    {
        // component
        lines = new Queue<LineRenderer>();

        // layermask
        wallLayer = LayerMask.GetMask("Wall");
    }

    private void CreateLine()
    {
        LineRenderer newLine = Instantiate(linePrefab, transform).GetComponent<LineRenderer>();

        newLine.transform.parent = transform;
        newLine.gameObject.SetActive(false);

        lines.Enqueue(newLine);
    }

    /// <summary>
    ///  대상의 움직임을 따라 가는 Line
    /// </summary>
    /// <param name="from">Line 출발 대상 ( transform )</param>
    /// <param name="to">Line 도착 대상 ( transform )</param>
    /// <param name="lifeTime">Line 지속 시간</param>
    /// <returns></returns>
    public float OnTrackingLine(Transform from, Transform to, float lifeTime = 1f)
    {
        if(lines.Count == 0)
            CreateLine();

        LineRenderer line = lines.Dequeue();

        // Line 초기화
        line.gameObject.SetActive(true);
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.positionCount = 2;

        StartCoroutine(UpdateLine(line, from, to));
        StartCoroutine(ReturnLine(line, lifeTime));

        return lifeTime;
    }

    private IEnumerator UpdateLine(LineRenderer line, Transform from, Transform to)
    {
        while(line.gameObject.activeSelf)
        {
            yield return null;

            Vector2 direction = (to.position - from.position).normalized;

            // RayCast
            RaycastHit2D ray = Physics2D.Raycast(from.position, direction, 50f, wallLayer);
            Vector2 endPos = ray.collider != null ? ray.point : (Vector2)from.position + direction * 50f;

            // 포지션 설정
            line.SetPosition(0, from.position);
            line.SetPosition(1, endPos);
        }
    }

    public float OnTwoPointLine(Vector2 from, Vector2 to, float lifeTime = 1f)
    {

        return lifeTime;
    }

    private IEnumerator ReturnLine(LineRenderer line, float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);

        lines.Enqueue(line);
        line.gameObject.SetActive(false);
    }
}
