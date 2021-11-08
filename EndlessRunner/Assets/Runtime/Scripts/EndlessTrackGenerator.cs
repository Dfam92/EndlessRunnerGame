using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTrackGenerator : MonoBehaviour
{
    [SerializeField] private TrackSegment[] segmentPrefabs;

    [SerializeField] private PlayerController player;

    [Header("Endless Generation Parameters")]
    [Space]

    [SerializeField] private int minTracksInFrontOfPlayer = 3;
    [SerializeField] private int initialTrackCount;
    [SerializeField] private float minDistanceToConsiderInsideTrack = 3;
    [SerializeField] private float wavesForReward;

    private int rewardCount = 0;
    private List<TrackSegment> currentSegments = new List<TrackSegment>();
    [SerializeField]private List<TrackSegment> Tracks = new List<TrackSegment>();

    private void Start()
    {
        TrackSegment initialTrack = Instantiate(segmentPrefabs[0], transform);
        currentSegments.Add(initialTrack);
        SpawnTracks(initialTrackCount);
    }

    private void Update()
    {
        PlayerTracksInfo();
    }

    private void PlayerTracksInfo()
    {
        int playerTrackIndex = FindTrackIndexWithPlayer();
        RemainTracksForNewSpawn(playerTrackIndex);
        DestroyPassedTracks(playerTrackIndex);
    }

    private void DestroyPassedTracks(int playerTrackIndex)
    {
        for (int i = 0; i < playerTrackIndex; i++)
        {
            TrackSegment track = currentSegments[i];
            //IMPORTANTE passar o GameObject
            Destroy(track.gameObject);
        }

        currentSegments.RemoveRange(0, playerTrackIndex);
    }

    private void RemainTracksForNewSpawn(int playerTrackIndex)
    {
        int tracksInFrontOfPlayer = currentSegments.Count - (playerTrackIndex + 1);
        if (tracksInFrontOfPlayer < minTracksInFrontOfPlayer)
        {
            
            SpawnTracks(minTracksInFrontOfPlayer - tracksInFrontOfPlayer);
            rewardCount += 1;
            Debug.Log(rewardCount);
            if(rewardCount > wavesForReward)
            {
                rewardCount = 0;
            }
        }
    }

    private int FindTrackIndexWithPlayer()
    {
        int playerTrackIndex = 0;
        for (int i = 0; i < currentSegments.Count; i++)
        {
            TrackSegment track = currentSegments[i];
            if (player.transform.position.z >= (track.Start.position.z + minDistanceToConsiderInsideTrack)
                && player.transform.position.z <= track.End.position.z)
            {
                playerTrackIndex = i;
                break;
            }
        }

        return playerTrackIndex;
    }

    private void SpawnTracks(int trackCount)
    {
        TrackSegment previousTrack = currentSegments.Count > 0
            ? currentSegments[currentSegments.Count - 1]
            : null;
        for (int i = 0; i < trackCount; i++)
        {
            previousTrack = SpawnTrackSegment(previousTrack); ;
        }
    }

    private TrackSegment SpawnTrackSegment(TrackSegment previousTrack)
    {
        TrackSegment trackInstance = rewardCount < wavesForReward
            ? Instantiate(Tracks[Random.Range(0, 3)], transform)
            : Instantiate(Tracks[3], transform);
        // posiciona o track no fim do previous track

        if (previousTrack != null)
        {
            trackInstance.transform.position = previousTrack.End.position + (trackInstance.transform.position - trackInstance.Start.position);
        }
        else
        {
            trackInstance.transform.localPosition = Vector3.zero;
        }
        currentSegments.Add(trackInstance);
        return trackInstance;
    }
}
