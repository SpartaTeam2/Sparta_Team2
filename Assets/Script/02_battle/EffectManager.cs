using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    ExplosionBlue,
    ExplosionHeart,
    ExplosionPurple,
    ExplosionYellow
}

public class EffectManager : MonoBehaviour
{
    #region singleton
    private static EffectManager instance;
    public static EffectManager Instance 
    { get  { return instance; } }

    private void Awake()
    {
        if(instance == null)
            instance = this;

        InitManager();
    }
    #endregion

    [SerializeField] private List<GameObject> effectPrefabs;
    private Dictionary<EffectType, Queue<ParticleSystem>> effectPool;
    private void InitManager()
    {
        effectPool = new Dictionary<EffectType, Queue<ParticleSystem>>();

        int effectCount = Enum.GetValues(typeof(EffectType)).Length;
        for(int i = 0; i < effectCount; i++)
        {
            effectPool.Add((EffectType)i, new Queue<ParticleSystem>());
        }
    }

    public void PlayEffect(EffectType type, Vector3 playerPos)
    {
        if (!effectPool.TryGetValue(type, out Queue<ParticleSystem> effectQueue))
            return;

        if(effectQueue.Count == 0)
        {
            CreateEffect(type, ref effectQueue);
        }

        if (!effectQueue.TryDequeue(out ParticleSystem effect))
            return;

        effect.gameObject.SetActive(true);
        effect.transform.position = playerPos;
        effect.Play();

        StartCoroutine(ReturnEffect(effect, type));
    }

    private void CreateEffect(EffectType type, ref Queue<ParticleSystem> effectQueue)
    {
        GameObject newEffect = Instantiate(effectPrefabs[(int)type], transform);
        ParticleSystem effectParticle = newEffect.GetComponent<ParticleSystem>();

        effectParticle.gameObject.SetActive(false);
        effectQueue.Enqueue(effectParticle);
    }

    IEnumerator ReturnEffect(ParticleSystem effect, EffectType type)
    {
        float time = effect.main.startLifetimeMultiplier;
        yield return new WaitForSeconds(time);

        if (!effectPool.TryGetValue(type, out Queue<ParticleSystem> effectQueue))
            Destroy(effect);

        effect.gameObject.SetActive(false);
        effectQueue.Enqueue(effect);
    }
}
