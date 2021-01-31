using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ActivationReceiver
{
    public int activationsNeeded = 0;
    private int currentActivations = 0;

    [Header("Graphics")]
    public Sprite closed;
    public Sprite open;

    [Header("Audio")]
    public AudioSource solvedSound;
    public AudioSource errorSound;

    private List<ActivationSender> senders;

    private Collider2D hitBox;
    private SpriteRenderer gfx;

    void Awake() {
        this.hitBox = this.GetComponent<Collider2D>();
        this.gfx = this.GetComponentInChildren<SpriteRenderer>();

        this.solved = false;
    }

    public override void Activate(bool isValid, ActivationSender sender)
    {
        if (solved)
            return;

        StartCoroutine(this.DelayedActivate(isValid, sender));
    }

    IEnumerator DelayedActivate(bool isValid, ActivationSender sender)
    {
        yield return new WaitForSeconds(0.4f);

        if (isValid == false)
        {
            this.currentActivations = 0;

            this.solved = false;
            this.errorSound.Play();
        }
        else
        {
            this.currentActivations++;

            if (this.currentActivations >= this.activationsNeeded)
            {
                this.solved = true;
                this.solvedSound.Play();
            }
        }
    }

    public override void AddSender(ActivationSender sender)
    {
        if (this.senders is null)
            this.senders = new List<ActivationSender>();

        this.senders.Add(sender);
    }

    public override void OnSolvedChanged()
    {
        if (this.solved)
        {
            this.hitBox.enabled = false;
            this.gfx.sprite = this.open;
        }
        else
        {
            this.hitBox.enabled = true;
            this.gfx.sprite = this.closed;

            // Restore activators state
            if (this.senders is null)
                return;

            foreach (var sender in this.senders)
            {
                sender.Restore();
            }
        }
    }
}