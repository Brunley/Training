namespace Highworm {
    /// <summary>
    /// A contract for any object that may participate in an encounter.
    /// </summary>
    public interface IMayEncounter {
        IMayParticipate Character {
            get;
            set;
        }
        decimal Order { get; set; }
    }
}