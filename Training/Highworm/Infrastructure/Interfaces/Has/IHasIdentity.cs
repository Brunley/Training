namespace Highworm {
    /// <summary>
    /// Defines a contract with an entity that may have a unique identity.
    /// </summary>
    public interface IHasIdentity {
        /// <summary>
        /// The unique identity assigned by the identity generator.
        /// </summary>
        string Id { get; set; }
    }
}