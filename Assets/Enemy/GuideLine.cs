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

    private void InitLine(LineRenderer line, float lineWidth)
    {
        line.positionCount = 2;

        // �� ����
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;

        line.SetPosition(0, new Vector3(0, 0, 0));
        line.SetPosition(1, new Vector3(0, 0, 0));

        line.gameObject.SetActive(true);
    }

    /// <summary>
    ///  ����� �������� ���� ���� Line
    /// </summary>
    /// <param name="from">Line ��� ��� ( transform )</param>
    /// <param name="to">Line ���� ��� ( transform )</param>
    /// <param name="lifeTime">Line ���� �ð�</param>
    /// <returns></returns>
    public float OnTrackingLine(Transform from, Transform to, float lineWidth, float lifeTime = 1f)
    {
        if(lines.Count == 0)
            CreateLine();

        // Line �ʱ�ȭ
        LineRenderer line = lines.Dequeue();
        InitLine(line, lineWidth);

        StartCoroutine(UpdateLine(line, from, to));
        StartCoroutine(ReturnLine(line, lifeTime));

        return lifeTime;
    }

    private IEnumerator UpdateLine(LineRenderer line, Transform from, Transform to)
    {
        while(line.gameObject.activeSelf)
        {
            yield return null;

            if (from == null || to == null)
                break;
            Vector2 fromPosition = from.position;
            Vector2 toPosition = to.position;

            Vector2 direction = (toPosition - fromPosition).normalized;

            // RayCast
            RaycastHit2D ray = Physics2D.Raycast(fromPosition, direction, maxDistance, wallLayer);
            Vector2 endPos = ray.collider != null ? 
                ray.point : fromPosition + direction * maxDistance;

            // ������ ����
            line.SetPosition(0, fromPosition);
            line.SetPosition(1, endPos);
        }
    }

    public float OnTwoPointLine(Vector2 from, Vector2 to, float lineWidth, float lifeTime = 1f)
    {
        if (lines.Count == 0)
            CreateLine();

        // Line �ʱ�ȭ
        LineRenderer line = lines.Dequeue();
        InitLine(line, lineWidth);

        Vector2 direction = (to - from).normalized;


        // RayCast
        RaycastHit2D ray = Physics2D.Raycast(from, direction, maxDistance, wallLayer);
        Vector2 endPos = ray.collider != null ?
            ray.point : from + direction * maxDistance;

        // ������ ����
        line.SetPosition(0, from);
        line.SetPosition(1, endPos);

        StartCoroutine(ReturnLine(line, lifeTime));

        return lifeTime;
    }

    private IEnumerator ReturnLine(LineRenderer line, float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);

        lines.Enqueue(line);
        line.gameObject.SetActive(false);
    }
}
