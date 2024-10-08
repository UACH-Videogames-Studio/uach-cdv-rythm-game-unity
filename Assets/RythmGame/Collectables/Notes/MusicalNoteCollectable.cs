using UnityEngine;

namespace RythmGame
{
    public class MusicalNoteCollectable : ScoredCollectableOnTriggerByPlayer
    {
        [SerializeField][Tooltip("The ScriptableObject for the note")] protected NotesScriptableObject notesScriptableObject;
        public delegate void OnCollectNote(MusicalOctave octave, MusicalNote note, int noteValue);
        public OnCollectNote OnCollectNoteEvent;

        [Tooltip("The musical note and octave that represents this gameobject")]
        [SerializeField] protected MusicalNote note;
        protected MusicalOctave octave;

        public override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnCollectNoteEvent?.Invoke(octave, note, notesScriptableObject.NoteValue);
                OnCollectEvent?.Invoke(ScoreValue);
                Dissappear();
            }
        }
        public void SetOctave(MusicalOctave octave)
        {
            this.octave = octave;
        }
    }
}
