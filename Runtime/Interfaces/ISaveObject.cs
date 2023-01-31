namespace Ikonoclast.Common
{
    /// <summary>
    /// Interface for complex saveable objects.
    /// </summary>
    public interface ISaveObject : ISave, IIdentity<string>
    {
        /// <summary>
        /// Identifier string in saving/loading.
        /// </summary>
        string ID
        {
            get;
        }

        /// <summary>
        /// Write saveable data into a new <see cref="Map"/> object.
        /// </summary>
        /// <returns></returns>
        Map Serialize();

        /// <summary>
        /// Write saveable data into an existing <see cref="Map"/> object.
        /// </summary>
        /// <returns></returns>
        void Serialize(Map map, bool overwrite = false);

        /// <summary>
        /// Read data from a <see cref="Map"/> object.
        /// </summary>
        /// <param name="map"></param>
        void Deserialize(Map map);
    }
}
