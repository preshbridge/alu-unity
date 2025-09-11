using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public Animator tyAnimator;
    public AudioSource footstepsGrassSource;
    public AudioSource footstepsStoneSource;
    public AudioSource landingGrassSource;
    public AudioSource landingStoneSource;

    public LayerMask grassLayer;
    public LayerMask stoneLayer;

    private string currentSurface = "Grass";
    private bool isFalling = false;

    void Update()
    {
        DetectFalling();
        PlayFootstepSound();
    }

    public void PlayFootstepSound()
    {
        if (!tyAnimator.GetBool("IsRunning") || isFalling)
            return;

        if (currentSurface == "Grass" && !footstepsGrassSource.isPlaying)
        {
            footstepsGrassSource.Play();
        }
        else if (currentSurface == "Stone" && !footstepsStoneSource.isPlaying)
        {
            footstepsStoneSource.Play();
        }
    }

    private void DetectFalling()
    {
        if (GetComponent<Rigidbody>().velocity.y < -0.1f)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isFalling)
        {
            PlayLandingSound();
            isFalling = false;
        }

        if (IsOnLayer(collision.gameObject.layer, grassLayer))
        {
            currentSurface = "Grass";
        }
        else if (IsOnLayer(collision.gameObject.layer, stoneLayer))
        {
            currentSurface = "Stone";
        }
    }

    private bool IsOnLayer(int objectLayer, LayerMask layerMask)
    {
        return (layerMask == (layerMask | (1 << objectLayer)));
    }

    private void PlayLandingSound()
    {
        if (currentSurface == "Grass" && !landingGrassSource.isPlaying)
        {
            landingGrassSource.Play();
        }
        else if (currentSurface == "Stone" && !landingStoneSource.isPlaying)
        {
            landingStoneSource.Play();
        }
    }
}
