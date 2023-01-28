namespace Ikonoclast.Common
{
    /// <summary>
    /// Interface for complex saveable objects.
    /// </summary>
    public interface ISaveObject : ISave
    {
        /// <summary>
        /// Identifier string in saving/loading.
        /// </summary>
        string ID
        {
            get;
        }

        /// <summary>
        /// Write saveable data into a <see cref="Map"/> object.
        /// </summary>
        /// <returns></returns>
        Map Serialize();

        /// <summary>
        /// Read data from a <see cref="Map"/> object.
        /// </summary>
        /// <param name="dict"></param>
        void Deserialize(Map dict);
    }
}
